using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class ContaMap : EntityTypeConfiguration<Conta>
    {
        public ContaMap()
        {
            // Primary Key
            this.HasKey(c => c.Id);
            
            this.Property(c => c.DataModificacao)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Conta");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.DataModificacao).HasColumnName("DataModificacao");

            // Relationships
            this.HasRequired(c => c.Plano)
                .WithRequiredDependent();

            this.HasRequired(c => c.Movimentacoes)
                .WithMany();

            this.HasRequired(c => c.Creditos)
                .WithMany();
        }
    }
}
