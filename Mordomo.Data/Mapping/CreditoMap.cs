using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class CreditoMap : EntityTypeConfiguration<Credito>
    {
        public CreditoMap()
        {
            // Primary Key
            this.HasKey(c => c.Id);

            // Properties
            this.Property(c => c.DataModificacao)
                .IsRequired();

            this.Property(c => c.DataCredito)
                .IsRequired();

            this.Property(c => c.DataExpiracao)
                .IsRequired();

            this.Property(c => c.Utilizado)
                .IsRequired();

            this.Property(c => c.MotivoCredito)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Credito");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.DataModificacao).HasColumnName("DataModificacao");
            this.Property(c => c.DataCredito).HasColumnName("DataCredito");
            this.Property(c => c.DataExpiracao).HasColumnName("DataExpiracao");
            this.Property(c => c.Utilizado).HasColumnName("Utilizado");
            this.Property(c => c.MotivoCredito).HasColumnName("MotivoCredito");
        }
    }
}
