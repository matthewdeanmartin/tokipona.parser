using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Exceptions;
using BasicTypes.Parser;
using NUnit.Framework;

namespace BasicTypes.Glosser
{
    //Can't delegate glossing to parts because you need to know position to gloss!
    [TestFixture]
    public class GlossMakerTests
    {
        [Test]
        public void LostDirects()
        {
            string regular = "sona olin li alasa e mu jan e ijo sin e poka esun e ali meli, lon meli suli, tawa ala mi?";
            string s = NormalizerCode.Normalizer.NormalizeText(regular, Dialect.LooseyGoosey);
            Console.WriteLine(Sentence.Parse(s, Dialect.LooseyGoosey).ToString());

            GlossMaker gm = new GlossMaker();
            Console.WriteLine(gm.Gloss(s, s));
        }

        [Test]
        public void GlossPlural()
        {
            string s = "mi mute li wile e moku mute e soweli mute e waso mute e kala mute e mani mute.";
            GlossMaker gm = new GlossMaker();
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s, "en", true));
        }

        [Test]
        public void MissingFragment()
        {
            string s = "tan ni la kala akesi li kama, tawa selo pi telo-suli.";
            GlossMaker gm = new GlossMaker();
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s, "en", true));
        }

        [Test]
        public void TheBiggerTheTheBiggerThe()
        {
            string s = "nena meli li suli la monsi li suli kin.";
            GlossMaker gm = new GlossMaker();
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s));
            Console.WriteLine(gm.Gloss(s, s, "en", true));
        }

        [Test]
        public void NounPhrase()
        {
            string s = "jan suli";
            GlossMaker gm = new GlossMaker();
            Console.WriteLine(gm.Gloss(s, s));
        }

        [Test]
        //[ExpectedException(typeof(Exception))] //A bad sentence can be all sorts of bad.
        public void IllegalNounPhrase()
        {
            try
            {
                GlossMaker gm = new GlossMaker();
                Dialect config = BasicTypes.Dialect.LooseyGoosey;
                config.TargetGloss = "en";
                config.GlossWithFallBacks = true;
                ParserUtils pu = new ParserUtils(config);

                string s = "jan suli pi pi pi";
                Sentence sentenceTree = pu.ParsedSentenceFactory(s, s);
                Console.WriteLine(gm.GlossOneSentence(false, sentenceTree, config));
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
                return;
            }
            catch (TpSyntaxException)
            {
                Assert.Pass();
                return;
            }
            Assert.Fail("Expected some sort of exception, didn't get it. Maybe this is throwing a different exception now?");
        }

        [Test]
        public void SimplePredicate()
        {
            GlossMaker gm = new GlossMaker();
            string s = "jan li suli";
            Console.WriteLine(gm.Gloss(s, s));
        }


        [Test]
        public void SimplePredicateConjunction()
        {
            GlossMaker gm = new GlossMaker();
            string s = "jan li suli li wawa";
            Console.WriteLine(gm.Gloss(s, s));
        }

        [Test]
        public void TransitiveVerb()
        {
            GlossMaker gm = new GlossMaker();
            string s = "jan li moku e kili";
            Console.WriteLine(gm.Gloss(s, s));
        }

        [Test]
        public void IntransitiveVerb()
        {
            GlossMaker gm = new GlossMaker();
            string s = "jan li moku, kepeken ilo moku";
            Console.WriteLine(gm.Gloss(s, s, "en", true));
            Console.WriteLine(gm.Gloss(s, s));
        }

    }
}
