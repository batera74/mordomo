using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(90);

            // Table & Column Mappings
            this.ToTable("Country");
            this.Property(p => p.Id).HasColumnName("Country_Id");
            this.Property(p => p.Name).HasColumnName("Name");
            
            //Relationships
            this.HasMany(c => c.States)
                .WithRequired(s => s.Country)
                .WillCascadeOnDelete();
        }
    }
}
