using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Knowledge;
using NUnit.Framework;

namespace BasicTypes.Parser
{
    [TestFixture]
    public class ParserUtilTests
    {
        [Test]
        public void SplitE()
        {
            string ePhrase = "li moku e soweli suli mute";
            TpPredicate predicate= ParserUtils.ProcessPredicates(ePhrase);
            Console.WriteLine(predicate.ToString("b"));
            Assert.IsTrue(predicate.Directs !=null);
        }

        [Test]
        public void SplitEAndPreserve()
        {
            string ePhrase = "li moku e soweli suli mute e wawa e tawa e kala e";
            string[] parts = ParserUtils.SplitOnParticlePreserving(Particles.e, ePhrase);
            foreach (string part in parts)
            {
                Console.WriteLine(part);
            }
        }

        [Test]
        public void IdentifyDiscourses_CanItEvenParseTheSentences()
        {
            string sample = CorpusKnowledgeTests.SampleText;
            CorpusKnowledge ck = new CorpusKnowledge(sample);
            Discourse[] s = ck.MakeSentences();
            for (int i = 0; i < s.Length; i++)
            {
                foreach (Sentence sentence in s[i])
                {
                    string reToStringed = sentence.ToString();
                    bool match = ck.Setences.Any(x => x.Trim() == reToStringed);
                    if (!match)
                    {
                        Console.WriteLine(match + " O:" + ck.Setences[i]);
                        Console.WriteLine(match + " R:" + sentence.ToString("b"));

                    }
                }
            }
        }

        [Test]
        public void IdentifyDiscourses_CanItEvenParseTheSentences_ShowGoodOnes()
        {
            string sample = CorpusKnowledgeTests.SampleText;
            CorpusKnowledge ck = new CorpusKnowledge(sample);
            Discourse[] s = ck.MakeSentences();
            for (int i = 0; i < s.Length; i++)
            {
                foreach (Sentence sentence in s[i])
                {
                    string reToStringed = sentence.ToString();
                    bool match = ck.Setences.Any(x => x.Trim() == reToStringed);
                    if (match)
                    {
                        Console.WriteLine(match + " O:" + ck.Setences[i]);
                        Console.WriteLine(match + " R:" + sentence.ToString("b"));

                    }
                }
            }
        }

        [Test]
        public void IdentifyDiscourses_CanWeGroupThem()
        {
            Sentence[] s = ParserUtils
                            .ParseIntoRawSentences(CorpusKnowledgeTests.SampleText)
                            .Select(x => ParserUtils.ParsedSentenceFactory(x))
                            .ToArray();
           Assert.Greater(s.Length,0);

           Discourse[] d =  ParserUtils.GroupIntoDiscourses(s);
            
           Assert.Greater(d.Length,0);

            foreach (Discourse discourse in d)
            {
                Assert.Greater(discourse.Count,0);     
            }

            Console.WriteLine("-------------------");
            foreach (Discourse discourse in d)
            {
                
                int i = 0;
                foreach (Sentence sentence in discourse)
                {
                    i++;
                    Console.WriteLine(i +") " + sentence.ToString("b"));    
                }
                
                Console.WriteLine("-------------------");
            }
        }

        [Test]
        public void OneWord()
        {
            string[] w = ParserUtils.JustTpWords("jan");
            Assert.AreEqual(1, w.Length);
        }

        [Test]
        public void TwoWords()
        {
            string[] w = ParserUtils.JustTpWords("jan lili");
            Assert.AreEqual(2, w.Length);
        }


        [Test]
        public void ThreWords()
        {
            string[] w = ParserUtils.JustTpWords("jan lili lon");
            Assert.AreEqual(3, w.Length);
        }

        [Test]
        public void WordsNumbersWithoutDash()
        {
            string[] w = ParserUtils.JustTpWords("1231231");
            Assert.AreEqual(1, w.Length);
        }

        [Test]
        public void WordsNumbersPunctuationWithoutDash()
        {
            string[] w = ParserUtils.JustTpWordsNumbersPunctuation("1231231");
            Assert.AreEqual(1, w.Length);
        }

        [Test]
        public void WordsNumbersWithDash()
        {
            string[] w= ParserUtils.JustTpWords("123-1231");
            foreach (string s in w)
            {
                Console.WriteLine(s);
            }
            Assert.AreEqual(1, w.Length);
        }

        [Test]
        public void WordsNumbersPunctuationWithDash()
        {
            string value = "123-1231";
            string[] w = ParserUtils.JustTpWordsNumbersPunctuation(value);
            foreach (string s in w)
            {
                Console.WriteLine(s);
            }
            Assert.AreEqual(1, w.Length);
            Assert.AreEqual(value, w[0]);
        }


        [Test]
        public void SplitOnEn()
        {
            string[] values = ParserUtils.SplitOnEn("jan Mato");
            Assert.AreEqual(1, values.Length);
            Assert.AreEqual("jan Mato", values[0]);
        }


        [Test]
        public void SplitOnEn2()
        {
            string[] values = ParserUtils.SplitOnEn("jan Mato en jan Wantu");
            Assert.AreEqual(2, values.Length);
            Assert.AreEqual("jan Mato", values[0]);
            Assert.AreEqual("jan Wantu", values[1]);
        }

        [Test]
        public void CorpusKnowledge_HeadedPhraseParser()
        {
            HeadedPhrase value = ParserUtils.HeadedPhraseParser("jan Mato");
            Assert.AreEqual(1, value.Modifiers.Count);
            Assert.AreEqual("jan", value.Head.ToString());
            Assert.AreEqual("Mato", value.Modifiers.First().Text);
        }

        [Test]
        public void ProcessSingletonEnChainOneEn()
        {
            Chain list = ParserUtils.ProcessEnPiChain("jan en soweli");
            Console.WriteLine(list.ToJsonNet());
            Console.WriteLine(list);
            Assert.AreEqual(1, list.SubChains[0].HeadedPhrases.Length);
            Assert.AreEqual(list.SubChains[0].HeadedPhrases[0].Head.Text, "jan");
            Assert.AreEqual(list.SubChains[1].HeadedPhrases[0].Head.Text, "soweli");
        }

        [Test]
        public void ProcessSingletonEnChainNoEn()
        {
            Chain list = ParserUtils.ProcessEnPiChain("jan Mato");
            Console.WriteLine(list);
            Assert.AreEqual(1, list.SubChains[0].HeadedPhrases.Length);
            Assert.AreEqual("jan", list.SubChains[0].HeadedPhrases[0].Head.Text);
            Assert.AreEqual("Mato", list.SubChains[0].HeadedPhrases[0].Modifiers.First().Text);
        }
        [Test]
        public void ProcessSingletonPredicate()
        {
            TpPredicate predicate = ParserUtils.ProcessPredicates("soweli lili");
            Assert.AreEqual("soweli", predicate.VerbPhrases.Head.Text);
            Assert.AreEqual("lili", predicate.VerbPhrases.Modifiers.First().Text);
        }

    }
}
