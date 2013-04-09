using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class PessoaJuridicaMap : EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaMap()
        {
            // Primary Key
            this.HasKey(p =>p.Id);

            // Properties
            this.Property(p =>p.DataModificacao)
                .IsRequired();

            this.Property(p =>p.NomeFantasia)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p =>p.RazaoSocial)
               .IsRequired()
               .HasMaxLength(100);

            this.Property(p =>p.CNPJ)
               .IsRequired()
               .HasMaxLength(14);

            this.Property(p =>p.TelefoneComercial)
               .IsRequired()
               .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("PessoaJuridica");
            this.Property(p =>p.Id).HasColumnName("Id");
            this.Property(p =>p.DataModificacao).HasColumnName("DataModificacao");
            this.Property(p => p.NomeFantasia).HasColumnName("NomeFantasia");
            this.Property(p => p.RazaoSocial).HasColumnName("RazaoSocial");
            this.Property(p => p.TelefoneComercial).HasColumnName("TelefoneComercial");
        }
    }
}
