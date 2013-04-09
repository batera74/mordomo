using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class CidadeMap : EntityTypeConfiguration<Cidade>
    {
        public CidadeMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(60);

            this.Property(p => p.DataModificacao)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Cidade");
            this.Property(p => p.Id).HasColumnName("Id");
            this.Property(p => p.Nome).HasColumnName("Nome");
            this.Property(p => p.DataModificacao).HasColumnName("DataModificacao");

            //relationships
            this.HasRequired(c => c.Estado)
                .WithRequiredDependent();
        }
    }
}
