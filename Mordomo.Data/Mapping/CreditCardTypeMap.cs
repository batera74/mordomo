using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class CreditCardTypeMap : EntityTypeConfiguration<CreditCardType>
    {
        public CreditCardTypeMap()
        {
            // Primary Key
            this.HasKey(p =>p.Id);

            // Properties
            this.Property(p =>p.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("CreditCardType");
            this.Property(p => p.Id).HasColumnName("CreditCardType_Id");
            this.Property(p =>p.Name).HasColumnName("Name");
            
        }
    }
}
