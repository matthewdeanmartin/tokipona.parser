using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BasicTypes.Collections;
using BasicTypes.Parser;

namespace BasicTypes
{
    public class ParserUtils
    {
        private Config config;
        public ParserUtils(Config config)
        {
            this.config = config;
        }
        public string[] ParseIntoRawSentences(string text)
        {
            //https://stackoverflow.com/questions/521146/c-sharp-split-string-but-keep-split-chars-separators
            //https://stackoverflow.com/questions/3115150/how-to-escape-regular-expression-special-characters-using-javascript

            //TODO: Normalize well known compound phrases jan pona => jan-pona
            //TODO: Normalize foreign words zap => 'zap', alternatively assume they are tp, but a mistake

            return Regex
                .Split(text, @"(?<=[\?!.:])")  //split preserving punctuation
                .Where(x => !string.IsNullOrWhiteSpace(x)) //skip empties
                .Select(x => Normalizer.NormalizeText(x, config))
                .ToArray();
        }


        public Discourse[] GroupIntoDiscourses(Sentence[] sentences)
        {
            List<Discourse> l = new List<Discourse>();

            Discourse d = new Discourse();
            l.Add(d);
            for (int i = 0; i < sentences.Length - 1; i++)
            {
                //Always add that sentence
                Sentence s = sentences[i];
                d.Add(s);

                //Next decide if we keep adding, or if we create a new discourse.
                //Keep adding if current implies a link to next OR next implies link to current.
                Sentence next = i < (sentences.Length - 1) ? null : sentences[i + 1];
                if (s.HasPunctuation())
                {
                    if (s.Punctuation == new Punctuation(":"))
                    {

                        //Linked to next!
                        continue;
                    }
                }
                else if (next != null && next.HasConjunction())
                {
                    continue;
                }
                d = new Discourse();
                l.Add(d);
            }
            foreach (Discourse discourse in l.ToArray())
            {
                if (discourse.Count == 0)
                {
                    l.Remove(discourse);
                }
            }
            return l.ToArray();
        }

        public const string validTpWordSplitter =
            @"([0-9-]+)|\b([JKLMNPSTW]?[aeiou]([jklmnpstw][aeiou][n]?)*)\b"+
            @"|\b([aeiou])\b"+
            @"|\b(([jklmnpstw]?[aeiou][n]?)*)\b"+
            @"|\b([aeiou][n]?)\b|"+
            @"\b([AEIOU][n]?)\b";

        //Can double match (word within word) :-(
        public string[] JustTpWords(string value)
        {
            //Allows:
            // a
            // an
            // A
            // An
            // na
            // nan
            // Na
            // Nan

            //http://regexhero.net/tester/
            
            return (from Match s in Regex.Matches(value,validTpWordSplitter) 
                    where !string.IsNullOrEmpty(s.Value) 
                    select s.Value).ToArray();
        }

        public string[] RemergeCompounds(string[] words)
        {
            if (!words.Any(x => x.Contains("-")))
            {
                //No compound words here
                return words;
            }
            List<string> merged= new List<string>();
            List<string> compound = new List<string>();
            for (int index = 0; index < words.Length; index++)
            {
                string word = words[index];
                if (word== "-")
                {
                    compound.Add(word);
                    continue;
                }
                if (index+1<words.Length &&  words[index + 1] == "-")
                {
                    compound.Add(word);
                    continue;
                }
                if (index - 1 >0 && words[index - 1] == "-")
                {
                    compound.Add(word);
                    continue;
                }

                if (compound.Count > 0)
                {
                    merged.Add(string.Join("", compound.ToArray()));
                    compound.Clear();
                }
                else
                {
                    merged.Add(word);
                }
            }
            //Edge case where the whole thing is a compound
            if (compound.Count > 0)
            {
                merged.Add(string.Join("", compound.ToArray()));
                compound.Clear();
            }
            return merged.ToArray();
        }

        public string[] JustTpWordsNumbersPunctuation(string value)
        {
            //Allows:
            // a
            // an
            // A
            // An
            // na
            // nan
            // Na
            // Nan
            Regex r = new Regex( validTpWordSplitter +"|"
                //+ "(" +validTpWordSplitter +")*" //Doesn't match compounds.
                + @"|([?.!'])");
            List<string> list = new List<string>();
            foreach (Match s in r.Matches(value))
            {
                if (!string.IsNullOrEmpty(s.Value))
                {
                    list.Add(s.Value);
                }
            }
            return list.ToArray();
        }

        public Sentence ParsedSentenceFactory(string sentence)
        {
            sentence = Normalizer.NormalizeText(sentence); //Any way to avoid calling this twice?

            if (sentence.EndsWith(" "))
            {
                throw new InvalidOperationException("Normalizer failed to trim");
            }
            Console.WriteLine("Normalized: " + sentence);

            //Get the final punctuation out or it will mess up parsing later.
            string possiblePunctuation = sentence[sentence.Length - 1].ToString();
            Punctuation punctuation;
            if (Punctuation.TryParse(possiblePunctuation, out punctuation))
            {
                sentence = sentence.Substring(0, sentence.Length-1);
            }

            const string liFinder = @"\bli\b";

            //Square bracket sentence contains all others
            //[S]
            //F la [S]
            //S la [S]
            //F la S la [S]
            //Maximal.. maybe later
            //F la S la F la S  => (F la S ) la (F la [S])
            //F la S la S la F la S la S
            //[{F la S} la {S} la {F la S}] la <S> 

            //Just dealing with la fragments
            string[] laParts =null;

            Sentence headSentence=null;
            List<Sentence> preconditions = new List<Sentence>();

            laParts = Splitters.SplitOnLa(sentence);

            if (laParts.Length>1)
            {
                int i = 0;
                List<Chain> laFragments = new List<Chain>();
                Sentence currentSentence = null;
                foreach (string laPart in laParts.Reverse())
                {
                    i++;
                    if (i == 1)
                    {
                        //Head sentence.
                        string laLessString = laPart.StartsWith("la ") ? laPart.Substring(3) : laPart;
                        headSentence = ProcessSimpleSentence(laLessString, punctuation);
                        continue; //Not dealing with "kin la!"
                    }

                    //Fragments & preconditions
                    Match m = Regex.Match(laPart, liFinder);
                    if (m.Success)
                    {
                        //This is a sentence
                        //Maybe should recurse.
                        currentSentence = ProcessSimpleSentence(sentence, punctuation);
                        preconditions.Add(currentSentence);
                    }
                    else
                    {
                        Chain fragment = ProcessEnPiChain(laPart);
                        if (currentSentence == null)
                        {
                            if (headSentence == null)
                            {
                                throw new InvalidOperationException(
                                    "Sentence appears to be headed by a fragment. Shouldn't deal with those here.");
                            }
                            headSentence.LaFragment.Add(fragment);
                        }
                        else
                        {
                            laFragments.Add(fragment);
                        }
                    }
                }
            }
            else
            {
                //No la at all.
                //Simple Sentence
                return ProcessSimpleSentence(sentence, punctuation);
            }
            if (headSentence == null)
            {
                throw new InvalidOperationException("This is not a sentence, should deal with it with it's own parser");
            }
            if (preconditions.Count == 0)
                return headSentence;
            Sentence s = new Sentence(preconditions.ToArray(), headSentence);
            return s;
        }


        private Sentence ProcessSimpleSentence(string sentence, Punctuation punctuation)
        {
            string[] liParts = Splitters.SplitOnLiOrO(sentence);
            string subjects = liParts[0].Trim();

            Chain subjectChain = ProcessEnPiChain(subjects);

            //Skip 1 on purpose
            PredicateList verbPhrases = new PredicateList();

            for (int i = 1; i < liParts.Length; i++)
            {
                string predicate = liParts[i].Trim();

                verbPhrases.Add(ProcessPredicates(predicate));
            }


            Sentence parsedSentence = new Sentence(subjectChain, verbPhrases, punctuation);
            return parsedSentence;
        }

        public Chain ProcessEnPiChain2(string subjects)
        {
            string[] subjectTokens = Splitters.SplitOnEn(subjects);

            //Split on pi
            //jan pi pali suli en soweli pi tawa wawa

            List<Chain> piChainList = new List<Chain>();
            for (int i = 0; i < subjectTokens.Length; i++)
            {
                string piChains = subjectTokens[i];

                string[] piLessTokens = Splitters.SplitOnPi(piChains);

                List<HeadedPhrase> headedPhrases = new List<HeadedPhrase>();
                foreach (string piLessToken in piLessTokens)
                {
                    //Console.WriteLine("Preparing to parse [" + piLessToken + "] as piLessToken");
                    //Splits on spaces & separates into head & tail
                    HeadedPhrase piPhrase = HeadedPhraseParser(piLessToken);
                    //Console.WriteLine("Ended up with " + piPhrase);
                    headedPhrases.Add(piPhrase);
                }
                Chain piChain = new Chain(ChainType.NounVerbPhrase, Particles.pi, headedPhrases.ToArray());
                piChainList.Add(piChain);
            }


            Chain subject = new Chain(ChainType.Subjects, Particles.en, piChainList.ToArray());
            return subject;
        }

        public Chain ProcessEnPiChain(string subjects)
        {
            if (String.IsNullOrEmpty(subjects))
            {
                throw new ArgumentException("Can't parse null/empty subjects");
            }
            string[] subjectTokens = Splitters.SplitOnEn(subjects);

            //Split on pi
            //jan pi pali suli en soweli pi tawa wawa

            List<Chain> subChains = new List<Chain>();
            for (int i = 0; i < subjectTokens.Length; i++)
            {
                string piChains = subjectTokens[i];

                string[] piLessTokens = Splitters.SplitOnPi(piChains);

                List<HeadedPhrase> piCollection = new List<HeadedPhrase>();
                foreach (string piLessToken in piLessTokens)
                {
                    //Console.WriteLine("Preparing to parse [" + piLessToken + "] as piLessToken");
                    //Splits on spaces & separates into head & tail
                    HeadedPhrase piPhrase = HeadedPhraseParser(piLessToken);
                    //Console.WriteLine("Ended up with " + piPhrase);
                    piCollection.Add(piPhrase);
                }
                Chain piChain = new Chain(ChainType.NounVerbPhrase, Particles.pi, piCollection.ToArray());
                subChains.Add(piChain);
            }

            Chain subject = new Chain(ChainType.Subjects, Particles.en, subChains.ToArray());
            return subject;
        }

        // jan li jo e soweli e kili e wawa lon anpa tawa anpa
        //     li jo e soweli e kili e wawa lon anpa tawa anpa
        public TpPredicate ProcessPredicates(string liPart)
        {
            Particle verbPhraseParticle = null;
            Chain directObjectChain = null;
            HeadedPhrase verbPhrase = null;
            Chain prepositionalChain = null;

            //Transitive Path.
            if (liPart.Split(new[] { ' ', '\t' }).Contains("e"))
            {
                Regex eSplit = new Regex("\\be\\b");
                string[] eParts = eSplit.Split(liPart);

                string[] verbPhraseParts = 
                    RemergeCompounds(
                    JustTpWordsNumbersPunctuation(eParts[0]));
                verbPhraseParticle = new Particle(verbPhraseParts[0]);
                if (verbPhraseParts.Length > 1)
                {
                    verbPhrase = HeadedPhraseParser(ArrayExtensions.Tail(verbPhraseParts));
                }
                else
                {
                    Debug.Print("This a prep phrase only thing?");
                }

                string verbsMaybePrepositions = eParts[eParts.Length - 1];

                //Only process preps in normalized sentences
                string[] partsWithPreps = null;
                if (verbsMaybePrepositions.Contains("~"))
                {
                    partsWithPreps = Splitters.SplitOnPrepositions(verbsMaybePrepositions);
                    if (partsWithPreps.Length == 1)
                    {
                        //This is the last e phrase or 1st prep.
                        if (partsWithPreps[0].Contains("~"))
                        {
                            //That is a prep phrase (is this possible?)
                        }
                        else
                        {
                            eParts[eParts.Length - 1] = partsWithPreps[0];
                            //No prep phrases.
                        }
                    }
                }


                string[] directObjects = ArrayExtensions.Tail(eParts);

                List<HeadedPhrase> doNPs = new List<HeadedPhrase>();
                foreach (string directObject in directObjects)
                {
                    HeadedPhrase phrase = HeadedPhraseParser(directObject);
                    doNPs.Add(phrase);
                }
                directObjectChain = new Chain(ChainType.Directs, Particles.e, doNPs.ToArray());

                if (partsWithPreps != null)
                {
                    prepositionalChain = new Chain(ChainType.Prepositionals, Particles.Blank, ProcessPrepositionalPhrases(partsWithPreps).ToArray());
                }
            }
            else
            {
                //Intransitives & Predictates

                string[] ppParts = Splitters.SplitOnPrepositions(liPart);

                if (ppParts.Length == 0) //Excect at least "li verb" or "li noun"
                {
                    throw new InvalidOperationException("Whoa, got " + ppParts.Length + " parts for " + liPart);
                }

                if (Punctuation.ContainsPunctuation(ppParts[0]))
                {
                    throw new InvalidOperationException("This has punctuation, may fail to parse");
                }
                string[] verbPhraseParts = RemergeCompounds(
                    JustTpWordsNumbersPunctuation((ppParts[0])));
                
                verbPhraseParticle = new Particle(verbPhraseParts[0]);

                
                if (verbPhraseParts.Length > 1)
                {
                    verbPhrase = HeadedPhraseParser(ArrayExtensions.Tail(verbPhraseParts));
                }
                else
                {
                    Debug.Print("This a prep phrase only thing?");
                }


                string[] prepositions = ArrayExtensions.Tail(ppParts);

                if (prepositions.Length != 0)
                {
                    List<Chain> pChains = new List<Chain>();
                    foreach (string pp in prepositions)
                    {
                        string[] phraseParts = RemergeCompounds(
                    JustTpWordsNumbersPunctuation(pp));
                        string preposition = phraseParts[0];
                        string[] tail = ArrayExtensions.Tail(phraseParts);

                        if (tail.Length == 0)
                        {
                            //uh oh. This is an intransitive verb, like "ni li lon"
                            //HACK: Oh, this is so ugly
                            verbPhrase = HeadedPhraseParser(new string[] { preposition.Replace("~", "") });
                            continue;
                        }

                        //HeadedPhrase phrase = HeadedPhraseParser(pp);
                        Chain c = new Chain(ChainType.Prepositionals,
                                            new Particle(preposition),
                                            new Chain[] { ProcessEnPiChain(string.Join(" ", tail)) });
                        pChains.Add(c);
                    }
                    if (pChains.Count > 0)
                    {
                        prepositionalChain = new Chain(ChainType.Prepositionals, Particles.Blank, pChains.ToArray());
                    }
                    else
                    {
                        //We changed our mind about a phrase being a prep phrase. Turned out to be verb phrase or predicate.
                    }
                }
            }
            return new TpPredicate(verbPhraseParticle, verbPhrase, directObjectChain, prepositionalChain);
        }

        public List<Chain> ProcessPrepositionalPhrases(string[] partsWithPreps)
        {
            List<Chain> prepositionalChain = new List<Chain>();
            foreach (string partsWithPrep in partsWithPreps)
            {
                if (partsWithPrep.Contains("~")) //Is it really?
                {
                    string preposition = RemergeCompounds(
                   JustTpWordsNumbersPunctuation((partsWithPrep)))[0];
                    string tail = preposition.Replace(partsWithPrep, "").Trim();
                    //These chains are ordered.
                    //kepeken x lon y kepeken z lon a   NOT EQUAL TO kepeken x  kepeken z lon a lon y
                    //Maybe.
                    prepositionalChain.Add(new Chain(ChainType.Prepositionals,
                        new Particle(preposition),
                        string.IsNullOrEmpty(tail) ? null : new Chain[] { ProcessEnPiChain(tail) }));
                }
                else
                {
                    //Is that surprising?
                    //The first part is not a prep phrase, it is a verb intr or predicate.
                    // throw new InvalidOperationException("Why doesn't a part with Prep contain a ~?");
                }
            }
            return prepositionalChain;
        }

        public HeadedPhrase HeadedPhraseParser(string[] value)
        {
            if (value == null || value.Length == 0)
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            //No Pi!
            HeadedPhrase phrase = new HeadedPhrase(new Word(value[0]), new WordSet(ArrayExtensions.Tail(value)));
            return phrase;
        }

        public HeadedPhrase HeadedPhraseParser(string value)
        {
            Config c = Config.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            //No Pi!
            string[] words = pu.JustTpWords(value);
            if (words.Length == 0)
            {
                throw new InvalidOperationException("Failed to parse: " + value);
            }
            HeadedPhrase phrase = new HeadedPhrase(new Word(words[0]), new WordSet(ArrayExtensions.Tail(words)));
            return phrase;
        }


    }
}
