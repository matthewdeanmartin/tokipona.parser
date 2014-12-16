using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TpLogic;
using TpLogic.Compress;


namespace TpTests
{
    [TestFixture]
    public class CompressDecompress
    {
        [Test]
        public void TestRecodeOneWordRoundTrip()
        {
            Recode recoder = new Recode();
            string data = "soweli";
            string shorter = recoder.Shorten(data);
            Assert.AreEqual("ow", shorter);
            string longer = recoder.ExpandTwoLetterWithSpaces(shorter);
            Assert.AreEqual(data,longer);
        }


        [Test]
        public void TestRecodeTwoWordRoundTrip()
        {
            Recode recoder = new Recode();
            string data = "soweli moku";
            string shorter = recoder.Shorten(data);
            Assert.AreEqual("ow mk", shorter,"Shorten failed");
            string longer = recoder.ExpandTwoLetterWithSpaces(shorter);
            Assert.AreEqual(data, longer, "Expand failed");
        }

        [Test]
        public void TestRecodeThreeWordRoundTrip()
        {
            Recode recoder = new Recode();
            string data = "soweli moku moku";
            string shorter = recoder.Shorten(data);
            Assert.AreEqual("ow mk mk", shorter, "Shorten failed");
            string longer = recoder.ExpandTwoLetterWithSpaces(shorter);
            Assert.AreEqual(data, longer, "Expand failed");
        }

        [Test]
        public void TestRecodeTwoWordRoundTripPunctuate()
        {
            Recode recoder = new Recode();
            string data = "soweli moku.";
            string shorter = recoder.Shorten(data);
            Assert.AreEqual("ow mk.", shorter);
            string longer = recoder.ExpandTwoLetterWithSpaces(shorter);
            Assert.AreEqual(data, longer);
        }

        [Test]
        public void TestRecodeTwoWordRoundTripProperModifer()
        {
            Recode recoder = new Recode();
            string data = "jan Mato";
            string shorter = recoder.Shorten(data);
            Assert.AreEqual("jn MATO", shorter);
            string longer = recoder.ExpandTwoLetterWithSpaces(shorter);
            Assert.AreEqual(data, longer);
        }

        //tan ni: mije  == ta ni: mj

        [Test]
        public void TestRecodeThreeWordRoundTripWithColon()
        {
            Recode recoder = new Recode();
            string data = "ni: mije";
            string shorter = recoder.Shorten(data);
            Assert.AreEqual("ni: mj", shorter);
            string longer = recoder.ExpandTwoLetterWithSpaces(shorter);
            Assert.AreEqual(data, longer);
        }
    }
}
