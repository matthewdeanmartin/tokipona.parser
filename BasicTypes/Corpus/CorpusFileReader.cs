using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

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
            DirectoryInfo di;
            if (Directory.Exists(@"C:\Users\mmartin\Documents\GitHub\tokipona.parser\"))
                di = new DirectoryInfo(@"C:\Users\mmartin\Documents\GitHub\tokipona.parser\BasicTypes\Corpus");
            else if (Directory.Exists(@"C:\Users\mmartin.Quasimodo-PC\Documents\GitHub\tokipona.parser\BasicTypes\Corpus"))
                di = new DirectoryInfo(@"C:\Users\mmartin.Quasimodo-PC\Documents\GitHub\tokipona.parser\BasicTypes\Corpus");
            else
            {            di = new DirectoryInfo(@"C:\Users\mmartin\code\GitHub\tokipona.parser\BasicTypes\Corpus");

            }
            //"*Yves*.txt"
            foreach (FileInfo file in di.EnumerateFiles("*.txt", SearchOption.AllDirectories).Reverse())
            {
                currentFile = file.FullName;
                //if (file.FullName.ContainsCheck("janKipoCollected")) continue;
                //if (file.FullName.ContainsCheck("toki sewi kolisu p2.txt")) continue;
                //if (file.FullName.ContainsCheck("nimi poka en nimi kule")) continue; //Has a defective conjunction of prep phrases, waiting to get some comm feedback before fixing text.
                //if (file.FullName.ContainsCheck("Book Summaries_Has ENGLISH.txt")) continue; //Asides in square brackets. Blaaaah!
                //if (file.FullName.ContainsCheck("Phonology")) continue; //full of prnounciation characters


                //if(!file.FullName.ContainsCheck("jan Mato")) continue;
                if (!suppressTrace)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine(file.Directory);
                    Console.WriteLine(file.Name);                    
                }
               yield return File.ReadAllText(file.FullName,Encoding.UTF8);
            }
        }

    }
}
