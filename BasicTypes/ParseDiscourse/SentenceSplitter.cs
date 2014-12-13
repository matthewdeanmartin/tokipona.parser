using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BasicTypes.CollectionsDiscourse;
using BasicTypes.Extensions;
using BasicTypes.NormalizerCode;
using NUnit.Framework;

namespace BasicTypes.ParseDiscourse
{
    //TODO: keep single line comments togeher
    //ID paragraphs (starts with tab or new line)
    //Treats double punctuation as a single thing (?!, !!, ??)
    //Treats quotes, parens, etc as its own concept. (maybe 1 level above sentence)
    //Auto close quotes on para breaks.

    public class SplitSentenceStrings
    {
        public SplitSentenceStrings(string[] sentences, bool[] isDirect)
        {
            this.Sentences = sentences;
            this.IsDirect = isDirect;
        }

        public string[] Sentences { get; private set; }
        public bool[] IsDirect { get; private set; }

    }

    public class SentenceSplitter
    {
        private readonly Dialect dialect;

        private SplitSentenceStrings current;
        public SentenceSplitter(Dialect dialect)
        {
            this.dialect = dialect;
        }

        public SplitSentenceStrings ParseIntoNonNormalizedSentencesWithDirectStatus(string text)
        {
            ParseIntoNonNormalizedSentences(text);
            return current;
        }

        public string[] ParseIntoNonNormalizedSentences(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            //https://stackoverflow.com/questions/521146/c-sharp-split-string-but-keep-split-chars-separators
            //https://stackoverflow.com/questions/3115150/how-to-escape-regular-expression-special-characters-using-javascript

            //TODO: Normalize well known compound phrases jan pona => jan-pona
            //TODO: Normalize foreign words zap => 'zap', alternatively assume they are tp, but a mistake

            //Normalize end lines.
            if (text.ContainsCheck("\r\n"))
            {
                text = text.Replace("\r\n", "\n");
            }
            if (text.ContainsCheck("\n\n"))
            {
                text = text.Replace("\n\n", "\n");
            }

            //Hyphenated words. This could cause a problem for compound words that cross lines.
            if (text.ContainsCheck("-\n"))
            {
                //TODO: Improve, should check if this actually joins a word.
                text= text.Replace("-\n", "");
            }
            
            ////"/\\*.*?\\*/"
            if (text.ContainsCheck("/*") || text.ContainsCheck("*/"))
            {
                text = NormalizationTasks.ApplyNormalization(text, "Comments", NormalizationTasks.StripMultilineComments);
            }


            //‘a! mi wile moku e wan soweli seli.’
            if (text.ContainsCheck('‘') && text.ContainsCheck('’'))
            {
                text = text.Replace('‘', '\'');
                text = text.Replace('’', '\'');
            }

            text = SwapQuoteAndSentenceTerminatorOrder(text);

            //Anything between /// and \n is a comment.
            string[] lines = text.Split(new[] { '\n' });
            string[] modifiedLines = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (line.StartCheck("///"))
                {
                    line = line.Replace("?", "QQQQQUESTIONMARK");
                    line = line.Replace(".", "PPPPERIOD");
                    line = line.Replace(":", "CCCCOLON");
                    line = line.Replace("!", "EEEEXCLAMATION");
                }
                if (line.ContainsCheck("\n///"))
                {
                    line = line.Replace("\n///", ".");
                }
                if (line.ContainsCheck("\""))
                {
                    line = ProcessDeliminterBetweenDoubleQuotes(line);
                }
                if (line.ContainsCheck("http://"))
                {
                    //Drat. not enough. http:// fsfasdf . adfadf . com / so on/
                    //line = line.Replace("http://", "httpXXX//");

                    line = Regex.Replace(line, @"(?i)\b((?:https?:(?:/{1,3}|[a-z0-9%])|[a-z0-9.\-]+[.](?:com|net|org|edu|gov|mil|aero|asia|biz|cat|coop|info|int|jobs|mobi|museum|name|post|pro|tel|travel|xxx|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|ax|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|cr|cs|cu|cv|cx|cy|cz|dd|de|dj|dk|dm|do|dz|ec|ee|eg|eh|er|es|et|eu|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gg|gh|gi|gl|gm|gn|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|im|in|io|iq|ir|is|it|je|jm|jo|jp|ke|kg|kh|ki|km|kn|kp|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|me|mg|mh|mk|ml|mm|mn|mo|mp|mq|mr|ms|mt|mu|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nu|nz|om|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|ps|pt|pw|py|qa|re|ro|rs|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|Ja|sk|sl|sm|sn|so|sr|ss|st|su|sv|sx|sy|sz|tc|td|tf|tg|th|tj|tk|tl|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw)/)(?:[^\s()<>{}\[\]]+|\([^\s()]*?\([^\s()]+\)[^\s()]*?\)|\([^\s]+?\))+(?:\([^\s()]*?\([^\s()]+\)[^\s()]*?\)|\([^\s]+?\)|[^\s`!()\[\]{};:'"".,<>?«»“”‘’])|(?:(?<!@)[a-z0-9]+(?:[.\-][a-z0-9]+)*[.](?:com|net|org|edu|gov|mil|aero|asia|biz|cat|coop|info|int|jobs|mobi|museum|name|post|pro|tel|travel|xxx|ac|ad|ae|af|ag|ai|al|am|an|ao|aq|ar|as|at|au|aw|ax|az|ba|bb|bd|be|bf|bg|bh|bi|bj|bm|bn|bo|br|bs|bt|bv|bw|by|bz|ca|cc|cd|cf|cg|ch|ci|ck|cl|cm|cn|co|cr|cs|cu|cv|cx|cy|cz|dd|de|dj|dk|dm|do|dz|ec|ee|eg|eh|er|es|et|eu|fi|fj|fk|fm|fo|fr|ga|gb|gd|ge|gf|gg|gh|gi|gl|gm|gn|gp|gq|gr|gs|gt|gu|gw|gy|hk|hm|hn|hr|ht|hu|id|ie|il|im|in|io|iq|ir|is|it|je|jm|jo|jp|ke|kg|kh|ki|km|kn|kp|kr|kw|ky|kz|la|lb|lc|li|lk|lr|ls|lt|lu|lv|ly|ma|mc|md|me|mg|mh|mk|ml|mm|mn|mo|mp|mq|mr|ms|mt|mu|mv|mw|mx|my|mz|na|nc|ne|nf|ng|ni|nl|no|np|nr|nu|nz|om|pa|pe|pf|pg|ph|pk|pl|pm|pn|pr|ps|pt|pw|py|qa|re|ro|rs|ru|rw|sa|sb|sc|sd|se|sg|sh|si|sj|Ja|sk|sl|sm|sn|so|sr|ss|st|su|sv|sx|sy|sz|tc|td|tf|tg|th|tj|tk|tl|tm|tn|to|tp|tr|tt|tv|tw|tz|ua|ug|uk|us|uy|uz|va|vc|ve|vg|vi|vn|vu|wf|ws|ye|yt|yu|za|zm|zw)\b/?(?!@)))", "\"URLSNOTSUPPORTED\"");
                }
                modifiedLines[i]=line;
            }

            string newText = string.Join("\n", modifiedLines);


            if (newText.ContainsCheck(";"))
            {
                //2 sentences connected... or 2 phrases connected?
                newText = newText.Replace(";", ":");
            }

            //Using commas as a sentence break.
            //jan Mato o, sina li lape anu seme?
            // o, sina
            if (newText.Contains(" o, sina "))
            {
                newText = newText.Replace(" o, sina ", " o! sina ");
            }
            
            //Crap. If we break on \n then sentences with line feeds are cut in half.
            //If we don't break on \n, then we blow up on intentional fragments like titles.
            //Choosing to not break on \n & and manually add . to titles.
            string[] finalLines= Regex
                .Split(newText, @"(?<=[\?!.:])") //split preserving punctuation
                .Where(x => !string.IsNullOrWhiteSpace(x)) //skip empties
                //.Select(x => Normalizer.NormalizeText(x, config))
                .Select(x => x)
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();

            for (int i = 0; i < finalLines.Length; i++)
            {
                //string line = finalLines[i];
                if (finalLines[i].ContainsCheck("httpXXX"))
                {
                    finalLines[i] = finalLines[i].Replace("httpXXX//", "http://");
                }
                if (finalLines[i].ContainsCheck("QQQQQUESTIONMARK") ||
                    finalLines[i].ContainsCheck("PPPPERIOD") ||
                    finalLines[i].ContainsCheck("CCCCOLON") ||
                    finalLines[i].ContainsCheck("EEEEXCLAMATION") 
                    //|| finalLines[i].ContainsCheck("\n///", "NEEEEWLINE")
                    )
                {
                    finalLines[i] = finalLines[i].Replace("QQQQQUESTIONMARK", "?");
                    finalLines[i] = finalLines[i].Replace("PPPPERIOD", ".");
                    finalLines[i] = finalLines[i].Replace("CCCCOLON", ":");
                    finalLines[i] = finalLines[i].Replace("EEEEXCLAMATION", "!");
                    //finalLines[i] = finalLines[i].Replace("NEEEEWLINE","\n///");
                }
            }

            for (int i = 0; i < finalLines.Length; i++)
            {
                string line = finalLines[i];
                if (line.ContainsCheck("QQQQQUESTIONMARK") ||
                    line.ContainsCheck("PPPPERIOD") ||
                    line.ContainsCheck("CCCCOLON") ||
                    line.ContainsCheck("EEEEXCLAMATION")
                    )
                {
                    throw new InvalidOperationException("WWWWAAT?");
                }
            }

            //If explicit, then ' means direct quote. Otherwise, we have to guess.
            bool[] isDirect = new bool[finalLines.Length];
            bool currentlyInDirect = false;
            for (int i = 0; i < finalLines.Length; i++)
            {
                string line = finalLines[i];
                if (line.StartCheck("'", "\""))
                {
                    currentlyInDirect=true;
                    finalLines[i] = finalLines[i].Substring(1);
                }
                isDirect[i] = currentlyInDirect;
                if (line.EndCheck("'","\""))
                {
                    currentlyInDirect = false;
                    finalLines[i] = finalLines[i].Substring(0, finalLines[i].Length-1);
                }
            }
            current=new SplitSentenceStrings(finalLines, null);
            return finalLines;
        }

        public static string SwapQuoteAndSentenceTerminatorOrder(string newText)
        {
//swap quote/terminator order
            foreach (string delims in new[] {".'", ".\"", "?'", "?\"", "!'", "!\""})
            {
                if (newText.ContainsCheck(delims))
                {
                    newText = newText.Replace(delims, delims[1] + delims[0].ToString());
                }
            }
            return newText;
        }

        private string ProcessDeliminterBetweenDoubleQuotes(string line)
        {
            StringBuilder sb =new StringBuilder();

            if (line.Count(x => x == '\"') <= 1) return line;

            bool inQuote = false;
            foreach (char c in line)
            {
                
                if (c == '\"')
                {
                    inQuote = !inQuote;
                }
                
                if (inQuote)
                {
                    if (c == '?')
                    {
                        sb.Append("QQQQQUESTIONMARK");
                        continue;
                    }
                    if (c == '.')
                    {
                        sb.Append("PPPPERIOD");
                        continue;
                    }
                    if (c == ':')
                    {
                        sb.Append("CCCCOLON");
                        continue;
                    }
                    if (c == '!')
                    {
                        sb.Append("EEEEXCLAMATION");
                        continue;
                    }
                }
                
                sb.Append(c);
            }
            return sb.ToString();
        }


        public List<Sentence>[] GroupIntoDiscourses(Sentence[] sentences)
        {
            List<List<Sentence>> l = new List<List<Sentence>>();

            List<Sentence> d = new List<Sentence>();
            l.Add(d);
            for (int i = 0; i < sentences.Length - 1; i++)
            {
                //Always add that sentence
                Sentence s = sentences[i];
                d.Add(s);

                //Next decide if we keep adding, or if we create a new discourse.
                //Keep adding if current implies a link to next OR next implies link to current.
                Sentence next = i < (sentences.Length - 1) ? null : sentences[i + 1];
                if (s.HasPunctuation())
                {
                    if (s.Punctuation == new Punctuation(":"))
                    {

                        //Linked to next!
                        continue;
                    }
                }
                else if (next != null && next.HasConjunction())
                {
                    continue;
                }
                d = new List<Sentence>();
                l.Add(d);
            }
            foreach (List<Sentence> discourse in l.ToArray())
            {
                if (discourse.Count == 0)
                {
                    l.Remove(discourse);
                }
            }
            return l.ToArray();
        }
    }

}
