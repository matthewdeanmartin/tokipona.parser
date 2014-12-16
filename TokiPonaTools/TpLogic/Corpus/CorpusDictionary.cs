using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TpLogic.Corpus
{
    //The dictionary of string, 
    public class CorpusDictionary
    {
        public FileInfo SourceFile { get; set; }
        public string Author { get; set; }
        public string CreateDate { get; set; }
    }
}
