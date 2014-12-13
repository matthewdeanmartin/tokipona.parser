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

        //This, is wrong. sina lili suwi is a very unusal compound pronoun, or it is a stand alone sentence.
        //sina lili suwi, o tawa poka mi!
        //[Test]
        //public void ProcessHeadVocativeAndImperative()
        //{
        //    Dialect c = Dialect.LooseyGoosey;
        //    ParserUtils pu = new ParserUtils(c);
        //
        //    const string vocative = "sina lili suwi, o tawa poka mi!";
        //    string normalized= Normalizer.NormalizeText(vocative, c);
        //    Sentence s = pu.ParsedSentenceFactory(normalized, vocative);
        //    Console.WriteLine(s.ToString());
        //    Console.WriteLine(s.ToString("b"));
        //}

        [Test]
        [Ignore]
        private void Bad_MiLi()
        {
            //This is really hard.

            //mi li anpa li pakala kin.
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);

            const string test = "mi li anpa li pakala kin.";
            try
            {
                Sentence s = pu.ParsedSentenceFactory(test, test);
                Console.WriteLine(s.ToString("b"));
                Assert.Fail("mi li should throw");
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }

        //tenpo ni la jan o!
        [Test]
        [Ignore]
        public void LostVocativeAfterLa()
        {
            //Possibley not worth addressing. In the corpus this happened because of an unmarked final exclamation.
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);

            const string expected = "tenpo ni la jan o!";

            Sentence s = pu.ParsedSentenceFactory(expected, expected);
            string result = s.ToString();
            Console.WriteLine();
            Assert.AreEqual(expected,result);
        }

        [Test]
        public void LiPi()
        {
            //Possibley not worth addressing. In the corpus this happened because of an unmarked final exclamation.
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);

            const string expected = "jan li pi ma Tosi.";

            Sentence s = pu.ParsedSentenceFactory(expected, expected);
            string result = s.ToString();
            Console.WriteLine();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void MissingVocativeHeadNoun()
        {
            //Possibley not worth addressing. In the corpus this happened because of an unmarked final exclamation.
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);

            const string expected = "soweli Ja o toki!";

            Sentence s = pu.ParsedSentenceFactory(expected, expected);
            string result = s.ToString();
            Console.WriteLine();
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void MissingVocativeHeadNoun_mi()
        {
            //Possibley not worth addressing. In the corpus this happened because of an unmarked final exclamation.
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);

            const string expected = "mi jan Pona.";
            Normalizer norm = new Normalizer(c);
            string normalized= norm.NormalizeText(expected);
            Console.WriteLine(normalized);
            Sentence s = pu.ParsedSentenceFactory(normalized, expected);
            string result = s.ToString();
            Console.WriteLine();
            Assert.AreEqual(expected, result);
        }
        
        //

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

        //mama mi o, sina lon sewi kon
        [Test]
        public void HeadVocativeWithSina_WithoutNormalizing()
        {
            //
            const string s = "mama mi o sina, lon sewi kon.";
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);
            Sentence sentence = pu.ParsedSentenceFactory(s, s);
            Console.WriteLine(s);
            Console.WriteLine(sentence.ToString());
            Console.WriteLine(sentence.ToString("b"));
            Assert.IsNotNull(sentence.HeadVocatives);
            Assert.IsTrue(sentence.HeadVocatives.Length == 1);
        }

        // ona mute o pana e mije lili tawa ma kasi suli li pakala e ona.

        [Test]
        public void MixedImperativeAndNonImperativeDoubleO()
        {

            //normalizing a mid sentence sina (li) is a pain.
            const string s = "ona mute o o pana e mije lili tawa ma kasi suli li pakala e ona.";
            Dialect dialect = Dialect.LooseyGoosey;
            Normalizer norm = new Normalizer(dialect);
            ParserUtils pu = new ParserUtils(dialect);
            string normalized = norm.NormalizeText(s);
            Sentence sentence = pu.ParsedSentenceFactory(normalized, s);
            Console.WriteLine(s);
            Console.WriteLine(sentence.ToString());
            Console.WriteLine(sentence.ToString("b"));
            Assert.IsNotNull(sentence.HeadVocatives);
            Assert.IsTrue(sentence.HeadVocatives.Length == 1);
        }

        [Test]
        public void HeadVocativeWithJan_WithNormalizing()
        {
            //normalizing a mid sentence sina (li) is a pain.
            const string s = "mama mi o, jan li lon sewi kon.";
            Dialect dialect = Dialect.LooseyGoosey;
            Normalizer norm = new Normalizer(dialect);
            ParserUtils pu = new ParserUtils(dialect);
            string normalized = norm.NormalizeText(s);
            Assert.IsTrue(!normalized.Contains(","));
            Sentence sentence = pu.ParsedSentenceFactory(normalized, s);
            Console.WriteLine(s);
            Console.WriteLine(sentence.ToString());
            Console.WriteLine(sentence.ToString("b"));
            Assert.IsNotNull(sentence.HeadVocatives);
            Assert.IsTrue(sentence.HeadVocatives.Length == 1);
        }

        [Test]
        public void HeadVocative()
        {
            const string s = "jan Enkitu o, toki sina li  toki ike li toki utala.";
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);
            Sentence sentence = pu.ParsedSentenceFactory(s, s);
            Console.WriteLine(s);
            Console.WriteLine(sentence.ToString());
            Console.WriteLine(sentence.ToString("b"));
            Assert.IsNotNull(sentence.HeadVocatives);
            Assert.IsTrue(sentence.HeadVocatives.Length == 1);
        }
        //
        [Test]
        public void PosessiveMiInSubject()
        {
            //const string s = "kili lon ma mi li pona tawa mi.";
            const string s = "kili, lon ma mi li pona, tawa mi.";

            Dialect dialect = Dialect.LooseyGoosey;
            Normalizer norm = new Normalizer(dialect);

            string normalized = norm.NormalizeText(s);
            Console.WriteLine(normalized);

            ParserUtils pu = new ParserUtils(dialect);

            Sentence sentence = pu.ParsedSentenceFactory(normalized, s);
            Console.WriteLine(s);
            Console.WriteLine(sentence.ToString());
            Console.WriteLine(sentence.ToString("b"));
            Assert.IsNotNull(sentence.Subjects);
            Assert.AreEqual(s, sentence.ToString());
        }

        //.
        [Test]
        public void BackwardsPiAndEn()
        {
            const string s = "ijo pi meli en mije li sama nimi pi jan Sonja.";
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);
            Sentence sentence = pu.ParsedSentenceFactory(s, s);
            Console.WriteLine(s);
            Console.WriteLine(sentence.ToString());
            Console.WriteLine(sentence.ToString("b"));
            Assert.IsNotNull(sentence.Subjects);
            Assert.AreEqual(sentence.ToString(), s);
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
