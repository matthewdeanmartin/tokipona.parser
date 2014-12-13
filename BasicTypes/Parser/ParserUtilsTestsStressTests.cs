using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using BasicTypes.Collections;
using BasicTypes.Corpus;
using BasicTypes.Extensions;
using BasicTypes.Glosser;
using BasicTypes.Knowledge;
using BasicTypes.NormalizerCode;
using BasicTypes.ParseDiscourse;
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
            Dialect dialect = Dialect.LooseyGoosey;
            
            SentenceSplitter ss = new SentenceSplitter(dialect);
            
            Normalizer norm = new Normalizer(dialect);
            foreach (string s in reader.NextFile())
            {
                string[] rawSentences = ss.ParseIntoNonNormalizedSentences(s);
                foreach (string sentence in rawSentences)
                {
                    string normalized = norm.NormalizeText(sentence);
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
            Dialect dialect = Dialect.LooseyGoosey;
            dialect.InferCompoundsPrepositionsForeignText = false;
            dialect.InferNumbers = true;
            dialect.NumberType = "Body";
            Normalizer norm = new Normalizer(dialect);
            CorpusFileReader reader = new CorpusFileReader();
            SentenceSplitter ss = new SentenceSplitter(dialect);

            foreach (string s in reader.NextFile())
            {
                foreach (string original in ss.ParseIntoNonNormalizedSentences(s))
                {
                    try
                    {
                        string normalized = norm.NormalizeText(original);
                        string result = NormalizeNumbers.FindNumbers(normalized, dialect);
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
        public void StressTestNormalize_AnuSeme()
        {
            int i = 0;
            Dialect dialect = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(dialect);

            Dialect english = Dialect.LooseyGoosey;
            english.TargetGloss = "en";
            english.GlossWithFallBacks = true;

            CorpusFileReader reader = new CorpusFileReader(true);
            GlossMaker gm = new GlossMaker();
            SentenceSplitter ss = new SentenceSplitter(dialect);
            
            Normalizer norm = new Normalizer(dialect);
            
            foreach (string s in reader.NextFile())
            {
                foreach (string original in ss.ParseIntoNonNormalizedSentences(s))
                {
                    //try
                    //{
                    string normalized = norm.NormalizeText(original);
                    
                    if (!(normalized.ContainsWholeWord("anu seme"))) continue;
                    i++;
                    Sentence structured = pu.ParsedSentenceFactory(normalized, original);
                    string diag = structured.ToString("b");

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
        public void StressTestNormalize_Pronouns()
        {
            int i = 0;
            Dialect dialect = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(dialect);
            
            Normalizer norm = new Normalizer(dialect);

            Dialect english = Dialect.LooseyGoosey;
            english.TargetGloss = "en";
            english.GlossWithFallBacks = true;

            CorpusFileReader reader = new CorpusFileReader();
            //GlossMaker gm = new GlossMaker();
            SentenceSplitter ss = new SentenceSplitter(dialect);

            foreach (string s in reader.NextFile())
            {
                foreach (string original in ss.ParseIntoNonNormalizedSentences(s))
                {
                    //try
                    //{
                    string normalized = norm.NormalizeText(original);
                    
                    if (!(normalized.ContainsWholeWord("mi") || normalized.ContainsWholeWord("sina") || normalized.ContainsWholeWord("ona"))) continue;
                    if (normalized.ContainsCheck("Kinla")) continue;//Has a logical operator in one of the sample sentences that I can't deal with yet, unrelated to kin, ala
                    if (normalized.ContainsCheck("o,")) continue;//Haven't dealt with vocatives yet.
                    if (normalized.ContainsCheck(" li pi ")) continue;//Will deal with these when I feel like it.

                    if (normalized.ContainsCheck("ona li alasa pona")) return;//Okay, this is some randome point in the middle. 100s is enough!

                    Sentence structured = pu.ParsedSentenceFactory(normalized, original);

                    bool foundInteresting = false;
                    if (structured.Subjects != null)
                    {
                        if (structured.Subjects.ComplexChains != null)
                        {
                            foreach (ComplexChain innerComplexChain in structured.Subjects.ComplexChains)
                            {
                                if (innerComplexChain.SubChains == null) continue;

                                foreach (Chain subChain in innerComplexChain.SubChains)
                                {
                                    if (subChain.HeadedPhrases == null) continue;

                                    foreach (HeadedPhrase headedPhrase in subChain.HeadedPhrases)
                                    {
                                        if (headedPhrase.Modifiers == null || headedPhrase.Modifiers.Count == 0)
                                        {
                                            continue;
                                        }
                                        if (headedPhrase.Head.Text == "mi" || headedPhrase.Head.Text == "sina" ||
                                        headedPhrase.Head.Text == "ona")
                                        {
                                            Console.WriteLine("Found  : " + headedPhrase);
                                            foundInteresting = true;
                                        }
                                    }
                                }
                            }
                        }

                        if (structured.Subjects.SubChains != null)
                        {
                            foreach (Chain subChain in structured.Subjects.SubChains)
                            {
                                if (subChain.HeadedPhrases == null) continue;

                                foreach (HeadedPhrase headedPhrase in subChain.HeadedPhrases)
                                {
                                    if (headedPhrase.Modifiers == null || headedPhrase.Modifiers.Count == 0)
                                    {
                                        continue;
                                    }
                                    if (headedPhrase.Head.Text == "mi" || headedPhrase.Head.Text == "sina" ||
                                        headedPhrase.Head.Text=="ona")
                                    {
                                        Console.WriteLine("Found  : " + headedPhrase);
                                        foundInteresting = true;
                                    }
                                }
                            }
                        }
                    }
                    
                    if(!foundInteresting) continue;
                    

                    string diag = structured.ToString("b");

                    //if ((normalized.ContainsCheck("%ante"))) continue; //verb!

                    Console.WriteLine("O: " + (original ?? "").Trim(new[] { '\n', '\r', ' ', '\t' }));
                    Console.WriteLine("B: " + diag);
                    //Console.WriteLine("G: " + gm.GlossOneSentence(false, structured, english));
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
        public void StressTestNormalize_VocativeImperatives()
        {
            int i = 0;
            Dialect dialect = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(dialect);

            Dialect english = Dialect.LooseyGoosey;
            english.TargetGloss = "en";
            english.GlossWithFallBacks = true;

            
            Normalizer norm = new Normalizer(dialect);

            CorpusFileReader reader = new CorpusFileReader();
            //GlossMaker gm = new GlossMaker();
            SentenceSplitter ss = new SentenceSplitter(dialect);

            foreach (string s in reader.NextFile())
            {
                foreach (string original in ss.ParseIntoNonNormalizedSentences(s))
                {
                    Sentence structured = null;
                    try
                    {
                    string normalized = norm.NormalizeText(original);
                    
                    if (string.IsNullOrWhiteSpace(normalized)) continue;
                    if (!(normalized.ContainsWholeWord("o"))) continue;
                    if (!(normalized.ContainsWholeWord("li"))) continue;
                    if ((normalized.StartsWith("o "))) continue; //These seem to be okay
                    if (normalized.ContainsCheck("Kinla")) continue;//Has a logical operator in one of the sample sentences that I can't deal with yet, unrelated to kin, ala
                    
                    structured = pu.ParsedSentenceFactory(normalized, original);
                    string diag = structured.ToString("b");

                    Console.WriteLine("O: " + (original ?? "").Trim(new[] { '\n', '\r', ' ', '\t' }));
                    Console.WriteLine("B: " + diag);
                    Console.WriteLine("...");

                    //Console.WriteLine("G: " + gm.GlossOneSentence(false, structured, english));
                    }
                    catch (Exception ex)
                    {
                            Console.WriteLine("FAILED : " + original);
                            if (structured != null)
                            {
                                Console.WriteLine(structured.ToString("b"));
                            }
                            Console.WriteLine(ex.Message);
                            i++;
                        
                    }

                }
            }
            Console.WriteLine("Failed Sentences: " + i);
            Assert.AreEqual(0,i);
        }


        [Test]
        public void StressTestNormalizeNotIndeedAlaKin()
        {
            int i = 0;
            Dialect dialect = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(dialect);

            Dialect english = Dialect.LooseyGoosey;
            english.TargetGloss = "en";
            english.GlossWithFallBacks = true;

            Normalizer norm = new Normalizer(dialect);

            CorpusFileReader reader = new CorpusFileReader();
            GlossMaker gm = new GlossMaker();
            SentenceSplitter ss = new SentenceSplitter(dialect);

            foreach (string s in reader.NextFile())
            {
                foreach (string original in ss.ParseIntoNonNormalizedSentences(s))
                {
                    if(original.Contains(" su ")) continue; //neologism, back when we didn't know what pu was and hoped it was something like scandinavian sem

                    //try
                    //{
                    string normalized = norm.NormalizeText(original);
                    
                    if (!(normalized.ContainsWholeWord("ala") || normalized.ContainsWholeWord("kin"))) continue;
                    if (normalized.ContainsCheck("Kinla")) continue;//Has a logical operator in one of the sample sentences that I can't deal with yet, unrelated to kin, ala
                    

                    if (normalized.StartCheck("kin la ")) continue; //no big deal
                    if(normalized.ContainsCheck("pilin pona o")) continue; //Not trying to solve vocatives right now
                    if (normalized.ContainsCheck(" o, ")) continue; //Not trying to solve vocatives right now
                    
                    Sentence structured = pu.ParsedSentenceFactory(normalized, original);
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
            Dialect dialect = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(dialect);

            Dialect english = Dialect.LooseyGoosey;
            english.TargetGloss = "en";
            english.GlossWithFallBacks = true;

            Normalizer norm = new Normalizer(dialect);

            CorpusFileReader reader = new CorpusFileReader();
            GlossMaker gm = new GlossMaker();
            SentenceSplitter ss = new SentenceSplitter(dialect);

            foreach (string s in reader.NextFile())
            {
                foreach (string original in ss.ParseIntoNonNormalizedSentences(s))
                {
                    //try
                    //{
                    string normalized = norm.NormalizeText(original);
                    
                    if (string.IsNullOrWhiteSpace(normalized)) continue;
                    if (!(normalized.ContainsWholeWord("anu") || normalized.ContainsWholeWord("taso")
                        || normalized.ContainsWholeWord("en") || normalized.ContainsWholeWord("xxxante"))) continue;

                    if (normalized.StartCheck("anu ")) continue; //tag conjunctions no big deal
                    if (normalized.StartCheck("taso ")) continue; //tag conjunctions no big deal

                    Sentence structured = pu.ParsedSentenceFactory(normalized, original);
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
        public void StressTest_Parse_SpitBack_LooselyCompare()
        {
            int i = 0;
            Dialect dialect = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(dialect);

            //Dialect english = Dialect.LooseyGoosey;
            //english.TargetGloss = "en";
            //english.GlossWithFallBacks = true;

            CorpusFileReader reader = new CorpusFileReader(true);
            Normalizer norm = new Normalizer(dialect);
            
            SentenceSplitter ss = new SentenceSplitter(dialect);

            int total = 0;
            int j = 0;
            foreach (string s in reader.NextFile())
            {
                foreach (string original in ss.ParseIntoNonNormalizedSentences(s))
                {
                    if (original.StartCheck("*") && reader.currentFile.ContainsCheck("janKipoCollected"))  // Can't parse:  *janMato 123 123 ni li musi!
                        continue;
                    if (original.StartCheck("///"))  //Don't care if commengs got corrupted.
                        continue;

                    total++;
                    try
                    {
                        string normalized = norm.NormalizeText(original);
                        
                        Sentence structured = pu.ParsedSentenceFactory(normalized, original);
                        string diag = structured.ToString();

                        if (!diag.TpLettersEqual(original))
                        {
                            Console.WriteLine("O: " + original.Trim(new[]{' ','\t','\n','\r'}).Replace("\n"," "));
                            Console.WriteLine("G: " + diag);
                            Console.WriteLine(" --- ");
                            j++;
                        }
                    }
                    catch (Exception)
                    {
                        i++;
                    }

                }
            }
            Console.WriteLine("Total: " + total);
            Console.WriteLine("Mismatched: " + j);
            Console.WriteLine("Failed Sentences: " + i);
        }

        [Test]
        public void StressTestNormalizeAndParseEverything()
        {
            int i = 0;
            int total = 0;
            Dialect dialect = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(dialect);

            Dialect english = Dialect.LooseyGoosey;
            english.TargetGloss = "en";
            english.GlossWithFallBacks = true;

            CorpusFileReader reader = new CorpusFileReader(true);
            GlossMaker gm = new GlossMaker();
            SentenceSplitter ss = new SentenceSplitter(dialect);

            Normalizer norm = new Normalizer(dialect);
            Stopwatch watch = new Stopwatch();
            watch.Start();
            foreach (string s in reader.NextFile())
            {
                if (reader.currentFile.ContainsCheck("janKipoCollected"))  continue; // Can't parse:  *janMato 123 123 ni li musi!

                foreach (string original in ss.ParseIntoNonNormalizedSentences(s))
                {
                    total++;
                    if (watch.ElapsedMilliseconds > 15000) return;
                    //if (total > 1000) return;
                    Sentence structured = null;
                    try
                    {
                        //string normalized = norm.NormalizeText(original);
                        structured = pu.ParsedSentenceFactory(original, original);
                        string diag = structured.ToString("b");

                        //if ((normalized.ContainsCheck("%ante"))) continue; //verb!

                        string gloss = gm.GlossOneSentence(false, structured, english);
                        // Console.WriteLine("O: " + (original??"").Trim(new []{'\n','\r',' ','\t'}));
                        // Console.WriteLine("B: " + diag);
                        // Console.WriteLine("G: " + gloss);
                    }
                    catch (Exception ex)
                    {
                            i++;
                            Console.WriteLine(SentenceDiagnostics.CurrentSentence.Original); 
                    
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
            Dialect c = Dialect.LooseyGoosey;
            c.TargetGloss = "en";
            CorpusKnowledge ck = new CorpusKnowledge(sample, c);

            List<Sentence>[] s = ck.MakeSentences();
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
            Dialect dialect = Dialect.LooseyGoosey;
            dialect.TargetGloss = "en";

            //ParserUtils pu = new ParserUtils(dialect);
            SentenceSplitter ss = new SentenceSplitter(dialect);

            Normalizer norm = new Normalizer(dialect);

            foreach (string sample in samples)
            {
                string[] sentences = ss.ParseIntoNonNormalizedSentences(sample);
                foreach (string sentence in sentences)
                {
                    if (sentence.ContainsCheck("Georgia"))
                    {
                        string result = norm.NormalizeText(sentence);
                        Assert.IsTrue(result.ContainsCheck("\"Georgia\""));
                    }
                }


            }

        }

        [Test]
        public void IdentifyDiscourses_ParseKnownGoodTexts_ShowGoodOnes()
        {
            //,CorpusTexts.JanSin  //Too many neologisms to cope. 
            string[] samples =
            {
                //CorpusTexts.UnpaText,
                //CorpusTexts.Gilgamesh,
                CorpusTexts.ProfesorAndMadMan,
                CorpusTexts.SampleText1,
                CorpusTexts.SampleText3,
                CorpusTexts.Lao,
                CorpusTexts.GeorgeSong,
                    CorpusTexts.CrazyAnimal,
                    CorpusTexts.CrazyAnimal2
                    ,CorpusTexts.RuneDanceSong
                    ,CorpusTexts.janPusaRice
                    ,CorpusTexts.janPend
            };
            Dialect dialect = Dialect.LooseyGoosey;
            dialect.TargetGloss = "en";

            GlossMaker gm = new GlossMaker();
            ParserUtils pu = new ParserUtils(dialect);

            int fail = 0;

            
            SentenceSplitter ss = new SentenceSplitter(dialect);
            
            Normalizer norm = new Normalizer(dialect);

            foreach (string sample in samples)
            {
                string[] sentenceStrings =  ss.ParseIntoNonNormalizedSentences(sample);
                string[] normalized = new string[sentenceStrings.Length];
                for (int index = 0; index < sentenceStrings.Length; index++)
                {
                    //try
                    //{
                        normalized[index] = norm.NormalizeText(sentenceStrings[index]);
                        Sentence sentence = pu.ParsedSentenceFactory(normalized[index], sentenceStrings[index]);

                        Console.WriteLine(sentence.ToString("g"));
                    //}
                    //catch (Exception ex)
                    //{
                    //    fail++;
                    //    Console.WriteLine(sentenceStrings[index]);
                    //    Console.WriteLine(ex);
                    //}

                }
                
                Console.WriteLine(fail + " failed sentences.");
            }

        }

        


        [Test]
        public void IdentifyDiscourses_CanWeGroupThem()
        {
            Dialect dialect = Dialect.LooseyGoosey;
            Normalizer norm = new Normalizer(dialect);

            ParserUtils pu = new ParserUtils(dialect);
            SentenceSplitter ss = new SentenceSplitter(dialect);

            Sentence[] s = ss
                            .ParseIntoNonNormalizedSentences(CorpusTexts.UnpaText)
                            .Where(x => !string.IsNullOrWhiteSpace(x))
                            .Select(x =>
                            {
                                string normalized = norm.NormalizeText(x);
                                if (string.IsNullOrWhiteSpace(normalized))
                                    return null;
                                return  pu.ParsedSentenceFactory(normalized, x);
                            })
                            .Where(x => x!=null)
                            .ToArray();
            Assert.Greater(s.Length, 0);


            List<Sentence>[] d = ss.GroupIntoDiscourses(s);

            Assert.Greater(d.Length, 0);

            foreach (List<Sentence> discourse in d)
            {
                Assert.Greater(discourse.Count, 0);
            }

            Console.WriteLine("-------------------");
            foreach (List<Sentence> discourse in d)
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
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);

            HeadedPhrase value = pu.HeadedPhraseParser("jan Mato");
            Assert.AreEqual(1, value.Modifiers.Count);
            Assert.AreEqual("jan", value.Head.ToString());
            Assert.AreEqual("Mato", value.Modifiers.First().Text);
        }

        [Test]
        public void ProcessSingletonEnChainOneEn()
        {
            Dialect c = Dialect.LooseyGoosey;
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
            Dialect c = Dialect.LooseyGoosey;
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
            Dialect c = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(c);

            TpPredicate predicate = pu.ProcessPredicates("li soweli lili");
            Assert.AreEqual("soweli", predicate.VerbPhrase.HeadVerb.Text);
            Assert.AreEqual("lili", predicate.VerbPhrase.Adverbs.First().Text);
        }

    }
}
