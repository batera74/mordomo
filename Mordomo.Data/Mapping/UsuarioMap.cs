using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            this.HasKey(u => u.Id);

            // Properties
            this.Property(u => u.DataModificacao)
                .IsRequired();

            this.Property(u => u.Email)                
                .IsRequired()
                .HasMaxLength(255);

            this.Property(u => u.Ativo)
                .IsRequired();

            this.Property(u => u.UltimoLogin)
                .IsRequired();

            this.Property(u => u.Telefone)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(u => u.Login)                
                .IsRequired()
                .HasMaxLength(50);

            this.Property(u => u.Password)
                .IsRequired();

            this.Property(u => u.Verificado)
                .IsRequired();


            // Table & Column Mappings
            this.ToTable("ItemOrdemServico");
            this.Property(u => u.Id).HasColumnName("Id");
            this.Property(u => u.DataModificacao).HasColumnName("DataModificacao");
            this.Property(u => u.Email).HasColumnName("Email");
            this.Property(u => u.Ativo).HasColumnName("Ativo");
            this.Property(u => u.UltimoLogin).HasColumnName("UltimoLogin");
            this.Property(u => u.Telefone).HasColumnName("Telefone");
            this.Property(u => u.Login).HasColumnName("Login");
            this.Property(u => u.Password).HasColumnName("Password");
            this.Property(u => u.Verificado).HasColumnName("Verificado");

            // Relationships
            this.HasOptional(u => u.Cliente)
                .WithOptionalDependent();

            this.HasOptional(u => u.Fornecedor)
                .WithOptionalDependent();

            this.HasMany(u => u.CartoesCredito)
                .WithRequired(c => c.Usuario);
                
        }
    }
}
