using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class PlanMap : EntityTypeConfiguration<Plan>
    {
        public PlanMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(p => p.ServiceOrdersPerMonth)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Plan");
            this.Property(p => p.Id).HasColumnName("Plan_Id");            
            this.Property(p => p.Name).HasColumnName("Name");
            this.Property(p => p.ServiceOrdersPerMonth).HasColumnName("ServiceOrdersPerMonth");
        }
    }
}
