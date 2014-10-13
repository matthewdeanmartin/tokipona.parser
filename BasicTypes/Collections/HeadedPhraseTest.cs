using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class HeadedPhraseTest
    {
        [Test]
        public void TestToStringThreeWords()
        {
            HeadedPhrase hp = new HeadedPhrase(Words.jan, new WordSet(new []{"lili","suli"}));
            Assert.AreEqual("jan lili suli",hp.ToString());  
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
        public void TwoWordProperModifierContainsBoth()
        {
            HeadedPhrase hp = new HeadedPhrase(Words.jan, new WordSet(new[] { "Mato" }));
            Assert.IsTrue(hp.Contains(new Word("jan")));
            Assert.IsTrue(hp.Contains(new Word("Mato")));
        }


        [Test]
        public void ParseAndToString()
        {
            HeadedPhrase hp = HeadedPhrase.Parse("jan Mato pi tomo suli");
            Assert.IsTrue(hp.Contains(new Word("jan")));
            Assert.IsTrue(hp.Contains(new Word("Mato")));
            Assert.IsTrue(hp.Contains(new Word("tomo")));
            Assert.IsTrue(hp.Contains(new Word("suli")));
            Assert.AreEqual("jan Mato pi tomo suli",hp.ToString());
        }

        [Test]
        public void CanSerialize()
        {
            HeadedPhrase hp = HeadedPhrase.Parse("jan Mato pi tomo suli");
            Assert.NotNull(hp.ToJsonDcJs());
        }
    }
}
