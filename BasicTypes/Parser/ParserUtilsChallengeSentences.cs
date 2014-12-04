using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.NormalizerCode;
using NUnit.Framework;

namespace BasicTypes.Parser
{
    //Sentence class tests. For testing specific sentences with specific expectations.
    [TestFixture]
    public class ParserUtilsChallengeSentences
    {

        [Test]
        public void ProcessVocative()
        {
            Dialect c = Dialect.LooseyGoosey;
            //c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            const string vocative = "jan sona pi ma pi kasi suli o!";
            Sentence s = pu.ParsedSentenceFactory(vocative, vocative);
            Console.WriteLine(s.ToString("b"));
        }

        //ilo lukin li waso tu e len pali e jaki sike:



        [Test]
        public void ProcessCalmVocative()
        {
            Dialect c = Dialect.LooseyGoosey;
            //c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            const string vocative = "jan Oliwa o, o, o.";
            Sentence s = pu.ParsedSentenceFactory(vocative, vocative);
            Console.WriteLine(s.ToString("b"));
        }

        [Test]
        public void DoubleObject()
        {
            const string s = "ilo lukin li waso tu e len pali e jaki sike.";
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);
            Sentence sentence = pu.ParsedSentenceFactory(s, s);
            Console.WriteLine(s);
            Console.WriteLine(sentence.ToString());
            Console.WriteLine(sentence.ToString("b"));
            Assert.IsNotNull(sentence.Subjects);
        }


        //o mi tu li kama tomo mi.
        [Test]
        public void OLetsHaveThisSentenceParse()
        {
            const string s = "o mi tu li kama tomo mi.";
            Dialect c = Dialect.LooseyGoosey;
            //c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);
            Sentence sentence = pu.ParsedSentenceFactory(s, s);
            Assert.IsNotNull(sentence.Subjects);
            //Assert.IsTrue(sentence.Subjects.Length > 0);

            //Assert.IsNotNull(sentence.Subjects[0].HeadedPhrases[0].Head.Text,"mi"); //pi chains :-(
        }

        [Test]
        public void LostPrep()
        {
            const string s = "o toki pona e mi tawa jan sewi Utu!";
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);
            Sentence sentence = pu.ParsedSentenceFactory(s, s);
            Assert.IsNotNull(sentence.Predicates[0].Prepositionals != null);
            Console.WriteLine(sentence.ToString("b"));
        }



        [Test]
        public void ParseJustO()
        {
            //o!
            const string s = "o!";
            ParserUtils pu = new ParserUtils(Dialect.LooseyGoosey);

            Sentence parsedSentence = pu.ParsedSentenceFactory(s, s);
            Console.WriteLine(parsedSentence.ToString());
        }

        //nena meli kin li tawa en tan li kama nena pi suli en kiwen.
        [Test]
        public void ParseThreePart()
        {
            const string s = "nena meli kin li tawa en tan li kama nena pi suli en kiwen.";
            ParserUtils pu = new ParserUtils(Dialect.LooseyGoosey);

            Sentence parsedSentence = pu.ParsedSentenceFactory(s, s);
            Console.WriteLine(parsedSentence.ToString());
            Assert.AreEqual(2, parsedSentence.Predicates.Count);
            Assert.IsNotNull(parsedSentence);
        }

    }
}
