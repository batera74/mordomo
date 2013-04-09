using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;


namespace Mordomo.Data.Mapping
{
    public class ServicoMap : EntityTypeConfiguration<Servico>
    {
        public ServicoMap()
        {
            // Primary Key
            this.HasKey(s => s.Id);

            // Properties
            this.Property(s => s.DataModificacao)
                .IsRequired();

            this.Property(s => s.Nome)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(s => s.Descricao)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("OrdemServico");
            this.Property(s => s.Id).HasColumnName("Id");
            this.Property(s => s.DataModificacao).HasColumnName("DataModificacao");
            this.Property(s => s.Nome).HasColumnName("Nome");
            this.Property(s => s.Descricao).HasColumnName("Descricao");

            // Relationships
            this.HasMany(s => s.Fornecedores)
                .WithMany(f => f.Servicos);
        }
    }
}
