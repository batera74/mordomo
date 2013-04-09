using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            // Primary Key
            this.HasKey(e => e.Id);

            // Properties
            this.Property(e => e.DataModificacao)
                .IsRequired();

            this.Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(e => e.Numero)
                .IsRequired();

            this.Property(e => e.Complemento)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(e => e.CodigoPostal)
                .IsRequired()
                .HasMaxLength(8);
            

            // Table & Column Mappings
            this.ToTable("OrdemServico");
            this.Property(e => e.Id).HasColumnName("Id");
            this.Property(e => e.DataModificacao).HasColumnName("DataModificacao");
            this.Property(e => e.Logradouro).HasColumnName("Logradouro");
            this.Property(e => e.Numero).HasColumnName("Numero");
            this.Property(e => e.Complemento).HasColumnName("Complemento");
            this.Property(e => e.CodigoPostal).HasColumnName("CodigoPostal");

            // Relationships
            this.HasRequired(e => e.TipoEndereco)
                .WithRequiredDependent();

            this.HasRequired(e => e.Cidade)
                .WithRequiredDependent();
        }
    }
}
