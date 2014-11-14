using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Services;
using BasicTypes.Collections;
using Newtonsoft.Json.Converters;
using NUnit.Framework;

namespace BasicTypes.Lorem
{
    [TestFixture]
    public class TextGeneratorTest
    {
        [Test]
        public void GenerateObjectAndStringify()
        {
            for (int i = 0; i < 1000; i++)
            {
                Sentence s = TextGenerator.GenerateSentence();
                Console.WriteLine(s.ToString());
                Console.WriteLine(s.ToString("b"));    
            }
        }

        [Test]
        public void GenerateObjectAndStringifyParse()
        {
            List<Sentence> sentences = new List<Sentence>();
            for (int i = 0; i < 1000; i++)
            {
                sentences.Add(TextGenerator.GenerateSentence());
            }
            
             
            ParserUtils pu=new ParserUtils(Dialect.WordProcessorRules);
            foreach (Sentence sentence in sentences)
            {
                string s = sentence.ToString();
                Console.WriteLine(s);
                try
                {
                    Sentence reparsed = pu.ParsedSentenceFactory(s, s);

                    Console.WriteLine(reparsed.ToString());
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("This isn't possible in a pi chain"))
                    {
                        Console.WriteLine("Prep phrase in a subject :-(");
                        continue;
                    }
                    else
                        throw;
                }
                
            }
        }
    }

    public class TextGenerator
    {
        static Random random = new Random(DateTime.Now.Millisecond);

        public static string GenerateText()
        {
            Sentence result = GenerateSentence();
            return result.ToString();
        }

        public static Sentence GenerateSentence()
        {
            //Exclamation, Fragment, Vocative, 
            //Simple, Simple + Optional Parts
            //
            bool isTransitive = random.Next(0, 100) < 50;

            VerbPhrase verbPhrase = RandomVerbPhrase(isTransitive?"vt":"vi");
            Chain nominal = RandomPiChain();

            TpPredicate p;
            if (random.Next(0, 100) < 75)
            {
                Chain prepositionals = null;
                if (random.Next(0, 100) < 35)
                {
                    prepositionals = RandomPrepChain();
                }
                
                Chain directs=null;
                if (isTransitive)
                {
                    directs = RandomEChain();
                }

                p = new TpPredicate(Particles.li, verbPhrase,directs,prepositionals);
            }
            else
            {
                p = new TpPredicate(Particles.li, nominal);
            }


            Sentence s = new Sentence(RandomPiChain(),new PredicateList(){ p},OptionalParts());
            return s;
        }

        public static SentenceOptionalParts OptionalParts()
        {
            if (random.Next(0, 100) < 75)
            {
                return null;
            }
            SentenceOptionalParts sop = new SentenceOptionalParts();
            sop.Fragments = RandomPiChain();
            if (random.Next(0, 100) < 25)
            {
                if (random.Next(0, 100) < 50)
                {
                    sop.Conjunction = Particles.taso;
                }
                else
                {
                    sop.Conjunction = Particles.anu;
                }
            }
            if (random.Next(0, 100) < 80)
            {
                sop.Punctuation = new Punctuation(".");
            }
            else
            {
                sop.Punctuation = new Punctuation(":");
            }
            //tag
            return sop;
        }

        public static VerbPhrase RandomVerbPhrase(string pos)
        {
            VerbPhrase vp;
            if (random.Next(0, 100) < 25)
            {
                 vp = new VerbPhrase(RandomPiChain());
            }
            else
            {
                vp = new VerbPhrase(RandomWord(pos),RandomModals(),RandomAdverbs());
            }

            return vp;
        }


        public static WordSet RandomAdverbs()
        {
            Dictionary<int, int> odds = new Dictionary<int, int>()
            {
                {0,88},
                {1,7},
                {2,5},
                {3,0},
                {4,0},
            };
            int last = 0;
            foreach (int key in odds.Keys.Select(x => x).ToArray())
            {
                odds[key] = odds[key] + last;
                last = odds[key];
            }
            int dice = random.Next(0, 101);
            var howMany = odds.Where(x => dice <= x.Value).Select(x => x.Key).First();

            WordSet ws = new WordSet();

            while (howMany > 0)
            {
                ws.Add(RandomWord("adv"));
                howMany--;
            }

            return ws;
        }

        public static WordSet RandomModals()
        {
            Dictionary<int, int> odds = new Dictionary<int, int>()
            {
                {0,74},
                {1,10},
                {2,10},
                {3,6},
                {4,0},
            };
            int last = 0;
            foreach (int key in odds.Keys.Select(x => x).ToArray())
            {
                odds[key] = odds[key] + last;
                last = odds[key];
            }

            int dice = random.Next(0, 101);
            var howMany = odds.Where(x => dice<=x.Value  ).Select(x=>x.Key).First();
            
            WordSet ws = new WordSet();

            while(howMany>0)
            {
                ws.Add(Token.Modals[random.Next(0, Token.Modals.Length)]);
                howMany--;
            }
            
            return ws;
        }

        public static Chain RandomPrepChain()
        {
            Dictionary<int, int> odds = new Dictionary<int, int>()
            {
                {1,74},
                {2,10},
                {3,10},
                {4,5},
                {5,1},
            };
            int last = 0;
            foreach (int key in odds.Keys.Select(x => x).ToArray())
            {
                odds[key] = odds[key] + last;
                last = odds[key];
            }

            int dice = random.Next(0, 101);
            var howMany = odds.Where(x => dice <= x.Value).Select(x => x.Key).First();

            List<Chain> prepositionals = new List<Chain>();

            while (howMany > 0)
            {
                prepositionals.Add(RandomPiChain());
                howMany--;
            }


            Chain c = new Chain(ChainType.MixedPrepositional, Particles.Blank, prepositionals.ToArray());
            return c;
        }

        public static Chain RandomEChain()
        {
            Dictionary<int, int> odds = new Dictionary<int, int>()
            {
                {1,74},
                {2,10},
                {3,10},
                {4,5},
                {5,1},
            };
            int last = 0;
            foreach (int key in odds.Keys.Select(x => x).ToArray())
            {
                odds[key] = odds[key] + last;
                last = odds[key];
            }

            int dice = random.Next(0, 101);
            var howMany = odds.Where(x => dice<=x.Value  ).Select(x=>x.Key).First();
            
            List<Chain> directObjects = new List<Chain>();

            while(howMany>0)
            {
                directObjects.Add(RandomPiChain());
                howMany--;
            }


            Chain c = new Chain(ChainType.Directs, Particles.e, directObjects.ToArray() );
            return c;
        }

        public static Chain RandomPiChain()
        {
            Word headWord = RandomWord("noun");
            WordSet modifiers = new WordSet() { RandomWord("adj") };
            List<Chain> agents = new List<Chain>();
            agents.Add(new Chain(ChainType.None, Particles.pi, new HeadedPhrase[] { new HeadedPhrase(headWord, modifiers) }));
            Chain c = new Chain(ChainType.Subjects, Particles.en, agents.ToArray());
            return c;
        }

        public static Word RandomWord(string pos)
        {
            
            //var glosses = Words.Glosses["en"].Where(x=>x.Key==pos).Select(x=>x);

            int count = Words.Dictionary.Count;

            // Words.Glosses["soweli"]["en"]["pos"][3]
            
            

            Word word = null;
            do
            {
                word = Words.Dictionary.ElementAt(random.Next(0, count)).Value;
                
            } while (word == null || word.IsParticle || Token.Deprecated.Contains(word.Text) || !Words.Glosses[word.Text]["en"].ContainsKey(pos));

            return word;
            //throw new InvalidOperationException("How did we get here?");
            //RandomValues(Words.Dictionary).GetEnumerator().Current;
        }

        //https://stackoverflow.com/questions/1028136/random-entry-from-dictionary
        public static IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            //return dict.ElementAt(rand.Next(0, dict.Count)).Value;

            Random rand = random;
            List<TValue> values = Enumerable.ToList(dict.Values);
            int size = dict.Count;
            while (true)
            {
                yield return values[rand.Next(size)];
            }
        }
    }
}
