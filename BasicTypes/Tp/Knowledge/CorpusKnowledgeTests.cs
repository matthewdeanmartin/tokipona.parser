using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Knowledge;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class CorpusKnowledgeTests
    {
        [Test]
        public void ArrayExtensionsTest()
        {
            string[] oneTwo = new string[] { "one", "two" };
            string[] tail = ArrayExtensions.Tail(oneTwo);
            Assert.AreEqual(1, tail.Length);
            Assert.AreEqual("two", tail[0]);
        }

        [Test]
        public void ArrayExtensionsTest2()
        {
            string[] oneTwoThree = new string[] { "one", "two", "three" };
            string[] tail = ArrayExtensions.Tail(oneTwoThree);
            Assert.AreEqual(2, tail.Length);
            Assert.AreEqual("two", tail[0]);
            Assert.AreEqual("three", tail[1]);
        }


        [Test]
        public void ParseAndToStringSimpleIntransitive()
        {
            string sample = "jan Mato li jan soweli.";
            Dialect dialect = Dialect.LooseyGoosey;
            dialect.TargetGloss = "en";

            CorpusKnowledge ck = new CorpusKnowledge(sample, dialect);
            List<Sentence>[] s = ck.MakeSentences();
            foreach (List<Sentence> d in s)
            {
                foreach (Sentence js in d)
                {
                    Sentence sentence = js;
                    Console.WriteLine(sentence.ToString());
                    Console.WriteLine(sentence.ToString("b"));

                    Assert.AreEqual(sample, sentence.ToString());    
                }
            }
        }


        [Test]
        public void SplitRealTest()
        {
            Dialect dialect = Dialect.LooseyGoosey;
            dialect.TargetGloss = "en";

            CorpusKnowledge c = new CorpusKnowledge(CorpusTexts.UnpaText,dialect);
            int i = 0;
            foreach (string sentence in c.Setences)
            {
                i++;
                Console.WriteLine(i + ") " + sentence);
            }
        }

     
    }
}
