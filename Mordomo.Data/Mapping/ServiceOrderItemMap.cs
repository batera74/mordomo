using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class ServiceOrderItemMap : EntityTypeConfiguration<ServiceOrderItem>
    {
        public ServiceOrderItemMap()
        {
            // Primary Key
            this.HasKey(i => i.Id);

            // Properties
            this.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("ServiceOrderItem");
            this.Property(i => i.Id).HasColumnName("ServiceOrderItem_Id");
            this.Property(i => i.Name).HasColumnName("Name");
            this.Property(i => i.Description).HasColumnName("Description");
        }
    }
}
