using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BasicTypes.Collections;
using BasicTypes.NormalizerCode;
using BasicTypes.ParseDiscourse;
using BasicTypes.Parser;
using NUnit.Framework.Constraints;

namespace BasicTypes.Knowledge
{
    //A special sort of knowledege that is already encoded.
    public class CorpusKnowledge
    {
        private readonly string[] sentences;
        private Dialect dialect;
        private Normalizer norm;
        public string[] Setences
        {
            get { return sentences; }
        }

        public CorpusKnowledge(string corpus, Dialect dialect)
        {
            //https://stackoverflow.com/questions/521146/c-sharp-split-string-but-keep-split-chars-separators
            //https://stackoverflow.com/questions/3115150/how-to-escape-regular-expression-special-characters-using-javascript

            this.dialect = dialect;
            this.norm = new Normalizer(dialect);

            SentenceSplitter ss = new SentenceSplitter(dialect);
            sentences = ss.ParseIntoNonNormalizedSentences(corpus);
            for (int index= 0; index < sentences.Length; index++)
            {
                sentences[index] = norm.NormalizeText(sentences[index]);
            }
        }

        public List<Sentence>[] MakeSentences()
        {
            ParserUtils pu = new ParserUtils(dialect);

            List<List<Sentence>> facts = new List<List<Sentence>>();

            foreach (string sentence in sentences)
            {
                if(string.IsNullOrWhiteSpace(sentence))continue;
                Sentence parsedSentence = pu.ParsedSentenceFactory(sentence,sentence);
                facts.Add(new List<Sentence>()
                    {
                        parsedSentence
                    });
            }
            
            return facts.ToArray();
        }
    }
}
