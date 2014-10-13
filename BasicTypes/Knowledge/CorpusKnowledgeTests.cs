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
            CorpusKnowledge ck = new CorpusKnowledge(sample);
            Discourse[] s = ck.MakeSentences();
            foreach (Discourse d in s)
            {
                foreach (Sentence js in d)
                {
                    Sentence sentence = js;
                    Console.WriteLine(sentence.ToString());
                    Assert.AreEqual(sample, sentence.ToString());    
                }
            }
        }


        [Test]
        public void SplitRealTest()
        {
            CorpusKnowledge c = new CorpusKnowledge(SampleText);
            int i = 0;
            foreach (string sentence in c.Setences)
            {
                i++;
                Console.WriteLine(i + ") " + sentence);
            }
        }

        //Added . to title.
        public static string SampleText = @"
jan lawa lili. 

tenpo pi lili mi la mi lukin e sitelen pona. akesi linja li moku e soweli suli. ni li sitelen: 

lipu li toki e ni: akesi linja li moku li tawa ala e nena uta. ona li moku la ona li lape. mi pilin pona tan ni. mi pali e sitelen pi nanpa wan: 

mi toki tawa jan suli: o lukin! sina pilin ike ala pilin ike tan sitelen ni?

ona li toki: mi pilin ike tan len lawa anu seme?

sitelen mi li ala e len lawa. sitelen mi li ni: akesi linja li moku e soweli suli mute. 

jan suli li sona taso e toki pona. mi pali e sitelen pi nanpa tu. ona li insa pi akesi linja: 

jan suli li toki: o pali ala e sitelen akesi anu insa akesi. o sona e sona nanpa e sona ma e sona tenpo e sona toki!

jan suli li pilin ike tawa sitelen mi la mi pali ala e sitelen sin. 

mi pali e ijo ante. mi kepeken e tomo tawa kon. ni li lon: sona ma li pona tawa mi. mi ken sona e ante pi ma Kina en ma Alisona. tenpo pimeja la sona ni li pona. 

tenpo lili la mi sona mute e jan suli. taso, mi pilin ike tan ni! 

tenpo ijo la mi pilin e ni: jan suli ni li pona. mi pana e sitelen pi nanpa wan tawa ona. mi wile sona e ni: jan ni li jo ala jo e pi sona pona? 

tenpo ali la jan suli li toki: ni li len lawa.  mi toki ala e akesi e ma kasi e sike sewi lili tawa ona tan ni. mi toki e musi pi jan suli e nasin wawa e len pi anpa lawa. jan suli li pilin pona tawa mi tan ni.";
    }
}
