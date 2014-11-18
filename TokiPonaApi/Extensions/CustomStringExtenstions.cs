using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokiPonaApi
{
    public static class Extensions
    {
        public static string HtmlEncode(this string s)
        {
            if (s == null)
            {
                return "null";
            }
            return HttpUtility.HtmlEncode(s);
        }
    }
}