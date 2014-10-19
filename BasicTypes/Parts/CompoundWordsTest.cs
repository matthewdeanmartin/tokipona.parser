using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Parts
{
    [TestFixture]
    public class CompoundWordsTest
    {
        [Test]
        public void ConstructCompoundWord()
        {
            CompoundWord w = new CompoundWord("tomo-tawa-kon");
            Assert.AreEqual(3,w.Parts.Length);
        }
    }
}
