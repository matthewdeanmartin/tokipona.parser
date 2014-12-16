using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TpLogic
{
    public class SentenceProcessor
    {
        public Collection<Sentence> SplitIntoSentences(string text)
        {
            Collection<Sentence> sentences = new Collection<Sentence>();

            if (text.Length == 0) return sentences;

            text = text.Trim();
            int offset = 0;
            for (int i = 0;i<text.Length ; i++)
            {
                if(text[i]=='.')
                {
                    Sentence s = ExtractSentence(text, i, offset);
                    s.Type = SentenceType.Indicative;
                    sentences.Add(s);
                    offset = i;
                }

                if (text[i] == '?')
                {
                    Sentence s = ExtractSentence(text, i, offset);
                    s.Type = SentenceType.Question;
                    sentences.Add(s);
                    offset = i;
                }

                if (text[i] == ':')
                {
                    Sentence s = ExtractSentence(text, i, offset);
                    s.Type = SentenceType.IndicativeCoordinated;
                    sentences.Add(s);
                    offset = i;
                }

                if (text[i] == '!')
                {
                    Sentence s = ExtractSentence(text, i, offset);
                    s.Type = SentenceType.Exclamation;
                    sentences.Add(s);
                    offset = i;
                }
            }

            return sentences;
        }

        private Sentence ExtractSentence(string text, int i, int offset)
        {
            Sentence s = new Sentence(text.Substring(offset, i - offset));
            return s;
        }
    }
    public enum SentenceType
    {
        None=0,
        Indicative=1, //.
        Question=2, //?
        IndicativeCoordinated = 3, //:
        Exclamation=4 //!
    }

    public class Sentence:Phrase
    {
        public Sentence(string sentenceText)
        {
            originalText = sentenceText;
            text = originalText.Trim(new char[] { '.', '?', ':', '!' });
            while (text.Contains("  "))
                text = text.Replace("  ", " ");
            words = text.Split(new char[] { ' ' });
        }

        public int LiCount()
        {
            return words.Count(word => word == "li");
        }

        public int LaCount()
        {
            return words.Count(word => word == "la");
        }

        public SentenceType Type { get; set; }
        
    }
}
