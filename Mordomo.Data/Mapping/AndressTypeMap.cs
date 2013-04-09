using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class AndressTypeMap : EntityTypeConfiguration<AndressType>
    {
        public AndressTypeMap()
        {
            // Primary Key
            this.HasKey(e => e.Id);

            // Properties

            this.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AndressType");
            this.Property(e => e.Id).HasColumnName("AndressType_Id");   
        }
    }
}
