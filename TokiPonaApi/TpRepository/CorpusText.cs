namespace TokiPonaApi.TpRepository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CorpusText
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string RawText { get; set; }

        public string ColorizedHtml { get; set; }

        public string PlaintextDiagram { get; set; }

        public string Gloss { get; set; }

        [StringLength(10)]
        public string GlossLanguage { get; set; }

        [StringLength(10)]
        public string Language { get; set; }

        [StringLength(10)]
        public string LanguageVersion { get; set; }

        [StringLength(10)]
        public string SyntaxStrictness { get; set; }

        [StringLength(50)]
        public string TextType { get; set; }

        [StringLength(50)]
        public string DraftStatus { get; set; }

        [StringLength(50)]
        public string Visibility { get; set; }

        public DateTime? Expiration { get; set; }

        [StringLength(4000)]
        public string Url { get; set; }

        [StringLength(10)]
        public string AllowComments { get; set; }

        [StringLength(250)]
        public string AllowCommentsBy { get; set; }
    }
}
