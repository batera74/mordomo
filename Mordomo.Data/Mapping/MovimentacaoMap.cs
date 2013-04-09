using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class MovimentacaoMap : EntityTypeConfiguration<Movimentacao>
    {
        public MovimentacaoMap()
        {
            // Primary Key
            this.HasKey(m =>m.Id);

            // Properties
            this.Property(m =>m.DataModificacao)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Movimentacao");
            this.Property(m =>m.Id).HasColumnName("Id");
            this.Property(m =>m.DataModificacao).HasColumnName("DataModificacao");

            // Relationships
            this.HasRequired(m => m.Cliente)
                .WithRequiredDependent();

            this.HasRequired(m => m.Fornecedor)
                .WithRequiredDependent();
            
            this.HasRequired(m => m.OrdemServico)
                .WithRequiredDependent();
        }
    }
}
