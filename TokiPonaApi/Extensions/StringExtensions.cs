using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Extensions
{
    public static class StringExtensions
    {
        public static string FormatString(this string format, params object[] args)
        {
            return string.Format(format, args);
        }   
    }
}

namespace DataAccess.Extensions.Html
{
    public static class StringHtmlExtensions
    {
        public static string Nl2Br(this string value)
        {
            return value.Replace("\r\n", "<br />").Replace("\n", "<br />");
        }

        public static string CleanBrTags(this string value)
        {
            return value.Replace(@"<br \>", "");
        }

    }
}
