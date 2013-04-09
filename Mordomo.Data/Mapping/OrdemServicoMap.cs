using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class OrdemServicoMap : EntityTypeConfiguration<OrdemServico>
    {
        public OrdemServicoMap()
        {
            // Primary Key
            this.HasKey(s => s.Id);

            // Properties
            this.Property(s => s.Valor)
                .IsRequired();

            this.Property(s => s.DataModificacao)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("OrdemServico");
            this.Property(s => s.Id).HasColumnName("Id");
            this.Property(s => s.Valor).HasColumnName("Valor");
            this.Property(s => s.DataModificacao).HasColumnName("DataModificacao");

            //relationships
            this.HasRequired(s => s.Cliente)
                .WithRequiredDependent();

            this.HasRequired(s => s.Fornecedor)
                .WithRequiredDependent();

            this.HasRequired(s => s.Status)
                .WithRequiredDependent();

            this.HasMany(s => s.ItemsOrdemServico)
                .WithMany();
        }
    }
}
