using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mordomo.Data.Mapping
{
    public class BreadcrumbItemMap : EntityTypeConfiguration<BreadcrumbItem>
    {
        public BreadcrumbItemMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("BreadcrumbItem");
            this.Property(t => t.Id).HasColumnName("BreadcrumbItem_Id");
            this.Property(t => t.Order).HasColumnName("Order");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
            this.Property(t => t.Page_Id).HasColumnName("Page_Id");
            this.Property(t => t.Breadcrumb_Id).HasColumnName("Breadcrumb_Id");

            // Relationships
            this.HasRequired(t => t.Breadcrumb)
                .WithMany(t => t.BreadcrumbItems)
                .HasForeignKey(d => d.Breadcrumb_Id);
            this.HasRequired(t => t.Page)
                .WithMany(t => t.BreadcrumbItems)
                .HasForeignKey(d => d.Page_Id);

        }
    }
}
