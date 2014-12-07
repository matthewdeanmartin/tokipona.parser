﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.CollectionsDiscourse;
using NUnit.Framework;

namespace BasicTypes.ParseDiscourse
{
    [TestFixture]
    public class ParagraphSplitterTests
    {
        [Test]
        public void TestOneSentenceIsNotNull()
        {
            ParagraphSplitter ps = new ParagraphSplitter(Dialect.LooseyGoosey);
            Prose prose= ps.ParseProse("ni li pona kin.");
            Assert.NotNull(prose);
            Console.WriteLine(prose.ToString());
        }

        [Test]
        public void TestOneSentenceIsOnePara()
        {
            ParagraphSplitter ps = new ParagraphSplitter(Dialect.LooseyGoosey);
            Prose prose = ps.ParseProse("ni li pona kin.");
            Assert.NotNull(prose);
            Assert.AreEqual(1,prose.Paragraphs.Length);
            Console.WriteLine(prose.ToString());
        }

        [Test]
        public void TestTwoParagraphsSentenceEach()
        {
            ParagraphSplitter ps = new ParagraphSplitter(Dialect.LooseyGoosey);
            Prose prose = ps.ParseProse(@"ni li pona kin.

ni li pona kin.");
            Assert.NotNull(prose);
            Assert.AreEqual(2, prose.Paragraphs.Length);
            Console.WriteLine(prose.ToString());
        }

        [Test]
        public void TestTwoParagraphsManySentenceEach()
        {
            ParagraphSplitter ps = new ParagraphSplitter(Dialect.LooseyGoosey);
            Prose prose = ps.ParseProse(@"ni li pona kin. ale li pona. moku li pona.

ni li pona kin. soweli li pona. waso li tawa kon.");
            Assert.NotNull(prose);
            Assert.AreEqual(2, prose.Paragraphs.Length);
            Console.WriteLine(prose.ToString());
        }

        [Test]
        public void TestFourParagraphsManySentenceEachTripleSpaced()
        {
            ParagraphSplitter ps = new ParagraphSplitter(Dialect.LooseyGoosey);
            Prose prose = ps.ParseProse(@"ni li pona kin. ale li pona. moku li pona.


ni li pona kin. soweli li pona. waso li tawa kon.");
            Assert.NotNull(prose);
            Assert.AreEqual(2, prose.Paragraphs.Length);
            Console.WriteLine(prose.ToString());
        }
    }
}
