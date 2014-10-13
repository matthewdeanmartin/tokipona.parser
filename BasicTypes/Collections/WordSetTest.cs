using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class WordSetTest
    {
        [Test]
        public void TestTwoWordsToString()
        {
            WordSet set = new WordSet(new String[]{"jan", "soweli" });
            Assert.AreEqual(2,set.Count);
            Assert.AreEqual("jan soweli", set.ToString());
        }

        [Test]
        public void TestTwoWordsWihtProperModifierToString()
        {
            WordSet set = new WordSet(new String[] { "jan", "Mato" });
            Assert.AreEqual(2, set.Count);
            Assert.AreEqual("jan Mato", set.ToString());
        }

        [Test]
        public void TestTwoWordsWihtProperModifierToStringUsingAdd()
        {
            WordSet set = new WordSet();
            set.Add(new Word("jan"));
            set.Add(new Word("Mato"));
            Assert.AreEqual(2, set.Count);
            Assert.AreEqual("jan Mato", set.ToString());
        }

        [Test]
        public void TestTwoWordsWihtProperModifierToStringUsingDictionaryWord()
        {
            WordSet set = new WordSet();
            set.Add(Words.jan);
            set.Add(new Word("Mato"));
            Assert.AreEqual(2, set.Count);
            Assert.AreEqual("jan Mato", set.ToString());
        }
    }
}
