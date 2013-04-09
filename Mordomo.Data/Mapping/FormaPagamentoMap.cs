using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class FormaPagamentoMap : EntityTypeConfiguration<FormaPagamento>
    {
        public FormaPagamentoMap()
        {
            // Primary Key
            this.HasKey(f => f.Id);

            // Properties
            this.Property(f => f.DataModificacao)
                .IsRequired();

            this.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("FormaPagamento");
            this.Property(e => e.Id).HasColumnName("Id");
            this.Property(e => e.DataModificacao).HasColumnName("DataModificacao");
            this.Property(e => e.Nome).HasColumnName("Nome");
        }
    }
}
