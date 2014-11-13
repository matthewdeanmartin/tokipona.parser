using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Transliterate
{
    [TestFixture]
    public class TransliterateSupport
    {
        [Test]
        public void TestSingleLetter()
        {
            Assert.IsTrue(TransliterateEngine.DifferByOnlyOneLetter("a", "b"));
        }

        [Test]
        public void TestSingleLetterSame()
        {
            Assert.IsTrue(TransliterateEngine.DifferByOnlyOneLetter("a", "a"));
        }

        [Test]
        public void TestMayLetterSame()
        {
            Assert.IsTrue(TransliterateEngine.DifferByOnlyOneLetter("aadsfasdf", "aadsfasdf"));
        }

        [Test]
        public void TestMayLetterDifferent()
        {
            Assert.IsTrue(TransliterateEngine.DifferByOnlyOneLetter("aadsfasdf", "aadsfastf"));
        }

        [Test]
        public void RemoveDoubleConsonants()
        {
            Assert.AreEqual("nanpa", TransliterateEngine.RemoveDoubleConstants("nanpa"));
        }

        [Test]
        public void RemoveDoubleConsonantsTs()
        {
            Assert.AreEqual("mata", TransliterateEngine.RemoveDoubleConstants("matta"));
        }

        [Test]
        public void LeaveConsonantClustersWithNp()
        {
            Assert.AreEqual("nanpa", TransliterateEngine.DropConsonantClusters("nanpa"));
        }

        [Test]
        public void LeaveConsonantClustersWithNb()
        {
            Assert.AreEqual("nanba", TransliterateEngine.DropConsonantClusters("nanba"));
        }

        [Test]
        public void LeaveConsonantClustersWithNk()
        {
            Assert.AreEqual("nanka", TransliterateEngine.DropConsonantClusters("nanka"));
        }
        //DropConsonantClusters
    }
}
