using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BasicTypes.Parts
{
    [TestFixture]
    public class WordConverterTests
    {
        [Test]
        public void YesWeCanConvertFromString()
        {
            WordConverter w = new WordConverter();
            Assert.IsTrue(w.CanConvertFrom(typeof(string))); 
        }

        [Test]
        public void SampleConversionDoesntYeildNull()
        {
            WordConverter w = new WordConverter();
            string jan = "jan";
            Word janWord = w.ConvertFrom(jan) as Word;
            Assert.NotNull(janWord);
        }

        [Test]
        public void SampleConversionYeildsSameText()
        {
            WordConverter w = new WordConverter();
            string jan = "jan";
            Word janWord = w.ConvertFrom(jan) as Word;
            Assert.NotNull(janWord);
            Assert.AreEqual(janWord.Text, jan);
        }

        [Test]
        public void ToAndFromStringMatch()
        {
            WordConverter w = new WordConverter();
            string jan = "jan";
            Word janWord = w.ConvertFrom(jan) as Word;
            Assert.NotNull(janWord);
            Assert.AreEqual(jan,janWord.ToString());
        }
    }
}
