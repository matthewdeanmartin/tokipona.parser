using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BasicTypes.Collections;

namespace BasicTypes
{
    class ParserUtils
    {
        public static string[] ParseIntoRawSentences(string text)
        {
            //https://stackoverflow.com/questions/521146/c-sharp-split-string-but-keep-split-chars-separators
            //https://stackoverflow.com/questions/3115150/how-to-escape-regular-expression-special-characters-using-javascript
            return  Regex
                .Split(text, @"(?<=[\?!.:])")  //split preserving punctuation
                .Where(x => !string.IsNullOrWhiteSpace(x)) //skip empties
                .Select(x => Regex.Replace(x, @"^\s+|\s+$", "")) //Remove extraneous whitespace
                .Select(x => Regex.Replace(x, @"\bla mi\b", "la mi li"))//normalize contractions
                .Select(x => Regex.Replace(x, @"\bla sina\b", "la sina li"))//normalize contractions
                .ToArray();  
        }

        public static Discourse[] GroupIntoDiscourses(Sentence[] sentences)
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
        public static string[] JustTpWords(string value)
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

        public static string[] JustTpWordsNumbersPunctuation(string value)
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

        public static Sentence ParsedSentenceFactory(string sentence)
        {
            string[] laParts = SplitOnLa(sentence);

            Regex liFinder=new Regex(@"\bli\b");

            List<HeadedPhrase> foundFragments = new List<HeadedPhrase>();
            
            foreach (string laPart in laParts)
            {
                Match m = liFinder.Match(laPart);
                if (m.Success)
                {
                    //li part
                }
                else
                {
                    //fragment
                    string[] piLessParts= ParserUtils.SplitOnPi(laPart);
                    Chain piChain = new Chain(ChainType.None, Particles.pi, piLessParts.Select(HeadedPhrase.Parse).ToArray());
                    foundFragments.Add(ParserUtils.HeadedPhraseParser(laPart));
                }
            }
            
            
            string[] liParts = SplitOnLi(sentence);
            string subjects = liParts[0].Trim();

            Chain subjectChain = ProcessEnPiChain(subjects);

            //Skip 1 on purpose
            PredicateList verbPhrases = new PredicateList();
            
            for (int i = 1; i < liParts.Length; i++)
            {
                string predicate = liParts[1].Trim();

                verbPhrases.Add(ProcessPredicates(predicate));
            }

            Sentence parsedSentence = new Sentence(subjectChain, verbPhrases, new Punctuation(sentence[sentence.Length - 1].ToString()));
            return parsedSentence;
        }

        public static Chain ProcessEnPiChain2(string subjects)
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

        public static Chain ProcessEnPiChain(string subjects)
        {
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
        public static TpPredicate ProcessPredicates(string liPart)
        {
            Chain directObjectChain = null;
            HeadedPhrase verbPhrase = null;
            Chain prepositionalChain = null;

            //Transitive Path.
            if (liPart.Contains(" e "))
            {
                Regex eSplit = new Regex("\\be\\b");
                string[] eParts = eSplit.Split(liPart);

                verbPhrase = HeadedPhraseParser(eParts[0]);

                string[] directObjects = ArrayExtensions.Tail(eParts);

                List<HeadedPhrase> doNPs = new List<HeadedPhrase>();
                foreach (string directObject in directObjects)
                {
                    HeadedPhrase phrase = HeadedPhraseParser(directObject);
                    doNPs.Add(phrase);
                }
                directObjectChain = new Chain(ChainType.Directs, Particles.e, doNPs.ToArray());

                string verbsMaybePrepositions = eParts[eParts.Length - 1];

                //if (Particle.ContainsProposition(verbAndMaybePrepositions))
                //{
                //    //string[] eParts = predicate.Split(new string[] { "e" }, StringSplitOptions.RemoveEmptyEntries);
                //    //Need to split but preserve what was split on.
                //    
                //}
            }
            else
            {
                //Intransitives & Predictates

                Regex splitOnPropositions = new Regex("\\b[~sike|~tawa|~sama|~poka|~insa|~anpa|~lon]\\b");
                string[] ppParts = splitOnPropositions.Split(liPart);

                verbPhrase = HeadedPhraseParser(ppParts[0]);

                string[] prepositions = ArrayExtensions.Tail(ppParts);

                List<HeadedPhrase> ppHPs = new List<HeadedPhrase>();
                foreach (string pp in prepositions)
                {
                    HeadedPhrase phrase = HeadedPhraseParser(pp);
                    ppHPs.Add(phrase);
                }
                prepositionalChain = new Chain(ChainType.Directs, Particles.e, ppHPs.ToArray());
            }
            return new TpPredicate(verbPhrase, directObjectChain, prepositionalChain);
        }

        public static HeadedPhrase HeadedPhraseParser(string value)
        {
            //No Pi!
            string[] words = ParserUtils.JustTpWords(value);
            HeadedPhrase phrase = new HeadedPhrase(new Word(words[0]),new WordSet(ArrayExtensions.Tail(words)));
            return phrase;
        }

        //Split on en
        // jan en soweli
        public static string[] SplitOnEn(string value)
        {
            Regex splitOnEn = new Regex("\\b" + Particles.en.Text + "\\b");
            string[] subjectTokens = splitOnEn.Split(value).Select(x => x.Trim()).ToArray();
            return subjectTokens;
        }

        public static string[] SplitOnPi(string value)
        {
            Regex splitOnPi = new Regex("\\b" + Particles.pi.Text + "\\b");
            string[] piLessTokens = splitOnPi.Split(value).Select(x => x.Trim()).ToArray();
            return piLessTokens;
        }

        public static string[] SplitOnLi(string value)
        {
            Regex liSplit = new Regex("\\b"+Particles.li.Text+"\\b");
            string[] liParts = liSplit.Split(value).Select(x => x.Trim()).ToArray();
            return liParts;
        }

        public static string[] SplitOnO(string value)
        {
            Regex oParts = new Regex("\\b" + Particles.o.Text + "\\b");
            string[] liParts = oParts.Split(value).Select(x => x.Trim()).ToArray();
            return liParts;
        }


        public static string[] SplitOnLa(string value)
        {
            Regex splitOnEn = new Regex("\\b" + Particles.la.Text + "\\b");
            string[] subjectTokens = splitOnEn.Split(value).Select(x => x.Trim()).ToArray();
            return subjectTokens;
        }

        public static string[] SplitOnParticle(Particle particle, string value)
        {
            Regex splitOnParticle = new Regex("\\b" + particle.Text + "\\b");
            string[] tokens = splitOnParticle.Split(value).Select(x => x.Trim()).ToArray();
            return tokens;
        }

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
