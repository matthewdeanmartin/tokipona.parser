using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BasicTypes.Exceptions;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class HeadedPhraseTest
    {
        [Test]
        public void ParseHeadedPhraseWithPrep()
        {
            string s = "kule ~lon palisa luka li pona ~tawa mi.";
            ParserUtils pu = new ParserUtils(Dialect.LooseyGoosey);
            Sentence sentence = pu.ParsedSentenceFactory(s, s);
            Console.WriteLine(sentence.ToString());
            Console.WriteLine(sentence.ToString("b"));
        
        }
        [Test]
        public void TestToStringThreeWords()
        {
            HeadedPhrase hp = new HeadedPhrase(Words.jan, new WordSet(new []{"lili","suli"}));
            Assert.AreEqual("jan lili suli",hp.ToString());  
        }

        [Test]
        public void ParticleModifiersWhut()
        {
            try
            {
                //li, pi, la, e, are illegal modifiers.
                HeadedPhrase hp = new HeadedPhrase(Words.jan, new WordSet(new[] {"lili", "suli", "li", "pi"}));
                Assert.AreEqual("jan lili suli li pi", hp.ToString());
            }
            catch (InvalidOperationException)
            {
                //Assert.Pass(); Throws SuccessException-- huh?
                return;
            }
            catch (TpSyntaxException)
            {
                //Assert.Pass(); Throws SuccessException-- huh?
                return;
            }
            Assert.Fail();

        }

        [Test]
        public void ParticleHeadWordWhut()
        {
            try
            {
                //li, pi, la, e, are illegal modifiers.
                HeadedPhrase hp = new HeadedPhrase(new Word("pi"), new WordSet(new[] {"lili", "suli", "li", "pi"}));
                Assert.AreEqual("jan lili suli li pi", hp.ToString());
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
                return;
            }
            catch (TpSyntaxException)
            {
                Assert.Pass();
                return;
            }
            Assert.Fail("Expected some sort of exception.");

        }

        [Test]
        public void TwoWordProperModifierContainsThre()
        {
            HeadedPhrase hp = new HeadedPhrase(Words.jan, new WordSet(new[] { "lili", "suli" }));
            Assert.IsTrue(hp.Contains(new Word("jan")));
            Assert.IsTrue(hp.Contains(new Word("lili")));
            Assert.IsTrue(hp.Contains(new Word("suli")));
        }

        [Test]
        public void TwoWordProperModifier()
        {
            HeadedPhrase hp = new HeadedPhrase(Words.jan, new WordSet(new[] { "Mato" }));
            Assert.AreEqual("jan Mato", hp.ToString());
        }


        [Test]
        public void ThreeWordDoubleProperModifier()
        {
            HeadedPhrase hp = new HeadedPhrase(Words.jan, new WordSet(new[] { "Mato" ,"Maton"}));
            Assert.AreEqual("jan Mato Maton", hp.ToString()); //ti is illegal
        }

        [Test]
        public void TwoWordProperModifierContainsBoth()
        {
            HeadedPhrase hp = new HeadedPhrase(Words.jan, new WordSet(new[] { "Mato" }));
            Assert.IsTrue(hp.Contains(new Word("jan")));
            Assert.IsTrue(hp.Contains(new Word("Mato")));
        }


        [Test]
        public void ParseAndToString()
        {
            HeadedPhrase hp = HeadedPhrase.Parse("jan Mato tomo suli");
            Assert.IsTrue(hp.Contains(new Word("jan")));
            Assert.IsTrue(hp.Contains(new Word("Mato")));
            Assert.IsTrue(hp.Contains(new Word("tomo")));
            Assert.IsTrue(hp.Contains(new Word("suli")));
            Assert.AreEqual("jan Mato tomo suli",hp.ToString());
        }

        [Test]
        public void CanSerialize()
        {
            HeadedPhrase hp = HeadedPhrase.Parse("jan Mato tomo suli");
            Assert.NotNull(hp.ToJsonDcJs());
        }
    }
}
