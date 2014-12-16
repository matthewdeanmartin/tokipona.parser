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
    public partial class Compress : System.Web.UI.Page
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
            string toConvert=Server.HtmlEncode(txtInput.Text);

            string result;
            result = recoder.Shorten(toConvert);
            result += "<br/><br/>" + result.Replace(" ", "").Trim().Replace("\n", "<br/>"); ;
            txtOutput.Text = result;

            result = recoder.ShortenToJapanese2(toConvert);
            result += "<br/><br/>" + result.Replace(" ", "").Trim().Replace("\n", "<br/>"); ;
            txtJapanese.Text = result;

            result = recoder.ShortenToChinese(toConvert);
            result += "<br/><br/>" + result.Replace(" ", "").Trim().Replace("\n", "<br/>"); ;
            txtChinese.Text = result;

            result = recoder.ShortenToUnicode(toConvert);
            result += "<br/><br/>" + result.Replace(" ", "").Trim().Replace("\n", "<br/>"); ;
            txtUnicode.Text = result;
            outputSection.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string toConvert= Server.HtmlEncode(txtInput.Text);
            txtOutput.Text = recoder.ExpandTwoLetterWithSpaces(toConvert);
            outputSection.Visible = true;

            txtJapanese.Text = recoder.ExpandJapanese(toConvert);
            txtChinese.Text = recoder.ExpandChinese(toConvert);
            txtUnicode.Text = recoder.ExpandUnicode(toConvert);
            outputSection.Visible = true;
        }
    }
}
