using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BasicTypes.Collections;
using BasicTypes.Exceptions;
using BasicTypes.Extensions;
using BasicTypes.Parser;

namespace BasicTypes
{
    public class ParserUtils
    {
        private readonly Dialect config;
        public ParserUtils(Dialect config)
        {
            this.config = config;
        }
        public string[] ParseIntoRawSentences(string text)
        {
            //https://stackoverflow.com/questions/521146/c-sharp-split-string-but-keep-split-chars-separators
            //https://stackoverflow.com/questions/3115150/how-to-escape-regular-expression-special-characters-using-javascript

            //TODO: Normalize well known compound phrases jan pona => jan-pona
            //TODO: Normalize foreign words zap => 'zap', alternatively assume they are tp, but a mistake

            //Normalize end lines.
            if (text.Contains("\r\n"))
            {
                text = text.Replace("\r\n", "\n");    
            }
            if (text.Contains("\n\n"))
            {
                text = text.Replace("\n\n", "\n");
            }

            //Crap. If we break on \n then sentences with line feeds are cut in half.
            //If we don't break on \n, then we blow up on intentional fragments like titles.
            //Choosing to not break on \n & and manually add . to titles.
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

        public const string ValidTpWordSplitter =
            @"([0-9-]+)|\b([JKLMNPSTW]?[aeiou]([jklmnpstw][aeiou][n]?)*)\b" +
            @"|\b([aeiou])\b" +
            @"|\b(([jklmnpstw]?[aeiou][n]?)*)\b" +
            @"|\b([aeiou][n]?)\b|" +
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

            return (from Match s in Regex.Matches(value, ValidTpWordSplitter)
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
            List<string> merged = new List<string>();
            List<string> compound = new List<string>();
            for (int index = 0; index < words.Length; index++)
            {
                string word = words[index];
                if (word == "-")
                {
                    compound.Add(word);
                    continue;
                }
                if (index + 1 < words.Length && words[index + 1] == "-")
                {
                    compound.Add(word);
                    continue;
                }
                if (index - 1 > 0 && words[index - 1] == "-")
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
            Regex r = new Regex(ValidTpWordSplitter + "|"
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
            if (sentence == "")
            {
                return null;
            }
            bool startsQuotedSpeech;
            bool endsQuotedSpeech;
            if (sentence.StartsWith("«"))
            {
                startsQuotedSpeech = true;
                sentence = sentence.Replace("«", " ").Trim();
            }
            if (sentence.StartsWith("»"))
            {
                endsQuotedSpeech= true;
                sentence = sentence.Replace("»", " ").Trim();
            }
            //TODO: do something with quoted speech. Big problem #1 it spans multiple sentences


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
                sentence = sentence.Substring(0, sentence.Length - 1);
            }

            
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

            Sentence headSentence = null;
            List<Sentence> preconditions = new List<Sentence>();

            string[] laParts = Splitters.SplitOnLa(sentence);

            //Degenerate sentences.
            if (laParts[laParts.Length - 1] == "la")
            {
                //We have a vocative sentence...
                Fragment fragment = new Fragment(ProcessEnPiChain(laParts[0]));
                Sentence fragmentSentence = new Sentence(fragment, punctuation);
                return fragmentSentence;
            }

            if (laParts.Length > 1)
            {
                int i = 0;
                List<Chain> laFragments = new List<Chain>();
                Sentence currentSentence = null;
                foreach (string subSentence in laParts.Reverse())
                {
                    i++;
                    if (i == 1)
                    {
                        //Head sentence.
                        // subSentence.StartsWith("la ") ? subSentence.Substring(3) : subSentence
                        string laLessString = subSentence.RemoveLeadingWholeWord("la");
                        headSentence = ProcessSimpleSentence(laLessString, punctuation);
                        continue; //Not dealing with "kin la!"
                    }

                    //Fragments & preconditions
                    const string liFinder = @"\bli\b";
                    Match m = Regex.Match(subSentence, liFinder);
                    if (m.Success)
                    {
                        //This is a sentence
                        //Maybe should recurse.
                        string laLessString = subSentence.RemoveLeadingWholeWord("la");

                        currentSentence = ProcessSimpleSentence(laLessString, null);
                        preconditions.Add(currentSentence);
                    }
                    else
                    {
                        string laLessString = subSentence.StartsWith("la ") ? subSentence.Substring(3) : subSentence;
                        Chain fragment = ProcessEnPiChain(laLessString);
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
            if (sentence.StartsOrContainsOrEnds("la"))
            {
                throw new InvalidOperationException("If it contains a la, anywhere, it isn't a simple sentence. " + sentence);
            }

            string[] liParts = Splitters.SplitOnLiOrO(sentence);

            //Degenerate sentences.
            if (liParts[liParts.Length - 1] == "o")
            {
                //We have a vocative sentence...
                Vocative vocative = new Vocative(ProcessEnPiChain(liParts[0]));
                Sentence s = new Sentence(vocative, punctuation);
                return s;
            }

            string subjects = liParts[0].Trim();

            Chain subjectChain = null;
            int startAt = 1; //slot 0 is normally a subject

            if (subjects.StartsWith("o "))
            {
                //This is a verb phrase with implicit subjects!
                startAt = 0;
            }
            else
            {
                subjectChain = ProcessEnPiChain(subjects);    
            }

            



            PredicateList verbPhrases = new PredicateList();

            for (int i = startAt; i < liParts.Length; i++)
            {
                string predicate = liParts[i].Trim();

                verbPhrases.Add(ProcessPredicates(predicate));
            }


            if (punctuation == null)
            {
                //Condition
                return new Sentence(subjectChain, verbPhrases);
            }
            
            //Head or complete sentence.
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

        public Chain ProcessPiChain(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Can't parse null/empty subjects");
            }
            if (value.Contains(" la ") || value.EndsWith(" la"))
            {
                throw new ArgumentException("Contains la. This isn't possible.");
            }

            string piChains = value;

            string[] piLessTokens = Splitters.SplitOnPi(piChains);

            List<HeadedPhrase> piCollection = new List<HeadedPhrase>();
            foreach (string piLessToken in piLessTokens)
            {
                HeadedPhrase piPhrase = HeadedPhraseParser(piLessToken);
                piCollection.Add(piPhrase);
            }
            return new Chain(ChainType.NounVerbPhrase, Particles.pi, piCollection.ToArray());

        }

        public Chain ProcessEnPiChain(string subjects)
        {
            if (String.IsNullOrEmpty(subjects))
            {
                throw new ArgumentException("Can't parse null/empty subjects");
            }
            foreach (var particle in new string[] {"la","li"})
            {
                if (subjects.StartsOrContainsOrEnds(particle))
                {
                    throw new ArgumentException("Subject phrase : " + subjects + " Contains "+particle+". This isn't possible.");
                }
            }

            string[] subjectTokens = Splitters.SplitOnEn(subjects);

            //Split on pi
            //jan pi pali suli en soweli pi tawa wawa

            List<Chain> subChains = new List<Chain>();
            for (int i = 0; i < subjectTokens.Length; i++)
            {
                string piChains = subjectTokens[i];

                if(piChains=="")
                    continue; //But how did that happen?

                string[] piLessTokens = Splitters.SplitOnPi(piChains);

                List<Chain> piCollection = new List<Chain>();
                foreach (string piLessToken in piLessTokens)
                {
                    Chain piPhrase = ProcessPiChain(piLessToken);
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
            if (string.IsNullOrWhiteSpace(liPart))
            {
                throw new InvalidOperationException("Missing argument, can't continue");
            }
            if (liPart == "li")
            {
                throw new InvalidOperationException("Can't do anything with just li");
            }
            Particle verbPhraseParticle = null;
            Chain directObjectChain = null;
            HeadedPhrase verbPhrase = null;
            Chain prepositionalChain = null;
            Chain nominalPredicate = null;
            //Transitive Path.
            if (liPart.Split(new[] { ' ', '\t' }).Contains("e"))
            {
                string[] eParts = Splitters.SplitOnE(liPart);

                string[] verbPhraseParts =
                    RemergeCompounds(
                    JustTpWordsNumbersPunctuation(eParts[0]));
                if (!Particle.IsParticle(verbPhraseParts[0]))
                {
                    throw new TpSyntaxException("uh-oh not a particle: " + verbPhraseParts[0] + " from "+ liPart);
                }
                verbPhraseParticle = new Particle(verbPhraseParts[0]);
                if (verbPhraseParts.Length > 1)
                {
                    if (verbPhraseParts.Any(x => x == "pi"))
                    {
                        //nominal predicate
                        nominalPredicate = ProcessPiChain(string.Join(" ", ArrayExtensions.Tail(verbPhraseParts)));
                    }
                    else
                    {
                        verbPhrase = HeadedPhraseParser(ArrayExtensions.Tail(verbPhraseParts));
                
                    }
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

                //List<HeadedPhrase> doNPs = new List<HeadedPhrase>();
                List<Chain> doPiChains = new List<Chain>();
                foreach (string directObject in directObjects)
                {
                    string eFree = directObject.Substring(2);
                    Chain phrase = ProcessPiChain(eFree);
                    doPiChains.Add(phrase);
                }
                directObjectChain = new Chain(ChainType.Directs, Particles.e, doPiChains.ToArray());

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

                if (!Particle.IsParticle(verbPhraseParts[0]))
                {
                    throw new TpSyntaxException("uh-oh not a particle: " + verbPhraseParts[0] + " from " + liPart);
                }
                verbPhraseParticle = new Particle(verbPhraseParts[0]);


                if (verbPhraseParts.Length > 1)
                {
                    if (verbPhraseParts.Any(x => x == "pi"))
                    {
                        //nominal predicate
                        nominalPredicate = ProcessPiChain(string.Join(" ", ArrayExtensions.Tail(verbPhraseParts)));
                    }
                    else
                    {
                        verbPhrase = HeadedPhraseParser(ArrayExtensions.Tail(verbPhraseParts));

                    }
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
                            //or a noun phrase.

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
            if(nominalPredicate==null)
                return new TpPredicate(verbPhraseParticle, verbPhrase, directObjectChain, prepositionalChain);
            else
            {
                return new TpPredicate(verbPhraseParticle, nominalPredicate, directObjectChain, prepositionalChain);
 
            }
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
            foreach (string particle in new string[]{"pi", "la", "e", "li"})
            {
                if (value.StartsOrContainsOrEnds(particle))
                {
                    throw new TpSyntaxException("Headed phrases have no particles. This one has " + particle + " ref: " + value);
                }    
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            //No Pi!
            string[] words = JustTpWords(value);
            if (words.Length == 0)
            {
                throw new InvalidOperationException("Failed to parse: " + value);
            }
            HeadedPhrase phrase = new HeadedPhrase(new Word(words[0]), new WordSet(ArrayExtensions.Tail(words)));
            return phrase;
        }


        public string ProcessDirects(object value)
        {
            throw new NotImplementedException();
        }
    }
}
