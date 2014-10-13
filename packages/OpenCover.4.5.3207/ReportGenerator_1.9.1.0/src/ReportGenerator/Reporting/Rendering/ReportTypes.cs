using System;

namespace Palmmedia.ReportGenerator.Reporting.Rendering
{
    /// <summary>
    /// Enumeration representing the various report types.
    /// </summary>
    [Flags]
    public enum ReportTypes
    {
        /// <summary>
        /// Not applied.
        /// </summary>
        None = 0,

        /// <summary>
        /// Full HTML report.
        /// </summary>
        Html = 1,

        /// <summary>
        /// Summary HTML report.
        /// </summary>
        HtmlSummary = 2,

        /// <summary>
        /// Full XML report.
        /// </summary>
        Xml = 4,

        /// <summary>
        /// Summary XML report.
        /// </summary>
        XmlSummary = 8,

        /// <summary>
        /// Full Latex report.
        /// </summary>
        Latex = 16,

        /// <summary>
        /// Summary Latex report.
        /// </summary>
        LatexSummary = 32
    }
}
