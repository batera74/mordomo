using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class TipoEnderecoMap : EntityTypeConfiguration<TipoEndereco>
    {
        public TipoEnderecoMap()
        {
            // Primary Key
            this.HasKey(e => e.Id);

            // Properties
            this.Property(e => e.DataModificacao)
                .IsRequired();

            this.Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TipoEndereco");
            this.Property(e => e.Id).HasColumnName("Id");
            this.Property(e => e.DataModificacao).HasColumnName("DataModificacao");
            this.Property(e => e.Nome).HasColumnName("Nome");
        }
    }
}
