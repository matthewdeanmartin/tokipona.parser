using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Compress;
using TpLogic.Corpus;


namespace TokiPona
{
    public partial class ReadingHelper : System.Web.UI.Page
    {
        private readonly Recode recoder = new Recode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DocumentPicker.DataSource = (new CorpusUtils()).Files();
                DocumentPicker.DataTextField = "value";
                DocumentPicker.DataValueField = "key";
                DocumentPicker.DataBind();

                txtInput.Text = SampleText.Anything();
                btnGloss_Click(this, new EventArgs());
            }
        }

        protected void btnGloss_Click(object sender, EventArgs e)
        {
            string toConvert = Server.HtmlEncode(txtInput.Text);

            Dictionary<string, string> words = Recode.GetDictionary();
            Dictionary<string, string> links = new Dictionary<string, string>(words.Count);
            foreach (var word in words)
            {
                links.Add(word.Key, string.Format("<a href=\"ClassicWordList.aspx#{0}\">{0}</a>",word.Key));
            }

            txtOutput.Text= recoder.ShortenToAnyDictionary(
                toConvert,
                links,
                Recode.ModifierStyle.CapitalizeFirst,
                Recode.PunctuationStyle.Western
                ).Replace("\n", "<br/>");
        }


        protected override void OnInit(EventArgs e)
        {
            DocumentPicker.SelectedIndexChanged += DocumentPickerSelectedIndexChanged;
            base.OnInit(e);
        }

        private void DocumentPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if(((DropDownList) sender).SelectedValue=="Default")
            {
                btnGloss_Click(this, new EventArgs());
                return;
            }
            
            FileInfo file = CorpusUtils.CreateFileInfo(((DropDownList)sender).SelectedValue); 
            
            using (StreamReader reader = file.OpenText())
            {
                txtInput.Text = reader.ReadToEnd();
                btnGloss_Click(this, new EventArgs());
            }
        }
    }
}