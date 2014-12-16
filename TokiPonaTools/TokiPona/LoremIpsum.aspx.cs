using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic;

namespace TokiPona
{
    public partial class LoremIpsum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Generate_Click(this, new EventArgs());
        }

        protected void Generate_Click(object sender, EventArgs e)
        {
            LoremIpsumGenerator lig = new LoremIpsumGenerator(DateTime.Now.Millisecond);
            Output.Text= lig.Generate(30);

        }
    }
}
