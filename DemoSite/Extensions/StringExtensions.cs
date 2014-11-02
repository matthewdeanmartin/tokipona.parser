using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Mvc;

namespace DemoSite
{
    public static class StringExtensions
    {
        public static string ToHtml(this string value)
        {
           return System.Web.HttpUtility.HtmlEncode(value);
        }
    }
}