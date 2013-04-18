using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mordomo.Data.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            // Table & Column Mappings
            this.ToTable("Account");
            this.Property(t => t.Id).HasColumnName("Account_Id");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
            this.Property(t => t.Plan_Id).HasColumnName("Plan_Id");

            // Relationships
            this.HasRequired(t => t.Client)
                .WithOptional(t => t.Account);

            this.HasRequired(t => t.Plan)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.Plan_Id);

        }
    }
}
