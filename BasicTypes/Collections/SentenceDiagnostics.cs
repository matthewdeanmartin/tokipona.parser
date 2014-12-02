using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    public class SentenceDiagnostics
    {
        public SentenceDiagnostics(string original, string normalized)
        {
            Original = original;
            Normalized = normalized;
        }

        public string Normalized { get; set; }
        public string Original { get; set; }
    }
}
