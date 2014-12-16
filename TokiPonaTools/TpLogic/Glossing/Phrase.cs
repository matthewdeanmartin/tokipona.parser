using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpLogic
{
    public class Phrase
    {
        protected string originalText;
        protected string text;
        protected string[] words;

        

        public string Text
        {
            get { return text; }
        }

        public string[] Words
        {
            get { return words; }
        }
    }
}
