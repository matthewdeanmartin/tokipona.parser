using System;
using System.Collections.Generic;
using BasicTypes.CollectionsDiscourse;
using BasicTypes.NormalizerCode;
using NUnit.Framework;

namespace BasicTypes.ParseDiscourse
{
    //TODO: keep single line comments togeher
    //ID paragraphs (starts with tab or new line)
    //Treats double punctuation as a single thing (?!, !!, ??)
    //Treats quotes, parens, etc as its own concept. (maybe 1 level above sentence)
    //Auto close quotes on para breaks.
    public class SentenceSplitter
    {
    }

    public class ParagraphSplitter
    {
        private readonly Dialect dialect;

        public ParagraphSplitter(Dialect dialect)
        {
            this.dialect = dialect;
        }

        public Prose ParseProse(string text)
        {
            List<Paragraph> paras = new List<Paragraph>();

            string[] splitters = new string[] { "\r\n", "\n\r","\n\n","\r\r" };
            string[] paraStrings= text.Split( splitters, StringSplitOptions.RemoveEmptyEntries);

            
            ParserUtils pu = new ParserUtils(dialect);
            Speaker speaker=null;
            string title = null;
            int i = 1;
            foreach (string paraString in paraStrings)
            {
                string[] sentenceStrings = pu.ParseIntoNonNormalizedSentences(paraString);

                Paragraph para = new Paragraph(); 
                foreach (string sentenceString in sentenceStrings)
                {
                    string normalized = Normalizer.NormalizeText(sentenceString, dialect);
                    Sentence sentence= pu.ParsedSentenceFactory(normalized, sentenceString);
                    if (i == 1 && sentence.Fragment != null)
                    {
                        title = sentence.ToString();
                    }
                    if (i == 2 && sentence.Fragment != null)
                    {
                        if (sentence.Fragment.Contains(Words.jan) ||
                            sentence.Fragment.Contains(Words.meli) ||
                            sentence.Fragment.Contains(Words.mije))
                        {                        title = sentence.ToString();
                            speaker = new Speaker(sentence.ToString());
                        }
                    }
                    para.Add(sentence);
                }
                paras.Add(para);
            }
            
            Prose p = new Prose(paras.ToArray(),title, speaker,DateTime.Now.ToString());
            return p;
        }
    }
}
