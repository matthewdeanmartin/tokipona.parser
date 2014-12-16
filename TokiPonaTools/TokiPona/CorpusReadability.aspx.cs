using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TpLogic.Corpus;
using TpLogic.Readability;

namespace TokiPona
{
    public partial class CropusReadability : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Process();
        }

        private void Process()
        {
            StringBuilder sb = new StringBuilder();
            string[] directories = Directory.GetDirectories(Server.MapPath(@"corpus"));

            int theCount = 0;
            int fileCount = 0;
            int rowCount = 0;
            for (int i = 0; i < directories.Length; i++)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directories[i]);

                fileCount = ProcessDirectory(directoryInfo, fileCount, ref rowCount, sb, theCount);
            }

            Output.Text = sb.ToString();
        }

        private int ProcessDirectory(DirectoryInfo directoryInfo, int fileCount, ref int rowCount, StringBuilder sb, int theCount)
        {
            if (directoryInfo.FullName.Contains("_svn") || directoryInfo.FullName.Contains(".svn")) return fileCount;
            //string query = search.Text;

            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                //Recursion going on here...
                fileCount += ProcessDirectory(subDirectory, fileCount, ref rowCount, sb, theCount);
            }

            FileInfo[] fileInfos = directoryInfo.GetFiles();
            foreach (FileInfo file in fileInfos)
            {
                if ((file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    continue;
                if (file.FullName.Contains("_svn") || file.FullName.Contains(".svn"))
                    continue;

                fileCount++;
                using (StreamReader reader = file.OpenText())
                {
                    string row = reader.ReadToEnd();

                    if (row == null)
                    {
                        continue;
                    }

                    sb.Append("<tr><td>");
                    sb.Append("<a href=\"DisplayText.aspx?file=");
                    string[] splitOn = new[] { "corpus" };
                    sb.Append(file.FullName.Split(splitOn, StringSplitOptions.RemoveEmptyEntries)[1]);
                    sb.Append("\">");
                    sb.Append(CorpusUtils.ExtractTitle(file.Name));
                    sb.Append("</a></td><td>");
                    sb.Append(CorpusUtils.ExtractAuthor(file.DirectoryName));
                    sb.Append("</td>");

                    //metrics

                    Metrics metrics= MetricsCalculator.Calculate(row);
                    sb.Append("<td>");
                    sb.Append(string.Format("{0:0.0}",metrics.ComplexNounPhrasePercent));
                    sb.Append("</td><td>");
                    sb.Append(string.Format("{0:0.0}", metrics.CoordinatingPercent));
                    sb.Append("</td><td>");
                    sb.Append(string.Format("{0:0.0}", metrics.FunctionWordPercent));
                    sb.Append("</td><td>");
                    sb.Append(string.Format("{0:0.0}", metrics.ProperModiferPercent));
                    sb.Append("</td><td>");
                    sb.Append(string.Format("{0:0.0}", metrics.WordsPerSentence));
                    sb.Append("</td><td>");

                    double composite =
                        (metrics.WordsPerSentence/9.5
                         +
                         metrics.ProperModiferPercent/.5
                         +
                         metrics.FunctionWordPercent/2.5
                         +
                         metrics.CoordinatingPercent/0.3
                         +
                         metrics.ComplexNounPhrasePercent/0.3)/5;

                    sb.Append(string.Format("{0:0.0}", composite));
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
            }

            return fileCount;
        }



    }
}