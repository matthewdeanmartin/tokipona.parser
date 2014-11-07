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
            Console.WriteLine(gm.Gloss(s, s,"en",true));
        }

        [Test]
        public void NounPhrase()
        {
            string s = "jan suli";
            GlossMaker gm = new GlossMaker();
            Console.WriteLine(gm.Gloss(s,s));
        }

        [Test]
        //[ExpectedException(typeof(Exception))] //A bad sentence can be all sorts of bad.
        public void IllegalNounPhrase()
        {
            try
            {
                GlossMaker gm = new GlossMaker();
                gm.ThrowOnSyntaxErrors = true;
                string s = "jan suli pi pi pi";
                Console.WriteLine(gm.Gloss(s,s));
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
            Console.WriteLine(gm.Gloss(s,s));
        }


        [Test]
        public void SimplePredicateConjunction()
        {
            GlossMaker gm = new GlossMaker();
            string s = "jan li suli li wawa";
            Console.WriteLine(gm.Gloss(s,s));
        }

        [Test]
        public void TransitiveVerb()
        {
            GlossMaker gm = new GlossMaker();
            string s = "jan li moku e kili";
            Console.WriteLine(gm.Gloss(s,s));
        }

        [Test]
        public void IntransitiveVerb()
        {
            GlossMaker gm = new GlossMaker();
            string s = "jan li moku, kepeken ilo moku";
            Console.WriteLine(gm.Gloss(s,s,"en",true));
            Console.WriteLine(gm.Gloss(s, s));
        }

    }
}
