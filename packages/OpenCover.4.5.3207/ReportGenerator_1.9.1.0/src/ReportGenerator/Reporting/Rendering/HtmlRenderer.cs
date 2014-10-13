using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using log4net;
using Palmmedia.ReportGenerator.Parser.Analysis;
using Palmmedia.ReportGenerator.Properties;

namespace Palmmedia.ReportGenerator.Reporting.Rendering
{
    /// <summary>
    /// HTML report renderer.
    /// </summary>
    internal class HtmlRenderer : RendererBase, IReportRenderer, IDisposable
    {
        #region HTML Snippets

        /// <summary>
        /// The head of each generated HTML file.
        /// </summary>
        private const string HtmlStart = @"<!DOCTYPE html>
<html>
<head>
<meta charset=""utf-8"" />
<title>{0} - {1}</title>
{2}
</head><body><div class=""container"">";

        /// <summary>
        /// The end of each generated HTML file.
        /// </summary>
        private const string HtmlEnd = @"</div>
{0}
</body></html>";

        /// <summary>
        /// The link to the static CSS file.
        /// </summary>
        private const string CssLink = "<link rel=\"stylesheet\" type=\"text/css\" href=\"report.css\" />";

        #endregion

        /// <summary>
        /// The Logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(HtmlRenderer));

        /// <summary>
        /// Dictionary containing the filenames of the class reports by class.
        /// </summary>
        private static readonly Dictionary<string, string> FileNameByClass = new Dictionary<string, string>();

        /// <summary>
        /// Indicates that only a summary report is created (no class reports).
        /// </summary>
        private readonly bool onlySummary;

        /// <summary>
        /// The report builder.
        /// </summary>
        private TextWriter reportTextWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlRenderer" /> class.
        /// </summary>
        /// <param name="onlySummary">if set to <c>true</c> only a summary report is created (no class reports).</param>
        public HtmlRenderer(bool onlySummary)
        {
            this.onlySummary = onlySummary;
        }

        /// <summary>
        /// Begins the summary report.
        /// </summary>
        /// <param name="targetDirectory">The target directory.</param>
        /// <param name="title">The title.</param>
        public void BeginSummaryReport(string targetDirectory, string title)
        {
            string targetPath = Path.Combine(targetDirectory, "index.htm");
            this.CreateTextWriter(targetPath);

            using (var cssStream = GetCombinedCss())
            {
                string style = this.onlySummary ?
                    "<style TYPE=\"text/css\">" + new StreamReader(cssStream).ReadToEnd() + "</style>"
                    : CssLink;

                this.reportTextWriter.WriteLine(HtmlStart, WebUtility.HtmlEncode(title), Resources.CoverageReport, style);
            }
        }

        /// <summary>
        /// Begins the class report.
        /// </summary>
        /// <param name="targetDirectory">The target directory.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="className">Name of the class.</param>
        public void BeginClassReport(string targetDirectory, string assemblyName, string className)
        {
            string fileName = GetClassReportFilename(assemblyName, className);

            this.CreateTextWriter(Path.Combine(targetDirectory, fileName));

            this.reportTextWriter.WriteLine(HtmlStart, WebUtility.HtmlEncode(className), Resources.CoverageReport, CssLink);
        }

        /// <summary>
        /// Adds a header to the report.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Header(string text)
        {
            this.reportTextWriter.WriteLine("<h1>{0}</h1>", WebUtility.HtmlEncode(text));
        }

        /// <summary>
        /// Adds the test methods to the report.
        /// </summary>
        /// <param name="testMethods">The test methods.</param>
        public void TestMethods(IEnumerable<TestMethod> testMethods)
        {
            if (testMethods == null)
            {
                throw new ArgumentNullException("testMethods");
            }

            if (!testMethods.Any())
            {
                return;
            }

            StringBuilder html = new StringBuilder();

            html.Append("<div id=\"testmethods\">");
            html.AppendFormat("<h2 id=\"pinheader\">{0}</h2>", Resources.Testmethods);
            html.Append("<a id=\"pin\">&nbsp;</a><div>");

            int counter = 0;

            html.AppendFormat("<span><input type=\"radio\" name= \"method\" value=\"AllTestMethods\" id=\"method{1}\" checked=\"checked\" /><label for=\"method{1}\" title=\"{0}\">{0}</label></span>", Resources.All, counter);

            foreach (var testMethod in testMethods)
            {
                counter++;
                html.AppendFormat(
                    "<span><input type=\"radio\" name= \"method\" value=\"M{0}\" id=\"method{0}\" /><label for=\"method{0}\" title=\"{2}\">{1}</label></span>",
                    testMethod.Id,
                    WebUtility.HtmlEncode(testMethod.ShortName),
                    WebUtility.HtmlEncode(testMethod.Name));
            }

            html.Append("</div></div>");

            this.reportTextWriter.WriteLine("<script type=\"text/javascript\">");
            this.reportTextWriter.WriteLine("/* <![CDATA[ */");
            this.reportTextWriter.WriteLine("document.write('{0}');", html.ToString());
            this.reportTextWriter.WriteLine("/* ]]> */");
            this.reportTextWriter.WriteLine("</script>");
        }

        /// <summary>
        /// Adds a file of a class to a report.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        public void File(string path)
        {
            this.reportTextWriter.WriteLine("<h2 id=\"{0}\">{1}</h2>", WebUtility.HtmlEncode(HtmlRenderer.ReplaceInvalidXmlChars(path)), WebUtility.HtmlEncode(path));
        }

        /// <summary>
        /// Adds a paragraph to the report.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Paragraph(string text)
        {
            this.reportTextWriter.WriteLine("<p>{0}</p>", WebUtility.HtmlEncode(text));
        }

        /// <summary>
        /// Adds a table with two columns to the report.
        /// </summary>
        public void BeginKeyValueTable()
        {
            this.reportTextWriter.WriteLine("<table class=\"overview\">");
            this.reportTextWriter.WriteLine("<colgroup>");
            this.reportTextWriter.WriteLine("<col width=\"135\" />");
            this.reportTextWriter.WriteLine("<col />");
            this.reportTextWriter.WriteLine("</colgroup>");
            this.reportTextWriter.WriteLine("<tbody>");
        }

        /// <summary>
        /// Adds a summary table to the report.
        /// </summary>
        public void BeginSummaryTable()
        {
            string html = string.Format(
                CultureInfo.InvariantCulture,
                "<div id=\"showcustomizebox\" class=\"customizebox\"><input href=\"#\" id=\"showcustomizeboxbutton\" value=\"{0}\" title=\"{1}\" type=\"submit\" /></div><div id=\"customizebox\" class=\"customizebox hidden\"><div><a href=\"#\" data-bind=\"click: collapseAll\">{2}</a> | <a href=\"#\" data-bind=\"click: expandAll\">{3}</a></div><div class=\"center\"><span data-bind=\"text: groupingDescription\"></span><br />{4}: <div id=\"namespaceslider\"></div></div> <div class=\"right\">{5}: <input type=\"text\" data-bind=\"value: filter, valueUpdate: \\'afterkeydown\\'\" /></div></div>",
                Resources.ShowCustomizeBox,
                Resources.ShowCustomizeBoxHelp,
                Resources.CollapseAll,
                Resources.ExpandAll,
                Resources.Grouping,
                Resources.Filter);

            this.reportTextWriter.WriteLine("<script type=\"text/javascript\">");
            this.reportTextWriter.WriteLine("/* <![CDATA[ */");
            this.reportTextWriter.WriteLine("document.write('{0}');", html);
            this.reportTextWriter.WriteLine("/* ]]> */");
            this.reportTextWriter.WriteLine("</script>");

            // Knockout template for assemblies
            this.reportTextWriter.WriteLine("<script type=\"text/html\" id=\"assembly-template\">");
            this.reportTextWriter.WriteLine(
                "<tr data-bind=\"visible: visible, css: {{ namespace: parent != null }}\"><th><a href=\"#\" data-bind=\"text: name, click: toggleCollapse, attr: {{ class: collapsed() ? 'collapsed' : 'expanded' }}\" title=\"{0}\"> </a></th><th class=\"right\" data-bind=\"text: coveredLines\"></th><th class=\"right\" data-bind=\"text: uncoveredLines\"></th><th class=\"right\" data-bind=\"text: coverableLines\"></th><th class=\"right\" data-bind=\"text: isNaN(coverage()) ? '' : coverage() + '%', attr: {{ title: isNaN(coverage()) ? '' : coverageType }}\"></th><th><table class=\"coverage\"><tr><td class=\"green\" data-bind=\"style: {{ width: Math.round(coverage()) + 'px' }}, visible: !isNaN(coverage()) && Math.round(coverage()) > 0\">&nbsp;</td><td class=\"red\"data-bind=\"style: {{ width: (100 - Math.round(coverage())) + 'px' }}, visible: !isNaN(coverage()) && 100 - Math.round(coverage()) > 0\">&nbsp;</td><td class=\"gray\" style=\"width: 100px;\" data-bind=\"visible: isNaN(coverage())\">&nbsp;</td></tr></table></th></tr>",
                Resources.CollapseExpand);
            this.reportTextWriter.WriteLine("<!-- ko template: { name: function(element) { return element.isNamespace ? 'assembly-template' : 'class-template'; } , foreach: subelements } -->");
            this.reportTextWriter.WriteLine("<!-- /ko -->");
            this.reportTextWriter.WriteLine("</script>");

            // Knockout template for classes
            this.reportTextWriter.WriteLine("<script type=\"text/html\" id=\"class-template\">");
            this.reportTextWriter.WriteLine("<tr data-bind=\"visible: visible, css: { namespace: parent().parent != null }\"><td><a data-bind=\"text: name, attr: { href: reportPath }, visible: reportPath !== ''\"></a><span data-bind=\"text: name, visible: reportPath === ''\"></span></td><td class=\"right\" data-bind=\"text: coveredLines\"></td><td class=\"right\" data-bind=\"text: uncoveredLines\"></td><td class=\"right\" data-bind=\"text: coverableLines\"></td><td class=\"right\" data-bind=\"text: isNaN(coverage()) ? '' : coverage() + '%', attr: { title: isNaN(coverage()) ? '' : coverageType }\"></td><td><table class=\"coverage\"><tr><td class=\"green\" data-bind=\"style: { width: Math.round(coverage()) + 'px' }, visible: !isNaN(coverage()) && Math.round(coverage()) > 0\">&nbsp;</td><td class=\"red\"data-bind=\"style: { width: (100 - Math.round(coverage())) + 'px' }, visible: !isNaN(coverage()) && 100 - Math.round(coverage()) > 0\">&nbsp;</td><td class=\"gray\" style=\"width: 100px;\" data-bind=\"visible: isNaN(coverage())\">&nbsp;</td></tr></table></td></tr>");
            this.reportTextWriter.WriteLine("</script>");

            this.reportTextWriter.WriteLine("<table id=\"summaryTable\" class=\"overview\">");
            this.reportTextWriter.WriteLine("<colgroup>");
            this.reportTextWriter.WriteLine("<col />");
            this.reportTextWriter.WriteLine("<col width=\"90\" />");
            this.reportTextWriter.WriteLine("<col width=\"105\" />");
            this.reportTextWriter.WriteLine("<col width=\"100\" />");
            this.reportTextWriter.WriteLine("<col width=\"60\" />");
            this.reportTextWriter.WriteLine("<col width=\"112\" />");
            this.reportTextWriter.WriteLine("</colgroup>");

            this.reportTextWriter.WriteLine(
                "<thead><tr><th><a href=\"#\" data-bind=\"attr: {{ class: sortby() === 'name' ? 'sortactive' + '_' + sortorder() : 'sortinactive_asc' }}, click: function(data, event) {{ changeSorting(data, event, 'name') }}\">{0}</a></th><th class=\"right\"><a href=\"#\" data-bind=\"attr: {{ class: sortby() === 'covered' ? 'sortactive' + '_' + sortorder() : 'sortinactive_asc' }}, click: function(data, event) {{ changeSorting(data, event, 'covered') }}\">{1}</a></th><th class=\"right\"><a href=\"#\" data-bind=\"attr: {{ class: sortby() === 'uncovered' ? 'sortactive' + '_' + sortorder() : 'sortinactive_asc' }}, click: function(data, event) {{ changeSorting(data, event, 'uncovered') }}\">{2}</a></th><th class=\"right\"><a href=\"#\" data-bind=\"attr: {{ class: sortby() === 'coverable' ? 'sortactive' + '_' + sortorder() : 'sortinactive_asc' }}, click: function(data, event) {{ changeSorting(data, event, 'coverable') }}\">{3}</a></th><th class=\"center\" colspan=\"2\"><a href=\"#\" data-bind=\"attr: {{ class: sortby() === 'coverage' ? 'sortactive' + '_' + sortorder() : 'sortinactive_asc' }}, click: function(data, event) {{ changeSorting(data, event, 'coverage') }}\">{4}</a></th></tr></thead>",
                Resources.Name,
                Resources.Covered,
                Resources.Uncovered,
                Resources.Coverable,
                Resources.Coverage);
            this.reportTextWriter.WriteLine("<tbody data-bind=\"template: { name: 'assembly-template', foreach: assemblies }\">");
        }

        /// <summary>
        /// Adds custom summary elements to the report.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        public void CustomSummary(IEnumerable<Assembly> assemblies)
        {
            if (assemblies == null)
            {
                throw new ArgumentNullException("assemblies");
            }

            this.reportTextWriter.WriteLine("<script type=\"text/javascript\">");
            this.reportTextWriter.WriteLine("/* <![CDATA[ */");

            this.reportTextWriter.WriteLine("var assemblies = [");

            foreach (var assembly in assemblies)
            {
                this.reportTextWriter.WriteLine("  {");
                this.reportTextWriter.WriteLine("    \"name\" : '{0}',", assembly.Name);
                this.reportTextWriter.WriteLine("    \"classes\" : [");

                foreach (var @class in assembly.Classes)
                {
                    this.reportTextWriter.WriteLine(
                        "    {{ \"name\" : '{0}', \"reportPath\" : '{1}', \"coveredLines\" : {2}, \"uncoveredLines\" : {3}, \"coverableLines\" : {4}, \"coverageType\" : '{5}', \"methodCoverage\" : {6} }},",
                    @class.Name,
                    this.onlySummary ? string.Empty : GetClassReportFilename(@class.Assembly.ShortName, @class.Name),
                    @class.CoveredLines,
                    @class.CoverableLines - @class.CoveredLines,
                    @class.CoverableLines,
                    @class.CoverageType,
                    @class.CoverageType == CoverageType.MethodCoverage && @class.CoverageQuota.HasValue ? @class.CoverageQuota.Value.ToString(CultureInfo.InvariantCulture) : "'-'");
                }

                this.reportTextWriter.WriteLine("  ]},");
            }

            this.reportTextWriter.WriteLine("];");

            this.reportTextWriter.WriteLine("/* ]]> */");
            this.reportTextWriter.WriteLine("</script>");
        }

        /// <summary>
        /// Adds a metrics table to the report.
        /// </summary>
        /// <param name="headers">The headers.</param>
        public void BeginMetricsTable(IEnumerable<string> headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }

            this.reportTextWriter.WriteLine("<table class=\"overview\">");
            this.reportTextWriter.Write("<thead><tr>");

            foreach (var header in headers)
            {
                this.reportTextWriter.Write("<th>{0}</th>", WebUtility.HtmlEncode(header));
            }

            this.reportTextWriter.WriteLine("</tr></thead>");
            this.reportTextWriter.WriteLine("<tbody>");
        }

        /// <summary>
        /// Adds a file analysis table to the report.
        /// </summary>
        /// <param name="headers">The headers.</param>
        public void BeginLineAnalysisTable(IEnumerable<string> headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }

            this.reportTextWriter.WriteLine("<table class=\"lineAnalysis\">");
            this.reportTextWriter.Write("<thead><tr>");

            foreach (var header in headers)
            {
                this.reportTextWriter.Write("<th>{0}</th>", WebUtility.HtmlEncode(header));
            }

            this.reportTextWriter.WriteLine("</tr></thead>");
            this.reportTextWriter.WriteLine("<tbody>");
        }

        /// <summary>
        /// Adds a table row with two cells to the report.
        /// </summary>
        /// <param name="key">The text of the first column.</param>
        /// <param name="value">The text of the second column.</param>
        public void KeyValueRow(string key, string value)
        {
            this.reportTextWriter.WriteLine(
                "<tr><th>{0}</th><td>{1}</td></tr>",
                WebUtility.HtmlEncode(key),
                WebUtility.HtmlEncode(value));
        }

        /// <summary>
        /// Adds a table row with two cells to the report.
        /// </summary>
        /// <param name="key">The text of the first column.</param>
        /// <param name="files">The files.</param>
        public void KeyValueRow(string key, IEnumerable<string> files)
        {
            string value = string.Join("<br />", files.Select(v => string.Format(CultureInfo.InvariantCulture, "<a href=\"#{0}\">{1}</a>", WebUtility.HtmlEncode(ReplaceInvalidXmlChars(v)), WebUtility.HtmlEncode(v))));

            this.reportTextWriter.WriteLine(
                "<tr><th>{0}</th><td>{1}</td></tr>",
                WebUtility.HtmlEncode(key),
                value);
        }

        /// <summary>
        /// Adds the given metric values to the report.
        /// </summary>
        /// <param name="metric">The metric.</param>
        public void MetricsRow(MethodMetric metric)
        {
            if (metric == null)
            {
                throw new ArgumentNullException("metric");
            }

            this.reportTextWriter.Write("<tr>");

            this.reportTextWriter.Write("<td title=\"{0}\">{1}</td>", WebUtility.HtmlEncode(metric.Name), WebUtility.HtmlEncode(metric.ShortName));

            foreach (var metricValue in metric.Metrics.Select(m => m.Value))
            {
                this.reportTextWriter.Write("<td>{0}</td>", metricValue.ToString(CultureInfo.InvariantCulture));
            }

            this.reportTextWriter.WriteLine("</tr>");
        }

        /// <summary>
        /// Adds the coverage information of a single line of a file to the report.
        /// </summary>
        /// <param name="analysis">The line analysis.</param>
        public void LineAnalysis(LineAnalysis analysis)
        {
            if (analysis == null)
            {
                throw new ArgumentNullException("analysis");
            }

            string formattedLine = analysis.LineContent
                .Replace(((char)11).ToString(), "  ") // replace tab
                .Replace(((char)9).ToString(), "  "); // replace tab

            if (formattedLine.Length > 120)
            {
                formattedLine = formattedLine.Substring(0, 120);
            }

            formattedLine = WebUtility.HtmlEncode(formattedLine);
            formattedLine = formattedLine.Replace(" ", "&nbsp;");

            string lineVisitStatus = ConvertToCssClass(analysis.LineVisitStatus, false);

            this.reportTextWriter.Write("<tr data-coverage=\"{");

            this.reportTextWriter.Write(
                "'AllTestMethods': {{'VC': '{0}', 'LVS': '{1}'}}",
                analysis.LineVisitStatus != LineVisitStatus.NotCoverable ? analysis.LineVisits.ToString(CultureInfo.InvariantCulture) : string.Empty,
                lineVisitStatus);

            foreach (var coverageByTestMethod in analysis.LineCoverageByTestMethod)
            {
                this.reportTextWriter.Write(
                    ", 'M{0}': {{'VC': '{1}', 'LVS': '{2}'}}",
                    coverageByTestMethod.Key.Id.ToString(CultureInfo.InvariantCulture),
                    coverageByTestMethod.Value.LineVisitStatus != LineVisitStatus.NotCoverable ? coverageByTestMethod.Value.LineVisits.ToString(CultureInfo.InvariantCulture) : string.Empty,
                    ConvertToCssClass(coverageByTestMethod.Value.LineVisitStatus, false));
            }

            this.reportTextWriter.Write("}\">");

            this.reportTextWriter.Write(
                "<td class=\"{0}\">&nbsp;</td>",
                lineVisitStatus);
            this.reportTextWriter.Write(
                "<td class=\"leftmargin rightmargin right\">{0}</td>",
                analysis.LineVisitStatus != LineVisitStatus.NotCoverable ? analysis.LineVisits.ToString(CultureInfo.InvariantCulture) : string.Empty);
            this.reportTextWriter.Write(
                "<td class=\"rightmargin right\"><code>{0}</code></td>",
                analysis.LineNumber);
            this.reportTextWriter.Write(
                "<td class=\"{0}\"><code>{1}</code></td>",
                ConvertToCssClass(analysis.LineVisitStatus, true),
                formattedLine);

            this.reportTextWriter.WriteLine("</tr>");
        }

        /// <summary>
        /// Finishes the current table.
        /// </summary>
        public void FinishTable()
        {
            this.reportTextWriter.WriteLine("</tbody>");
            this.reportTextWriter.WriteLine("</table>");
        }

        /// <summary>
        /// Adds the coverage information of an assembly to the report.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public void SummaryAssembly(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }

            this.reportTextWriter.WriteLine(
                "<tr><th>{0}</th><th class=\"right\">{1}</th><th class=\"right\">{2}</th><th class=\"right\">{3}</th><th title=\"{4}\" class=\"right\">{5}</th><th>{6}</th></tr>",
                WebUtility.HtmlEncode(assembly.Name),
                assembly.CoveredLines,
                assembly.CoverableLines - assembly.CoveredLines,
                assembly.CoverableLines,
                assembly.CoverageQuota.HasValue ? CoverageType.LineCoverage.ToString() : string.Empty,
                assembly.CoverageQuota.HasValue ? assembly.CoverageQuota.Value.ToString(CultureInfo.InvariantCulture) + "%" : string.Empty,
                CreateCoverageTable(assembly.CoverageQuota));
        }

        /// <summary>
        /// Adds the coverage information of a class to the report.
        /// </summary>
        /// <param name="class">The class.</param>
        public void SummaryClass(Class @class)
        {
            if (@class == null)
            {
                throw new ArgumentNullException("class");
            }

            string filenameColumn = @class.Name;

            if (!this.onlySummary)
            {
                filenameColumn = string.Format(
                    CultureInfo.InvariantCulture,
                    "<a href=\"{0}\">{1}</a>",
                    WebUtility.HtmlEncode(GetClassReportFilename(@class.Assembly.ShortName, @class.Name)),
                    WebUtility.HtmlEncode(@class.Name));
            }

            this.reportTextWriter.WriteLine(
                "<tr><td>{0}</td><td class=\"right\">{1}</td><td class=\"right\">{2}</td><td class=\"right\">{3}</td><td title=\"{4}\" class=\"right\">{5}</td><td>{6}</td></tr>",
                filenameColumn,
                @class.CoveredLines,
                @class.CoverableLines - @class.CoveredLines,
                @class.CoverableLines,
                @class.CoverageType,
                @class.CoverageQuota.HasValue ? @class.CoverageQuota.Value.ToString(CultureInfo.InvariantCulture) + "%" : string.Empty,
                CreateCoverageTable(@class.CoverageQuota));
        }

        /// <summary>
        /// Saves a summary report.
        /// </summary>
        /// <param name="targetDirectory">The target directory.</param>
        public void SaveSummaryReport(string targetDirectory)
        {
            this.SaveReport();

            if (!this.onlySummary)
            {
                SaveCss(targetDirectory);
                SaveJavaScript(targetDirectory);
            }
        }

        /// <summary>
        /// Saves a class report.
        /// </summary><param name="targetDirectory">The target directory.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="className">Name of the class.</param>
        public void SaveClassReport(string targetDirectory, string assemblyName, string className)
        {
            this.SaveReport();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.reportTextWriter != null)
                {
                    this.reportTextWriter.Dispose();
                }
            }
        }

        /// <summary>
        /// Builds a table showing the coverage quota with red and green bars.
        /// </summary>
        /// <param name="coverage">The coverage quota.</param>
        /// <returns>Table showing the coverage quota with red and green bars.</returns>
        private static string CreateCoverageTable(decimal? coverage)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append("<table class=\"coverage\"><tr>");

            if (coverage.HasValue)
            {
                int covered = (int)Math.Round(coverage.Value, 0);
                int uncovered = 100 - covered;

                if (covered > 0)
                {
                    stringBuilder.Append("<td class=\"green\" style=\"width: " + covered + "px;\">&nbsp;</td>");
                }

                if (uncovered > 0)
                {
                    stringBuilder.Append("<td class=\"red\" style=\"width: " + uncovered + "px;\">&nbsp;</td>");
                }
            }
            else
            {
                stringBuilder.Append("<td class=\"gray\" style=\"width: 100px;\">&nbsp;</td>");
            }

            stringBuilder.Append("</tr></table>");
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts the <see cref="LineVisitStatus" /> to the corresponding CSS class.
        /// </summary>
        /// <param name="lineVisitStatus">The line visit status.</param>
        /// <param name="lightcolor">if set to <c>true</c> a CSS class representing a light color is returned.</param>
        /// <returns>The corresponding CSS class.</returns>
        private static string ConvertToCssClass(LineVisitStatus lineVisitStatus, bool lightcolor)
        {
            if (lineVisitStatus == LineVisitStatus.Covered)
            {
                return lightcolor ? "lightgreen" : "green";
            }
            else if (lineVisitStatus == LineVisitStatus.NotCovered)
            {
                return lightcolor ? "lightred" : "red";
            }
            else
            {
                return lightcolor ? "lightgray" : "gray";
            }
        }

        /// <summary>
        /// Gets the file name of the report file for the given class.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns>The file name.</returns>
        private static string GetClassReportFilename(string assemblyName, string className)
        {
            string key = assemblyName + "_" + className;

            string fileName = null;

            if (!FileNameByClass.TryGetValue(key, out fileName))
            {
                lock (FileNameByClass)
                {
                    if (!FileNameByClass.TryGetValue(key, out fileName))
                    {
                        string shortClassName = className.Substring(className.LastIndexOf('.') + 1);
                        fileName = RendererBase.ReplaceInvalidPathChars(assemblyName + "_" + shortClassName) + ".htm";

                        if (FileNameByClass.Values.Any(v => v.Equals(fileName, StringComparison.OrdinalIgnoreCase)))
                        {
                            int counter = 2;

                            do
                            {
                                fileName = RendererBase.ReplaceInvalidPathChars(assemblyName + "_" + shortClassName + counter) + ".htm";
                                counter++;
                            }
                            while (FileNameByClass.Values.Any(v => v.Equals(fileName, StringComparison.OrdinalIgnoreCase)));
                        }

                        FileNameByClass.Add(key, fileName);
                    }
                }
            }

            return fileName;
        }

        /// <summary>
        /// Saves the CSS.
        /// </summary>
        /// <param name="targetDirectory">The target directory.</param>
        private static void SaveCss(string targetDirectory)
        {
            string targetPath = Path.Combine(targetDirectory, "report.css");

            try
            {
                using (var fs = new FileStream(targetPath, FileMode.Create))
                {
                    using (var cssStream = GetCombinedCss())
                    {
                        cssStream.CopyTo(fs);
                    }
                }
            }
            catch (Exception ex)
            {
                string error = string.Format(CultureInfo.InvariantCulture, Resources.ReportNotSaved, targetPath, ex.Message);
                Logger.Error(error);
                throw new RenderingException(error, ex);
            }
        }

        /// <summary>
        /// Saves the java script.
        /// </summary>
        /// <param name="targetDirectory">The target directory.</param>
        private static void SaveJavaScript(string targetDirectory)
        {
            string targetPath = Path.Combine(targetDirectory, "combined.js");

            try
            {
                using (var fs = new FileStream(targetPath, FileMode.Create))
                {
                    using (var javaScriptStream = GetCombinedJavascript())
                    {
                        javaScriptStream.CopyTo(fs);
                    }
                }
            }
            catch (Exception ex)
            {
                string error = string.Format(CultureInfo.InvariantCulture, Resources.ReportNotSaved, targetPath, ex.Message);
                Logger.Error(error);
                throw new RenderingException(error, ex);
            }
        }

        /// <summary>
        /// Gets the combined CSS.
        /// </summary>
        /// <returns>The combined CSS.</returns>
        private static Stream GetCombinedCss()
        {
            var ms = new MemoryStream();

            using (Stream stream = typeof(HtmlRenderer).Assembly.GetManifestResourceStream(
                "Palmmedia.ReportGenerator.Reporting.Rendering.resources.custom.css"))
            {
                stream.CopyTo(ms);
            }

            byte[] lineBreak = Encoding.UTF8.GetBytes(Environment.NewLine);
            ms.Write(lineBreak, 0, lineBreak.Length);

            using (Stream stream = typeof(HtmlRenderer).Assembly.GetManifestResourceStream(
                "Palmmedia.ReportGenerator.Reporting.Rendering.resources.jquery-ui-1.10.0.custom.min.css"))
            {
                stream.CopyTo(ms);
            }

            ms.Position = 0;

            return ms;
        }

        /// <summary>
        /// Gets the combined javascript.
        /// </summary>
        /// <returns>The combined javascript.</returns>
        private static Stream GetCombinedJavascript()
        {
            var ms = new MemoryStream();

            using (Stream stream = typeof(HtmlRenderer).Assembly.GetManifestResourceStream(
                "Palmmedia.ReportGenerator.Reporting.Rendering.resources.jquery-1.9.1.min.js"))
            {
                stream.CopyTo(ms);
            }

            byte[] lineBreak = Encoding.UTF8.GetBytes(Environment.NewLine);
            ms.Write(lineBreak, 0, lineBreak.Length);

            using (Stream stream = typeof(HtmlRenderer).Assembly.GetManifestResourceStream(
                "Palmmedia.ReportGenerator.Reporting.Rendering.resources.jquery-ui-1.10.0.custom.min.js"))
            {
                stream.CopyTo(ms);
            }

            ms.Write(lineBreak, 0, lineBreak.Length);

            using (Stream stream = typeof(HtmlRenderer).Assembly.GetManifestResourceStream(
                "Palmmedia.ReportGenerator.Reporting.Rendering.resources.knockout-2.2.1.js"))
            {
                stream.CopyTo(ms);
            }

            ms.Write(lineBreak, 0, lineBreak.Length);

            byte[] translations = Encoding.UTF8.GetBytes(
                string.Format(
                CultureInfo.InvariantCulture,
                "var translations = {{ 'lineCoverage': '{0}', 'noGrouping': '{1}', 'byAssembly': '{2}', 'byNamespace': '{3}', 'all': '{4}' }};",
                CoverageType.LineCoverage.ToString(),
                Resources.NoGrouping,
                Resources.ByAssembly,
                Resources.ByNamespace,
                Resources.All));

            ms.Write(translations, 0, translations.Length);

            ms.Write(lineBreak, 0, lineBreak.Length);
            ms.Write(lineBreak, 0, lineBreak.Length);

            using (Stream stream = typeof(HtmlRenderer).Assembly.GetManifestResourceStream(
                "Palmmedia.ReportGenerator.Reporting.Rendering.resources.custom.js"))
            {
                stream.CopyTo(ms);
            }

            ms.Position = 0;

            return ms;
        }

        /// <summary>
        /// Initializes the text writer.
        /// </summary>
        /// <param name="targetPath">The target path.</param>
        private void CreateTextWriter(string targetPath)
        {
            try
            {
                this.reportTextWriter = new StreamWriter(new FileStream(targetPath, FileMode.Create));
            }
            catch (Exception ex)
            {
                string error = string.Format(CultureInfo.InvariantCulture, Resources.ReportNotSaved, targetPath, ex.Message);
                Logger.Error(error);
                throw new RenderingException(error, ex);
            }
        }

        /// <summary>
        /// Saves the report.
        /// </summary>
        private void SaveReport()
        {
            this.FinishReport();

            this.reportTextWriter.Flush();
            this.reportTextWriter.Dispose();

            this.reportTextWriter = null;
        }

        /// <summary>
        /// Finishes the report.
        /// </summary>
        private void FinishReport()
        {
            this.reportTextWriter.Write(string.Format(
                CultureInfo.InvariantCulture,
                "<div class=\"footer\">{0} {1} {2}<br />{3} - {4}<br /><a href=\"http://www.palmmedia.de\">www.palmmedia.de</a></div>",
                Resources.GeneratedBy,
                this.GetType().Assembly.GetName().Name,
                this.GetType().Assembly.GetName().Version,
                DateTime.Now.ToShortDateString(),
                DateTime.Now.ToLongTimeString()));

            using (var javaScriptStream = GetCombinedJavascript())
            {
                string javascript = this.onlySummary ?
                    "<script type=\"text/javascript\">/* <![CDATA[ */ " + new StreamReader(javaScriptStream).ReadToEnd() + " /* ]]> */ </script>"
                    : "<script type=\"text/javascript\" src=\"combined.js\"></script>";

                this.reportTextWriter.Write(HtmlEnd, javascript);
            }
        }
    }
}
