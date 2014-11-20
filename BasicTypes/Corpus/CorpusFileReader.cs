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
            DirectoryInfo di;
            if (Directory.Exists(@"C:\Users\mmartin\Documents\GitHub\tokipona.parser\"))
                di = new DirectoryInfo(@"C:\Users\mmartin\Documents\GitHub\tokipona.parser\BasicTypes\Corpus");
            else
                di = new DirectoryInfo(@"C:\Users\mmartin\code\GitHub\tokipona.parser\BasicTypes\Corpus");
            //"*Yves*.txt"
            foreach (FileInfo file in di.EnumerateFiles("*.txt", SearchOption.AllDirectories).Reverse())
            {
                if (file.FullName.Contains("janKipoCollected")) continue;
                if (file.FullName.Contains("toki sewi kolisu p2.txt")) continue;
                if (file.FullName.Contains("nimi poka en nimi kule")) continue; //Has a defective conjunction of prep phrases, waiting to get some comm feedback before fixing text.
                if (file.FullName.Contains("Book Summaries_Has ENGLISH.txt")) continue; //Asides in square brackets. Blaaaah!
                


                //if(!file.FullName.Contains("jan Mato")) continue;
                Console.WriteLine("----------------------------------");
                Console.WriteLine(file.Directory);
                Console.WriteLine(file.Name);
               yield return File.ReadAllText(file.FullName,Encoding.UTF8);
            }
        }

    }
}
