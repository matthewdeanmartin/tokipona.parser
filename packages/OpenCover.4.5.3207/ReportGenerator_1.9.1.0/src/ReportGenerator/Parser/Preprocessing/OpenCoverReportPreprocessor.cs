using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using log4net;
using Palmmedia.ReportGenerator.Common;
using Palmmedia.ReportGenerator.Parser.Preprocessing.CodeAnalysis;
using Palmmedia.ReportGenerator.Parser.Preprocessing.FileSearch;
using Palmmedia.ReportGenerator.Properties;

namespace Palmmedia.ReportGenerator.Parser.Preprocessing
{
    /// <summary>
    /// Preprocessor for OpenCover reports.
    /// </summary>
    internal class OpenCoverReportPreprocessor : ReportPreprocessorBase
    {
        /// <summary>
        /// Regex to analyze/split a method name.
        /// </summary>
        private const string MethodRegex = @"^.*::(?<MethodName>.+)\((?<Arguments>.*)\)$";

        /// <summary>
        /// The Logger.
        /// </summary>
        private static readonly ILog Logger = LogManager.GetLogger(typeof(OpenCoverReportPreprocessor));

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCoverReportPreprocessor"/> class.
        /// </summary>
        /// <param name="report">The report.</param>
        /// <param name="classSearcherFactory">The class searcher factory.</param>
        /// <param name="globalClassSearcher">The global class searcher.</param>
        public OpenCoverReportPreprocessor(XContainer report, ClassSearcherFactory classSearcherFactory, ClassSearcher globalClassSearcher)
            : base(report, classSearcherFactory, globalClassSearcher)
        {
        }

        /// <summary>
        /// Executes the preprocessing of the report.
        /// </summary>
        public override void Execute()
        {
            foreach (var module in this.Report.Descendants("Module").ToArray())
            {
                this.AddCoverageDataOfAutoProperties(module);

                // A new instance is created for every module.
                this.ClassSearcher = null;
            }
        }

        /// <summary>
        /// Adds a new source code file to the report.
        /// </summary>
        /// <param name="filesContainer">The files container.</param>
        /// <param name="fileId">The file id.</param>
        /// <param name="file">The file path.</param>
        protected override void AddNewFile(XContainer filesContainer, string fileId, string file)
        {
            filesContainer.Add(new XElement("File", new XAttribute("uid", fileId), new XAttribute("fullPath", file)));
        }

        /// <summary>
        /// Updates the property element.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="elementPosition">The element position.</param>
        /// <param name="fileId">The file id.</param>
        private static void UpdatePropertyElement(XContainer property, SourceElementPosition elementPosition, string fileId)
        {
            property.Add(new XElement("FileRef", new XAttribute("uid", fileId)));

            var seqpnt = new XElement(
                "SequencePoint",
                new XAttribute("vc", property.Element("MethodPoint").Attribute("vc").Value),
                new XAttribute("sl", elementPosition.Start));

            property.Element("SequencePoints").Add(seqpnt);
        }

        /// <summary>
        /// Adds the coverage data of auto properties.
        /// </summary>
        /// <param name="module">The module.</param>
        private void AddCoverageDataOfAutoProperties(XElement module)
        {
            if (module.Element("Files") == null)
            {
                module.Add(new XElement("Files"));
            }

            var filenameByFileIdDictionary = module
                .Element("Files")
                .Elements("File")
                .ToDictionary(f => f.Attribute("uid").Value, f => f.Attribute("fullPath").Value);

            Func<XElement, bool> isProperty = v => v.HasAttributeWithValue("isGetter", "true") || v.HasAttributeWithValue("isSetter", "true");

            var unexecutedProperties = module
                                    .Elements("Classes")
                                    .Elements("Class")
                                    .Where(c => !c.Element("FullName").Value.Contains("__")
                                        && !c.Element("FullName").Value.Contains("<")
                                        && !c.Element("FullName").Value.Contains("/"))
                                    .Elements("Methods")
                                    .Elements("Method")
                                    .Where(m => m.Attribute("skippedDueTo") == null
                                        && isProperty(m)
                                        && m.Element("SequencePoints") != null
                                        && !m.Element("SequencePoints").Elements().Any())
                                    .ToArray();

            long counter = 0;
            foreach (var property in unexecutedProperties)
            {
                string propertyName = Regex.Match(property.Element("Name").Value, MethodRegex).Groups["MethodName"].Value;

                var propertyElement = new PropertyElement(property.Parent.Parent.Element("FullName").Value.Replace("/", string.Empty), propertyName);

                // Get files in which property could be defined
                var fileIds = property.Parent
                    .Elements("Method")
                    .Elements("FileRef")
                    .Select(f => f.Attribute("uid").Value)
                    .Distinct()
                    .ToArray();

                if (this.SearchElement(
                    propertyElement,
                    filenameByFileIdDictionary,
                    fileIds,
                    property,
                    UpdatePropertyElement,
                    property.Parent.Parent.Parent.Parent.Element("Files")))
                {
                    counter++;
                }
            }

            if (unexecutedProperties.LongLength > 0)
            {
                Logger.DebugFormat("  " + Resources.AddedCoverageInformationOfPropertiesOpenCover, counter, unexecutedProperties.LongLength, module.Element("ModuleName").Value);
            }
        }
    }
}
