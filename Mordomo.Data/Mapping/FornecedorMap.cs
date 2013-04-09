using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p => p.DataModificacao)
                .IsRequired();

            this.Property(p => p.Logo)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Fornecedor");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.DataModificacao).HasColumnName("DataModificacao");
            this.Property(p => p.Logo).HasColumnName("Logo");

            // Relationships
            this.HasMany(f => f.Servicos)
                .WithMany(s => s.Fornecedores);
        }
    }
}
