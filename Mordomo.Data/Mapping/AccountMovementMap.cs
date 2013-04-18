using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mordomo.Data.Mapping
{
    public class AccountMovementMap : EntityTypeConfiguration<AccountMovement>
    {
        public AccountMovementMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            // Table & Column Mappings
            this.ToTable("AccountMovement");
            this.Property(t => t.Id).HasColumnName("AccountMovement_Id");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
            this.Property(t => t.Account_Id).HasColumnName("Account_Id");

            // Relationships
            this.HasRequired(t => t.Account)
                .WithMany(t => t.AccountMovements)
                .HasForeignKey(d => d.Account_Id);
            this.HasRequired(t => t.ServiceOrder)
                .WithOptional(t => t.AccountMovement);

        }
    }
}
