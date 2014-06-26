// This file is part of AlarmWorkflow.
// 
// AlarmWorkflow is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// AlarmWorkflow is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with AlarmWorkflow.  If not, see <http://www.gnu.org/licenses/>.

namespace AlarmWorkflow.Website.Reports.Areas.Hydranten.Models
{
    using System.Data.Entity;

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

            modelBuilder.Entity<Hydrant>()
                .Property(e => e.ImagePath)
                .IsUnicode(false);
        }
    }
}
