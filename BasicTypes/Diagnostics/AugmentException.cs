using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Collections;

namespace BasicTypes.Diagnostics
{
    public class AugmentException
    {
        public static string WithSentences(string message)
        {
            if (SentenceDiagnostics.CurrentSentence == null)
            {
                return message;
            }
            return message + "\n" + SentenceDiagnostics.CurrentSentence.Original;
        }
    }
}
