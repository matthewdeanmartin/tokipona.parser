using System.ComponentModel.DataAnnotations;

namespace DemoSite.Models
{
    public class SimpleParserViewModel
    {
        public string SourceText { get; set; }
        public string Normalized { get; set; }
        public string Formatted { get; set; }
        public string FormattedPos { get; set; }     
        public string Glossed { get; set; }
        public string Recovered { get; set; }
        public string Colorized { get; set; }
    }
}