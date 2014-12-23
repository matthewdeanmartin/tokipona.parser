using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokiPona
{
    public partial class Tour : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.ToString().ToUpper().Contains("Default.aspx".ToUpper()))
            {
                Visible = true;
                return;
            }
            if (Request.Url.ToString().ToUpper().Contains("Tour0".ToUpper()))
            {
                Visible = true;
                return;
            }
            if (Request.QueryString["Tour"]==null)
            {
                Visible = false;
                return;
            }
            Visible = Request.QueryString["Tour"].ToUpper() =="true".ToUpper();
            
            
        }
    }
}