using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class PlanoMap : EntityTypeConfiguration<Plano>
    {
        public PlanoMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p => p.DataModificacao)
                .IsRequired();

            this.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(p => p.OrdemServicoPorMes)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Plano");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.DataModificacao).HasColumnName("DataModificacao");
            this.Property(p => p.Nome).HasColumnName("Nome");
            this.Property(p => p.OrdemServicoPorMes).HasColumnName("OrdemServicoPorMes");
        }
    }
}
