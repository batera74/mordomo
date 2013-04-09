using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    class StatusServiceOrderMap : EntityTypeConfiguration<StatusServiceOrder>
    {
        public StatusServiceOrderMap()
        {
            // Primary Key
            this.HasKey(s => s.Id);

            // Properties
            this.Property(s => s.Status)
                .IsRequired()
                .HasMaxLength(50);


            // Table & Column Mappings
            this.ToTable("StatusServiceOrder");
            this.Property(s => s.Id).HasColumnName("StatusServiceOrder_Id");
            this.Property(s => s.Status).HasColumnName("Status");
        }
    }
}
