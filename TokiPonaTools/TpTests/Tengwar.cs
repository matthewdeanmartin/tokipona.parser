using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TpLogic.Compress;

namespace TpTests
{
    [TestFixture]
    public class Tengwar
    {
        [Test]
        public void Captialize()
        {
            TengwarMaker maker = new TengwarMaker();
            
            string capitalized = maker.Captitalize("pilin",3);

            Assert.AreEqual("pilIn", capitalized);
        }

        [Test]
        public void CaptializeFinal()
        {
            TengwarMaker maker = new TengwarMaker();

            string capitalized = maker.Captitalize("pilin", 4);

            Assert.AreEqual("piliN", capitalized);
        }
        [Test]
        public void SingleSentence()
        {
            TengwarMaker maker = new TengwarMaker();
            maker.sb.Clear();
            maker.Convert("mi wile unpa e meli.");
            string result = maker.sb.ToString();
            Assert.AreEqual(".mI wilE quMpa qe mElI.", result);
        }

        [Test]
        public void SingleSentence2()
        {
            TengwarMaker maker = new TengwarMaker();
            maker.sb.Clear();
            maker.Convert("mi pilin pona.");
            string result = maker.sb.ToString();
            Assert.AreEqual(".mI pilIN ponA.", result);
        }

        [Test]
        public void SingleWord()
        {
            TengwarMaker maker = new TengwarMaker();
            maker.sb.Clear();
            maker.Convert("meli.");
            string result = maker.sb.ToString();
            Assert.AreEqual(".mElI.", result);
        }
    }
}
