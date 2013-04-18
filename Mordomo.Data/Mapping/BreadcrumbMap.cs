using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mordomo.Data.Mapping
{
    public class BreadcrumbMap : EntityTypeConfiguration<Breadcrumb>
    {
        public BreadcrumbMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("Breadcrumb");
            this.Property(t => t.Id).HasColumnName("Breadcrumb_Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
        }
    }
}
