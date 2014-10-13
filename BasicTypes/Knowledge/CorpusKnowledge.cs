using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BasicTypes.Collections;

using NUnit.Framework.Constraints;

namespace BasicTypes.Knowledge
{
    //A special sort of knowledege that is already encoded.
    public class CorpusKnowledge
    {
        private readonly string[] sentences;

        public string[] Setences
        {
            get { return sentences; }
        }

        public CorpusKnowledge(string corpus)
        {
            //https://stackoverflow.com/questions/521146/c-sharp-split-string-but-keep-split-chars-separators
            //https://stackoverflow.com/questions/3115150/how-to-escape-regular-expression-special-characters-using-javascript
            sentences = ParserUtils.ParseIntoRawSentences(corpus);
        }

        public Discourse[] MakeSentences()
        {
            List<Discourse> facts = new List<Discourse>();

            foreach (string sentence in sentences)
            {
                Sentence parsedSentence = ParserUtils.ParsedSentenceFactory(sentence);
                facts.Add(new Discourse()
                    {
                        parsedSentence
                    });
            }
            
            return facts.ToArray();
        }
    }
}
