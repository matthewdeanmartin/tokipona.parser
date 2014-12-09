using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.CollectionsDiscourse;
using BasicTypes.NormalizerCode;

namespace BasicTypes.ParseDiscourse
{
    public class ParagraphSplitter
    {
        private readonly Dialect dialect;
        readonly ParserUtils pu;

        public ParagraphSplitter(Dialect dialect)
        {
            this.dialect = dialect;
            pu = new ParserUtils(dialect);
        }

        public Prose ParseProse(string text, string policy = "guess")
        {
            text = text.Trim(new char[] { '\r', '\n' });
            List<Paragraph> paras = new List<Paragraph>();

            string[] doubleSpace = new string[] { "\r\n\r\n", "\n\r\n\r", "\n\n\n\n", "\r\r\r\r" };
            string[] paraStrings = text.Split(doubleSpace, StringSplitOptions.RemoveEmptyEntries);


            string[] singleSpace = new string[] { "\n", "\n" };



            if (paraStrings.Length == 1)
            {
                //We only got 1 paragraph. Was this because the document is short?
                //Or because we actually are seeing this:
                //
                //  blah blah. blah blah. (para break)
                //  blah blah. blah blah. (para break)
                //
                string[] alternative = text.Split(singleSpace, StringSplitOptions.RemoveEmptyEntries);

                //If new line is a para break, then every line should have at least onen sentence 
                //terminator
                if (alternative.All(x => x.Contains(".") || x.Contains("?") || x.Contains("!")))
                {
                    paraStrings = alternative;
                }
            }

            //int max = paraStrings.Max(x=>x.Length);
            //if(max.)


            Speaker speaker = null;
            string title = null;
            int i = 1;

            SentenceSplitter ss = new SentenceSplitter(dialect);

            foreach (string paraString in paraStrings)
            {
                string[] sentenceStrings = ss.ParseIntoNonNormalizedSentences(paraString);

                Paragraph para = new Paragraph();
                foreach (string sentenceString in sentenceStrings)
                {
                    string normalized = Normalizer.NormalizeText(sentenceString, dialect);
                    Sentence sentence = pu.ParsedSentenceFactory(normalized, sentenceString);
                    if (i == 1 && sentence.Fragment != null)
                    {
                        title = sentence.ToString();
                    }
                    if (i == 2 && sentence.Fragment != null)
                    {
                        if (sentence.Fragment.Contains(Words.jan) ||
                            sentence.Fragment.Contains(Words.meli) ||
                            sentence.Fragment.Contains(Words.mije))
                        {
                            title = sentence.ToString();
                            speaker = new Speaker(sentence.ToString());
                        }
                    }
                    para.Add(sentence);
                }
                paras.Add(para);
            }

            Prose p = new Prose(paras.ToArray(), title, speaker, DateTime.Now.ToString());
            return p;
        }
    }

}
