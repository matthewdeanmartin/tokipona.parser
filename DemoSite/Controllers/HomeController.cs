using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.History;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Data.Entity;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Xml.Linq;
using BasicTypes;
using BasicTypes.CollectionsDiscourse;
using BasicTypes.Glosser;
using BasicTypes.Html;
using BasicTypes.Knowledge;
using BasicTypes.Lorem;
using BasicTypes.NormalizerCode;
using BasicTypes.ParseDiscourse;
using BasicTypes.Parser;
using BasicTypes.Persist;
using DemoSite.Extensions;
using DemoSite.Models;
using Should.Core.Exceptions;
using System.Security.Claims;

namespace DemoSite.Controllers
{
    public class HomeController : Controller
    {
        public class FakeView : IView
        {
            public void Render(ViewContext viewContext, TextWriter writer)
            {
                throw new InvalidOperationException();
            }
        }

        public string MakeUrl(string id)
        {
            return "http://tokipona.net" + Url.Action("Index", "L", new { i = id });
        }

        public ActionResult Display(string shortUrl)
        {
            using (CorpusTextsContext context = new CorpusTextsContext())
            {
                var item = context.CorpusTexts.FirstOrDefault(x => x.ShortUrl == shortUrl);

                if (item != null)
                {
                    SimpleParserViewModel model = new SimpleParserViewModel();

                    model.SourceText = item.SnippetText;
                    model.SentenceOrParagraph = "Paragraph";
                    Parse(model);
                    model.SnippetUrl = MakeUrl(item.ShortUrl);
                    model.SnippetUrlParam = item.ShortUrl;
                    //var h = new HtmlHelper(new ViewContext(ControllerContext, new FakeView(), new ViewDataDictionary(), new TempDataDictionary(), TextWriter.Null), new ViewPage());
                    //MvcHtmlString adfasdfext= h.TextArea("SnippetUrl", model.SnippetUrl, 1, 50, null);
                    //string result= adfasdfext.ToString();
                    //string result2 = adfasdfext.ToHtmlString();

                    return View("Index", model);
                }

                return View("Index", new SimpleParserViewModel() { SnippetSavingError = "Cannot find any such text at that URL" });
            }
        }

        //[HttpParamAction]
        private ActionResult SaveText(SimpleParserViewModel parse)
        {
            parse.SnippetSavingError = null;

            string toSave = parse.SourceText;


            // Cast the Thread.CurrentPrincipal
            ClaimsPrincipal icp = Thread.CurrentPrincipal as ClaimsPrincipal;

            if (icp == null)
            {
                parse.SnippetSavingError = "<b>NOT SAVED. You must create an account and/or login</b>";
                parse.SnippetUrl = parse.SnippetSavingError;
                parse.SnippetUrlParam = "";
                return View("Index", parse);
            }

            // Access IClaimsIdentity which contains claims
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)icp.Identity;

            // Access claims
            string userId = null;
            foreach (Claim claim in claimsIdentity.Claims)
            {
                if (claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                {
                    userId = claim.Value;
                }
                //Debug.WriteLine(claim.Value);
            }
            if (userId == null)
            {
                parse.SnippetSavingError = "<b>NOT SAVED. You must create an account and/or login</b>";
                parse.SnippetUrl = parse.SnippetSavingError;
                parse.SnippetUrlParam = "";
                return View("Index", parse);
            }

            decimal percent = NormalizeForeignText.PercentTokiPona(toSave);
            if (percent < 0.80m)
            {
                parse.SnippetSavingError = "<b>NOT SAVED. Insufficient toki pona here, only " + String.Format("Value: {0:P2}.", percent) + "</b>";
                parse.SnippetUrl = parse.SnippetSavingError;
                parse.SnippetUrlParam = "";
                return View("Index", parse);
            }

           

            //Save to DB
            using (CorpusTextsContext context = new CorpusTextsContext())
            {
                int count = context.CorpusTexts.Count();

                var query = context.CorpusTexts.Where(x => x.SnippetText == toSave).FirstOrDefault();
                if (query == null)
                {
                    CorpusText text = new CorpusText();
                    text.Id = NativeMethods.CreateGuid();
                    text.AspNetUserId = userId;// icp.Identity.Name;
                    text.SnippetText = toSave;
                    text.CreatedOn = DateTime.Now;
                    text.UpdatedOn = text.CreatedOn;
                    text.ShortUrl = Base36Encode(Convert.ToUInt64(count));
                    parse.SnippetUrl = MakeUrl(text.ShortUrl);
                    parse.SnippetUrlParam = text.ShortUrl;
                    context.CorpusTexts.Add(text);
                    context.SaveChanges();
                }
                else
                {
                    parse.SnippetUrl = MakeUrl(query.ShortUrl); 
                    parse.SnippetUrlParam = query.ShortUrl;
                }
            }

            return Display(parse.SnippetUrlParam);
        }

        //From wikipedia: https://en.wikipedia.org/wiki/Base_36#C.23_implementation
        private const string Clist = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly char[] Clistarr = Clist.ToCharArray();

        public static long Base36Decode(string inputString)
        {
            long result = 0;
            var pow = 0;
            for (var i = inputString.Length - 1; i >= 0; i--)
            {
                var c = inputString[i];
                var pos = Clist.IndexOf(c);
                if (pos > -1)
                    result += pos * (long)Math.Pow(Clist.Length, pow);
                else
                    return -1;
                pow++;
            }
            return result;
        }

        public static string Base36Encode(ulong inputNumber)
        {
            var sb = new StringBuilder();
            do
            {
                sb.Append(Clistarr[inputNumber % (ulong)Clist.Length]);
                inputNumber /= (ulong)Clist.Length;
            } while (inputNumber != 0);
            return Reverse(sb.ToString());
        }

        public static string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

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

        //[HttpParamAction]
        public ActionResult Parse(SimpleParserViewModel parse)
        {
            if (parse.ButtonClicked == "SaveText")
            {
                return SaveText(parse);
            }

            if (parse.SourceText == null)
            {
                parse = RandomText();
            }
            if (parse.SentenceOrParagraph == "Paragraph")
            {
                ProcessParserModelParagraphs(parse);
            }
            else
            {
                ProcessParserModelSentences(parse);
            }
            return View("Index", parse);
        }

        private static Dialect BindDialect(SimpleParserViewModel parse)
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

            if (parse.Numbers != null)
            {
                dialect.NumberType = parse.Numbers;
            }
            return dialect;
        }

        private static void ProcessParserModelParagraphs(SimpleParserViewModel parse)
        {
            Dialect dialect = BindDialect(parse);
            ParagraphSplitter ps = new ParagraphSplitter(dialect);

            StringBuilder normalizedSb = new StringBuilder();
            StringBuilder spitBackSb = new StringBuilder();
            StringBuilder bracketSb = new StringBuilder();
            StringBuilder posSb = new StringBuilder();
            StringBuilder glossSb = new StringBuilder();

            StringBuilder errors = new StringBuilder();
            StringBuilder colorized = new StringBuilder();

            HtmlFormatter hf = new HtmlFormatter();

            Prose prose;
            try
            {
                prose = ps.ParseProse(parse.SourceText);
            }
            catch (Exception ex)
            {
                //We CAN'T.
                ProcessParserModelSentences(parse);
                return;
            }


            foreach (Paragraph paragraph in prose.Paragraphs)
            {

                //////// TP
                try
                {
                    spitBackSb.AppendLine(paragraph.ToString("g", dialect).ToHtml() + "<br/>");
                }
                catch (Exception ex)
                {
                    string error = "[[CANNOT REPEAT BACK:  " + ex.Message + "]]";
                    spitBackSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                    //spitBackSb.AppendLine(hf.BoldTheWords(paragraph.ToHtml()) + "<br/>");
                    //UpdateErrors(errors, error, sentence);
                }

                try
                {
                    //string result = parsedSentence.ToString("html", dialect);
                    //if (result.Replace("<span", "").Contains("<"))
                    //{
                    //    throw new InvalidOperationException("No HTML allowed in input");
                    //}
                    colorized.AppendLine(paragraph.ToString("html", dialect) + "<br/>");
                }
                catch (Exception ex)
                {
                    string error = "[[CANNOT COLORIZE:  " + ex.Message + "]]";
                    spitBackSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                    //spitBackSb.AppendLine(hf.BoldTheWords(sentence.ToHtml()) + "<br/>");
                    //
                    //UpdateErrors(errors, error, sentence);
                }

                //////// TP
                try
                {
                    bracketSb.AppendLine(hf.BoldTheWords(paragraph.ToString("b", dialect).ToHtml()) + "<br/>");
                }
                catch (Exception ex)
                {
                    string error = "[[CANNOT BRACKET:  " + ex.Message + "]]";
                    bracketSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                    //bracketSb.AppendLine(hf.BoldTheWords(sentence.ToHtml()) + "<br/>");
                    //UpdateErrors(errors, error, sentence);

                }


                //////// ENGLISH
                try
                {
                    dialect.TargetGloss = "en";
                    GlossMaker gm = new GlossMaker();
                    string glossed = gm.GlossParagraph(paragraph, dialect);
                    glossSb.AppendLine(glossed.ToHtml() + "<br/>");
                    glossed = gm.GlossParagraph(paragraph, dialect, true);
                    posSb.AppendLine(glossed.ToHtml() + "<br/>"); //bs doesn't do anything.
                }
                catch (Exception ex)
                {
                    string error = "[[CANNOT GLOSS:  " + ex.Message.ToHtml() + "]]";
                    glossSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                    //glossSb.AppendLine(hf.BoldTheWords(sentence.ToHtml()) + "<br/>");

                    posSb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                    //posSb.AppendLine(hf.BoldTheWords(sentence.ToHtml()) + "<br/>");

                    //UpdateErrors(errors, error, sentence);
                }
                //}
                //catch (Exception ex)
                //{
                //    string error = "[[CANNOT Parse:  " + ex.Message.ToHtml() + "]]";

                //    foreach (StringBuilder sb in new StringBuilder[] { //normalizedSb,
                //        spitBackSb, bracketSb, posSb, glossSb, colorized })
                //    {
                //        sb.AppendLine(hf.BoldTheWords(error.ToHtml()) + "<br/>");
                //        sb.Append(sentence.ToHtml() + "<br/>");
                //    }

                //    UpdateErrors(errors, error, sentence);
                //}
                //finally
                //{
                //    dialect.TargetGloss = "tp";
                //}
            }

            parse.Normalized = normalizedSb.ToString();
            parse.Recovered = spitBackSb.ToString();
            parse.Formatted = bracketSb.ToString();
            parse.FormattedPos = hf.SubThePartsOfSpeech(posSb.ToString());
            parse.Glossed = glossSb.ToString();
            parse.Colorized = colorized.ToString();
            parse.Errors = errors.ToString();
        }

        private static void ProcessParserModelSentences(SimpleParserViewModel parse)
        {
            Dialect dialect = BindDialect(parse);

            ParserUtils pu = new ParserUtils(dialect);
            SentenceSplitter ss = new SentenceSplitter(dialect);
            Normalizer norm = new Normalizer(dialect);

            string[] sentences = ss.ParseIntoNonNormalizedSentences(parse.SourceText);
            StringBuilder normalizedSb = new StringBuilder();
            StringBuilder spitBackSb = new StringBuilder();
            StringBuilder bracketSb = new StringBuilder();
            StringBuilder posSb = new StringBuilder();
            StringBuilder glossSb = new StringBuilder();

            StringBuilder errors = new StringBuilder();
            StringBuilder colorized = new StringBuilder();

            HtmlFormatter hf = new HtmlFormatter();

            int i = 1;
            foreach (string sentence in sentences)
            {
                string lineNumber = LineNumber(i, true);
                string normalized;
                try
                {
                    normalized = norm.NormalizeText(sentence);
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
                normalizedSb.AppendLine(lineNumber + hf.BoldTheWords(normalized.ToHtml()) + "<br/>");

                try
                {
                    Sentence parsedSentence = pu.ParsedSentenceFactory(normalized, sentence);

                    //////// TP
                    try
                    {
                        spitBackSb.AppendLine(lineNumber + parsedSentence.ToString("g", dialect).ToHtml() + "<br/>");
                    }
                    catch (Exception ex)
                    {
                        string error = "[[CANNOT REPEAT BACK:  " + ex.Message + " for " + sentence + "]]";
                        spitBackSb.AppendLine(lineNumber + hf.BoldTheWords(error.ToHtml()) + "<br/>");
                        spitBackSb.AppendLine(lineNumber + hf.BoldTheWords(sentence.ToHtml()) + "<br/>");
                        UpdateErrors(errors, error, sentence);
                    }

                    try
                    {
                        //string result = parsedSentence.ToString("html", dialect);
                        //if (result.Replace("<span", "").Contains("<"))
                        //{
                        //    throw new InvalidOperationException("No HTML allowed in input");
                        //}
                        colorized.AppendLine(lineNumber + parsedSentence.ToString("html", dialect) + "<br/>");
                    }
                    catch (Exception ex)
                    {
                        string error = "[[CANNOT COLORIZE:  " + ex.Message + "]]";
                        spitBackSb.AppendLine(lineNumber + hf.BoldTheWords(error.ToHtml()) + "<br/>");
                        spitBackSb.AppendLine(lineNumber + hf.BoldTheWords(sentence.ToHtml()) + "<br/>");

                        UpdateErrors(errors, error, sentence);
                    }

                    //////// TP
                    try
                    {
                        bracketSb.AppendLine(lineNumber + hf.BoldTheWords(parsedSentence.ToString("b", dialect).ToHtml()) + "<br/>");
                    }
                    catch (Exception ex)
                    {
                        string error = "[[CANNOT BRACKET:  " + ex.Message + " for " + sentence + "]]";
                        bracketSb.AppendLine(lineNumber + hf.BoldTheWords(error.ToHtml()) + "<br/>");
                        bracketSb.AppendLine(lineNumber + hf.BoldTheWords(sentence.ToHtml()) + "<br/>");
                        UpdateErrors(errors, error, sentence);

                    }


                    //////// ENGLISH
                    try
                    {
                        dialect.TargetGloss = "en";
                        GlossMaker gm = new GlossMaker();
                        string glossed = gm.Gloss(normalized, sentence, "en", false);
                        glossSb.AppendLine(lineNumber + glossed.ToHtml() + "<br/>");
                        glossed = gm.Gloss(normalized, sentence, "en", true);
                        posSb.AppendLine(lineNumber + glossed.ToHtml() + "<br/>"); //bs doesn't do anything.
                    }
                    catch (Exception ex)
                    {
                        string error = "[[CANNOT GLOSS:  " + ex.Message.ToHtml() + " for " + sentence.ToHtml() + "]]";
                        glossSb.AppendLine(lineNumber + hf.BoldTheWords(error.ToHtml()) + "<br/>");
                        glossSb.AppendLine(lineNumber + hf.BoldTheWords(sentence.ToHtml()) + "<br/>");

                        posSb.AppendLine(lineNumber + hf.BoldTheWords(error.ToHtml()) + "<br/>");
                        posSb.AppendLine(lineNumber + hf.BoldTheWords(sentence.ToHtml()) + "<br/>");

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
                i++;
            }

            parse.Normalized = normalizedSb.ToString();
            parse.Recovered = spitBackSb.ToString();
            parse.Formatted = bracketSb.ToString();
            parse.FormattedPos = hf.SubThePartsOfSpeech(posSb.ToString());
            parse.Glossed = glossSb.ToString();
            parse.Colorized = colorized.ToString();
            parse.Errors = errors.ToString();
        }

        private static string LineNumber(int i, bool enabled)
        {
            if (enabled) return i + ". ";
            return "";
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
                    ,CorpusTexts.JanSin  
                    , CorpusTexts.RuneDanceSong
                    , CorpusTexts.janPusaRice
                    , CorpusTexts.janPend,
                    CorpusTexts.ProfesorAndMadMan
                    //"nena meli li suli la monsi li suli kin."
                };
            SimpleParserViewModel vm = new SimpleParserViewModel()
            {
                SourceText = samples[r.Next(samples.Length)]
            };
            ProcessParserModelSentences(vm);
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
                    ,CorpusTexts.JanSin  
                    ,CorpusTexts.RuneDanceSong
                    ,CorpusTexts.janPusaRice
                    ,CorpusTexts.janPend
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
            Normalizer norm = new Normalizer(dialect);
            SentenceSplitter ss = new SentenceSplitter(dialect);

            string[] sentences = ss.ParseIntoNonNormalizedSentences(parse.SourceText);

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
                    normalized = norm.NormalizeText(sentence);
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