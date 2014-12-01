namespace TokiPonaApi.TpRepository
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Syntax")]
    public partial class Syntax
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(10)]
        public string Language { get; set; }

        [StringLength(4000)]
        public string LanguageLicenseUrl { get; set; }

        [StringLength(4000)]
        public string ColorizeUrl { get; set; }

        [StringLength(4000)]
        public string DiagramUrl { get; set; }

        [StringLength(4000)]
        public string SyntaxErrorsUrl { get; set; }

        [StringLength(4000)]
        public string Inventor { get; set; }

    }
}
