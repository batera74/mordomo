using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class PessoaFisicaMap : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p => p.DataModificacao)
                .IsRequired();

            this.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(p => p.Sobrenome)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p => p.DataNascimento)
                .IsRequired();

            this.Property(p => p.CPF)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(p => p.Celular)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(p => p.Genero)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("PessoaFisica");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.DataModificacao).HasColumnName("DataModificacao");
            this.Property(p => p.Nome).HasColumnName("Nome");
            this.Property(p => p.Sobrenome).HasColumnName("Sobrenome");
            this.Property(p => p.DataNascimento).HasColumnName("DataNascimento");
            this.Property(p => p.CPF).HasColumnName("CPF");
            this.Property(p => p.Celular).HasColumnName("Celular");
            this.Property(p => p.Genero).HasColumnName("Genero");
        }
    }
}
