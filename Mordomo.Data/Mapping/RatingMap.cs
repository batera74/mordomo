using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class RatingMap : EntityTypeConfiguration<Rating>
    {
        public RatingMap()
        {
            // Primary Key
            this.HasKey(s => s.Id);

            // Properties
            this.Property(s => s.Commentary)
                .IsRequired()
                .HasMaxLength(200);
            
            // Table & Column Mappings
            this.ToTable("Rating");
            this.Property(s => s.Id).HasColumnName("Rating_Id");

            // Relationships
            this.HasRequired(s => s.Provider)
                .WithMany(p => p.Ratings);

            this.HasRequired(s => s.Client)
                .WithMany(c => c.Ratings);
        }
    }
}
