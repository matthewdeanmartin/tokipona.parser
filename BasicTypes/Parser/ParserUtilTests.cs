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
    /// <summary>
    /// Tests that parse something higher level than a string array.
    /// </summary>
    [TestFixture]
    public class ParserUtilTests
    {
        //
        [Test]
        public void SplitSentenceWithColon_Normalized()
        {
            string s = "sina toki e ni: mi wile e ni.";
            Config c = Config.DialectFactory;
            //c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);
            string[] parts= pu.ParseIntoRawSentences(s);
            Assert.AreEqual("sina li toki e ni:",parts[0]);
            Assert.AreEqual("mi li wile e ni.", parts[1]);
        }

        [Test]
        public void ProcessVocative()
        {
            Config c = Config.DialectFactory;
            //c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            const string vocative = "jan sona pi ma pi kasi suli o!";
            Sentence s = pu.ParsedSentenceFactory(vocative);
            Console.WriteLine(s.ToString("b"));
        }

        [Test]
        public void CreateTpPredicateAfterSplitingEChain()
        {
            Config c = Config.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            const string ePhrase = "li moku e soweli suli mute";
            TpPredicate predicate = pu.ProcessPredicates(ePhrase);
            Console.WriteLine(predicate.ToString("b"));
            Assert.IsTrue(predicate.Directs != null);
        }

        [Test]
        public void IdentifyDiscourses_CanItEvenParseTheSentences()
        {
            string sample = CorpusKnowledgeTests.SampleText;
            Config c = Config.DialectFactory;
            c.TargetGloss = "en";
            CorpusKnowledge ck = new CorpusKnowledge(sample,c);
            Discourse[] s = ck.MakeSentences();
            for (int i = 0; i < s.Length; i++)
            {
                foreach (Sentence sentence in s[i])
                {
                    string reToStringed = sentence==null?"[NULL SENTENCE]":sentence.ToString();
                    bool match = ck.Setences.Any(x => x.Trim() == reToStringed);
                    if (!match)
                    {
                        Console.WriteLine(match + " O:" + ck.Setences[i]);
                        Console.WriteLine(match + " R:" +  (sentence==null?"[NULL SENTENCE]":sentence.ToString("b")));

                    }
                }
            }
        }

        [Test]
        public void IdentifyDiscourses_CanItEvenParseTheSentences_ShowGoodOnes()
        {
            string sample = CorpusKnowledgeTests.SampleText;
            Config dialect = Config.DialectFactory;
            dialect.TargetGloss = "en";

            CorpusKnowledge ck = new CorpusKnowledge(sample, dialect);
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
            Config c = Config.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            Sentence[] s = pu
                            .ParseIntoRawSentences(CorpusKnowledgeTests.SampleText)
                            .Select(x => pu.ParsedSentenceFactory(x))
                            .ToArray();
           Assert.Greater(s.Length,0);

           Discourse[] d =  pu.GroupIntoDiscourses(s);
            
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
        public void CorpusKnowledge_HeadedPhraseParser()
        {
            Config c = Config.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            HeadedPhrase value = pu.HeadedPhraseParser("jan Mato");
            Assert.AreEqual(1, value.Modifiers.Count);
            Assert.AreEqual("jan", value.Head.ToString());
            Assert.AreEqual("Mato", value.Modifiers.First().Text);
        }

        [Test]
        public void ProcessSingletonEnChainOneEn()
        {
            Config c = Config.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            Chain list = pu.ProcessEnPiChain("jan en soweli");
            Console.WriteLine(list.ToJsonNet());
            Console.WriteLine(list);
            //Assert.AreEqual(1, list.SubChains[0].HeadedPhrases.Length);
            //Assert.AreEqual(list.SubChains[0].HeadedPhrases[0].Head.Text, "jan");
            //Assert.AreEqual(list.SubChains[1].HeadedPhrases[0].Head.Text, "soweli");
        }

        [Test]
        public void ProcessSingletonEnChainNoEn()
        {
            Config c = Config.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            Chain list = pu.ProcessEnPiChain("jan Mato");
            Console.WriteLine(list);
            //Assert.AreEqual(1, list.SubChains[0].SubChains.Length);
            //Assert.AreEqual("jan", list.SubChains[0].SubChains[0].HeadedPhrases.Head.Text);
            //Assert.AreEqual("Mato", list.SubChains[0].HeadedPhrases[0].Modifiers.First().Text);
        }
        [Test]
        public void ProcessSingletonPredicate()
        {
            Config c = Config.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            TpPredicate predicate = pu.ProcessPredicates("li soweli lili");
            Assert.AreEqual("soweli", predicate.VerbPhrases.Head.Text);
            Assert.AreEqual("lili", predicate.VerbPhrases.Modifiers.First().Text);
        }

    }
}
