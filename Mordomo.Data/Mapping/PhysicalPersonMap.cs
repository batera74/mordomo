using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class PhysicalPersonMap : EntityTypeConfiguration<PhysicalPerson>
    {
        public PhysicalPersonMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(p => p.BirthDate)
                .IsRequired();

            this.Property(p => p.CPF)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(p => p.MobilePhone)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(p => p.Gender)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("PhysicalPerson");
            this.Property(p => p.Id).HasColumnName("PhysicalPerson_Id");            
            this.Property(p => p.Name).HasColumnName("Name");
            this.Property(p => p.LastName).HasColumnName("LastName");
            this.Property(p => p.BirthDate).HasColumnName("BirthDate");
            this.Property(p => p.CPF).HasColumnName("CPF");
            this.Property(p => p.MobilePhone).HasColumnName("MobilePhone");
            this.Property(p => p.Gender).HasColumnName("Gender");
        
            //Relationships

            this.HasRequired(p => p.User)
                .WithOptional(u => u.PhysicalPerson);
        }
    }
}
