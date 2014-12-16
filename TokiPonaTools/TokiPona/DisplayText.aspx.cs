using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Corpus;
using TpLogic.Compress;
using System.IO;

// for Split, GroupBy, Select, OrderBy, etc.

namespace TokiPona
{
    public partial class DisplayText : System.Web.UI.Page
    {
        private Dictionary<string, string> ColorizedText()
        {
            Dictionary<string, string> dictionary = Recode.GetDictionary();
            Dictionary<string, string> dictionaryOut = new Dictionary<string, string>();
            foreach (string word in dictionary.Keys)
            {
                string formated;
                if ((from c in new string[] { "la", "li", "e", "o", "pi" }
                     where word == c
                     select c).Count() == 1)
                {
                    //Is thingy.
                    formated = "<span class=\"function\">" + word + "</span>";
                }
                else if ((from c in new string[] { "ni", "ona", "mi", "sina" }
                     where word == c
                     select c).Count() == 1)
                {
                    formated = "<span class=\"anaphora\">" + word + "</span>";
                }
                else if(word=="anu"||word=="en")
                {
                    formated = "<span class=\"conjunction\">" + word + "</span>";
                }
                else if (PrepositionStyle.SelectedValue == "do"
                    && (from c in new string[] { "kepeken", "poka", "lon", "tawa", "sama", "tan" }
                        where word == c
                        select c).Count() == 1)
                {
                    formated = "<span class=\"prep\">" + word + "</span>";
                }
                else
                {
                    formated = "<span class=\"content\">" + word + "</span>";
                }

                dictionaryOut.Add(word, formated);
            }
            return dictionaryOut;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if(Request.QueryString["file"]!=null)
                {
                    FileInfo file = CorpusUtils.CreateFileInfo("\\" + Request.QueryString["file"].Replace("..", ""));
                    if(file.Exists)
                    {
                        ColorizeThisFile(file);
                        InstructionPanel.Visible = false;
                        return;
                    }
                    
                }
                DocumentPicker.DataSource = (new CorpusUtils()).Files();
                DocumentPicker.DataTextField = "value";
                DocumentPicker.DataValueField = "key";
                DocumentPicker.DataBind();

                //Colorize(SampleText.Giraffe());
                DocumentPickerSelectedIndexChanged(DocumentPicker, new EventArgs());
            }
        }

        protected override void OnInit(EventArgs e)
        {
            DocumentPicker.SelectedIndexChanged += DocumentPickerSelectedIndexChanged;
            base.OnInit(e);
        }

        private void DocumentPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            ColorizeThisFile(CorpusUtils.CreateFileInfo(((DropDownList)sender).SelectedValue));
        }

        private void ColorizeThisFile(FileInfo file)
        {
            using (StreamReader reader = file.OpenText())
            {
                Colorize(reader.ReadToEnd());
            }
        }

        private void Colorize(string value)
        {
            Recode c = new Recode();
            CorpusText.Text =
            c.ShortenToAnyDictionary(
                value,
                ColorizedText(),
                Recode.ModifierStyle.CapitalizeFirst,
                Recode.PunctuationStyle.Western,
                "<span class=\"proper\">",
                "</span>"
                ).Replace(Environment.NewLine, "<br/>").Replace("\n", "<br/>");
            Graph.Text =  "\n" +
                CreateGraph(value);
        }

        //Source
        //http://stackoverflow.com/questions/3169051/code-golf-word-frequency-chart
        private string CreateGraph(string text)  // must define a Main
        {
            StringBuilder sb = new StringBuilder();
            // split into words
            var allwords = System.Text.RegularExpressions.Regex.Split(
                // convert stdin to lowercase
                text.ToLower(),
                // eliminate stopwords and non-letters
                @"(\W)+")
                .Where(x => x.ToString().Trim() != "")
                .GroupBy(x => x) // group by words
                .OrderBy(x => -x.Count()) // sort descending by count
                .Take(200); // take first 22 words

            // compute length of longest bar + word
            var lendivisor = allwords.Max(y => y.Count() / (76.0 - y.Key.Length));

            // prepare text to print
            var toPrint = allwords.Select(x =>
                new
                {
                    // remember bar pseudographics (will be used in two places)
                    Bar = new string('_', (int)(x.Count() / lendivisor)),
                    Word = x.Key
                })
                .ToList();  // convert to list so we can index into it

            // print top of first bar
            sb.Append(" " + toPrint[0].Bar + "\n");

            toPrint.ForEach(x =>  // for each word, print its bar and the word
                sb.Append("|" + x.Bar + "| " + x.Word + "\n"));
            return sb.ToString();
        }

    }
}