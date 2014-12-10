using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Services;
using System.Web.UI.WebControls;
using BasicTypes.Collections;
using BasicTypes.CollectionsDegenerate;
using BasicTypes.Glosser;
using BasicTypes.NormalizerCode;
using BasicTypes.Parts;
using Newtonsoft.Json.Converters;
using NUnit.Framework;

namespace BasicTypes.Lorem
{
    public class TextGenerator
    {
        private readonly Dialect dialect;
        public TextGenerator(Dialect dialect)
        {
            this.dialect = dialect;
        }

        private static readonly Random random = new Random(DateTime.Now.Millisecond);

        public string GenerateText()
        {
            Sentence result = GenerateSentence();
            return result.ToString();
        }

        public Sentence GenerateSentence()
        {
            //Exclamation, Fragment, Vocative, 
            //Simple, Simple + Optional Parts
            //
            int dice = random.Next(0, 100);
            if (dice < 5)
            {
                return SingleExclamation();
            }
            //if (dice < 7)
            //{
            //    return SingleFragment(); //Boring.
            //}
            if (dice < 10)
            {
                return SingleVocative();
            }
            if (dice < 20)
            {
                Sentence conclusion = SingleSimpleSentence(".");
                List<Sentence> premesis = new List<Sentence>(2);
                Sentence premise = SingleSimpleSentence("NONE");
                premesis.Add(premise);
                if (random.Next(0, 100) < 10)
                {
                    Sentence premise1 = SingleSimpleSentence("NONE");
                    premesis.Add(premise1);
                }
                return new Sentence(SentenceDiagnostics.NotFromParser,premesis.ToArray(), conclusion);
            }
            return SingleSimpleSentence();
        }

        private Sentence SingleVocative()
        {
            Vocative e = new Vocative(RandomEnPiChainOfProperModifers());
            Sentence s = new Sentence(e, new Punctuation("!"), SentenceDiagnostics.NotFromParser);
            return s;
        }

        //language|word|noun|adj|vt|vi|adv|prep|pronoun|kama|conditional|interj|conj|
        private Sentence SingleExclamation()
        {
            Word interj = RandomWord("interj");
            //Word[] exclamationModifiers = new Word[]
            //{
            //    Words.a, Words.kin
            //};
            Dictionary<int, int> odds = new Dictionary<int, int>
            {
                {0,85},
                {1,10},
                {2,5}
            };
            int last = 0;
            foreach (int key in odds.Keys.Select(x => x).ToArray())
            {
                odds[key] = odds[key] + last;
                last = odds[key];
            }
            int dice = random.Next(0, 101);
            WordSet ws = new WordSet();
            if (dice < 25)
            {
                dice = random.Next(0, 101);
                var howMany = odds.Where(x => dice <= x.Value).Select(x => x.Key).First();
                while (howMany > 0)
                {
                    ws.Add(new Word(Token.Modals[random.Next(0, Token.Modals.Length)]));
                    howMany--;
                }
                Exclamation e = new Exclamation(new HeadedPhrase(interj, ws));
                Sentence s = new Sentence(e, new Punctuation("!"),SentenceDiagnostics.NotFromParser);
                return s;
            }
            else
            {
                Exclamation e = new Exclamation(new HeadedPhrase(interj));
                Sentence s = new Sentence(e, new Punctuation("!"), SentenceDiagnostics.NotFromParser);
                return s;
            }

        }

        private Sentence SingleSimpleSentence(string punct =null)
        {
            int howMany = 1;
            if (random.Next(0, 100) < 10)
            {
                howMany = 2;
            }
            else if (random.Next(0, 100) < 20)
            {
                howMany = 3;
            }
            PredicateList pl = new PredicateList();
            while(howMany>0)
            {
                var p = GeneratePredicate();
                pl.Add(p);
                howMany--;
            }
            
            SentenceOptionalParts parts = OptionalParts(punct);
            if (parts != null)
            {
                if (punct == "NONE")
                {
                    parts.Punctuation = null;
                }
            }

            Sentence s = new Sentence(RandomEnPiChain(), pl, SentenceDiagnostics.NotFromParser,parts);
            return s;
        }

        private TpPredicate GeneratePredicate()
        {
            bool isTransitive = random.Next(0, 100) < 50;

            VerbPhrase verbPhrase = RandomVerbPhrase(isTransitive ? "vt" : "vi");
            ComplexChain nominal = RandomEnPiChain();

            TpPredicate p;
            if (random.Next(0, 100) < 75)
            {
                PrepositionalPhrase[] prepositionals = null;
                if (random.Next(0, 100) < 35)
                {
                    prepositionals = RandomPrepChain();
                }

                ComplexChain directs = null;
                if (isTransitive)
                {
                    directs = RandomEChain();
                }

                p = new TpPredicate(Particles.li, verbPhrase, directs, prepositionals);
            }
            else
            {
                p = new TpPredicate(Particles.li, nominal);
            }
            return p;
        }

        public SentenceOptionalParts OptionalParts(string punct=null)
        {
            if (random.Next(0, 100) < 75)
            {
                if (punct != null && punct!="NONE")
                {
                    return new SentenceOptionalParts { Punctuation =  new Punctuation(punct)};
                }
                return null;
            }
            SentenceOptionalParts sop = new SentenceOptionalParts();
            sop.Fragments = RandomEnPiChain();
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
            int isQuestion = random.Next(0, 100);
            if (isQuestion < 30)
            {
                sop.Punctuation = new Punctuation(".");
            }
            else if (isQuestion < 60)
            {
                sop.Punctuation = new Punctuation(":");
            }
            else
            {
                if (random.Next(0, 100) < 50)
                {
                    sop.TagQuestion = new TagQuestion();
                }
                sop.Punctuation = new Punctuation("?");
            }

            if (sop.Punctuation == null && punct != null)
            {
                sop.Punctuation = new Punctuation(punct);
            }
            //tag
            return sop;
        }

        public VerbPhrase RandomVerbPhrase(string pos)
        {
            VerbPhrase vp;
            if (random.Next(0, 100) < 25)
            {
                vp = new VerbPhrase(RandomEnPiChain());
            }
            else
            {
                vp = new VerbPhrase(RandomWord(pos), RandomModals(), RandomAdverbs());
            }

            return vp;
        }


        public WordSet RandomAdverbs()
        {
            Dictionary<int, int> odds = new Dictionary<int, int>
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
            Dictionary<int, int> odds = new Dictionary<int, int>
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
            var howMany = odds.Where(x => dice <= x.Value).Select(x => x.Key).First();

            WordSet ws = new WordSet();

            while (howMany > 0)
            {
                ws.Add(new Word(Token.Modals[random.Next(0, Token.Modals.Length)]));
                howMany--;
            }

            return ws;
        }

        public PrepositionalPhrase[] RandomPrepChain()
        {
            Dictionary<int, int> odds = new Dictionary<int, int>
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

            List<PrepositionalPhrase> prepositionals = new List<PrepositionalPhrase>();

            while (howMany > 0)
            {
                Word w = new Word(Particles.Prepositions[random.Next(0, 6)]);
                PrepositionalPhrase pp = new PrepositionalPhrase(w, RandomEnPiChain());
                prepositionals.Add(pp);
                howMany--;
            }
            return prepositionals.ToArray();
        }

        public ComplexChain RandomEChain()
        {
            Dictionary<int, int> odds = new Dictionary<int, int>
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

            List<ComplexChain> directObjects = new List<ComplexChain>();

            while (howMany > 0)
            {
                directObjects.Add(RandomEnPiChain());
                howMany--;
            }

            ComplexChain c = new ComplexChain(Particles.e, directObjects.ToArray());
            return c;
        }


        public ComplexChain RandomEnPiChainOfProperModifers()
        {
            Word headWord;
            int dice = random.Next(0, 100);
            if (dice < 70)
            {
                headWord = Words.jan;
            }
            else if (dice < 84)
            {
                headWord = Words.meli;
            }
            else if (dice < 99)
            {
                headWord = Words.mije;
            }
            else
            {
                headWord = Words.soweli;
            }

            WordSet modifiers;
            if (random.Next(0, 100) < 75)
            {
                modifiers = new WordSet { Neologism.MakeProperNeologism() };
            }
            else
            {
                modifiers = new WordSet { Neologism.MakeProperNeologism(), Neologism.MakeProperNeologism() };
            }

            List<Chain> agents = new List<Chain>();
            agents.Add(new Chain(Particles.pi, new[] { new HeadedPhrase(headWord, modifiers) }));
            ComplexChain c = new ComplexChain(Particles.en, agents.ToArray());
            return c;
        }

        public ComplexChain RandomEnPiChain()
        {
            Word headWord = RandomWord("noun");
            WordSet modifiers = new WordSet { RandomWord("adj") };
            List<Chain> agents = new List<Chain>();
            agents.Add(new Chain(Particles.pi, new[] { new HeadedPhrase(headWord, modifiers) }));
            ComplexChain c = new ComplexChain(Particles.en, agents.ToArray());
            return c;
        }

        public Word RandomWord(string pos)
        {
            int count = Words.Dictionary.Count;

            Word word;
            do
            {
                word = Words.Dictionary.ElementAt(random.Next(0, count)).Value;
                
            } while (
                word == null || word.IsParticle ||
                (!dialect.IncludeApocrypha && Token.Deprecated.Contains(word.Text))
                || !Words.Glosses[word.Text]["en"].ContainsKey(pos));

            return word;
        }

        //https://stackoverflow.com/questions/1028136/random-entry-from-dictionary
        public static IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            //return dict.ElementAt(rand.Next(0, dict.Count)).Value;

            Random rand = random;
            List<TValue> values = dict.Values.ToList();
            int size = dict.Count;
            while (true)
            {
                yield return values[rand.Next(size)];
            }
        }
    }
}
