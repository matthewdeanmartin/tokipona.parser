using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Compress;
using TpLogic.Corpus;

namespace TokiPona
{
    public partial class SitelenSuwi : System.Web.UI.Page
    {
        private Recode recoder = new Recode();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtInput.Text = SampleText.Anything();
                btnCompress_Click(this, new EventArgs());
            }
        }

        protected void btnCompress_Click(object sender, EventArgs e)
        {
            string toConvert = Server.HtmlEncode(txtInput.Text);

            images.InnerHtml = recoder.ShortenToAnyDictionary(
            HttpUtility.HtmlEncode(toConvert),
            Recode.GetHeiroglyphDictionary(),
            Recode.ModifierStyle.CapitalizeFirst, Recode.PunctuationStyle.Western                
            ).Replace("\n","<br/>");
        }
    }
}
