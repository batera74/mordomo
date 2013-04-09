using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            // Primary Key
            this.HasKey(p =>p.Id);
                      
            // Properties
            this.Property(p =>p.DataModificacao)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Cliente");
            this.Property(p =>p.Id).HasColumnName("Id");
            this.Property(p =>p.DataModificacao).HasColumnName("DataModificacao");

            // Relationships
            this.HasRequired(p =>p.Conta)
                .WithRequiredPrincipal(co => co.Cliente);
        }
    }
}
