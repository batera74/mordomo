using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Table & Column Mappings
            this.ToTable("Menu");
            this.Property(p => p.Id).HasColumnName("Menu_Id");       

            //Relationships
            this.HasMany(m => m.MenuItems)
                .WithRequired(mi => mi.Menu)
                .WillCascadeOnDelete();
        }
    }
}
