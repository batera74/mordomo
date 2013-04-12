using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class PageMap : EntityTypeConfiguration<Page>
    {
        public PageMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("Page");
            this.Property(p => p.Id).HasColumnName("Page_Id");
        }
    }
}
