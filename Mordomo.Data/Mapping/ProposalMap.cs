using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mordomo.Data.Mapping
{
    public class ProposalMap : EntityTypeConfiguration<Proposal>
    {
        public ProposalMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Proposal");
            this.Property(t => t.Id).HasColumnName("Proposal_Id");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
            this.Property(t => t.Client_Id).HasColumnName("Client_Id");
            this.Property(t => t.Status_Id).HasColumnName("Status_Id");

            // Relationships
            this.HasOptional(t => t.Client)
                .WithMany(t => t.Proposals)
                .HasForeignKey(d => d.Client_Id);
            this.HasOptional(t => t.Status)
                .WithMany(t => t.Proposals)
                .HasForeignKey(d => d.Status_Id);

        }
    }
}
