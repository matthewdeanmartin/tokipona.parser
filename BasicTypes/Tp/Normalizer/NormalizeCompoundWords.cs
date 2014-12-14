using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BasicTypes.Dictionary;
using BasicTypes.Extensions;
using BasicTypes.Parts;

namespace BasicTypes.NormalizerCode
{

    //This has some ugly code in it because the perf monitor said like, 90% of the time was being spent in this function.
    //So the ugly perf optimizations have been worth it.
    public class NormalizeCompoundWords
    {
        internal class ExtendedCompoundWord
        {
            public ExtendedCompoundWord(CompoundWord w, string spacey, string trimmed)
            {
                Word = w;
                Spacey = spacey;
                TrimmedWord = trimmed;
            }
            public CompoundWord Word { get; set; }
            public string Spacey { get; set; }
            public string TrimmedWord { get; set; }
        }

        private readonly string[] modalsDash;
        private readonly string[] prepsDash;
        private readonly string[] dashPreps;
        private readonly Dictionary<string, ExtendedCompoundWord> sortedDictionary = new Dictionary<string, ExtendedCompoundWord>();
        public NormalizeCompoundWords()
        {
             modalsDash = Token.Modals.Select(x => x + "-").ToArray();
             prepsDash = Particles.Prepositions.Select(x => x + "-").ToArray();
             dashPreps = Particles.Prepositions.Select(x => x + "-").ToArray();

            foreach (var pair in CompoundWords.Dictionary.OrderBy(x => x.Key.Length*-1))
            {
                //Need to treat la fragments separately.
                if (pair.Key.EndCheck("-la")) continue;
                if (pair.Key.StartCheck("pi-"))
                    continue;
                        //This is essentially a possessive or adjective noun phrase, should deal with via POS for compound words.
                if (pair.Key.EndCheck("-ala")) continue; //negation is special.
                if (pair.Key.StartCheck("li-"))
                    continue;
                        //These are essentially verb markers and all verbs phrases are templates (i.e. can have additional words inserted & be the same template)
                if (pair.Key.ContainsCheck("-e-")) continue;

                //TODO: Can't distinguish these yet.
                //ijo li wile sona e ni. //modal + verb
                //mi pana e wile-sona ni.//question
                bool thatsAModal = false;
                foreach (string modal in modalsDash)
                {
                    if (pair.Key.StartCheck(modal))
                    {
                        thatsAModal = true;
                    }
                }

                if (thatsAModal) continue;

                //lon-poka 
                bool thatsAPreposition = false;

                //Perf trace said concats were expensive.
                foreach (string preposition in dashPreps)
                {
                    if (pair.Key.EndCheck(preposition)) // jan ante li toki kepeken toki ante taso.
                    {
                        thatsAPreposition = true;
                    }
                }
                foreach (string preposition in prepsDash)
                {
                    if (pair.Key.StartCheck(preposition))
                    {
                        thatsAPreposition = true;
                    }

                }
                if (thatsAPreposition) continue;

                sortedDictionary.Add(pair.Key, new ExtendedCompoundWord(pair.Value, pair.Key.Replace("-", " "), pair.Key.Trim(new char[] { ' ', '-' })));
            }
        }

        public string ProcessCompoundWords(string normalized)
        {
            foreach (var pair in sortedDictionary)
            {
                if (normalized.Length < pair.Value.Spacey.Length) continue;

                if (!normalized.ContainsCheck(pair.Value.Spacey)) continue;
                //Short strings can't contain a longer compound word.
                
                var isIt = Regex.Match(normalized, @"\b" + pair.Value.Spacey + @"\b");
                if (isIt.Success)
                {
                    //This won't replace on boundaries though.
                    string savePoint = string.Copy(normalized);
                    normalized = normalized.Replace(pair.Value.Spacey, pair.Value.TrimmedWord);
                    if (normalized.ContainsCheck("-" + pair.Key) || normalized.ContainsCheck(pair.Key + "-"))
                    {
                        //Undo! We matched a word that crosses compound words. How is that even possible?
                        normalized = savePoint;
                    }
                }
            }
            return normalized;
        }
    }
}
