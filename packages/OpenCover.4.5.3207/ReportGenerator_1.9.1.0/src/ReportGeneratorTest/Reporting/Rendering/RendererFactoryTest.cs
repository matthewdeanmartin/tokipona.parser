using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palmmedia.ReportGenerator.Reporting.Rendering;
using System.Linq;
using System.Reflection;

namespace Palmmedia.ReportGeneratorTest.Reporting.Rendering
{
    /// <summary>
    /// This is a test class for RendererFactory and is intended
    /// to contain all RendererFactory Unit Tests
    /// </summary>
    [TestClass]
    public class RendererFactoryTest
    {
        [TestMethod]
        public void SupportsParallelClassReports_Html_TrueIsReturned()
        {
            var factory = new RendererFactory(ReportTypes.Html);
            Assert.IsTrue(factory.SupportsParallelClassReports, "True was expected.");

            factory = new RendererFactory(ReportTypes.HtmlSummary);
            Assert.IsTrue(factory.SupportsParallelClassReports, "True was expected.");
        }

        [TestMethod]
        public void SupportsParallelClassReports_Xml_TrueIsReturned()
        {
            var factory = new RendererFactory(ReportTypes.Xml);
            Assert.IsTrue(factory.SupportsParallelClassReports, "True was expected.");

            factory = new RendererFactory(ReportTypes.XmlSummary);
            Assert.IsTrue(factory.SupportsParallelClassReports, "True was expected.");
        }

        [TestMethod]
        public void SupportsParallelClassReports_Latex_FalseIsReturned()
        {
            var factory = new RendererFactory(ReportTypes.Latex);
            Assert.IsFalse(factory.SupportsParallelClassReports, "False was expected.");
        }

        [TestMethod]
        public void SupportsParallelClassReports_LatexSummary_TrueIsReturned()
        {
            var factory = new RendererFactory(ReportTypes.LatexSummary);
            Assert.IsTrue(factory.SupportsParallelClassReports, "True was expected.");
        }

        [TestMethod]
        public void CreateSummaryRenderer_Html_NewInstanceIsCreated()
        {
            var factory = new RendererFactory(ReportTypes.Html);

            var renderer1 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();
            var renderer2 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();
            
            Assert.AreNotSame(renderer1, renderer2, "New instance expected.");
            Assert.IsInstanceOfType(renderer1, typeof(HtmlRenderer), "Wrong type returned.");
        }

        [TestMethod]
        public void CreateSummaryRenderer_HtmlSummary_NewInstanceIsCreated()
        {
            var factory = new RendererFactory(ReportTypes.HtmlSummary);

            var renderer1 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();
            var renderer2 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();

            Assert.AreNotSame(renderer1, renderer2, "New instance expected.");
            Assert.IsInstanceOfType(renderer1, typeof(HtmlRenderer), "Wrong type returned.");
        }

        [TestMethod]
        public void CreateSummaryRenderer_Xml_NewInstanceIsCreated()
        {
            var factory = new RendererFactory(ReportTypes.Xml);

            var renderer1 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();
            var renderer2 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();

            Assert.AreNotSame(renderer1, renderer2, "New instance expected.");
            Assert.IsInstanceOfType(renderer1, typeof(XmlRenderer), "Wrong type returned.");
        }

        [TestMethod]
        public void CreateSummaryRenderer_XmlSummary_NewInstanceIsCreated()
        {
            var factory = new RendererFactory(ReportTypes.XmlSummary);

            var renderer1 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();
            var renderer2 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();

            Assert.AreNotSame(renderer1, renderer2, "New instance expected.");
            Assert.IsInstanceOfType(renderer1, typeof(XmlRenderer), "Wrong type returned.");
        }

        [TestMethod]
        public void CreateSummaryRenderer_Latex_SingletonIsReturned()
        {
            var factory = new RendererFactory(ReportTypes.Latex);

            var renderer1 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();
            var renderer2 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();

            Assert.AreSame(renderer1, renderer2, "Singleton instance expected.");
            Assert.IsInstanceOfType(renderer1, typeof(LatexRenderer), "Wrong type returned.");
        }

        [TestMethod]
        public void CreateSummaryRenderer_LatexSummary_SingletonIsReturned()
        {
            var factory = new RendererFactory(ReportTypes.LatexSummary);

            var renderer1 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();
            var renderer2 = GetInnerRenderers(factory.CreateSummaryRenderer()).First();

            Assert.AreSame(renderer1, renderer2, "Singleton instance expected.");
            Assert.IsInstanceOfType(renderer1, typeof(LatexRenderer), "Wrong type returned.");
        }

        [TestMethod]
        public void CreateClassRenderer_Html_NewInstanceIsCreated()
        {
            var factory = new RendererFactory(ReportTypes.Html);

            var renderer1 = GetInnerRenderers(factory.CreateClassRenderer()).First();
            var renderer2 = GetInnerRenderers(factory.CreateClassRenderer()).First();

            Assert.AreNotSame(renderer1, renderer2, "New instance expected.");
            Assert.IsInstanceOfType(renderer1, typeof(HtmlRenderer), "Wrong type returned.");
        }

        [TestMethod]
        public void CreateClassRenderer_HtmlSummary_NoInstanceIsReturned()
        {
            var factory = new RendererFactory(ReportTypes.HtmlSummary);

            Assert.IsTrue(!GetInnerRenderers(factory.CreateClassRenderer()).Any(), "No renderer expected.");
        }

        [TestMethod]
        public void CreateClassRenderer_Xml_NewInstanceIsCreated()
        {
            var factory = new RendererFactory(ReportTypes.Xml);

            var renderer1 = GetInnerRenderers(factory.CreateClassRenderer()).First();
            var renderer2 = GetInnerRenderers(factory.CreateClassRenderer()).First();

            Assert.AreNotSame(renderer1, renderer2, "New instance expected.");
            Assert.IsInstanceOfType(renderer1, typeof(XmlRenderer), "Wrong type returned.");
        }

        [TestMethod]
        public void CreateClassRenderer_XmlSummary_NoInstanceIsReturned()
        {
            var factory = new RendererFactory(ReportTypes.XmlSummary);

            Assert.IsTrue(!GetInnerRenderers(factory.CreateClassRenderer()).Any(), "No renderer expected.");
        }

        [TestMethod]
        public void CreateClassRenderer_Latex_SingletonIsReturned()
        {
            var factory = new RendererFactory(ReportTypes.Latex);

            var renderer1 = GetInnerRenderers(factory.CreateClassRenderer()).First();
            var renderer2 = GetInnerRenderers(factory.CreateClassRenderer()).First();

            Assert.AreSame(renderer1, renderer2, "Singleton instance expected.");
            Assert.IsInstanceOfType(renderer1, typeof(LatexRenderer), "Wrong type returned.");
        }

        [TestMethod]
        public void CreateClassRenderer_LatexSummary_NoInstanceIsReturned()
        {
            var factory = new RendererFactory(ReportTypes.LatexSummary);

            Assert.IsTrue(!GetInnerRenderers(factory.CreateClassRenderer()).Any(), "No renderer expected.");
        }

        [TestMethod]
        public void CreateClassRenderer_SeveralReportType_CorrectNumberIsReturned()
        {
            var factory = new RendererFactory(ReportTypes.Latex | ReportTypes.Xml | ReportTypes.Html);

            Assert.AreEqual(3, GetInnerRenderers(factory.CreateClassRenderer()).Count(), "Wrong number of renderers.");
        }

        private static IEnumerable<IReportRenderer> GetInnerRenderers(IReportRenderer renderer)
        {
            var reportRenderersField = typeof(MultiRenderer).GetField("renderers", BindingFlags.NonPublic | BindingFlags.Instance);

            return reportRenderersField.GetValue(renderer) as IEnumerable<IReportRenderer>;
        }
    }
}
