using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mordomo.Data.Mapping
{
    public class CreditMap : EntityTypeConfiguration<Credit>
    {
        public CreditMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CreditReason)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Credit");
            this.Property(t => t.Id).HasColumnName("Credit_Id");
            this.Property(t => t.CreditDate).HasColumnName("CreditDate");
            this.Property(t => t.ExpirationDate).HasColumnName("ExpirationDate");
            this.Property(t => t.Used).HasColumnName("Used");
            this.Property(t => t.CreditReason).HasColumnName("CreditReason");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
            this.Property(t => t.Account_Id).HasColumnName("Account_Id");

            // Relationships
            this.HasRequired(t => t.Account)
                .WithMany(t => t.Credits)
                .HasForeignKey(d => d.Account_Id);

        }
    }
}
