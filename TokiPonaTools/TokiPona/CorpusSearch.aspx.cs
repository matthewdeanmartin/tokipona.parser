using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Corpus;

namespace TokiPona
{
    public partial class CorpusSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["word"]!=null)
                {
                    search.Text = @"\b" + HttpUtility.HtmlEncode(Request.QueryString["word"]).Trim() + @"\b";
                    searchCommand_Click(this,new EventArgs());
                }
            }
        }

        protected void searchCommand_Click(object sender, EventArgs e)
        {
            Output.Text = "";

            string command = search.Text;
            if (command.Length > 50)
            {
                Output.Text = "Command is 50 characters or longer. I won't run it.";
                return;
            }

            StringBuilder sb = new StringBuilder();
            string[] directories= Directory.GetDirectories(Server.MapPath(@"corpus"));

            int theCount = 0;
            int fileCount = 0;
            int rowCount = 0;
            for (int i =0;i<directories.Length;i++)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directories[i]);

                fileCount = ProcessDirectory(directoryInfo, fileCount, ref rowCount,  sb, theCount);
            }

            DisplayOutput(fileCount, rowCount, sb);  
        }

        private int ProcessDirectory(DirectoryInfo directoryInfo, int fileCount, ref int rowCount, StringBuilder sb, int theCount)
        {
            if (directoryInfo.FullName.Contains("_svn")) return fileCount;

            string query = search.Text;

            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                //Recursion going on here...
                fileCount += ProcessDirectory(subDirectory, fileCount, ref rowCount, sb, theCount);
            }

            FileInfo[] fileInfos= directoryInfo.GetFiles();
            foreach(FileInfo file in fileInfos)
            {
                if ((file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    continue;
                if (file.FullName.Contains(("_svn")))
                    continue;

                fileCount++;
                using (StreamReader reader = file.OpenText())
                {
                    string row = reader.ReadLine();
                    while (row != null)
                    {
                        rowCount++;

                        Regex ex = new Regex(query, RegexOptions.None);
                        MatchCollection found = ex.Matches(row);


                        if (found.Count > 0)
                        {
                            sb.Append("<br/><b>");
                            //sb.Append("<a href=\"corpus");//Plain text

                            //corpus\\forums\jan Mato\(C) Stulkan sem starir a hafid.txt
                            sb.Append("<a href=\"DisplayText.aspx?file=");
                            string[] splitOn = new []{"corpus"};
                            sb.Append(file.FullName.Split(splitOn,StringSplitOptions.RemoveEmptyEntries)[1]);
                            sb.Append("\">");
                            sb.Append(CorpusUtils.ExtractTitle(file.Name));
                            sb.Append("</a> ");
                            sb.Append(" by ");
                            sb.Append(CorpusUtils.ExtractAuthor(file.DirectoryName));
                            sb.Append("</b><br/>");
                                
                            foreach (var foo in found)
                            {
                                theCount++;
                                sb.Append("<b>");
                                sb.Append(foo.ToString());
                                sb.Append("</b>: ");
                                    
                            }
                            sb.Append(row);
                            sb.Append("<br/>");

                            if (theCount > 100)
                            {
                                DisplayOutput(fileCount, rowCount, sb);
                                return fileCount;
                            }
                        }
                        row = reader.ReadLine();
                    }
                }
            }
            return fileCount;
        }

        

        private void DisplayOutput(int fileCount, int rowCount, StringBuilder sb)
        {
            sb.Insert(0,string.Format("<h2>Files Processed {0}, Rows Processed {1}</h2>", fileCount, rowCount));

            Output.Text = sb.ToString();
        }
    }
}