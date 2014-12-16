using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TpLogic
{
    //Pi chains and finally leaf nouns and modifiers.
    public class NounPhraseProcessor
    {
        public Collection<NounPhrase> SplitIntoNounPhrases(string text)
        {
            Collection<NounPhrase> subjects = new Collection<NounPhrase>();

            if (text.Length == 0) return subjects;

            text = text.Trim();



            if (!text.Contains(" pi ")) //|| text.Contains(" pu ");
            {
                subjects.Add(new NounPhrase(text));
                return subjects;
            }

            int offset = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text.Substring(i).StartsWith(" pi "))
                {
                    NounPhrase s = ExtractNounPhrase(text, i, offset);
                    //s.Type = SubjectType.And;
                    subjects.Add(s);
                    offset = i + 4;
                }

                if(!text.Substring(offset).Contains(" pi "))
                {
                    NounPhrase s = new NounPhrase(text.Substring(offset));
                    s.Type = NpType.Pi;
                    subjects.Add(s);
                    break;
                }

                //Subordinate
                //if (text.Substring(i).StartsWith(" pu "))
                //{
                //    NounPhrase s = ExtractNounPhrase(text, i, offset);
                //    subjects.Add(s);
                //    //s.Type = SubjectType.Or;
                //    offset = i + 5;
                //}
            }

            return subjects;
        }

        private NounPhrase ExtractNounPhrase(string text, int i, int offset)
        {
            NounPhrase s = new NounPhrase(text.Substring(offset, i - offset));
            return s;
        }
    }

    public enum NpType
    {
        None=0,
        Pi=1
    }

    public class NounPhrase:Phrase
    {
        public NpType Type
        {
            get; set;
        }

        public string HeadNoun()
        {
            return words[0];
        }

        public string[] Modifiers()
        {
            if(words.Length==1) return new string[0];

            string[] modifiers = new string[words.Length-1];
            for (int i=1; i < words.Length;i++ )
            {
                modifiers[i - 1] = words[i];
            }

            return modifiers;
        }

        public NounPhrase(string subjectText)
        {
            originalText = subjectText;
            text = originalText.Trim(new char[] { '.', '?', ':', '!' });
            while (text.Contains("  "))
                text = text.Replace("  ", " ");
            words = text.Split(new char[] {' '});
        }


    }
}
