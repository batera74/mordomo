using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class CreditCardMap : EntityTypeConfiguration<CreditCard>
    {
        public CreditCardMap()
        {
            // Primary Key
            this.HasKey(p =>p.Id);

            // Properties
            this.Property(p => p.CreditCardNumber)
                .IsRequired()
                .HasMaxLength(24);

            this.Property(p =>p.SecurityCode)
                .IsRequired()
                .HasMaxLength(3);
            
            this.Property(p =>p.ExpirationMonth)
                .IsRequired();

            this.Property(p =>p.ExpirationYear)
                .IsRequired();
                        
            // Table & Column Mappings
            this.ToTable("CreditCard");
            this.Property(p => p.Id).HasColumnName("CreditCard_Id");
            this.Property(p => p.CreditCardNumber).HasColumnName("CreditCardNumber");
            this.Property(p => p.SecurityCode).HasColumnName("SecurityCode");
            this.Property(p => p.ExpirationMonth).HasColumnName("ExpirationMonth");
            this.Property(p => p.ExpirationYear).HasColumnName("ExpirationYear");
            
            
            //Relationships
            this.HasRequired(p => p.CreditCardType)
                .WithMany()
                .WillCascadeOnDelete(false);

            this.HasRequired(p => p.User)
                .WithMany(u => u.CreditCards)
                .WillCascadeOnDelete();
        }
    }
}
