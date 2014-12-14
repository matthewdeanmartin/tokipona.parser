using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTypes.Html
{
    public class HtmlTagHelper
    {
        public static string SpanWrap(string cssClass, string text)
        {
            return "<span class=\"" + cssClass + "\">" + text + "</span>";
        }

        public static string TagWrap(string tag, string cssClass, string text)
        {
                return "<span class=\""+cssClass+"\">" + text + "</span>";
        }

        public static string ReduceTags(string tag, string text)
        {
            return text.Replace("</" + tag + "> <" + tag + ">", " ");
        }
    }
}
