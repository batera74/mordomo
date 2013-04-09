using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class CreditMap : EntityTypeConfiguration<Credit>
    {
        public CreditMap()
        {
            // Primary Key
            this.HasKey(c => c.Id);

            // Properties
            this.Property(c => c.CreditDate)
                .IsRequired();

            this.Property(c => c.ExpirationDate)
                .IsRequired();

            this.Property(c => c.Used)
                .IsRequired();

            this.Property(c => c.CreditReason)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Credit");
            this.Property(c => c.Id).HasColumnName("Credit_Id");
            this.Property(c => c.CreditDate).HasColumnName("CreditDate");
            this.Property(c => c.ExpirationDate).HasColumnName("ExpirationDate");
            this.Property(c => c.Used).HasColumnName("Used");
            this.Property(c => c.CreditReason).HasColumnName("CreditReason");
        }
    }
}
