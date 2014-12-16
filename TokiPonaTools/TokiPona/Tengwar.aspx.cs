using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Compress;
using TpLogic.Corpus;

namespace TokiPona
{
    public partial class Tengwar : System.Web.UI.Page
    {
        private void DocumentPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if (((DropDownList)sender).SelectedValue == "Default")
            {
                btnConvert_Click(this, new EventArgs());
                return;
            }

            FileInfo file = CorpusUtils.CreateFileInfo(((DropDownList)sender).SelectedValue);

            using (StreamReader reader = file.OpenText())
            {
                txtInput.Text = reader.ReadToEnd();
                btnConvert_Click(this, new EventArgs()); 
            }
        }

        protected override void OnInit(EventArgs e)
        {
            DocumentPicker.SelectedIndexChanged += DocumentPickerSelectedIndexChanged;
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DocumentPicker.DataSource = (new CorpusUtils()).Files();
                DocumentPicker.DataTextField = "value";
                DocumentPicker.DataValueField = "key";
                DocumentPicker.DataBind();

                txtInput.Text = SampleText.Anything();
                btnConvert_Click(this, new EventArgs());
            }
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            TengwarMaker maker = new TengwarMaker();
            maker.sb.Clear();
            maker.Convert(HttpUtility.HtmlEncode(txtInput.Text));
            txtOutput.Text = maker.sb.ToString().Replace("\n","<br/>");
        }

        
    }
}
