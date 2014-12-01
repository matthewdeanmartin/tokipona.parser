namespace TokiPonaApi.TpRepository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TokiAwenContext : DbContext
    {
        public TokiAwenContext()
            : base("name=TokiAwenContext")
        {
        }

        public virtual DbSet<CorpusText> CorpusTexts { get; set; }
        public virtual DbSet<Syntax> Syntaxes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
