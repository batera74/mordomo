using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class ItemOrdemServicoMap : EntityTypeConfiguration<ItemOrdemServico>
    {
        public ItemOrdemServicoMap()
        {
            // Primary Key
            this.HasKey(i => i.Id);

            // Properties
            this.Property(i => i.DataModificacao)
                .IsRequired();

            this.Property(i => i.Nome)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(i => i.Descricao)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("ItemOrdemServico");
            this.Property(i => i.Id).HasColumnName("Id");
            this.Property(i => i.Nome).HasColumnName("Nome");
            this.Property(i => i.DataModificacao).HasColumnName("DataModificacao");
            this.Property(i => i.Descricao).HasColumnName("Descricao");

            // Relationships
            this.HasMany(i => i.OrdensServico)
                .WithMany();
        }
    }
}
