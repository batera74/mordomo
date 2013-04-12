using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class BreadcrumbItemMap : EntityTypeConfiguration<BreadcrumbItem>
    {
        public BreadcrumbItemMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);
            
            // Table & Column Mappings
            this.ToTable("BreadcrumbItem");
            this.Property(p => p.Id).HasColumnName("BreadcrumbItem_Id");

            //Relationships
            this.HasRequired(b => b.Page);
        }
    }
}
