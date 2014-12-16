using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Compress;
using TpLogic.Corpus;

namespace TokiPona
{
    public partial class Relex : Page
    {
        private readonly Recode recoder = new Recode();

        protected override void OnInit(EventArgs e)
        {
            DocumentPicker.SelectedIndexChanged += DocumentPickerSelectedIndexChanged;
            base.OnInit(e);
        }

        void DocumentPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if(((DropDownList) sender).SelectedValue=="Default")
            {
                btnCompress_Click(this, new EventArgs());
                return;
            }
            
            FileInfo file = CorpusUtils.CreateFileInfo(((DropDownList)sender).SelectedValue); 
            
            using (StreamReader reader = file.OpenText())
            {
                txtInput.Text = reader.ReadToEnd();
                btnCompress_Click(this, new EventArgs());
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DocumentPicker.DataSource = (new CorpusUtils()).Files();
                DocumentPicker.DataTextField = "value";
                DocumentPicker.DataValueField = "key";
                DocumentPicker.DataBind();

                txtInput.Text = SampleText.Anything();
                btnCompress_Click(this, new EventArgs());
            }
        }

        protected void TargetLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCompress_Click(this, new EventArgs());
        }

        protected void btnCompress_Click(object sender, EventArgs e)
        {
            string toConvert = Server.HtmlEncode(txtInput.Text);

            Dictionary<string, string> target;

            if(TargetLanguage.SelectedValue=="Latin")
            {
                target = Recode.GetLatinRelex();
            }
            else if(TargetLanguage.SelectedValue=="Russian")
            {
                target = Recode.GetRussianRelex();
            }
            else if (TargetLanguage.SelectedValue == "Icelandic")
            {
                target = Recode.GetIcelandicRelex();
            }
            else
            {
                target = Recode.GetEnglishRelex();
            }

            StringBuilder sb = new StringBuilder();
            foreach(var foo in target)
            {
                sb.Append(foo.Key.ToLower());
                sb.Append( "\t");
                sb.Append( foo.Value);
                sb.Append("\n");
            }
            RelexDictionary.Controls.Add(new Literal { Text = sb.ToString()});
            string relexFirstPass=recoder.ShortenToAnyDictionary(
                toConvert,
                target, 
                Recode.ModifierStyle.CapitalizeFirst, 
                Recode.PunctuationStyle.Western
                ).Replace("\n", "<br/>");

            if(phonotactics.SelectedValue=="forceTp")
            {
                TransliterateEngine transliterator = new TransliterateEngine();
                string trace;
                relexFirstPass = transliterator.Transliterate(
                    relexFirstPass, 
                    out trace, 
                    TransliterateEngine.DefaultOptions()).ToLower();
            }
            
            
            txtOutput.Text = relexFirstPass;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string toConvert = Server.HtmlEncode(txtInput.Text);
            //txtOutput.Text = recoder.ExpandTwoLetterWithSpaces(toConvert);

        }
    }
}
