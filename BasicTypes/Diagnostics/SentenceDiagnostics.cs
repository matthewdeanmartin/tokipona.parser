using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicTypes.Collections
{
    /// <summary>
    /// No matter where things blow up, we want to know what sentence we are in, even if the current method doesn't know.
    /// </summary>
    public class SentenceDiagnostics
    {
        private static readonly ThreadLocal<SentenceDiagnostics> currentSentence = new ThreadLocal<SentenceDiagnostics>();

        public static SentenceDiagnostics CurrentSentence
        {
            get { return currentSentence.Value; }
            set { currentSentence.Value = value; }
        }

        public SentenceDiagnostics(string original, string normalized)
        {
            Original = original;
            Normalized = normalized;
            CurrentSentence = this;
        }

        public SentenceDiagnostics(string original, string normalized, string fileName)
        {
            Original = original;
            Normalized = normalized;
            FileName = fileName;
            CurrentSentence = this;
        }

        public string Normalized { get; set; }
        public string Original { get; set; }
        public string FileName { get; set; }
    }
}
