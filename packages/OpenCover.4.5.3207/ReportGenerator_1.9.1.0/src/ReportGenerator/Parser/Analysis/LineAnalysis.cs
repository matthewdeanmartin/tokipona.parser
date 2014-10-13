using System.Collections.Generic;

namespace Palmmedia.ReportGenerator.Parser.Analysis
{
    /// <summary>
    /// Full coverage information of a line in a source file.
    /// </summary>
    public class LineAnalysis : ShortLineAnalysis
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LineAnalysis" /> class.
        /// </summary>
        /// <param name="lineVisits">The number of line visits.</param>
        /// <param name="lineCoverageByTestMethod">The line coverage by test method.</param>
        /// <param name="lineNumber">The line number.</param>
        /// <param name="lineContent">Content of the line.</param>
        public LineAnalysis(int lineVisits, IDictionary<TestMethod, ShortLineAnalysis> lineCoverageByTestMethod, int lineNumber, string lineContent)
            : base(lineVisits)
        {
            this.LineCoverageByTestMethod = lineCoverageByTestMethod;
            this.LineNumber = lineNumber;
            this.LineContent = lineContent;
        }

        /// <summary>
        /// Gets the line number.
        /// </summary>
        public int LineNumber { get; private set; }

        /// <summary>
        /// Gets the content of the line.
        /// </summary>
        /// <value>
        /// The content of the line.
        /// </value>
        public string LineContent { get; private set; }

        /// <summary>
        /// Gets the line coverage by test method.
        /// </summary>
        /// <value>
        /// The line coverage by test method.
        /// </value>
        public IDictionary<TestMethod, ShortLineAnalysis> LineCoverageByTestMethod { get; private set; }
    }
}
