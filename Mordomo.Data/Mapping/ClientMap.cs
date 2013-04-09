using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            this.HasKey(p =>p.Id);

            // Table & Column Mappings
            this.ToTable("Client");
            this.Property(p => p.Id).HasColumnName("Client_Id");            

            // Relationships
            this.HasRequired(p =>p.Account)
                .WithRequiredPrincipal(co => co.Client);
        }
    }
}
