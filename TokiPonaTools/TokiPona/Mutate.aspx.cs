using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Compress;
using TpLogic.Corpus;

namespace TokiPona
{
    public partial class Mutate : System.Web.UI.Page
    {
        Random ran = new Random(DateTime.Now.Millisecond);

        protected void Page_Load(object sender, EventArgs args)
        {
            if (!Page.IsPostBack)
            {
                txtInput.Text = SampleText.Anything();

                //aeiou
                //jklmnpstw
                //Random letters
                SimpleRandomAssignment();

                Degenerate_Click(this,new EventArgs());
            }
        }

        private void SimpleRandomAssignment()
        {
            string consonants = "bcdfghjklmnpqrstvwxyz";

            SetUp(j, ref consonants);
            SetUp(k, ref consonants);
            SetUp(l, ref consonants);
            SetUp(m, ref consonants);
            SetUp(n, ref consonants);
            SetUp(p, ref consonants);
            SetUp(s, ref consonants);
            SetUp(t, ref consonants);
            SetUp(w, ref consonants);

            string vowels = "aeiou";
            SetUp(a, ref vowels);
            SetUp(e, ref vowels);
            SetUp(i, ref vowels);
            SetUp(o, ref vowels);
            SetUp(u, ref vowels);
        }

        private void SetUp(TextBox box, ref string consonants)
        {
            char next = consonants[ran.Next(0, consonants.Length - 1)];
            box.Text = next.ToString();
            consonants = consonants.Replace(next.ToString(), "");
        }

        protected void Degenerate_Click(object sender, EventArgs args)
        {
            //Transform
            Dictionary<string,string> words = Recode.GetDictionary();
            Dictionary<char,string> alphabet = new Dictionary<char, string>();
            alphabet.Add('a',HttpUtility.HtmlEncode(a.Text));
            alphabet.Add('e', HttpUtility.HtmlEncode(e.Text));
            alphabet.Add('i', HttpUtility.HtmlEncode(i.Text));
            alphabet.Add('o', HttpUtility.HtmlEncode(o.Text));
            alphabet.Add('u', HttpUtility.HtmlEncode(u.Text));
            alphabet.Add('j', HttpUtility.HtmlEncode(j.Text));
            alphabet.Add('k', HttpUtility.HtmlEncode(k.Text)); 
            alphabet.Add('l', HttpUtility.HtmlEncode(l.Text)); 
            alphabet.Add('m', HttpUtility.HtmlEncode(m.Text));
            alphabet.Add('n', HttpUtility.HtmlEncode(n.Text));
            alphabet.Add('p', HttpUtility.HtmlEncode(p.Text));
            alphabet.Add('s', HttpUtility.HtmlEncode(s.Text));
            alphabet.Add('t', HttpUtility.HtmlEncode(t.Text));
            alphabet.Add('w', HttpUtility.HtmlEncode(w.Text));
                       

            Dictionary<string,string> mutated = new Dictionary<string, string>(words.Count);
            foreach(string key in words.Keys)
            {
                StringBuilder sb = new StringBuilder();
                foreach(char c in key)
                {
                    sb.Append(alphabet[c]);
                }
                mutated.Add(key,sb.ToString());
            }

            var sortedDict = (from entry in mutated orderby entry.Value ascending select entry);
            

            StringBuilder newWordList = new StringBuilder();
            foreach (var pair in sortedDict)
            {
                newWordList.Append("<b>");
                newWordList.Append(pair.Key);
                newWordList.Append("</b> : ");
                newWordList.Append(pair.Value);
                newWordList.Append("<br/>");
            }
            txtOutput.Text = newWordList.ToString();

            Recode recoder = new Recode();
            txtSampleText.Text= recoder.ShortenToAnyDictionary(
                HttpUtility.HtmlEncode(txtInput.Text), 
                mutated,Recode.ModifierStyle.CapitalizeFirst, Recode.PunctuationStyle.Western                
                ).Replace("\n","<br/>");
            //Apply common processes (reduplicatoin, gemmination, errosion, rebracketing)
            //Check for validity
            //Re-do if invalid
        }

        protected void NewMapping_Click(object sender, EventArgs e)
        {
            SimpleRandomAssignment();
        }
    }
}
