using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Orthography;

namespace TokiPona
{
    public partial class SpellWords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                this.txtInput.Text = "soweli";
                btnSpell_Click(this,new EventArgs());
            }
        }

        protected void btnSpell_Click(object sender, EventArgs e)
        {
            string toConvert = Server.HtmlEncode(txtInput.Text);
            txtEnglish.Text = Spell.SpellEnglishOnly(toConvert).Replace("-", ", ");
            txtGreek.Text = Spell.SpellGreek(toConvert).Replace("-", ", ");
            txtMilitary.Text = Spell.SpellMilitary(toConvert);
        }
    }
}
