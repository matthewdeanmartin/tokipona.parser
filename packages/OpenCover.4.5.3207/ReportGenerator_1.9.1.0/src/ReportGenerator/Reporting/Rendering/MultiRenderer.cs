using System;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Parser.Analysis;

namespace Palmmedia.ReportGenerator.Reporting.Rendering
{
    /// <summary>
    /// Renderer that aggregates several renderers.
    /// </summary>
    internal class MultiRenderer : IReportRenderer, IDisposable
    {
        /// <summary>
        /// The renderers.
        /// </summary>
        private readonly IEnumerable<IReportRenderer> renderers;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiRenderer"/> class.
        /// </summary>
        /// <param name="renderers">The renderers.</param>
        public MultiRenderer(IEnumerable<IReportRenderer> renderers)
        {
            if (renderers == null)
            {
                throw new ArgumentNullException("renderers");
            }

            this.renderers = renderers;
        }

        /// <summary>
        /// Begins the summary report.
        /// </summary>
        /// <param name="targetDirectory">The target directory.</param>
        /// <param name="title">The title.</param>
        public void BeginSummaryReport(string targetDirectory, string title)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.BeginSummaryReport(targetDirectory, title);
            }
        }

        /// <summary>
        /// Adds custom summary elements to the report.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        public void CustomSummary(IEnumerable<Assembly> assemblies)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.CustomSummary(assemblies);
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
            foreach (var renderer in this.renderers)
            {
                renderer.BeginClassReport(targetDirectory, assemblyName, className);
            }
        }

        /// <summary>
        /// Adds a header to the report.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Header(string text)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.Header(text);
            }
        }

        /// <summary>
        /// Adds the test methods to the report.
        /// </summary>
        /// <param name="testMethods">The test methods.</param>
        public void TestMethods(IEnumerable<TestMethod> testMethods)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.TestMethods(testMethods);
            }
        }

        /// <summary>
        /// Adds a file of a class to a report.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        public void File(string path)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.File(path);
            }
        }

        /// <summary>
        /// Adds a paragraph to the report.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Paragraph(string text)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.Paragraph(text);
            }
        }

        /// <summary>
        /// Adds a table with two columns to the report.
        /// </summary>
        public void BeginKeyValueTable()
        {
            foreach (var renderer in this.renderers)
            {
                renderer.BeginKeyValueTable();
            }
        }

        /// <summary>
        /// Adds a summary table to the report.
        /// </summary>
        public void BeginSummaryTable()
        {
            foreach (var renderer in this.renderers)
            {
                renderer.BeginSummaryTable();
            }
        }

        /// <summary>
        /// Adds a metrics table to the report.
        /// </summary>
        /// <param name="headers">The headers.</param>
        public void BeginMetricsTable(IEnumerable<string> headers)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.BeginMetricsTable(headers);
            }
        }

        /// <summary>
        /// Adds a file analysis table to the report.
        /// </summary>
        /// <param name="headers">The headers.</param>
        public void BeginLineAnalysisTable(IEnumerable<string> headers)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.BeginLineAnalysisTable(headers);
            }
        }

        /// <summary>
        /// Adds a table row with two cells to the report.
        /// </summary>
        /// <param name="key">The text of the first column.</param>
        /// <param name="value">The text of the second column.</param>
        public void KeyValueRow(string key, string value)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.KeyValueRow(key, value);
            }
        }

        /// <summary>
        /// Adds a table row with two cells to the report.
        /// </summary>
        /// <param name="key">The text of the first column.</param>
        /// <param name="files">The files.</param>
        public void KeyValueRow(string key, IEnumerable<string> files)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.KeyValueRow(key, files);
            }
        }

        /// <summary>
        /// Adds the given metric values to the report.
        /// </summary>
        /// <param name="metric">The metric.</param>
        public void MetricsRow(MethodMetric metric)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.MetricsRow(metric);
            }
        }

        /// <summary>
        /// Adds the coverage information of a single line of a file to the report.
        /// </summary>
        /// <param name="analysis">The line analysis.</param>
        public void LineAnalysis(LineAnalysis analysis)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.LineAnalysis(analysis);
            }
        }

        /// <summary>
        /// Finishes the current table.
        /// </summary>
        public void FinishTable()
        {
            foreach (var renderer in this.renderers)
            {
                renderer.FinishTable();
            }
        }

        /// <summary>
        /// Adds the coverage information of an assembly to the report.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public void SummaryAssembly(Assembly assembly)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.SummaryAssembly(assembly);
            }
        }

        /// <summary>
        /// Adds the coverage information of a class to the report.
        /// </summary>
        /// <param name="class">The class.</param>
        public void SummaryClass(Class @class)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.SummaryClass(@class);
            }
        }

        /// <summary>
        /// Saves a summary report.
        /// </summary>
        /// <param name="targetDirectory">The target directory.</param>
        public void SaveSummaryReport(string targetDirectory)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.SaveSummaryReport(targetDirectory);
            }
        }

        /// <summary>
        /// Saves a class report.
        /// </summary>
        /// <param name="targetDirectory">The target directory.</param>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="className">Name of the class.</param>
        public void SaveClassReport(string targetDirectory, string assemblyName, string className)
        {
            foreach (var renderer in this.renderers)
            {
                renderer.SaveClassReport(targetDirectory, assemblyName, className);
            }
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
                foreach (var renderer in this.renderers)
                {
                    IDisposable disposableRenderer = renderer as IDisposable;

                    if (disposableRenderer != null)
                    {
                        disposableRenderer.Dispose();
                    }
                }
            }
        }
    }
}
