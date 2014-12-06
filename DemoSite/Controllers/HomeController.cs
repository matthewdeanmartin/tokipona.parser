using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using BasicTypes;
using BasicTypes.Glosser;
using BasicTypes.Html;
using BasicTypes.Knowledge;
using BasicTypes.Lorem;
using BasicTypes.NormalizerCode;
using BasicTypes.Parser;
using DemoSite.Models;

namespace DemoSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult LoremIpsum()
        {
            Dialect dialect = Dialect.LooseyGoosey;
            dialect.IncludeApocrypha = false;
            TextGenerator tg = new TextGenerator(dialect);
            List<Sentence> sentences = new List<Sentence>();
            for (int i = 0; i < 1000; i++)
            {
                Sentence s = tg.GenerateSentence();
                sentences.Add(s);
            }
            StringBuilder spitBackSb = new StringBuilder();
            StringBuilder bracketSb = new StringBuilder();
            StringBuilder posSb = new StringBuilder();
            StringBuilder glossSb = new StringBuilder();
            StringBuilder colorized = new StringBuilder();
            StringBuilder errors = new StringBuilder();
            HtmlFormatter hf = new HtmlFormatter();

            StringBuilder sb = new StringBuilder();

            foreach (Sentence s in sentences)
            {

                Sentence parsedSentence = s;
                string normalized;
                //////// TP
                try
                {
                    normalized = parsedSentence.ToString("g", dialect);
                    spitBackSb.AppendLine(normalized.ToHtml() + "<br/>");
                }
                catch (Exception ex)
                {
                    string error = "[[CANNOT REPEAT BACK:  " + ex.Message + "]]";
                    spitBackSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                    errors.Append(error);
                }

                try
                {
                    string result = parsedSentence.ToString("html", dialect);
                    //if (result.Replace("<span", "").Contains("<"))
                    //{
                    //    throw new InvalidOperationException("No HTML allowed in input");
                    //}
                    colorized.AppendLine(result + "<br/>");
                }
                catch (Exception ex)
                {
                    string error = "[[CANNOT COLORIZE:  " + ex.Message + "]]";
                    spitBackSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                    errors.Append(error);
                }

                //////// TP
                try
                {
                    string diagrammed = parsedSentence.ToString("b", dialect);
                    bracketSb.AppendLine(hf.BoldTheWords(diagrammed.ToHtml()) + "<br/>");
                }
                catch (Exception ex)
                {
                    string error = "[[CANNOT BRACKET:  " + ex.Message + "]]";
                    bracketSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                    errors.Append(error);
                }


                //////// ENGLISH
                try
                {
                    dialect.TargetGloss = "en";
                    GlossMaker gm = new GlossMaker();
                    string glossed = gm.GlossOneSentence(false, s, dialect);
                    glossSb.AppendLine(glossed.ToHtml() + "<br/>");
                    glossed = gm.GlossOneSentence(true, s, dialect);
                    posSb.AppendLine(glossed.ToHtml() + "<br/>"); //bs doesn't do anything.
                }
                catch (Exception ex)
                {
                    string error = "[[CANNOT GLOSS:  " + ex.Message.ToHtml() + "]]";
                    glossSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                    errors.Append(error);
                }


                sb.Append(colorized.ToString());
                //sb.Append("<br/>");
                sb.Append(bracketSb.ToString());
                //sb.Append("<br/>");
                sb.Append(glossSb.ToString());
                sb.Append(hf.SubThePartsOfSpeech(posSb.ToString()));
                //sb.Append("<br/>");
                sb.Append("<br/>");

                spitBackSb.Clear();
                bracketSb.Clear();
                posSb.Clear();
                glossSb.Clear();
                colorized.Clear();
            }

            return View(new LoremIpsumModel { Html = sb.ToString() });

        }

        public ActionResult Parse(SimpleParserViewModel parse)
        {
            if (parse.SourceText == null)
            {
                parse = RandomText();
            }
            ProcessParserModel(parse);
            return View("Index", parse);
        }

        private static void ProcessParserModel(SimpleParserViewModel parse)
        {

            Dialect dialect;
            if (parse.Dialect == "LooseyGoosey")
            {
                dialect = Dialect.LooseyGoosey;
            }
            else if (parse.Dialect == "WordProcessorRules")
            {
                dialect = Dialect.WordProcessorRules;
            }
            else
            {
                throw new ArgumentOutOfRangeException("parse", "Need a valid dialect");
            }
            ParserUtils pu = new ParserUtils(dialect);
            string[] sentences = pu.ParseIntoNonNormalizedSentences(parse.SourceText);
            StringBuilder normalizedSb = new StringBuilder();
            StringBuilder spitBackSb = new StringBuilder();
            StringBuilder bracketSb = new StringBuilder();
            StringBuilder posSb = new StringBuilder();
            StringBuilder glossSb = new StringBuilder();

            StringBuilder errors = new StringBuilder();
            StringBuilder colorized = new StringBuilder();

            HtmlFormatter hf = new HtmlFormatter();

            foreach (string sentence in sentences)
            {
                string normalized;
                try
                {
                    normalized = Normalizer.NormalizeText(sentence, dialect);
                }
                catch (Exception ex)
                {
                    string error = "[[CANNOT NORMALIZE:  " + ex.Message + "]]";
                    normalizedSb.AppendLine(error.ToHtml() + "<br/>");
                    normalizedSb.AppendLine(hf.BoldTheWords(sentence.ToHtml()) + "<br/>");
                    normalized = sentence;
                    UpdateErrors(errors, error, sentence);
                }
                //////// TP
                normalizedSb.AppendLine(hf.BoldTheWords(normalized.ToHtml()) + "<br/>");

                Sentence parsedSentence;
                try
                {
                    parsedSentence = pu.ParsedSentenceFactory(normalized, sentence);

                    //////// TP
                    try
                    {
                        spitBackSb.AppendLine(parsedSentence.ToString("g", dialect).ToHtml() + "<br/>");
                    }
                    catch (Exception ex)
                    {
                        string error = "[[CANNOT REPEAT BACK:  " + ex.Message + " for " + sentence + "]]";
                        spitBackSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                        spitBackSb.AppendLine(hf.BoldTheWords(sentence.ToHtml()) + "<br/>");
                        UpdateErrors(errors, error, sentence);
                    }

                    try
                    {
                        //string result = parsedSentence.ToString("html", dialect);
                        //if (result.Replace("<span", "").Contains("<"))
                        //{
                        //    throw new InvalidOperationException("No HTML allowed in input");
                        //}
                        colorized.AppendLine(parsedSentence.ToString("html", dialect) + "<br/>");
                    }
                    catch (Exception ex)
                    {
                        string error = "[[CANNOT COLORIZE:  " + ex.Message + "]]";
                        spitBackSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                        spitBackSb.AppendLine(hf.BoldTheWords(sentence.ToHtml()) + "<br/>");

                        UpdateErrors(errors, error, sentence);
                    }

                    //////// TP
                    try
                    {
                        bracketSb.AppendLine(hf.BoldTheWords(parsedSentence.ToString("b", dialect).ToHtml()) + "<br/>");
                    }
                    catch (Exception ex)
                    {
                        string error = "[[CANNOT BRACKET:  " + ex.Message + " for " + sentence + "]]";
                        bracketSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                        bracketSb.AppendLine(hf.BoldTheWords(sentence.ToHtml()) + "<br/>");
                        UpdateErrors(errors, error, sentence);

                    }


                    //////// ENGLISH
                    try
                    {
                        dialect.TargetGloss = "en";
                        GlossMaker gm = new GlossMaker();
                        string glossed = gm.Gloss(normalized, sentence, "en", false);
                        glossSb.AppendLine(glossed.ToHtml() + "<br/>");
                        glossed = gm.Gloss(normalized, sentence, "en", true);
                        posSb.AppendLine(glossed.ToHtml() + "<br/>"); //bs doesn't do anything.
                    }
                    catch (Exception ex)
                    {
                        string error = "[[CANNOT GLOSS:  " + ex.Message.ToHtml() + " for " + sentence.ToHtml() + "]]";
                        glossSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                        glossSb.AppendLine(hf.BoldTheWords(sentence.ToHtml()) + "<br/>");

                        posSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                        posSb.AppendLine(hf.BoldTheWords(sentence.ToHtml()) + "<br/>");

                        UpdateErrors(errors, error, sentence);
                    }
                }
                catch (Exception ex)
                {
                    string error = "[[CANNOT Parse:  " + ex.Message.ToHtml() + "]]";

                    foreach (StringBuilder sb in new StringBuilder[] { //normalizedSb,
                        spitBackSb, bracketSb, posSb, glossSb, colorized })
                    {
                        sb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                        sb.Append(sentence.ToHtml() + "<br/>");
                    }

                    UpdateErrors(errors, error, sentence);
                }
                finally
                {
                    dialect.TargetGloss = "tp";
                }
            }

            parse.Normalized = normalizedSb.ToString();
            parse.Recovered = spitBackSb.ToString();
            parse.Formatted = bracketSb.ToString();
            parse.FormattedPos = hf.SubThePartsOfSpeech(posSb.ToString());
            parse.Glossed = glossSb.ToString();
            parse.Colorized = colorized.ToString();
            parse.Errors = errors.ToString();
        }

        private static void UpdateErrors(StringBuilder errors, string error, string sentence)
        {
            errors.Append(error + "<br/>");
            errors.Append(sentence.ToHtml() + "<br/>");
        }

        public ActionResult Index()
        {
            var vm = RandomText();
            return View(vm);
        }

        private static Random r = new Random(DateTime.Now.Millisecond);

        private static SimpleParserViewModel RandomText()
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
                    , CorpusTexts.RuneDanceSong
                    , CorpusTexts.janPusaRice
                    , CorpusTexts.janPend,
                    CorpusTexts.ProfesorAndMadMan,
                    "nena meli li suli la monsi li suli kin."
                };
            SimpleParserViewModel vm = new SimpleParserViewModel()
            {
                SourceText = samples[r.Next(samples.Length)]
            };
            ProcessParserModel(vm);
            return vm;
        }

        public ActionResult Serializations()
        {

            Random r = new Random(DateTime.Now.Millisecond);

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
                    ,CorpusTexts.janPend,
                    "nena meli li suli la monsi li suli kin."
                };
            SerializationsModel sm = new SerializationsModel()
            {
                SourceText = samples[r.Next(samples.Length)]
            };

            ProcessSerializationsModel(sm);

            return View(sm);
        }


        private static void ProcessSerializationsModel(SerializationsModel parse)
        {
            Dialect dialect = Dialect.LooseyGoosey;
            ParserUtils pu = new ParserUtils(dialect);
            string[] sentences = pu.ParseIntoNonNormalizedSentences(parse.SourceText);

            StringBuilder errors = new StringBuilder();

            List<Sentence> parseSentences = new List<Sentence>();
            int i = 0;
            foreach (string sentence in sentences)
            {
                i++;
                if (i >= 3) continue;
                string normalized;
                try
                {
                    normalized = Normalizer.NormalizeText(sentence, dialect);
                }
                catch (Exception ex)
                {
                    normalized = "[[CANNOT NORMALIZE:  " + ex.Message + " for " + sentence + "]]";
                    errors.AppendLine(normalized + "<br/>");
                    continue;
                }


                Sentence parsedSentence;
                try
                {
                    parsedSentence = pu.ParsedSentenceFactory(normalized, sentence);
                    parseSentences.Add(parsedSentence);
                }
                catch (Exception ex)
                {
                    string cantParse = "[[CANNOT PARSE:  " + ex.Message.ToHtml() + " for " + sentence.ToHtml() + "]]";
                    errors.AppendLine(cantParse.ToHtml() + "<br/>");
                }
                finally
                {
                    dialect.TargetGloss = "tp";
                }
            }

            parse.Json = parseSentences.ToJsonNet();
            parse.Xml = FormatXml(parseSentences.ToDataContractXml());
            parse.Html = "Not implemented yet";
        }

        public static string FormatXml(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml);
                return doc.ToString();
            }
            catch (Exception)
            {
                return xml;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Overview";

            return View();
        }
        public ActionResult ChangeLog()
        {
            ViewBag.Message = "Change Log";

            return View();
        }
        public ActionResult BracketHelp()
        {
            ViewBag.Message = "Bracket Help";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "No contact info yet! Catch me on twitter maybe @janmato";

            return View();
        }
        public ActionResult StrictMode()
        {
            //ViewBag.Message = "No contact info yet! Catch me on twitter maybe @janmato";

            return View();
        }
        //
    }
}