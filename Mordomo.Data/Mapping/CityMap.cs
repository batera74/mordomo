using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(60);

            // Table & Column Mappings
            this.ToTable("City");
            this.Property(p => p.Id).HasColumnName("City_Id");
            this.Property(p => p.Name).HasColumnName("Name");            
        }
    }
}
