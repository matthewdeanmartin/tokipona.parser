using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TokiPona
{
    public partial class Numbers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i<1000; i++)
            {
                int remainder = i;
                string nanpa="";
                string equation = "";

                string roman = "";

                while(remainder>0)
                {
                    if (remainder - 100 > 0)
                    {
                        nanpa = nanpa + " ala";
                        equation += "+ 100";
                        roman += "A";
                    }
                    else
                    {
                        break;
                    }
                    remainder = remainder - 100;
                }

                while(remainder>0)
                {
                    if (remainder - 20 > 0)
                    {
                        nanpa = nanpa + " mute";
                        equation += "+ 20 ";
                        roman += "M";
                    }
                    else
                    {
                        break;
                    }
                    remainder = remainder - 20;
                }

                while(remainder>0)
                {
                    if (remainder - 5 > 0)
                    {
                        nanpa = nanpa + " luka";
                        equation += "+ 5 ";
                        roman += "L";
                    }
                    else
                    {
                        break;
                    }
                    remainder = remainder - 5;
                }

                while (remainder > 0)
                {
                    if (remainder - 2 > 0)
                    {
                        nanpa = nanpa + " tu";
                        equation += "+ 2 ";
                        roman += "T";
                    }
                    else
                    {
                        break;
                    }
                    remainder = remainder - 2;
                }

                while(remainder>0)
                {
                    if (remainder - 1 > 0)
                    {
                        nanpa = nanpa + " wan";
                        equation += "+ 1 ";
                        roman += "W";
                    }
                    else
                    {
                        break;
                    }
                    remainder = remainder - 1;
                }

                if(i==1)
                {
                    nanpa = "ali";
                    equation = "+ 0";
                    roman += "";
                }
                this.OutText.Text += i-1 + ": " + nanpa + "  = " + equation.Substring(1) +  ", " + roman+ "<br/>";
            }


        }
    }
}
