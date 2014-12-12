using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Glosser;
using BasicTypes.NormalizerCode;
using NUnit.Framework;

namespace BasicTypes.Lorem
{
    [TestFixture]
    public class TextGeneratorTest
    {

        //Discourse patterns.
        //Title (sentence or fragement)
        //Sentence 1-4, then paragraph break.
        //Author. (jan Sowanso)

        //Person one says, "...."
        //Person two says, "...."

        //Question, Answer.

        [Test]
        public void GenerateDiscourse()
        {
            Dialect d = Dialect.LooseyGoosey;
            d.IncludeApocrypha = false;
            TextGenerator tg = new TextGenerator(d);

            for (int i = 0; i < 1000; i++)
            {
                Sentence s = tg.GenerateSentence();
                Console.WriteLine(s.ToString());
                Console.WriteLine(s.ToString("b"));
            }
        }


        [Test]
        public void GenerateObjectAndStringify()
        {
            Dialect d = Dialect.LooseyGoosey;
            d.IncludeApocrypha = false;
            TextGenerator tg = new TextGenerator(d);
            for (int i = 0; i < 1000; i++)
            {
                Sentence s = tg.GenerateSentence();
                Console.WriteLine(s.ToString());
                Console.WriteLine(s.ToString("b"));
            }
        }

        [Test]
        public void GenerateObjectAndStringifyParse(Dialect dialect)
        {
            Dialect d = Dialect.LooseyGoosey;
            d.IncludeApocrypha = false;
            TextGenerator tg = new TextGenerator(d);
            List<Sentence> sentences = new List<Sentence>();
            for (int i = 0; i < 1000; i++)
            {
                sentences.Add(tg.GenerateSentence());
            }


            ParserUtils pu = new ParserUtils(Dialect.WordProcessorRules);
            foreach (Sentence sentence in sentences)
            {
                string s = sentence.ToString();
                Console.WriteLine(s);
                try
                {
                    Sentence reparsed = pu.ParsedSentenceFactory(s, s);

                    Console.WriteLine(reparsed.ToString());
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("This isn't possible in a pi chain"))
                    {
                        Console.WriteLine("Prep phrase in a subject :-(");
                        continue;
                    }
                    else
                        throw;
                }

            }
        }


        [Test]
        public void GenerateObjectAndStringifyParseGloss()
        {
            //Important! create teh dialect only once, mixing this is bad biz.
            Dialect dialect = Dialect.LooseyGoosey;
            dialect.IncludeApocrypha = false;

            List<Sentence> sentences = new List<Sentence>();
            
            TextGenerator tg = new TextGenerator(dialect);
            for (int i = 0; i < 1000; i++)
            {
                sentences.Add(tg.GenerateSentence());
            }

            ParserUtils pu = new ParserUtils(dialect);

            GlossMaker gm = new GlossMaker();

            foreach (Sentence sentence in sentences)
            {
                string s = sentence.ToString();

                //string sn = Normalizer.NormalizeText(s,dialect );
                Console.WriteLine(s);
                Console.WriteLine(sentence.ToString("b"));
                Console.WriteLine(gm.Gloss(s, s,dialect));

                Sentence reparsed = pu.ParsedSentenceFactory(s, s);

                string reparseString = reparsed.ToString();
                //string normalize = Normalizer.NormalizeText(reparseString, dialect);
                Console.WriteLine(reparseString);
                Console.WriteLine(gm.Gloss(reparseString, s, dialect));
            }
        }
    }
}
