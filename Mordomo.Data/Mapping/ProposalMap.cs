using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class ProposalMap : EntityTypeConfiguration<Proposal>
    {
        public ProposalMap()
        {
            // Primary Key
            this.HasKey(m => m.Id);

            // Table & Column Mappings
            this.ToTable("Proposal");
            this.Property(m => m.Id).HasColumnName("Proposal_Id");

            // Relationships
            this.HasRequired(s => s.Status)
                .WithMany();

            this.HasMany(p => p.ServiceOrders)
                .WithRequired(s => s.Proposal);
        }
    }
}
