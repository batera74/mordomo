using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class AndressMap : EntityTypeConfiguration<Andress>
    {
        public AndressMap()
        {
            // Primary Key
            this.HasKey(e => e.Id);

            // Properties

            this.Property(e => e.AndressLine1)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(e => e.Number)
                .IsRequired();

            this.Property(e => e.Complement)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(8);
            

            // Table & Column Mappings
            this.ToTable("Andress");
            this.Property(m => m.Id).HasColumnName("Andress_Id");

            // Relationships
            this.HasRequired(e => e.AndressType)
                .WithRequiredDependent();

            this.HasRequired(e => e.City)
                .WithRequiredDependent();
        }
    }
}
