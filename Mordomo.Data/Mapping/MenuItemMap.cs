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
            this.Property(p => p.Menu_Id).HasColumnName("Menu_Id");
            this.Property(p => p.Page_Id).HasColumnName("Page_Id");
            this.Property(p => p.ParentMenuItem_Id).HasColumnName("ParentMenuItem_Id");

            //Relationships
            this.HasRequired(m => m.Menu)
                .WithMany(me => me.MenuItems)
                .HasForeignKey(m => m.Menu_Id);

            this.HasRequired(m => m.Page)
                .WithMany(p => p.MenuItems)
                .HasForeignKey(m => m.Page_Id);

            this.HasOptional(m => m.ParentMenuItem)
                .WithMany(p => p.SubItems)
                .HasForeignKey(m => m.ParentMenuItem_Id);
        }
    }
}
