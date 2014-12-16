using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TpLogic.Readability
{
    public class Metrics
    {
        public int SentenceCount;
        public int WordCount;
        public double WordsPerSentence;
        public double ProperModiferPercent;
        public double ProperModifierMaximum;
        public double ComplexNounPhrasePercent;
        public double ComplexNoundPhraseMaximum;
        public double FunctionWordPercent;
        public double FunctionWordMaximum;
        public double CoordinatingPercent;
        public double CoordinatingMaximum;

    }
    public class MetricsCalculator
    {
        public static Metrics Calculate(string input)
        {
            if(input.Length==0)return new Metrics();

            Metrics metrics = new Metrics();
            string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] sentences = input.Split(new char[] { '?', '.', ':' }, StringSplitOptions.RemoveEmptyEntries);


            metrics.SentenceCount = sentences.Length;
            metrics.WordCount = words.Length;

            metrics.WordsPerSentence = Convert.ToDouble(words.Length) / Convert.ToDouble(sentences.Length);
            
            double properModifiers = 0;
            
            foreach (string s in words)
            {
                if(s.Length<1) continue;
                if (s.Substring(0, 1) == s.Substring(0, 1).ToUpper())
                {
                    properModifiers++;
                }
            }

            metrics.ProperModiferPercent = (properModifiers/Convert.ToDouble(sentences.Length));
            metrics.ProperModifierMaximum=metrics.WordsPerSentence / 3;

            double piCount = 0;
            foreach (string s in words)
            {
                if (s == "pi")
                {
                    piCount++;
                }
            }
            metrics.ComplexNounPhrasePercent = (piCount/Convert.ToDouble(sentences.Length));
            metrics.ComplexNoundPhraseMaximum = metrics.WordsPerSentence/4.0;
            
            double functionCount = 0;

            //This over counts prepositions since most preps are also verbs
            foreach (string s in words)
            {
                if (s == "la"
                    || s == "o"
                    || s == "e"
                    || s == "li"
                    || s == "pi"
                    || s == "kepeken"
                    || s == "lon"
                    || s == "poka"
                    || s == "sama"
                    || s == "tan"
                    || s == "tawa")
                {
                    functionCount++;
                }
            }
            metrics.FunctionWordPercent = (functionCount/Convert.ToDouble(sentences.Length));
            metrics.FunctionWordMaximum = metrics.WordsPerSentence/2.0;
                
            double coordinatingCount = 0;
            foreach (string s in words)
            {
                if (s == "ona" || s == "ni")
                {
                    coordinatingCount++;
                }
            }

            metrics.CoordinatingPercent=  coordinatingCount / Convert.ToDouble(sentences.Length);
            metrics.CoordinatingMaximum= metrics.WordsPerSentence * 3;

            return metrics;
        }
    }
}
