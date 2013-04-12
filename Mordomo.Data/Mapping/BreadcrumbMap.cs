﻿using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class BreadcrumbMap : EntityTypeConfiguration<Breadcrumb>
    {
        public BreadcrumbMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("Breadcrumb");
            this.Property(p => p.Id).HasColumnName("Breadcrumb_Id");

            //Relationships
            this.HasMany(b => b.BreadcrumbItems)
                .WithRequired(bi => bi.Breadcrumb);
        }
    }
}
