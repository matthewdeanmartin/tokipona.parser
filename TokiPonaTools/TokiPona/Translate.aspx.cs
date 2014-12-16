using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokiPona
{
    public partial class Translate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            Load += Page_Load;
            DoTranslation.Click += new EventHandler(DoTranslation_Click);
            base.OnInit(e);
        }

        void DoTranslation_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
