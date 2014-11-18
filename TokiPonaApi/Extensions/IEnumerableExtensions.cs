using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DataAccess.Extensions
{
    public static class IEnumerableExtensions
    {
        //string html = @"<style type = ""text/css""> .tableStyle{border: solid 5 green;} 
        //th.header{ background-color:#FF3300} tr.rowStyle { background-color:#33FFFF; 
        //border: solid 1 black; } tr.alternate { background-color:#99FF66; 
        //border: solid 1 black;}</style>";
        //html += personList.ToHtmlTable("tableStyle", "header", "rowStyle", "alternate");
        //this.webBrowser1.DocumentText = html;
        public static string ToHtmlTable<T>(this IEnumerable<T> list, string tableStyle, string headerStyle, string rowStyle, string alternateRowStyle)
        {

            var result = new StringBuilder();
            if (String.IsNullOrEmpty(tableStyle))
            {
                result.Append("<table id=\"" + typeof(T).Name + "Table\">");
            }
            else
            {
                result.Append("<table id=\"" + typeof(T).Name + "Table\" class=\"" + tableStyle + "\">");
            }

            var propertyArray = typeof(T).GetProperties();
            foreach (var prop in propertyArray)
            {
                if (String.IsNullOrEmpty(headerStyle))
                {
                    result.AppendFormat("<th>{0}</th>", prop.Name);
                }
                else
                {
                    result.AppendFormat("<th class=\"{0}\">{1}</th>", headerStyle, prop.Name);
                }
            }

            List<T> collection = list.ToList();
            for (int i = 0; i < collection.Count(); i++)
            {
                if (!String.IsNullOrEmpty(rowStyle) && !String.IsNullOrEmpty(alternateRowStyle))
                {
                    result.AppendFormat("<tr class=\"{0}\">", i % 2 == 0 ? rowStyle : alternateRowStyle);
                }
                else
                {
                    result.AppendFormat("<tr>");
                }

                foreach (var prop in propertyArray)
                {
                    object value = prop.GetValue(collection.ElementAt(i), null);
                    result.AppendFormat("<td>{0}</td>", value ?? String.Empty);
                }
                result.AppendLine("</tr>");
            }
            result.Append("</table>");
            return result.ToString();
        }
    }
}
