using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes
{
    [TestFixture]
    public class WordEqualityTests
    {
        [Test]
        public void Tests()
        {
            Word w = Words.jan;
            Word ws = new Word("jan");
            Assert.IsTrue(WordByValue.Instance.Equals(w,ws));
        }
    }
}
