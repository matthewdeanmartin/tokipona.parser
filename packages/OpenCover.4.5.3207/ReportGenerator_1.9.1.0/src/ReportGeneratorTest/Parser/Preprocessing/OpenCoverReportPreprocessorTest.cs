using System.IO;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palmmedia.ReportGenerator.Parser.Preprocessing;
using Palmmedia.ReportGenerator.Parser.Preprocessing.FileSearch;

namespace Palmmedia.ReportGeneratorTest.Parser.Preprocessing
{
    /// <summary>
    /// This is a test class for OpenCoverReportPreprocessor and is intended
    /// to contain all OpenCoverReportPreprocessor Unit Tests
    /// </summary>
    [TestClass]
    public class OpenCoverReportPreprocessorTest
    {
        private static readonly string filePath = Path.Combine(FileManager.GetReportDirectory(), "OpenCover.xml");

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            FileManager.CopyTestClasses();
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            FileManager.DeleteTestClasses();
        }

        // Use TestInitialize to run code before running each test
        // [TestInitialize]
        // public void MyTestInitialize()
        // {
        // }

        // Use TestCleanup to run code after each test has run
        // [TestCleanup]
        // public void MyTestCleanup()
        // {
        // }

        #endregion

        /// <summary>
        /// A test for Execute
        /// </summary>
        [TestMethod]
        public void Execute_SequencePointsOfAutoPropertiesAdded()
        {
            XDocument report = XDocument.Load(filePath);

            var classSearcherFactory = new ClassSearcherFactory();
            new OpenCoverReportPreprocessor(report, classSearcherFactory, new ClassSearcher(string.Empty)).Execute();

            Assert.AreEqual(9, report.Descendants("File").Count(), "Wrong number of total files.");

            var gettersAndSetters = report.Descendants("Class")
                .Single(c => c.Element("FullName") != null && c.Element("FullName").Value == "Test.TestClass2")
                .Elements("Methods")
                .Elements("Method")
                .Where(m => m.Attribute("isGetter").Value == "true" || m.Attribute("isSetter").Value == "true");

            foreach (var getterOrSetter in gettersAndSetters)
            {
                Assert.IsTrue(getterOrSetter.Element("FileRef") != null);
                Assert.IsTrue(getterOrSetter.Element("SequencePoints") != null);

                var sequencePoints = getterOrSetter.Element("SequencePoints").Elements("SequencePoint");
                Assert.AreEqual(1, sequencePoints.Count(), "Wrong number of sequence points.");
                Assert.AreEqual(getterOrSetter.Element("MethodPoint").Attribute("vc").Value, sequencePoints.First().Attribute("vc").Value, "Getter or setter should have been visited.");
            }
        }
    }
}
