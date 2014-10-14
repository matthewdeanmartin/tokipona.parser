using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Parts
{
    [TestFixture]
    public class ConvertWordToBasicTypeTests
    {
        [Test]
        public void ConverToNumbers()
        {
            IConvertible c = new ConvertWordsToBasicTypes(Words.wan) as IConvertible;
            Assert.AreEqual(1,c.ToInt32(null));
            c = new ConvertWordsToBasicTypes(Words.tu) as IConvertible;
            Assert.AreEqual(2, c.ToInt32(null));
            c = new ConvertWordsToBasicTypes(Words.luka) as IConvertible;
            Assert.AreEqual(5, c.ToInt32(null));
        }

        [Test]
        public void ConverToBoolean()
        {
            IConvertible c = new ConvertWordsToBasicTypes(Words.wan) as IConvertible;
            Assert.AreEqual(true, c.ToBoolean(null));
            c = new ConvertWordsToBasicTypes(Words.ala) as IConvertible;
            Assert.AreEqual(false, c.ToBoolean(null));
            c = new ConvertWordsToBasicTypes(Words.lon) as IConvertible;
            Assert.AreEqual(true, c.ToBoolean(null));
        }
    }
}
