using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using BasicTypes;
using BasicTypes.Glosser;
using BasicTypes.Knowledge;
using BasicTypes.NormalizerCode;
using BasicTypes.Parser;
using DemoSite.Models;

namespace DemoSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Parse(SimpleParserViewModel parse)
        {
            ProcessParserModel(parse);
            return View("Index", parse);
        }

        private static void ProcessParserModel(SimpleParserViewModel parse)
        {
            Dialect dialect = Dialect.DialectFactory;
            ParserUtils pu = new ParserUtils(dialect);
            string[] sentences = pu.ParseIntoNonNormalizedSentences(parse.SourceText);
            StringBuilder normalizedSb = new StringBuilder();
            StringBuilder spitBackSb = new StringBuilder();
            StringBuilder bracketSb = new StringBuilder();
            StringBuilder posSb = new StringBuilder();
            StringBuilder glossSb = new StringBuilder();


            foreach (string sentence in sentences)
            {
                string normalized;
                try
                {
                    normalized = Normalizer.NormalizeText(sentence, dialect);
                }
                catch (Exception ex)
                {
                    normalized = "[[CANNOT NORMALIZE: nena suli! " + ex.Message + " for " + sentence + "]]";
                    normalizedSb.AppendLine(normalized + "<br/>");
                    continue;
                }
                normalizedSb.AppendLine(normalized.ToHtml() + "<br/>");

                Sentence parsedSentence;
                try
                {
                    parsedSentence = pu.ParsedSentenceFactory(normalized, sentence);
                    try
                    {
                        spitBackSb.AppendLine(parsedSentence.ToString("g", dialect).ToHtml() + "<br/>");
                    }
                    catch (Exception ex)
                    {
                        string error = "[[CANNOT REPEAT BACK: nena suli! " + ex.Message + " for " + sentence + "]]";
                        spitBackSb.AppendLine(error.ToHtml() + "<br/>");
                    }

                    try
                    {
                        bracketSb.AppendLine(parsedSentence.ToString("b", dialect).ToHtml() + "<br/>");
                        //posSb.AppendLine(parsedSentence.ToString("bs", dialect) + "<br/>"); //bs doesn't do anything.
                    }
                    catch (Exception ex)
                    {
                        string error = "[[CANNOT BRACKET: nena suli! " + ex.Message + " for " + sentence + "]]";
                        bracketSb.AppendLine(error.ToHtml() + "<br/>");
                    }

                    try
                    {
                        dialect.TargetGloss = "en";
                        GlossMaker gm = new GlossMaker();
                        string glossed= gm.Gloss(normalized, sentence, "en", false);
                        glossSb.AppendLine(glossed.ToHtml() + "<br/>");
                        glossed = gm.Gloss(normalized, sentence, "en", true);
                        posSb.AppendLine(glossed.ToHtml() + "<br/>"); //bs doesn't do anything.
                    }
                    catch (Exception ex)
                    {
                        string error = "[[CANNOT GLOSS: nena suli! " + ex.Message.ToHtml() + " for " + sentence.ToHtml() + "]]";
                        glossSb.AppendLine(error.ToHtml() + "<br/>");
                    }
                }
                catch (Exception ex)
                {
                    string cantParse = "[[CANNOT PARSE: nena suli! " + ex.Message.ToHtml() + " for " + sentence.ToHtml() + "]]";
                    foreach (var sb in new StringBuilder[]
                    {
                        spitBackSb,
                        bracketSb,
                        posSb,
                        glossSb
                    })
                    {
                        sb.AppendLine(cantParse.ToHtml() + "<br/>");
                    }
                }
                finally
                {
                    dialect.TargetGloss = "tp";
                }
            }

            parse.Normalized = normalizedSb.ToString();
            parse.Recovered = spitBackSb.ToString();
            parse.Formatted = bracketSb.ToString();
            parse.FormattedPos = posSb.ToString();
            parse.Glossed = glossSb.ToString();
        }

        public ActionResult Index()
        {
            Random r= new Random(DateTime.Now.Millisecond);

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
            SimpleParserViewModel vm = new SimpleParserViewModel()
            {
                SourceText = samples[r.Next(samples.Length)]
            };
            ProcessParserModel(vm);
            return View(vm);
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
    }
}