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
        public void NounPhrase()
        {
            GlossMaker gm = new GlossMaker();
            Console.WriteLine(gm.Gloss("jan suli"));
        }

        [Test]
        //[ExpectedException(typeof(Exception))] //A bad sentence can be all sorts of bad.
        public void IllegalNounPhrase()
        {
            try
            {
                GlossMaker gm = new GlossMaker();
                gm.ThrowOnSyntaxErrors = true;
                Console.WriteLine(gm.Gloss("jan suli pi pi pi"));
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
            Console.WriteLine(gm.Gloss("jan li suli"));
        }


        [Test]
        public void SimplePredicateConjunction()
        {
            GlossMaker gm = new GlossMaker();
            Console.WriteLine(gm.Gloss("jan li suli li wawa"));
        }

        [Test]
        public void TransitiveVerb()
        {
            GlossMaker gm = new GlossMaker();
            Console.WriteLine(gm.Gloss("jan li moku e kili"));
        }

        [Test]
        public void IntransitiveVerb()
        {
            GlossMaker gm = new GlossMaker();
            Console.WriteLine(gm.Gloss("jan li moku, kepeken ilo moku","en",true));
            Console.WriteLine(gm.Gloss("jan li moku, kepeken ilo moku"));
        }

        [Test]
        public void Normalize_IntransitiveVerb()
        {
            string value= Normalizer.NormalizeText("jan li moku, kepeken ilo moku");
            Console.WriteLine(value);
            Assert.IsTrue(value.Contains("~"),value);
        }
    }
}
