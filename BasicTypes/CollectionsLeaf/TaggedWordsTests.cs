using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using NUnit.Framework;

namespace BasicTypes.CollectionsLeaf
{
    [TestFixture]
    public class TaggedWords
    {
        [Test]
        public void SuliAla()
        {
            //Do the brain dead basic things work
            TaggedWord w = new TaggedWord(Words.suli, new WordList(new Word[] {Words.ala}));
            Assert.AreEqual("suli ala", w.ToString());
        }

        [Test]
        public void SuliAlaParse()
        {
            Dialect dialect = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(dialect);
            HeadedPhrase hp = pu.HeadedPhraseParser("suli ala");
            Assert.AreEqual("suli ala", hp.ToString());
        }

        [Test]
        public void SuliAlaKin()
        {
            //Do the brain dead basic things work
            TaggedWord w = new TaggedWord(Words.suli, new WordList(new Word[] {Words.ala, Words.kin}));
            Assert.AreEqual("suli ala kin", w.ToString());
        }


        [Test]
        public void SuliAlaKinParse()
        {
            string testPhrase = "suli ala";
            Dialect dialect = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(dialect);
            HeadedPhrase hp = pu.HeadedPhraseParser(testPhrase);
            Assert.AreEqual(testPhrase, hp.ToString());
        }

        [Test]
        public void MokuAlaMoku()
        {
            //Do the brain dead basic things work
            TaggedWord w = new TaggedWord(Words.moku, new WordList(new Word[] {Words.ala, Words.moku}));
            Assert.AreEqual("moku ala moku", w.ToString());
        }

        [Test]
        public void MokuAlaMokuParse()
        {
            string testPhrase = "moku ala moku";
            Dialect dialect = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(dialect);
            HeadedPhrase hp = pu.HeadedPhraseParser(testPhrase);
            Assert.AreEqual(testPhrase, hp.ToString());
        }


        [Test]
        public void PonaKin()
        {
            //Do the brain dead basic things work
            TaggedWord w = new TaggedWord(Words.pona, new WordList(new Word[] {Words.kin}));
            Assert.AreEqual("pona kin", w.ToString());
        }

        [Test]
        public void PonaKinParse()
        {
            string testPhrase = "pona kin";
            Dialect dialect = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(dialect);
            HeadedPhrase hp = pu.HeadedPhraseParser(testPhrase);
            Assert.AreEqual(testPhrase, hp.ToString());
        }

        [Test]
        public void KiwenKiwen()
        {
            //Do the brain dead basic things work
            TaggedWord w = new TaggedWord(Words.kiwen, new WordList(new Word[] {Words.kiwen}));
            Assert.AreEqual("kiwen kiwen", w.ToString());
        }

        [Test]
        public void KiwenKiwenParse()
        {
            string testPhrase = "kiwen kiwen";
            Dialect dialect = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(dialect);
            HeadedPhrase hp = pu.HeadedPhraseParser(testPhrase);
            Assert.AreEqual(testPhrase, hp.ToString());
        }

        [Test]
        public void KiwenKiwenKiwen()
        {
            //Do the brain dead basic things work
            TaggedWord w = new TaggedWord(Words.kiwen, new WordList(new Word[] {Words.kiwen, Words.kiwen}));
            Assert.AreEqual("kiwen kiwen kiwen", w.ToString());
        }

        [Test]
        public void KiwenKiwenKiwenParse()
        {
            string testPhrase = "kiwen kiwen kiwen";
            Dialect dialect = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(dialect);
            HeadedPhrase hp = pu.HeadedPhraseParser(testPhrase);
            Assert.AreEqual(testPhrase, hp.ToString());
        }


    }
}
