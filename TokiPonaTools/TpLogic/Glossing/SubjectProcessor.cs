using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace TpLogic
{
    //Roughly everything before the first li, split by en or anu
    
    public class SubjectProcessor
    {
        public Collection<Subject> SplitIntoSubjects(string text)
        {
            Collection<Subject> subjects = new Collection<Subject>();

            if (text.Length == 0) return subjects;

            text = text.Trim();

            //li is expected. If we don't have it, it is a sentence fragment.
            //Anything after the li must *not* be the subject.
            if (text.Contains(" li "))
            {
                text = text.Substring(0, text.IndexOf(" li "));
            }

            int offset = 0;
            for (int i = 0;i<text.Length ; i++)
            {
                if(text.Substring(i).StartsWith(" en "))
                {
                    Subject s = ExtractSubject(text, i, offset);
                    s.Type = SubjectType.And;
                    subjects.Add(s);
                    offset = i+4;
                }

                if (text.Substring(i).StartsWith(" anu "))
                {
                    Subject s = ExtractSubject(text, i, offset);
                    subjects.Add(s);
                    s.Type = SubjectType.Or;
                    offset = i+5;
                }
            }

            //There is always a last, but not always any of the above
            Subject last = new Subject(text.Substring(offset));
            subjects.Add(last);
            last.Type = SubjectType.None;
            
            return subjects;
        }

        private Subject ExtractSubject(string text, int i, int offset)
        {
            Subject s = new Subject(text.Substring(offset, i - offset));
            return s;
        }
    }


    public enum SubjectType
    {
        None = 0, //none
        And = 1, //en
        Or = 2, //anu
    }


    //Has noun + modifer(*) + pi
    public class Subject:Phrase
    {
        public SubjectType Type { get; set; }

        public Subject(string subjectText)
        {
            originalText = subjectText;
            text = originalText.Trim(new char[] { '.', '?', ':', '!' });
            while (text.Contains("  "))
                text = text.Replace("  ", " ");
            words = text.Split(new char[] {' '});
        }
    }
}
