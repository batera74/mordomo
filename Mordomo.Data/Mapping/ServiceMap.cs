using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;


namespace Mordomo.Data.Mapping
{
    public class ServiceMap : EntityTypeConfiguration<Service>
    {
        public ServiceMap()
        {
            // Primary Key
            this.HasKey(s => s.Id);

            // Properties
            this.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("Service");
            this.Property(s => s.Id).HasColumnName("Service_Id");
            this.Property(s => s.Name).HasColumnName("Name");
            this.Property(s => s.Description).HasColumnName("Description");

            // Relationships
            this.HasMany(s => s.Providers)
                .WithMany(f => f.Services);
        }
    }
}
