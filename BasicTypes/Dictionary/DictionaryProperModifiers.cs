using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Mappers;
using BasicTypes.Corpus;
using BasicTypes.Extensions;
using BasicTypes.ParseDiscourse;
using BasicTypes.Parser;
using BasicTypes.NormalizerCode;
using BasicTypes.Parts;
using NUnit.Framework;

namespace BasicTypes.Dictionary
{
    //Dictionary that exploits the head word as a clue to what it is, e.g. toki, jan, ma, kulupu, ilo, etc.
    public class DictionaryProperModifiers
    {
        Dictionary<string, ProperModifier> d = new Dictionary<string, ProperModifier>();

    }

    [TestFixture]
    public class DictionaryPropertModifiersList
    {
        [Test]
        public void FindProperModifiers()
        {
            int i = 0;
            Dialect dialect = Dialect.LooseyGoosey;
            dialect.InferCompoundsPrepositionsForeignText = false;
            ParserUtils pu = new ParserUtils(dialect);

            CorpusFileReader reader = new CorpusFileReader();
            Dictionary<string, int> words = new Dictionary<string, int>(500);
            
            SentenceSplitter ss = new SentenceSplitter(dialect);
            
            foreach (string s in reader.NextFile())
            {
                string[] sentences = ss.ParseIntoNonNormalizedSentences(s);
                foreach (string original in sentences)
                {
                    Sentence structured = null;
                    string normalized;
                    try
                    {
                        normalized = Normalizer.NormalizeText(original, dialect);
                        structured = pu.ParsedSentenceFactory(normalized, original);
                        //string diag = structured.ToString("b");


                        string stringified = structured.Subjects.ToString();
                        if (!stringified.Contains(" ")) continue;//single word
                        if (stringified.Contains(@"""")) continue;//foreign
                        if (stringified.StartsWith(@"nanpa")) continue;//implicit number
                        if (stringified.StartsWith(@"#")) continue;//explicit number by punctuation
                        if (stringified.ContainsLetter(Token.AlphabetUpper))
                        {
                            if (words.ContainsKey(stringified))
                            {
                                words[stringified] = words[stringified] + 1;
                            }
                            else
                            {
                                words.Add(stringified, 1);
                                Console.WriteLine(i + " : " + stringified);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("ORIGINAL  : " + original);
                        //if (structured != null)
                        //{
                        //    Console.WriteLine(structured.ToString("b"));
                        //}
                        //Console.WriteLine(ex.Message);
                        i++;
                    }

                }
            }
            foreach (KeyValuePair<string, int> pair in words.OrderBy(x => x.Value))
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }


        [Test]
        public void FindProperModifiersInCompoundDictionary()
        {
            int i = 0;
            Dialect dialect = Dialect.LooseyGoosey;
            dialect.InferCompoundsPrepositionsForeignText = false;
            ParserUtils pu = new ParserUtils(dialect);
            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (var item in CompoundWords.Dictionary)
            {

                string stringified = item.Key;
                if (stringified.ContainsLetter(Token.AlphabetUpper))
                {
                    if (words.ContainsKey(stringified))
                    {
                        words[stringified] = words[stringified] + 1;
                    }
                    else
                    {
                        words.Add(stringified, 1);
                        Console.WriteLine(i + " : " + stringified);
                    }
                }
            }
            foreach (KeyValuePair<string, int> pair in words.OrderBy(x => x.Value))
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }
    }
}
