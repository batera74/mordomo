using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    class StatusOrdemServicoMap : EntityTypeConfiguration<StatusOrdemServico>
    {
        public StatusOrdemServicoMap()
        {
            // Primary Key
            this.HasKey(s => s.Id);

            // Properties
            this.Property(s => s.DataModificacao)
                .IsRequired();

            this.Property(s => s.Status)
                .IsRequired()
                .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("StatusOrdemServico");
            this.Property(s => s.Id).HasColumnName("Id");
            this.Property(s => s.DataModificacao).HasColumnName("DataModificacao");
            this.Property(s => s.Status).HasColumnName("Status");
        }
    }
}
