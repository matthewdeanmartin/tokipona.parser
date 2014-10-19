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

            Config c = Config.MakeDefault;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            sentences = pu.ParseIntoRawSentences(corpus);
        }

        public Discourse[] MakeSentences()
        {
            Config c = Config.MakeDefault;
            c.ThrowOnSyntaxError = false;
            ParserUtils pu = new ParserUtils(c);

            List<Discourse> facts = new List<Discourse>();

            foreach (string sentence in sentences)
            {
                Sentence parsedSentence = pu.ParsedSentenceFactory(sentence);
                facts.Add(new Discourse()
                    {
                        parsedSentence
                    });
            }
            
            return facts.ToArray();
        }
    }
}
