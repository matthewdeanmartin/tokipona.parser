using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Corpus
{

    public class CorpusFileReader
    {
        //Return all files
        public IEnumerable<string> NextFile()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\mmartin\Documents\GitHub\tokipona.parser\BasicTypes\Corpus");
            foreach (FileInfo file in di.EnumerateFiles("*Yves*.txt", SearchOption.AllDirectories))
            {
               yield return File.ReadAllText(file.FullName,Encoding.UTF8);
            }
        }

    }
}
