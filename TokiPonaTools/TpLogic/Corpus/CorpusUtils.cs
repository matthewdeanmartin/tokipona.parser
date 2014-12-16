using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace TpLogic.Corpus
{
    public class CorpusUtils
    {

        public static string ExtractTitle(string fileName)
        {
            if (fileName.Length == 0) return "";
            if (!fileName.Contains(".")) return fileName;
            return fileName.Substring(0, fileName.LastIndexOf(@"."));
        }
        public static string ExtractAuthor(string directory)
        {
            if (directory.Length == 0) return "";
            if (!directory.Contains(@"\")) return directory;
            return directory.Substring(directory.LastIndexOf(@"\") + 1);
        }

        public Dictionary<string,string> Files()
        {
            Dictionary<string,string> fileList = new Dictionary<string, string>();
            string[] directories= Directory.GetDirectories(HttpContext.Current.Server.MapPath(@"corpus"));

            for (int i =0;i<directories.Length;i++)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directories[i]);

                ProcessDirectory(directoryInfo, ref fileList);
            }

            return fileList;
        }

        private void ProcessDirectory(DirectoryInfo directoryInfo,
            ref Dictionary<string, string> fileList)
        {
            if (directoryInfo.FullName.Contains("_svn")) return;
            if (directoryInfo.FullName.Contains(".svn")) return;

            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo subDirectory in subDirectories)
            {
                //Recursion going on here...
                ProcessDirectory(subDirectory, ref fileList);
            }

            FileInfo[] fileInfos= directoryInfo.GetFiles();
            foreach(FileInfo file in fileInfos)
            {
                if ((file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    continue;
                if (file.FullName.Contains("_svn") || file.FullName.Contains(".svn"))
                    continue;

                string[] splitOn = new[] { "corpus" };

                
                string key = file.FullName.Split(splitOn, StringSplitOptions.RemoveEmptyEntries)[1];
                string value = CorpusUtils.ExtractTitle(file.Name)
                                + ", " + CorpusUtils.ExtractAuthor(file.DirectoryName);
                if(!fileList.ContainsKey(key))
                    fileList.Add(key,value);
            }
        }

        public static FileInfo CreateFileInfo(string selectedValue)
        {
            string rightHandPart = selectedValue.Substring(1).Replace("..","");// ((DropDownList)sender).SelectedValue;
            string leftPart= HttpContext.Current.Server.MapPath(@"\corpus\");
            FileInfo fi = new FileInfo(leftPart + rightHandPart);
            if (!fi.Exists)
            {
                fi = new FileInfo((leftPart + rightHandPart).Replace(@"\corpus\", @"\tp\corpus\"));
            }

            
            
            return fi;
        }
    }
}
