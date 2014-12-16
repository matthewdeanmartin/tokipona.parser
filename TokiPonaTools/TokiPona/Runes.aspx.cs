using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Corpus;

namespace TokiPona
{
    public partial class Runes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtInput.Text = SampleText.Song();
                btnConvert_Click(this, new EventArgs());
            }
        }

        protected void btnConvert_Click(object sender, EventArgs e)
        {
            if (this.RuneOptions.SelectedValue == "all")//vs. "some"
            {
                error.Text = "Sorry, we haven't worked out the correspondences yet.";
                txtOutput.Text = "";
                return;
            }

            Dictionary<char,char> letters = new Dictionary<char, char>();
            letters.Add('a','\u16A8');
            letters.Add('e','\u16D6');//
            letters.Add('i', '\u16C1');//
            letters.Add('o', '\u16DF');//
            letters.Add('u', '\u16A2');//
            letters.Add('j', '\u16C3');//
            letters.Add('k', '\u16B2');//
            letters.Add('l', '\u16DA');//
            letters.Add('m', '\u16D7');//
            letters.Add('n', '\u16BE');//
            letters.Add('p', '\u16C8');//
            letters.Add('s', '\u16CA');//
            letters.Add('t', '\u16CF');//
            letters.Add('w', '\u16B9');//
            letters.Add('.', '\u16EB');//
            letters.Add(':', '\u16EC');//
            letters.Add('+', '\u16ED');//


            string start =HttpUtility.HtmlEncode(txtInput.Text);
            
            StringBuilder sb =new StringBuilder();
            foreach(char c in start)
            {
                if(letters.ContainsKey(c))
                {
                    sb.Append(letters[c]);
                }
                else
                {
                    sb.Append(c);
                }
            }
            txtOutput.Text = sb.ToString().Replace("\n","<br/>");
        }
    }
}
