using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palmmedia.ReportGenerator;
using Palmmedia.ReportGenerator.Reporting.Rendering;

namespace Palmmedia.ReportGeneratorTest
{
    /// <summary>
    /// This is a test class for ReportConfigurationBuilder and is intended
    /// to contain all ReportConfigurationBuilder Unit Tests
    /// </summary>
    [TestClass]
    public class ReportConfigurationBuilderTest
    {
        private static readonly string reportPath = Path.Combine(FileManager.GetReportDirectory(), "OpenCover.xml");

        private ReportConfiguration configuration;

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize]
        // public static void MyClassInitialize(TestContext testContext)
        // {
        // }

        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup]
        // public static void MyClassCleanup()
        // {
        // }

        // Use TestInitialize to run code before running each test
        // [TestInitialize]
        // public void MyTestInitialize()
        // {
        // }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
            Assert.IsNotNull(this.configuration.ReportFiles);
            Assert.IsNotNull(this.configuration.SourceDirectories);
            Assert.IsNotNull(this.configuration.Filters);
        }

        #endregion

        [TestMethod]
        public void InitWithLegacyArguments_AllPropertiesApplied()
        {
            string[] legacyArguments = new string[] 
            { 
                reportPath,
                "C:\\temp",
                ReportTypes.Latex.ToString()
            };

            this.configuration = ReportConfigurationBuilder.Create(legacyArguments);

            Assert.IsTrue(this.configuration.ReportFiles.Contains(reportPath), "ReportPath does not exist in ReportFiles.");
            Assert.AreEqual("C:\\temp", this.configuration.TargetDirectory, "Wrong target directory applied.");
            Assert.AreEqual(ReportTypes.Latex, this.configuration.ReportType, "Wrong report type applied.");
            Assert.IsFalse(this.configuration.SourceDirectories.Any(), "Source directories should be empty.");
            Assert.IsFalse(this.configuration.Filters.Any(), "Filters should be empty.");
        }

        [TestMethod]
        public void InitWithNamedArguments_AllPropertiesApplied()
        {
            string[] namedArguments = new string[]
            { 
                "-reports:" + reportPath,
                "-targetdir:C:\\temp",
                "-reporttype:" + ReportTypes.Latex.ToString(),
                "-sourcedirs:C:\\temp\\source;C:\\temp\\source2",
                "-filters:+Test;-Test",
                "-verbosity:" + VerbosityLevel.Info.ToString()
            };

            this.configuration = ReportConfigurationBuilder.Create(namedArguments);

            Assert.IsTrue(this.configuration.ReportFiles.Contains(reportPath), "ReportPath does not exist in ReportFiles.");
            Assert.AreEqual("C:\\temp", this.configuration.TargetDirectory, "Wrong target directory applied.");
            Assert.AreEqual(ReportTypes.Latex, this.configuration.ReportType, "Wrong report type applied.");
            Assert.IsTrue(this.configuration.SourceDirectories.Contains("C:\\temp\\source"), "Directory does not exist in Source directories.");
            Assert.IsTrue(this.configuration.SourceDirectories.Contains("C:\\temp\\source2"), "Directory does not exist in Source directories.");
            Assert.IsTrue(this.configuration.Filters.Contains("+Test"), "Filter does not exist in ReportFiles.");
            Assert.IsTrue(this.configuration.Filters.Contains("-Test"), "Filter does not exist in ReportFiles.");
            Assert.AreEqual(VerbosityLevel.Info, this.configuration.VerbosityLevel, "Wrong verbosity level applied.");
        }
    }
}
