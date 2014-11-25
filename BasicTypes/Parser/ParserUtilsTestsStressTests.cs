using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BasicTypes.Collections;
using BasicTypes.Corpus;
using BasicTypes.Extensions;
using BasicTypes.Glosser;
using BasicTypes.Knowledge;
using BasicTypes.NormalizerCode;
using NUnit.Framework;

namespace BasicTypes.Parser
{
    /// <summary>
    /// Tests that parse something higher level than a string array.
    /// </summary>
    [TestFixture]
    public class ParserUtilsTestsStressTests
    {
        [Test]
        public void SpellCheck()
        {
            string text = CorpusTexts.JanSin;
            TokenParserUtils pu = new TokenParserUtils();
            string[] words = pu.JustTpWordsNumbersPunctuation(text);
            foreach (string word in words)
            {
                try
                {
                    Word w = new Word(word);
                }
                catch (Exception)
                {
                    Console.WriteLine("Uh-oh: " + word);
                }
            }

        }






        [Test]
        public void SpellCheck_ForStressTest_UsingOnlyWordConstructor()
        {
            CorpusFileReader reader = new CorpusFileReader();
            Dictionary<string, string> bad = new Dictionary<string, string>();
            List<string> good = new List<string>();
            TokenParserUtils tpu = new TokenParserUtils();
            Dialect dialect = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(dialect);

            foreach (string s in reader.NextFile())
            {
                string[] rawSentences = pu.ParseIntoNonNormalizedSentences(s);
                foreach (string sentence in rawSentences)
                {
                    string normalized = Normalizer.NormalizeText(sentence, dialect);
                    //Normalization improved stuff
                    string[] words = tpu.JustTokens(normalized);
                    for (int index = 0; index < words.Length; index++)
                    {
                        //Don't remove double quotes or we can't ID some marked foreign text.
                        //'"'
                        words[index] = words[index].Trim(new[] { ':', '.', '\'', '«', '»', '!', '?', '-', '[', ']' });
                    }
                    foreach (string word in words.Where(x => !string.IsNullOrEmpty(x)))
                    {
                        if (good.Contains(word)) continue;

                        try
                        {
                            Word w = new Word(word);
                        }
                        catch (Exception ex)
                        {
                            if (bad.ContainsKey(word))
                            {
                                bad[word] = (Convert.ToInt32(bad[word]) + 1).ToString();
                                //bad.Add(word, ex.Message);
                            }
                            else
                            {
                                bad.Add(word, "1");
                            }
                        }
                    }
                }
            }
            foreach (KeyValuePair<string, string> pair in bad)
            {
                if (Convert.ToInt32(pair.Value) > 10)
                {
                    Console.WriteLine("Uh-oh: " + pair.Key + " " + pair.Value);
                }
            }

        }

        [Test]
        public void StressTestParseThingsWithNumbers()
        {
            int i = 0;
            Dialect dialect = Dialect.DialectFactory;
            dialect.InferCompoundsPrepositionsForeignText = false;
            ParserUtils pu = new ParserUtils(dialect);

            CorpusFileReader reader = new CorpusFileReader();
            foreach (string s in reader.NextFile())
            {
                foreach (string original in pu.ParseIntoNonNormalizedSentences(s))
                {
                    try
                    {
                        string normalized = Normalizer.NormalizeText(original, dialect);
                        string result = NormalizeNumbers.FindNumbers(normalized);
                        if (result.ContainsCheck("#"))
                        {
                            Console.WriteLine("O: " + original);
                            Console.WriteLine("N: " + normalized);
                            Console.WriteLine("#: " + result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ORIGINAL  : " + original);
                        Console.WriteLine(ex.Message);
                        i++;
                    }

                }
            }
            Console.WriteLine("Failed Sentences: " + i);
        }

        [Test]
        public void StressTestNormalizeNotIndeedAlaKin()
        {
            int i = 0;
            Dialect dialect = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(dialect);

            Dialect english = Dialect.DialectFactory;
            english.ThrowOnSyntaxError = false;
            english.TargetGloss = "en";
            english.GlossWithFallBacks = true;

            CorpusFileReader reader = new CorpusFileReader();
            GlossMaker gm = new GlossMaker();

            foreach (string s in reader.NextFile())
            {
                foreach (string original in pu.ParseIntoNonNormalizedSentences(s))
                {
                    Sentence structured = null;
                    //try
                    //{
                    string normalized = Normalizer.NormalizeText(original, dialect);
                    if (string.IsNullOrWhiteSpace(normalized) && !string.IsNullOrWhiteSpace(original)
                        && !new String[] { ".", ":", "?", "!", "'.", "'!", "\".", "''.", ").", "\"«" }.Contains(original.Trim()))
                    //BUG:happens when we have ni li ni?:  or ni li ni...
                    //BUG:Any maybe 'ni li ni?' or 'ni li ni'? are failing due to quotes
                    {
                        throw new InvalidOperationException("Normalizer turned this into null or white space : " + original);
                    }
                    if (original == "\".") continue;//BUG:
                    if (string.IsNullOrWhiteSpace(normalized)) continue;
                    if (!(normalized.ContainsWholeWord("ala") || normalized.ContainsWholeWord("kin"))) continue;

                    if (normalized.StartCheck("kin la ")) continue; //no big deal

                    structured = pu.ParsedSentenceFactory(normalized, original);
                    string diag = structured.ToString("b");

                    //if ((normalized.ContainsCheck("%ante"))) continue; //verb!

                    Console.WriteLine("O: " + (original ?? "").Trim(new[] { '\n', '\r', ' ', '\t' }));
                    Console.WriteLine("B: " + diag);
                    Console.WriteLine("G: " + gm.GlossOneSentence(false, structured, english));
                    //}
                    //catch (Exception ex)
                    //{
                    //    if (ex.Message.ContainsCheck("all tests"))
                    //    {
                    //        Console.WriteLine("ORIGINAL  : " + original);
                    //        if (structured != null)
                    //        {
                    //            Console.WriteLine(structured.ToString("b"));
                    //        }
                    //        Console.WriteLine(ex.Message);
                    //        i++;
                    //    }
                    //    else throw;
                    //}

                }
            }
            Console.WriteLine("Failed Sentences: " + i);
        }

        [Test]
        public void StressTestNormalizeAndParseLogicalOperators()
        {
            int i = 0;
            Dialect dialect = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(dialect);

            Dialect english = Dialect.DialectFactory;
            english.ThrowOnSyntaxError = false;
            english.TargetGloss = "en";
            english.GlossWithFallBacks = true;

            CorpusFileReader reader = new CorpusFileReader();
            GlossMaker gm = new GlossMaker();

            foreach (string s in reader.NextFile())
            {
                foreach (string original in pu.ParseIntoNonNormalizedSentences(s))
                {
                    Sentence structured = null;
                    //try
                    //{
                    string normalized = Normalizer.NormalizeText(original, dialect);
                    if (string.IsNullOrWhiteSpace(normalized) && !string.IsNullOrWhiteSpace(original)
                        && !new String[] { ".", ":", "?", "!", "'.", "'!", "\".", "''.", ").", "\"«" }.Contains(original.Trim()))
                    //BUG:happens when we have ni li ni?:  or ni li ni...
                    //BUG:Any maybe 'ni li ni?' or 'ni li ni'? are failing due to quotes
                    {
                        throw new InvalidOperationException("Normalizer turned this into null or white space : " + original);
                    }
                    if (original == "\".") continue;//BUG:
                    if (string.IsNullOrWhiteSpace(normalized)) continue;
                    if (!(normalized.ContainsWholeWord("anu") || normalized.ContainsWholeWord("taso")
                        || normalized.ContainsWholeWord("en") || normalized.ContainsWholeWord("xxxante"))) continue;

                    if (normalized.StartCheck("anu ")) continue; //tag conjunctions no big deal
                    if (normalized.StartCheck("taso ")) continue; //tag conjunctions no big deal

                    structured = pu.ParsedSentenceFactory(normalized, original);
                    string diag = structured.ToString("b");

                    //if ((normalized.ContainsCheck("%ante"))) continue; //verb!

                    Console.WriteLine("O: " + (original ?? "").Trim(new[] { '\n', '\r', ' ', '\t' }));
                    Console.WriteLine("B: " + diag);
                    Console.WriteLine("G: " + gm.GlossOneSentence(false, structured, english));
                    //}
                    //catch (Exception ex)
                    //{
                    //    if (ex.Message.ContainsCheck("all tests"))
                    //    {
                    //        Console.WriteLine("ORIGINAL  : " + original);
                    //        if (structured != null)
                    //        {
                    //            Console.WriteLine(structured.ToString("b"));
                    //        }
                    //        Console.WriteLine(ex.Message);
                    //        i++;
                    //    }
                    //    else throw;
                    //}

                }
            }
            Console.WriteLine("Failed Sentences: " + i);
        }

        [Test]
        public void StressTestNormalizeAndParseEverything()
        {
            int i = 0;
            Dialect dialect = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(dialect);

            Dialect english = Dialect.DialectFactory;
            english.ThrowOnSyntaxError = false;
            english.TargetGloss = "en";
            english.GlossWithFallBacks = true;

            CorpusFileReader reader = new CorpusFileReader();
            GlossMaker gm = new GlossMaker();

            foreach (string s in reader.NextFile())
            {
                foreach (string original in pu.ParseIntoNonNormalizedSentences(s))
                {
                    Sentence structured = null;
                    try
                    {
                        string normalized = Normalizer.NormalizeText(original, dialect);
                        if (string.IsNullOrWhiteSpace(normalized) && !string.IsNullOrWhiteSpace(original)
                            && !new String[] { ".", ":", "?", "!", "'.", "'!", "\".", "''.", ").", "\"«" }.Contains(original.Trim()))
                        //BUG:happens when we have ni li ni?:  or ni li ni...
                        //BUG:Any maybe 'ni li ni?' or 'ni li ni'? are failing due to quotes
                        {
                            throw new InvalidOperationException("Normalizer turned this into null or white space : " + original);
                        }
                        if (original == "\".") continue;//BUG:
                        if (string.IsNullOrWhiteSpace(normalized)) continue;

                        structured = pu.ParsedSentenceFactory(normalized, original);
                        string diag = structured.ToString("b");

                        //if ((normalized.ContainsCheck("%ante"))) continue; //verb!

                        Console.WriteLine("O: " + (original??"").Trim(new []{'\n','\r',' ','\t'}));
                        Console.WriteLine("B: " + diag);
                        Console.WriteLine("G: " + gm.GlossOneSentence(false, structured, english));
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.ContainsCheck("all tests"))
                        {
                            Console.WriteLine("ORIGINAL  : " + original);
                            if (structured != null)
                            {
                                Console.WriteLine(structured.ToString("b"));
                            }
                            Console.WriteLine(ex.Message);
                            i++;
                        }
                        Console.WriteLine(ex.Message);
                        //else throw;
                    }

                }
            }
            Console.WriteLine("Failed Sentences: " + i);
        }

        [Test]
        public void IdentifyDiscourses_CanItEvenParseTheSentences()
        {
            string sample = CorpusTexts.UnpaText;
            Dialect c = Dialect.DialectFactory;
            c.TargetGloss = "en";
            CorpusKnowledge ck = new CorpusKnowledge(sample, c);

            Discourse[] s = ck.MakeSentences();
            for (int i = 0; i < s.Length; i++)
            {
                foreach (Sentence sentence in s[i])
                {
                    string reToStringed = sentence == null ? "[NULL SENTENCE]" : sentence.ToString();
                    bool match = ck.Setences.Any(x => x.Trim() == reToStringed);
                    if (!match)
                    {
                        Console.WriteLine(match + " O:" + ck.Setences[i]);
                        Console.WriteLine(match + " R:" + (sentence == null ? "[NULL SENTENCE]" : sentence.ToString("b")));

                    }
                }
            }
        }

        [Test]
        public void WhyDidNormalizerStripOffTheDoubleQuotes()
        {
            //,CorpusTexts.JanSin  //Too many neologisms to cope. 
            string[] samples =
            {
                CorpusTexts.GeorgeSong
            };
            Dialect dialect = Dialect.DialectFactory;
            dialect.TargetGloss = "en";

            ParserUtils pu = new ParserUtils(dialect);
            foreach (string sample in samples)
            {
                string[] sentences = pu.ParseIntoNonNormalizedSentences(sample);
                foreach (string sentence in sentences)
                {
                    if (sentence.ContainsCheck("Georgia"))
                    {
                        string result = Normalizer.NormalizeText(sentence, dialect);
                        Assert.IsTrue(result.ContainsCheck("\"Georgia\""));
                    }
                }


            }

        }

        [Test]
        public void IdentifyDiscourses_CanItEvenParseTheSentences_ShowGoodOnes()
        {
            //,CorpusTexts.JanSin  //Too many neologisms to cope. 
            string[] samples =
            {
                //CorpusTexts.UnpaText,
                //CorpusTexts.Gilgamesh,
                //CorpusTexts.SampleText1,
                //CorpusTexts.SampleText3,
                //CorpusTexts.Lao,
                CorpusTexts.GeorgeSong,
                //    CorpusTexts.CrazyAnimal,
                //    CorpusTexts.CrazyAnimal2
                //    ,CorpusTexts.RuneDanceSong
                //    ,CorpusTexts.janPusaRice
                //    ,CorpusTexts.janPend
            };
            Dialect dialect = Dialect.DialectFactory;
            dialect.TargetGloss = "en";

            GlossMaker gm = new GlossMaker();
            foreach (string sample in samples)
            {
                CorpusKnowledge ck = new CorpusKnowledge(sample, dialect);
                Discourse[] s = ck.MakeSentences();
                for (int i = 0; i < s.Length; i++)
                {
                    foreach (Sentence sentence in s[i])
                    {
                        string reToStringed = sentence == null ? "[NULL]" : sentence.ToString();
                        bool match = ck.Setences.Any(x => x.Trim() == reToStringed);
                        //if (match)
                        //{
                        Console.WriteLine(match + " O:" + ck.Setences[i]);
                        Console.WriteLine(match + " Rg:" + (sentence == null ? "[NULL]" : sentence.ToString("g")));
                        Console.WriteLine(match + " Rb:" + (sentence == null ? "[NULL]" : sentence.ToString("b")));

                        //TODO: Need to store original somewhere...
                        Console.WriteLine(match + " Ren:" + (sentence == null ? "[NULL]" : gm.Gloss(sentence.ToString("g"), "n/a")));
                        //}
                    }
                }
            }

        }

        


        [Test]
        public void IdentifyDiscourses_CanWeGroupThem()
        {
            Dialect c = Dialect.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            Sentence[] s = pu
                            .ParseIntoNonNormalizedSentences(CorpusTexts.UnpaText)
                            .Select(x => pu.ParsedSentenceFactory(x, x))
                            .Where(x => x != null)
                            .ToArray();
            Assert.Greater(s.Length, 0);

            Discourse[] d = pu.GroupIntoDiscourses(s);

            Assert.Greater(d.Length, 0);

            foreach (Discourse discourse in d)
            {
                Assert.Greater(discourse.Count, 0);
            }

            Console.WriteLine("-------------------");
            foreach (Discourse discourse in d)
            {

                int i = 0;
                foreach (Sentence sentence in discourse)
                {
                    i++;
                    Console.WriteLine(i + ") " + sentence.ToString("b"));
                }

                Console.WriteLine("-------------------");
            }
        }



        [Test]
        public void CorpusKnowledge_HeadedPhraseParser()
        {
            Dialect c = Dialect.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            HeadedPhrase value = pu.HeadedPhraseParser("jan Mato");
            Assert.AreEqual(1, value.Modifiers.Count);
            Assert.AreEqual("jan", value.Head.ToString());
            Assert.AreEqual("Mato", value.Modifiers.First().Text);
        }

        [Test]
        public void ProcessSingletonEnChainOneEn()
        {
            Dialect c = Dialect.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            ComplexChain list = pu.ProcessEnPiChain("jan en soweli");
            Console.WriteLine(list.ToJsonNet());
            Console.WriteLine(list);
            //Assert.AreEqual(1, list.SubChains[0].HeadedPhrases.Length);
            //Assert.AreEqual(list.SubChains[0].HeadedPhrases[0].Head.Text, "jan");
            //Assert.AreEqual(list.SubChains[1].HeadedPhrases[0].Head.Text, "soweli");
        }

        [Test]
        public void ProcessSingletonEnChainNoEn()
        {
            Dialect c = Dialect.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            ComplexChain list = pu.ProcessEnPiChain("jan Mato");
            Console.WriteLine(list);
            //Assert.AreEqual(1, list.SubChains[0].SubChains.Length);
            //Assert.AreEqual("jan", list.SubChains[0].SubChains[0].HeadedPhrases.Head.Text);
            //Assert.AreEqual("Mato", list.SubChains[0].HeadedPhrases[0].Modifiers.First().Text);
        }
        [Test]
        public void ProcessSingletonPredicate()
        {
            Dialect c = Dialect.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            TpPredicate predicate = pu.ProcessPredicates("li soweli lili");
            Assert.AreEqual("soweli", predicate.VerbPhrase.HeadVerb.Text);
            Assert.AreEqual("lili", predicate.VerbPhrase.Adverbs.First().Text);
        }

    }
}
