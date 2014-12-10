using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.ParseDiscourse;
using NUnit.Framework;

namespace BasicTypes.NormalizerCode
{
    [TestFixture]
    public class NormalizeForeignTextTests
    {
        [Test]
        [Ignore]
        public void LeadingExplicitNeologism()
        {
            //Oh boy. This is a foreign exclamation that is phonotactically valid toki pona.
            //Decided to modal as neologism, not foreign word.
            string s = @"
+aleluja! +amen! mi tawa tomo sona mi Tamanawisi!
  
";
            Execute(s);
        }

        [Test]
        public void TwoPartForeignName()
        {
            string s = @"jan ali o, toki!

jan Gary Shannon li pali e toki sin tu pi kulupu jan e toki ""Madjal"" e
toki Kalusa.";
            Execute(s);
        }
        [Test]
        public void  Number()
        {
            string s = @"mi pilin e ni: toki pi jan Sonja lon #3610 li toki sama ni.";
            Execute(s);
        }
        [Test]
        public void Polanek()
        {
            string s = @"Ranek
la mi tawa Polanek,
li toki sama ni:
Pi, Pi, Pi, Kopytka li tawa e mi,
Pi, Pi, Pi, Kopytka li tawa e mi.";
            Execute(s);
        }

        private static void Execute(string s)
        {
            Dialect dialect = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(dialect);
            SentenceSplitter ss = new SentenceSplitter(dialect);

            foreach (string original in ss.ParseIntoNonNormalizedSentences(s))
            {
                Console.WriteLine("----");
                string normalized = Normalizer.NormalizeText(original, dialect);
                Console.WriteLine(normalized);
                Sentence structured = pu.ParsedSentenceFactory(normalized, original);
            }
        }
    }
}
