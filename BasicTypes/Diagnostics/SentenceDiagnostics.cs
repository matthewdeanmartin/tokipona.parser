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
        //I checked, this has no appreciable affect on performance.
        private static readonly ThreadLocal<SentenceDiagnostics> currentSentence = new ThreadLocal<SentenceDiagnostics>();
        //private static SentenceDiagnostics currentSentence;
        public static SentenceDiagnostics CurrentSentence
        {
            //get { return currentSentence; }
            //set { currentSentence = value; }
            get { return currentSentence.Value; }
            set { currentSentence.Value = value; }
        }

        /// <summary>
        /// Diagnostics is so important, I'd rather this was required when it isn't, versus missing when it is.
        /// </summary>
        public static SentenceDiagnostics NotFromParser  = new SentenceDiagnostics("Not From Parser","Not From Parser");

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
