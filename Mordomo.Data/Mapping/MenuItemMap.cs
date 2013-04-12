using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class MenuItemMap : EntityTypeConfiguration<MenuItem>
    {
        public MenuItemMap()
        {
            //Primary Key
            this.HasKey(m => m.Id);

            // Table & Column Mappings
            this.ToTable("MenuItem");
            this.Property(p => p.Id).HasColumnName("MenuItem_Id");       

            //Relationships
            this.HasRequired(m => m.Menu);

            this.HasRequired(m => m.Page);

            this.HasMany(s => s.SubItems);

            this.HasOptional(s => s.ParentMenuItem)
                .WithMany(m => m.SubItems);                
        }
    }
}
