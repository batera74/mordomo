using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mordomo.Data.Mapping
{
    public class ServiceMap : EntityTypeConfiguration<Service>
    {
        public ServiceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Service");
            this.Property(t => t.Id).HasColumnName("Service_Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Image).HasColumnName("Image");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
        }
    }
}
