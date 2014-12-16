using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Compress;

namespace TokiPona
{
    public partial class DomainNames : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string,string> allWords= Recode.GetDictionary();
            StringBuilder sb = new StringBuilder();
            foreach(var word in allWords )
            {
                if(word.Key.Length>3)
                {
                    sb.Append("<tr>");
                    sb.Append("<td><a href=\"http://" + word.Key + ".com\">" + word.Key + ".com</a>");
                    string domain = word.Key + ".com";
                    try
                    {
                        //performs the DNS lookup
                        IPHostEntry he =  Dns.GetHostByName(domain);
                        IPAddress[] ip_addrs = he.AddressList;
                        foreach (IPAddress ip in ip_addrs)
                        {
                            sb.Append(ip);
                            sb.Append("<br/>");
                        }
                    }
                    catch (System.Exception ex)
                    {
                        sb.Append(ex.ToString());
                    }
                    sb.Append("</td>");

                    sb.Append("<td><a href=\"http://" + word.Key + ".org\">" + word.Key + ".org</a>");
                    domain = word.Key + ".org";
                    try
                    {
                        //performs the DNS lookup
                        IPHostEntry he = Dns.GetHostByName(domain);
                        IPAddress[] ip_addrs = he.AddressList;
                        foreach (IPAddress ip in ip_addrs)
                        {
                            sb.Append(ip);
                            sb.Append("<br/>");
                        }
                    }
                    catch (System.Exception ex)
                    {
                        sb.Append(ex.ToString());
                    }
                    sb.Append("</td>");
                    sb.Append("<td><a href=\"http://" + word.Key + ".net\">" + word.Key + ".net</a>");
                    domain = word.Key + ".net";
                    try
                    {
                        //performs the DNS lookup
                        IPHostEntry he = Dns.GetHostByName(domain);
                        IPAddress[] ip_addrs = he.AddressList;
                        foreach (IPAddress ip in ip_addrs)
                        {
                            sb.Append(ip);
                            sb.Append("<br/>");
                        }
                    }
                    catch (System.Exception ex)
                    {
                        sb.Append(ex.ToString());
                    }
                    sb.Append("</td>");
                    sb.Append("<td><a href=\"http://" + word.Key + ".info\">" + word.Key + ".info</a>");
                    domain = word.Key + ".info";
                    try
                    {
                        //performs the DNS lookup
                        IPHostEntry he = Dns.GetHostByName(domain);
                        
                        IPAddress[] ip_addrs = he.AddressList;
                        foreach (IPAddress ip in ip_addrs)
                        {
                            sb.Append(ip);
                            sb.Append("<br/>");
                            break;//one is fine..
                        }
                    }
                    catch (System.Exception)
                    {
                        sb.Append("No DNS Entry");
                    }
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                
            }
            this.rows.Text = sb.ToString();
        }
    }
}