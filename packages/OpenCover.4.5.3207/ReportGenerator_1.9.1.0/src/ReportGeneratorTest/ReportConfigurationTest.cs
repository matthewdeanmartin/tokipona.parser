using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palmmedia.ReportGenerator;
using Palmmedia.ReportGenerator.Reporting.Rendering;

namespace Palmmedia.ReportGeneratorTest
{
    /// <summary>
    /// This is a test class for ReportConfiguration and is intended
    /// to contain all ReportConfiguration Unit Tests
    /// </summary>
    [TestClass]
    public class ReportConfigurationTest
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
        public void InitByConstructor_AllDefaultValuesApplied()
        {
            this.configuration = new ReportConfiguration(
                new[] { reportPath },
                "C:\\temp",
                new string[] { },
                new string[] { },
                new string[] { },
                string.Empty);

            Assert.IsTrue(this.configuration.ReportFiles.Contains(reportPath), "ReportPath does not exist in ReportFiles.");
            Assert.AreEqual("C:\\temp", this.configuration.TargetDirectory, "Wrong target directory applied.");
            Assert.AreEqual(ReportTypes.Html, this.configuration.ReportType, "Wrong report type applied.");
            Assert.AreEqual(0, this.configuration.SourceDirectories.Count(), "Wrong number of source directories.");
            Assert.AreEqual(0, this.configuration.Filters.Count(), "Wrong number of filters.");
            Assert.AreEqual(VerbosityLevel.Verbose, this.configuration.VerbosityLevel, "Wrong verbosity level applied.");
        }

        [TestMethod]
        public void InitByConstructor_AllPropertiesApplied()
        {
            this.configuration = new ReportConfiguration(
                new[] { reportPath },
                "C:\\temp",
                new[] { ReportTypes.Latex.ToString(), ReportTypes.Xml.ToString(), ReportTypes.Html.ToString() },
                new[] { FileManager.GetCodeAnalysisDirectory() },
                new[] { "+Test", "-Test" },
                VerbosityLevel.Info.ToString());

            Assert.IsTrue(this.configuration.ReportFiles.Contains(reportPath), "ReportPath does not exist in ReportFiles.");
            Assert.AreEqual("C:\\temp", this.configuration.TargetDirectory, "Wrong target directory applied.");
            Assert.IsTrue(this.configuration.ReportType.HasFlag(ReportTypes.Latex), "Wrong report type applied.");
            Assert.IsTrue(this.configuration.ReportType.HasFlag(ReportTypes.Xml), "Wrong report type applied.");
            Assert.IsTrue(this.configuration.ReportType.HasFlag(ReportTypes.Html), "Wrong report type applied.");
            Assert.IsTrue(this.configuration.SourceDirectories.Contains(FileManager.GetCodeAnalysisDirectory()), "Directory does not exist in Source directories.");
            Assert.IsTrue(this.configuration.Filters.Contains("+Test"), "Filter does not exist in ReportFiles.");
            Assert.IsTrue(this.configuration.Filters.Contains("-Test"), "Filter does not exist in ReportFiles.");
            Assert.AreEqual(VerbosityLevel.Info, this.configuration.VerbosityLevel, "Wrong verbosity level applied.");
        }

        [TestMethod]
        public void Validate_AllPropertiesApplied_ValidationPasses()
        {
            this.InitByConstructor_AllPropertiesApplied();

            Assert.IsTrue(this.configuration.Validate(), "Validation should pass.");
        }

        [TestMethod]
        public void Validate_NoReport_ValidationFails()
        {
            this.configuration = new ReportConfiguration(
                new string[] { },
                "C:\\temp",
                new[] { ReportTypes.Latex.ToString() },
                new[] { FileManager.GetCodeAnalysisDirectory() },
                new[] { "+Test", "-Test" },
                VerbosityLevel.Info.ToString());

            Assert.IsFalse(this.configuration.Validate(), "Validation should fail.");
        }

        [TestMethod]
        public void Validate_NonExistingReport_ValidationFails()
        {
            this.configuration = new ReportConfiguration(
                new[] { "123.xml" },
                "C:\\temp",
                new[] { ReportTypes.Latex.ToString() },
                new[] { FileManager.GetCodeAnalysisDirectory() },
                new[] { "+Test", "-Test" },
                VerbosityLevel.Info.ToString());

            Assert.IsFalse(this.configuration.Validate(), "Validation should fail.");
        }

        [TestMethod]
        public void Validate_NoTargetDirectory_ValidationFails()
        {
            this.configuration = new ReportConfiguration(
                new[] { reportPath },
                string.Empty,
                new[] { ReportTypes.Latex.ToString() },
                new[] { FileManager.GetCodeAnalysisDirectory() },
                new[] { "+Test", "-Test" },
                VerbosityLevel.Info.ToString());

            Assert.IsFalse(this.configuration.Validate(), "Validation should fail.");
        }

        [TestMethod]
        public void Validate_InvalidTargetDirectory_ValidationFails()
        {
            this.configuration = new ReportConfiguration(
                new[] { reportPath },
                "C:\\temp:?$",
                new[] { ReportTypes.Latex.ToString() },
                new[] { FileManager.GetCodeAnalysisDirectory() },
                new[] { "+Test", "-Test" },
                VerbosityLevel.Info.ToString());

            Assert.IsFalse(this.configuration.Validate(), "Validation should fail.");
        }

        [TestMethod]
        public void Validate_InvalidReportType_ValidationFails()
        {
            this.configuration = new ReportConfiguration(
                new[] { reportPath },
                "C:\\temp",
                new[] { "DoesNotExist" },
                new[] { FileManager.GetCodeAnalysisDirectory() },
                new[] { "+Test", "-Test" },
                VerbosityLevel.Info.ToString());

            Assert.IsFalse(this.configuration.Validate(), "Validation should fail.");
        }

        [TestMethod]
        public void Validate_NotExistingSourceDirectory_ValidationFails()
        {
            this.configuration = new ReportConfiguration(
                new[] { reportPath },
                "C:\\temp",
                new[] { ReportTypes.Latex.ToString() },
                new[] { Path.Combine(FileManager.GetCodeAnalysisDirectory(), "123456") },
                new[] { "+Test", "-Test" },
                VerbosityLevel.Info.ToString());

            Assert.IsFalse(this.configuration.Validate(), "Validation should fail.");
        }

        [TestMethod]
        public void Validate_InvalidFilter_ValidationFails()
        {
            this.configuration = new ReportConfiguration(
                new[] { reportPath },
                @"C:\\temp",
                new[] { ReportTypes.Latex.ToString() },
                new[] { FileManager.GetCodeAnalysisDirectory() },
                new[] { "Test" },
                VerbosityLevel.Info.ToString());

            Assert.IsFalse(this.configuration.Validate(), "Validation should fail.");
        }
    }
}
