using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mordomo.Data.Mapping
{
    public class PlanMap : EntityTypeConfiguration<Plan>
    {
        public PlanMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Plan");
            this.Property(t => t.Id).HasColumnName("Plan_Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.ServiceOrdersPerMonth).HasColumnName("ServiceOrdersPerMonth");
            this.Property(t => t.CryptImage).HasColumnName("CryptImage");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
        }
    }
}
