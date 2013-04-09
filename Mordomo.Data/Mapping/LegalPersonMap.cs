using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class LegalPersonMap : EntityTypeConfiguration<LegalPerson>
    {
        public LegalPersonMap()
        {
            // Primary Key
            this.HasKey(p =>p.Id);

            // Properties
            this.Property(p =>p.FancyName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p =>p.CorporateName)
               .IsRequired()
               .HasMaxLength(100);

            this.Property(p =>p.CNPJ)
               .IsRequired()
               .HasMaxLength(14);

            this.Property(p =>p.BusinessPhone)
               .IsRequired()
               .HasMaxLength(11);

            // Table & Column Mappings
            this.ToTable("LegalPerson");
            this.Property(p => p.Id).HasColumnName("LegalPerson_Id");            
            this.Property(p => p.FancyName).HasColumnName("FancyName");
            this.Property(p => p.CorporateName).HasColumnName("CorporateName");
            this.Property(p => p.BusinessPhone).HasColumnName("BusinessPhone");

            //Relationships
            this.HasRequired(p => p.User)
                .WithOptional(u => u.LegalPerson);
        }
    }
}
