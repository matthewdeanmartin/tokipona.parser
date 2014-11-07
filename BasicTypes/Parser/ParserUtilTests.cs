﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.Corpus;
using BasicTypes.Glosser;
using BasicTypes.Knowledge;
using NUnit.Framework;

namespace BasicTypes.Parser
{
    /// <summary>
    /// Tests that parse something higher level than a string array.
    /// </summary>
    [TestFixture]
    public class ParserUtilTests
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
        public void ShouldBeGoodKunpapa()
        {
            string s = "jan Kunpapa";
            Normalizer n = new Normalizer();
            Console.WriteLine(Normalizer.NormalizeText(s));
            TokenParserUtils pu = new TokenParserUtils();

            Word[] words = pu.ValidWords(s);


            foreach (Word word in words)
            {
                Console.WriteLine(word);
            }
        }



        //jan Oliwa 
        [Test]
        public void ShouldBeGoodProperModifier()
        {
            string s = "jan Oliwa";
            Normalizer n = new Normalizer();
            Console.WriteLine(Normalizer.NormalizeText(s));
            TokenParserUtils pu = new TokenParserUtils();

            Word[] words = pu.ValidWords(s);


            foreach (Word word in words)
            {
                Console.WriteLine(word);
            }
        }


        //jan MaliyA
        [Test]
        public void DoubleBadProperModifer()
        {
            string s = "jan MaliyA";
            Normalizer n = new Normalizer();
            Console.WriteLine(Normalizer.NormalizeText(s));
            TokenParserUtils pu = new TokenParserUtils();
            Word[] words;
            try
            {
                words = pu.ValidWords(s);
            }
            catch (Exception)
            {
                return;
            }

            foreach (Word word in words)
            {
                Console.WriteLine(word);
            }

            Assert.Fail();
        }

        //o mi tu li kama tomo mi.
        [Test]
        public void OLetsHaveThisSentenceParse()
        {
            string s = "o mi tu li kama tomo mi.";
            Dialect c = Dialect.DialectFactory;
            //c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);
            Sentence sentence = pu.ParsedSentenceFactory(s, s);
            Assert.IsNotNull(sentence.Subjects);
            Assert.IsTrue(sentence.Subjects.Length > 0);

            //Assert.IsNotNull(sentence.Subjects[0].HeadedPhrases[0].Head.Text,"mi"); //pi chains :-(
        }

        [Test]
        public void LostPrep()
        {
            string s = "o toki pona e mi tawa jan sewi Utu!";
            Dialect c = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(c);
            Sentence sentence = pu.ParsedSentenceFactory(s, s);
            Assert.IsNotNull(sentence.Predicates[0].Prepositionals!=null);
        }

        //
        [Test]
        public void SplitSentenceWithColon_Normalized()
        {
            string s = "sina toki e ni: mi wile e ni.";
            Dialect c = Dialect.DialectFactory;
            //c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);
            string[] parts = pu.ParseIntoRawSentences(s);
            Assert.AreEqual("sina li toki e ni:", parts[0]);
            Assert.AreEqual("mi li wile e ni.", parts[1]);
        }

        [Test]
        public void ProcessVocative()
        {
            Dialect c = Dialect.DialectFactory;
            //c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            const string vocative = "jan sona pi ma pi kasi suli o!";
            Sentence s = pu.ParsedSentenceFactory(vocative, vocative);
            Console.WriteLine(s.ToString("b"));
        }
        [Test]
        public void ProcessCalmVocative_JustRunIsVocative()
        {

            const string vocative = "jan Oliwa o, o, o.";
            bool isIt = Normalizer.IsVocative(vocative);
            Assert.IsTrue(isIt, "Expected to ID a vocative.");
        }



        [Test]
        public void ProcessCalmVocative()
        {
            Dialect c = Dialect.DialectFactory;
            //c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            const string vocative = "jan Oliwa o, o, o.";
            Sentence s = pu.ParsedSentenceFactory(vocative, vocative);
            Console.WriteLine(s.ToString("b"));
        }


        [Test]
        public void CreateTpPredicateAfterSplitingEChain()
        {
            Dialect c = Dialect.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            const string ePhrase = "li moku e soweli suli mute";
            TpPredicate predicate = pu.ProcessPredicates(ePhrase);
            Console.WriteLine(predicate.ToString("b"));
            Assert.IsTrue(predicate.Directs != null);
        }

        [Test]
        public void SpellCheck_ForStressTest_UsingOnlyWordConstructor()
        {
            CorpusFileReader reader = new CorpusFileReader();
            Dictionary<string, string> bad = new Dictionary<string, string>();
            List<string> good = new List<string>();
            TokenParserUtils tpu = new TokenParserUtils();
            ParserUtils pu = new ParserUtils(Dialect.DialectFactory);

            foreach (string s in reader.NextFile())
            {
                string[] rawSentences = pu.ParseIntoRawSentences(s);
                foreach (string sentence in rawSentences)
                {
                    string normalized = Normalizer.NormalizeText(sentence);
                    //Normalization improved stuff
                    string[] words = tpu.JustTokens(normalized);
                    for (int index = 0; index < words.Length; index++)
                    {
                        //Don't remove double quotes or we can't ID some marked foreign text.
                        //'"'
                        words[index] = words[index].Trim(new char[]{':','.','\'','«','»','!','?','-','[',']'});
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
        public void StressTestNormalizeAndParseEverything()
        {
            int i = 0;
            ParserUtils pu = new ParserUtils(Dialect.DialectFactory);

            CorpusFileReader reader = new CorpusFileReader();
            foreach (string s in reader.NextFile())
            {
                foreach (string original in pu.ParseIntoRawSentences(s))
                {
                    Sentence structured=null;
                    string normalized;
                    try
                    {
                        normalized = Normalizer.NormalizeText(original);
                        structured = pu.ParsedSentenceFactory(normalized, original);
                        string diag = structured.ToString("b");
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ORIGINAL  : " + original);
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
        public void IdentifyDiscourses_CanItEvenParseTheSentences_ShowGoodOnes()
        {
            string[] samples =
                new string[]
                {
                CorpusTexts.UnpaText,
                CorpusTexts.Gilgamesh,
                CorpusTexts.SampleText1,
                CorpusTexts.SampleText3,
                CorpusTexts.Lao,
                CorpusTexts.GeorgeSong,
                    CorpusTexts.CrazyAnimal,
                    CorpusTexts.CrazyAnimal2
                    //,CorpusTexts.JanSin  //Too many neologisms to cope. 
                    ,CorpusTexts.RuneDanceSong
                    ,CorpusTexts.janPusaRice
                    ,CorpusTexts.janPend
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
        public void ParseJustO()
        {
            //o!
            string s = "o!";
            ParserUtils pu = new ParserUtils(Dialect.DialectFactory);

            Sentence parsedSentence = pu.ParsedSentenceFactory(s, s);
            Console.WriteLine(parsedSentence.ToString());
        }

        //nena meli kin li tawa en tan li kama nena pi suli en kiwen.
        [Test]
        public void ParseThreePart()
        {
            string s = "nena meli kin li tawa en tan li kama nena pi suli en kiwen.";
            ParserUtils pu = new ParserUtils(Dialect.DialectFactory);

            Sentence parsedSentence = pu.ParsedSentenceFactory(s, s);
            Console.WriteLine(parsedSentence.ToString());
            Assert.AreEqual(2, parsedSentence.Predicates.Count);
            Assert.IsNotNull(parsedSentence);
        }


        [Test]
        public void IdentifyDiscourses_CanWeGroupThem()
        {
            Dialect c = Dialect.DialectFactory;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            Sentence[] s = pu
                            .ParseIntoRawSentences(CorpusTexts.UnpaText)
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

            Chain list = pu.ProcessEnPiChain("jan en soweli");
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

            Chain list = pu.ProcessEnPiChain("jan Mato");
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
