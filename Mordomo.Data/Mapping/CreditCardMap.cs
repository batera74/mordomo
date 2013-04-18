using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mordomo.Data.Mapping
{
    public class CreditCardMap : EntityTypeConfiguration<CreditCard>
    {
        public CreditCardMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.CreditCardNumber)
                .IsRequired()
                .HasMaxLength(24);

            this.Property(t => t.SecurityCode)
                .IsRequired()
                .HasMaxLength(3);

            // Table & Column Mappings
            this.ToTable("CreditCard");
            this.Property(t => t.Id).HasColumnName("CreditCard_Id");
            this.Property(t => t.CreditCardNumber).HasColumnName("CreditCardNumber");
            this.Property(t => t.SecurityCode).HasColumnName("SecurityCode");
            this.Property(t => t.ExpirationMonth).HasColumnName("ExpirationMonth");
            this.Property(t => t.ExpirationYear).HasColumnName("ExpirationYear");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
            this.Property(t => t.User_Id).HasColumnName("User_Id");
            this.Property(t => t.CreditCardType_Id).HasColumnName("CreditCardType_Id");

            // Relationships
            this.HasRequired(t => t.CreditCardType)
                .WithMany(t => t.CreditCards)
                .HasForeignKey(d => d.CreditCardType_Id);
            this.HasRequired(t => t.User)
                .WithMany(t => t.CreditCards)
                .HasForeignKey(d => d.User_Id);

        }
    }
}
