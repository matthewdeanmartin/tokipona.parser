using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokiPona
{
    public partial class GlossAnything : System.Web.UI.Page
    {
        private Dictionary<string, string> dictionary = new Dictionary<string, string>();

        public string Doit(string sentence)
        {
            StringBuilder untranslated = new StringBuilder();
            StringBuilder translatedGloss = new StringBuilder();
            int blocks = 0;
            string[] strArrays = this.Tokenize(sentence);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string word = strArrays[i];
                int longest = word.Length;
                string translated = this.Translate(word);
                if (translated.Length > longest)
                {
                    longest = translated.Length;
                }
                int segment = longest + 3;
                translatedGloss.Append(translated.PadRight(segment, ' '));
                untranslated.Append(word.PadRight(segment, ' '));
                blocks++;
            }
            string[] str = new string[] { untranslated.ToString(), "\n", translatedGloss.ToString(), "\n", this.fluidTranslation.Text };
            return string.Concat(str);
        }

        public string GlossItLikeList(string sentence)
        {
            StringBuilder translatedGloss = new StringBuilder("<ul class=\"word_spacing_list\">");
            StringBuilder untranslated = new StringBuilder("<ul class=\"word_spacing_list_top\">");
            int blocks = 0;
            string[] strArrays = this.Tokenize(sentence);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string word = strArrays[i];
                int longest = word.Length;
                string translated = this.Translate(word);
                if (translated.Length > longest)
                {
                    longest = translated.Length;
                }
                int segment = longest + 3;
                string boxWith = "70";
                if (segment < 4)
                {
                    boxWith = "30";
                }
                else if (segment < 8)
                {
                    boxWith = "40";
                }
                else if (segment < 10)
                {
                    boxWith = "60";
                }
                else if (segment < 12)
                {
                    boxWith = "80";
                }
                else if (segment < 15)
                {
                    boxWith = "90";
                }
                translatedGloss.Append(string.Concat("<li class=\"w", boxWith, "\">"));
                translatedGloss.Append(translated);
                translatedGloss.Append("</li>\n");
                untranslated.Append(string.Concat("<li class=\"w", boxWith, "\">"));
                untranslated.Append(word);
                untranslated.Append("</li>\n");
                blocks++;
            }
            string[] str = new string[] { untranslated.ToString(), "</ul>\n", translatedGloss.ToString(), "</ul>\n<p class=\"word_spacing_list_clearing\">", this.fluidTranslation.Text, "</p>" };
            return string.Concat(str);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string sentence = this.inputText.Text;
            if (string.IsNullOrEmpty(this.dictionaryText.Text))
            {
                StringBuilder blankDictionary = new StringBuilder();
                string[] strArrays = this.Tokenize(sentence);
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    blankDictionary.Append(strArrays[i]);
                    blankDictionary.Append(",\n");
                }
                this.dictionaryText.Text = blankDictionary.ToString();
            }
            this.glossBox.Text = this.Doit(sentence);
            this.nonPreGlossBox.Text = this.TableGloss(sentence);
            this.GlossAsList.Text = this.GlossItLikeList(sentence);
        }

        protected void ShowHtml(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.ID == "ShowUl")
            {
                this.Session["GlossHtml"] = this.GlossAsList.Text;
            }
            if (button.ID == "ShowTable")
            {
                this.Session["GlossHtml"] = this.nonPreGlossBox.Text;
            }
            if (button.ID == "ShowPre")
            {
                this.Session["GlossHtml"] = string.Concat("<pre>", this.glossBox.Text, "</pre>");
            }
            base.Response.Redirect("GlossAnythingDisplay.aspx");
        }

        public string TableGloss(string sentence)
        {
            StringBuilder untranslatedTable = new StringBuilder("<tr>");
            StringBuilder translatedGlossTable = new StringBuilder("<tr>");
            int blocks = 0;
            string[] strArrays = this.Tokenize(sentence);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string word = strArrays[i];
                int longest = word.Length;
                string translated = this.Translate(word);
                if (translated.Length > longest)
                {
                    longest = translated.Length;
                }
                untranslatedTable.Append(" <td  align=\"left\">");
                untranslatedTable.Append(word);
                untranslatedTable.Append("</td>\n");
                translatedGlossTable.Append("  <td  align=\"left\">");
                translatedGlossTable.Append(translated);
                translatedGlossTable.Append("</td>\n");
                blocks++;
            }
            object[] str = new object[] { "<table border=\"0\">\r\n", untranslatedTable.ToString(), "</tr>\n", translatedGlossTable.ToString(), "</tr><tr><td colspan=\"", blocks, "\">", this.fluidTranslation.Text, "</td>\n</tr>\n</table>" };
            return string.Concat(str);
        }

        private string[] Tokenize(string sentence)
        {
            string[] strArrays = new string[] { " ", "\n" };
            return sentence.Split(strArrays, StringSplitOptions.RemoveEmptyEntries);
        }

        public string Translate(string word)
        {
            string str;
            string[] strArrays = this.Tokenize(this.dictionaryText.Text);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string entry = strArrays[i];
                string[] strArrays1 = new string[] { "," };
                string[] parts = entry.Split(strArrays1, StringSplitOptions.RemoveEmptyEntries);
                if (!this.dictionary.Keys.Contains<string>(parts[0]))
                {
                    if ((int)parts.Length >= 2)
                    {
                        Dictionary<string, string> strs = this.dictionary;
                        string str1 = parts[0];
                        char[] chrArray = new char[] { ' ', '\n' };
                        string str2 = str1.Trim(chrArray);
                        string str3 = parts[1];
                        chrArray = new char[] { ' ', '\n' };
                        strs.Add(str2, str3.Trim(chrArray));
                    }
                }
            }
            str = (!this.dictionary.Keys.Contains<string>(word) ? "n/a" : this.dictionary[word].Trim());
            return str;
        }
    }
}