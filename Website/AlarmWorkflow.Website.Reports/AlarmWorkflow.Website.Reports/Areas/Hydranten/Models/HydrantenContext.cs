namespace AlarmWorkflow.Website.Reports.Areas.Hydranten.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HydrantenContext : DbContext
    {
        public HydrantenContext()
            : base("name=HydrantenContext")
        {
        }

        public virtual DbSet<Hydrant_Ergebnis> hydrant_ergebnis { get; set; }
        public virtual DbSet<Hydrant_Lage> hydrant_lage { get; set; }
        public virtual DbSet<Hydrant> hydrantens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hydrant_Ergebnis>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Hydrant_Ergebnis>()
                .HasMany(e => e.hydrantens)
                .WithRequired(e => e.hydrant_ergebnis)
                .HasForeignKey(e => e.LastResult)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hydrant_Lage>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Hydrant_Lage>()
                .HasMany(e => e.hydrantens)
                .WithRequired(e => e.hydrant_lage)
                .HasForeignKey(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hydrant>()
                .Property(e => e.Barcode)
                .IsUnicode(false);

            modelBuilder.Entity<Hydrant>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Hydrant>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<Hydrant>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Hydrant>()
                .Property(e => e.Housenumber)
                .IsUnicode(false);

            modelBuilder.Entity<Hydrant>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<Hydrant>()
                .Property(e => e.CommentCheck)
                .IsUnicode(false);
        }
    }
}
