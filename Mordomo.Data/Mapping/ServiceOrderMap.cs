using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class ServiceOrderMap : EntityTypeConfiguration<ServiceOrder>
    {
        public ServiceOrderMap()
        {
            // Primary Key
            this.HasKey(s => s.Id);

            // Properties
            this.Property(s => s.TotalAmount)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ServiceOrder");
            this.Property(s => s.Id).HasColumnName("ServiceOrder_Id");
            this.Property(s => s.TotalAmount).HasColumnName("TotalAmount");

            //Relationships
            this.HasRequired(s => s.Status)
                .WithMany();

            this.HasMany(s => s.ServiceOrderItems)
                .WithMany(si => si.ServiceOrders);              
        }
    }
}
