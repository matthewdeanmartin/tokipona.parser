using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;
using BasicTypes.ParseDiscourse;

namespace BasicTypes.Corpus
{

    public class CorpusFileReader
    {
        public string currentFile="";
        private bool suppressTrace =false;
        public CorpusFileReader()
        {
        }
        public CorpusFileReader(bool suppressTrace)
        {
            this.suppressTrace = suppressTrace;
        }
        //Return all files
        public IEnumerable<string> NextFile()
        {
            string path = @"tokipona.parser\BasicTypes\Tp\Corpus";
            DirectoryInfo di;
            if (Directory.Exists(@"C:\Users\mmartin\Documents\GitHub\tokipona.parser\"))
                di = new DirectoryInfo(@"C:\Users\mmartin\Documents\GitHub\" + path);
            else if (Directory.Exists(@"C:\Users\mmartin.Quasimodo-PC\Documents\GitHub\" + path))
                di = new DirectoryInfo(@"C:\Users\mmartin.Quasimodo-PC\Documents\GitHub\" + path);
            else
            {
                di = new DirectoryInfo(@"C:\Users\mmartin\code\GitHub\" + path);

            }
            //"*Yves*.txt"
            foreach (FileInfo file in di.EnumerateFiles("*.txt", SearchOption.AllDirectories).Reverse())
            {
                currentFile = file.FullName;
                
                if (!suppressTrace)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine(file.Directory);
                    Console.WriteLine(file.Name);                    
                }
                string results;
                if (currentFile.Contains("janKipoCollected"))
                {
                    results = File.ReadAllText(file.FullName, Encoding.UTF8);
                    results = NormalizeJanKipoSet.Normalize(results);
                }
                else
                {
                    results= File.ReadAllText(file.FullName, Encoding.UTF8);
                }
                yield return results;
            }
        }

    }
}
