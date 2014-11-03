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
            //DirectoryInfo di = new DirectoryInfo(@"C:\Users\mmartin\Documents\GitHub\tokipona.parser\BasicTypes\Corpus");
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\mmartin\code\GitHub\tokipona.parser\BasicTypes\Corpus");
            //"*Yves*.txt"
            foreach (FileInfo file in di.EnumerateFiles("*.txt", SearchOption.AllDirectories))
            {
                if (file.FullName.Contains("janKipoCollected")) continue;
                if (file.FullName.Contains("toki sewi kolisu p2.txt")) continue;
                //if(!file.FullName.Contains("jan Mato")) continue;
                Console.WriteLine("----------------------------------");
                Console.WriteLine(file.Directory);
                Console.WriteLine(file.Name);
               yield return File.ReadAllText(file.FullName,Encoding.UTF8);
            }
        }

    }
}
