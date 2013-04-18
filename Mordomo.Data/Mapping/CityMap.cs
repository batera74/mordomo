using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mordomo.Data.Mapping
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            // Table & Column Mappings
            this.ToTable("City");
            this.Property(t => t.Id).HasColumnName("City_Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
            this.Property(t => t.State_Id).HasColumnName("State_Id");

            // Relationships
            this.HasRequired(t => t.State)
                .WithMany(t => t.Cities)
                .HasForeignKey(d => d.State_Id);

        }
    }
}
