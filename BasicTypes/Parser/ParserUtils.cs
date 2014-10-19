using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

            return  Regex
                .Split(text, @"(?<=[\?!.:])")  //split preserving punctuation
                .Where(x => !string.IsNullOrWhiteSpace(x)) //skip empties
                .Select(x=> Normalizer.NormalizeText(x, true))
                .ToArray();  
        }

       
        public Discourse[] GroupIntoDiscourses(Sentence[] sentences)
        {
            List<Discourse> l = new List<Discourse>();

            Discourse d = new Discourse();
            l.Add(d);
            for (int i = 0; i < sentences.Length - 1; i++ )
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
                else if(next!=null && next.HasConjunction())
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
            Regex r = new Regex(@"([0-9-]+)|\b([JKLMNPSTW]?[aeiou]([jklmnpstw][aeiou][n]?)*)\b|\b([aeiou])\b|\b(([jklmnpstw]?[aeiou][n]?)*)\b|\b([aeiou][n]?)\b|\b([AEIOU][n]?)\b");

            List<string> list = new List<string>();
            foreach (System.Text.RegularExpressions.Match s in r.Matches(value))
            {
                if (!string.IsNullOrEmpty(s.Value))
                {
                    list.Add(s.Value);
                }
            }
            return list.ToArray();
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
            //([aeiou])|(([jklmnpstw][aeiou])*[n]?)|([aeiou][n]?)|(([JKLMNPSTW][aeiou])*[n]?)|([AEIOU][n]?)|([1234567890])|([?.!"'])
            Regex r = new Regex(@"([0-9-]+)|\b([aeiou])\b|\b(([jklmnpstw][aeiou])*[n]?)\b|\b([aeiou][n]?)\b|\b(([JKLMNPSTW][aeiou])*[n]?)\b|\b([AEIOU][n]?)\b|\b([1234567890]*)\b|([?.!'])");
            List<string> list = new List<string>();
            foreach (System.Text.RegularExpressions.Match s in r.Matches(value))
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
            sentence= Normalizer.NormalizeText(sentence); //Any way to avoid calling this twice?

            Console.WriteLine("Normalized: " + sentence);

            string[] laParts = SplitOnLa(sentence);

            const string liFinder = @"\bli\b";
            
            List<HeadedPhrase> foundFragments = new List<HeadedPhrase>();
            
            foreach (string laPart in laParts)
            {
                Match m = Regex.Match(laPart,liFinder);
                if (m.Success)
                {
                    //li part
                }
                else
                {
                    //fragment
                    string[] piLessParts= ParserUtils.SplitOnPi(laPart);
                    Chain piChain = new Chain(ChainType.None, Particles.pi, piLessParts.Select(HeadedPhrase.Parse).ToArray());
                    foundFragments.Add(HeadedPhraseParser(laPart));
                }
            }
            
            
            string[] liParts = SplitOnLi(sentence);
            string subjects = liParts[0].Trim();

            Chain subjectChain = ProcessEnPiChain(subjects);

            //Skip 1 on purpose
            PredicateList verbPhrases = new PredicateList();
            
            for (int i = 1; i < liParts.Length; i++)
            {
                string predicate = liParts[i].Trim();

                verbPhrases.Add(ProcessPredicates(predicate));
            }

            string possiblePunctuation = sentence[sentence.Length - 1].ToString();
            Punctuation punctuation = null;
            Punctuation.TryParse(possiblePunctuation, out punctuation);
            Sentence parsedSentence = new Sentence(subjectChain, verbPhrases, punctuation);
            return parsedSentence;
        }

        public Chain ProcessEnPiChain2(string subjects)
        {
            string[] subjectTokens = SplitOnEn(subjects);

            //Split on pi
            //jan pi pali suli en soweli pi tawa wawa

            List<Chain> piChainList = new List<Chain>();
            for (int i = 0; i < subjectTokens.Length; i++)
            {
                string piChains = subjectTokens[i];

                string[] piLessTokens = SplitOnPi(piChains);

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
            string[] subjectTokens = SplitOnEn(subjects);

            //Split on pi
            //jan pi pali suli en soweli pi tawa wawa

            List<Chain> subChains = new List<Chain>();
            for (int i = 0; i < subjectTokens.Length; i++)
            {
                string piChains = subjectTokens[i];

                string[] piLessTokens = SplitOnPi(piChains);

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
            Chain directObjectChain = null;
            HeadedPhrase verbPhrase = null;
            Chain prepositionalChain = null;

            //Transitive Path.
            if (liPart.Split(new[] {' ', '\t'}).Contains("e"))
            {
                Regex eSplit = new Regex("\\be\\b");
                string[] eParts = eSplit.Split(liPart);

                verbPhrase = HeadedPhraseParser(eParts[0]);

                string verbsMaybePrepositions = eParts[eParts.Length - 1];

                //Only process preps in normalized sentences
                string[] partsWithPreps = null;
                if (verbsMaybePrepositions.Contains("~"))
                {
                    partsWithPreps = SplitOnPrepositions(verbsMaybePrepositions);
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
                  prepositionalChain = new Chain(ChainType.Prepositionals, Particles.Blank ,  ProcessPrepositionalPhrases(partsWithPreps).ToArray());
                }
            }
            else
            {
                //Intransitives & Predictates

                string[] ppParts = SplitOnPrepositions(liPart);

                if (ppParts.Length == 0)
                {
                    throw new InvalidOperationException("Whoa, got zero parts for " + liPart);
                }
                verbPhrase = HeadedPhraseParser(ppParts[0]);

                string[] prepositions = ArrayExtensions.Tail(ppParts);

                
                List<Chain> pChains = new List<Chain>();
                foreach (string pp in prepositions)
                {
                    string[] phraseParts = JustTpWordsNumbersPunctuation(pp);
                    string preposition = phraseParts[0];
                    string[] tail = ArrayExtensions.Tail(phraseParts);

                    HeadedPhrase phrase = HeadedPhraseParser(pp);
                    Chain c = new Chain(ChainType.Prepositionals, new Particle(preposition), new Chain[] { ProcessEnPiChain(string.Join(" ", tail)) });
                    pChains.Add(c);
                }
                prepositionalChain = new Chain(ChainType.Prepositionals, Particles.Blank ,pChains.ToArray());
            }
            return new TpPredicate(verbPhrase, directObjectChain, prepositionalChain);
        }

        public List<Chain> ProcessPrepositionalPhrases(string[] partsWithPreps)
        {
            List<Chain> prepositionalChain = new List<Chain>();
            foreach (string partsWithPrep in partsWithPreps)
            {
                string preposition = JustTpWordsNumbersPunctuation(partsWithPrep)[0];
                string tail = preposition.Replace(preposition, "").Trim();

                if (partsWithPrep.Contains("~")) //Is it really?
                {
                    //These chains are ordered.
                    //kepeken x lon y kepeken z lon a   NOT EQUAL TO kepeken x  kepeken z lon a lon y
                    //Maybe.
                    prepositionalChain.Add(new Chain(ChainType.Prepositionals,
                        new Particle(preposition),
                        string.IsNullOrEmpty(tail) ? null : new Chain[] {ProcessEnPiChain(tail)}));
                }
                else
                {
                    //Is that surprising?
                }
            }
            return prepositionalChain;
        }

        public HeadedPhrase HeadedPhraseParser(string value)
        {
            Config c = Config.MakeDefault;
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
            HeadedPhrase phrase = new HeadedPhrase(new Word(words[0]),new WordSet(ArrayExtensions.Tail(words)));
            return phrase;
        }

        //Split on en
        // jan en soweli
        public static string[] SplitOnEn(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            Regex splitOnEn = new Regex("\\b" + Particles.en.Text + "\\b");
            string[] subjectTokens = splitOnEn.Split(value).Select(x => x.Trim()).ToArray();
            return subjectTokens;
        }

        public static string[] SplitOnPi(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            Regex splitOnPi = new Regex("\\b" + Particles.pi.Text + "\\b");
            string[] piLessTokens = splitOnPi.Split(value).Select(x => x.Trim()).Where(x=> !string.IsNullOrEmpty(x)).ToArray();
            return piLessTokens;
        }






        public static string[] SplitOnLi(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            Regex liSplit = new Regex("\\b"+Particles.li.Text+"\\b");
            string[] parts = liSplit.Split(value).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            //if (parts.Length == 0)
            //{
            //    throw new InvalidOperationException("Parse lost all parts for " + value);
            //}
            return parts;
        }

        public static string[] SplitOnO(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            Regex oParts = new Regex("\\b" + Particles.o.Text + "\\b");
            string[] liParts = oParts.Split(value).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return liParts;
        }


        public static string[] SplitOnLa(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            Regex splitOnEn = new Regex("\\b" + Particles.la.Text + "\\b");
            string[] subjectTokens = splitOnEn.Split(value).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return subjectTokens;
        }

        public static string[] SplitOnPrepositions(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Impossible to parse a null or zero length string.");
            }
            string pattern = @"{0}\b";
            string[] preps= new string[]{"~kepeken","~tawa","~poka","~sama","~tan","~lon"};
            //string[] preps = new string[] { "kepeken", "tawa", "poka", "sama", "tan", };
            string  parts= string.Join("|", preps.Select(x => String.Format(pattern, x)));
            //@"\s(?=\bkepeken\b|\bsama\b|\btawa\b|\btawa\b)"
            Regex splitOnEn = new Regex(@"\s(?="+parts+")");
            string[] prepTokens = splitOnEn.Split(value).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if(prepTokens.Any(x=>x.Contains(" ~")))
            {
                throw new InvalidOperationException("Split failed");
            }
            if (prepTokens.Length == 0)
            {
                throw new InvalidOperationException("Whoa, got zero parts for " + value);
            }
            return prepTokens;
            
        }

        public static string[] SplitOnParticle(Particle particle, string value)
        {
            Regex splitOnParticle = new Regex("\\b" + particle.Text + "\\b");
            string[] tokens = splitOnParticle.Split(value).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            return tokens;
        }

        //Gah, what a mess.
        [Obsolete]
        public static string[] SplitOnParticlePreserving(Particle particle, string value)
        {
            StringBuilder sb = new StringBuilder();
            List<string> parts = new List<string>();
            for (int i = 0; i < value.Length; i++)
            {
                string possible = value.Substring(i, particle.Text.Length);
                if (particle.Text == possible)
                {
                    if (i<value.Length -1)
                    {
                        string nextChar = value.Substring(i + 1, 1);
                        string lastChar=" ";
                        if (i - particle.Text.Length >= 0)
                        {
                            lastChar = value.Substring(i - particle.Text.Length, 1);
                     
                        }
                        
                        if (nextChar==" " ||  IsBoundary(nextChar) && IsBoundary(lastChar))
                        {
                            parts.Add(sb.ToString());
                            sb = new StringBuilder();

                        }
                    }
                    else
                    {
                        parts.Add(sb.ToString());
                        sb = new StringBuilder();
                    }
                }
                sb.Append(value[i]);
            }
            parts.Add(sb.ToString());
            return parts.ToArray();
        }

        private static bool IsBoundary(string boundary)
        {
            Regex matcher = new Regex("[a-zA-Z]");
            Match c = matcher.Match(boundary);
            
            return !c.Success;

        }
    }
}
