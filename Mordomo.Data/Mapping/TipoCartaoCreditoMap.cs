using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class TipoCartaoCreditoMap : EntityTypeConfiguration<TipoCartaoCredito>
    {
        public TipoCartaoCreditoMap()
        {
            // Primary Key
            this.HasKey(p =>p.Id);

            // Properties
            this.Property(p =>p.Nome)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(p =>p.DataModificacao)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("TipoCartaoCredito");
            this.Property(p =>p.Id).HasColumnName("Id");
            this.Property(p =>p.Nome).HasColumnName("Nome");
            this.Property(p =>p.DataModificacao).HasColumnName("DataModificacao");
        }
    }
}
