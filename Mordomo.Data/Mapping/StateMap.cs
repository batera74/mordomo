using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mordomo.Data.Mapping
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("State");
            this.Property(t => t.Id).HasColumnName("State_Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Acronym).HasColumnName("Acronym");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
            this.Property(t => t.Country_Id).HasColumnName("Country_Id");

            // Relationships
            this.HasRequired(t => t.Country)
                .WithMany(t => t.States)
                .HasForeignKey(d => d.Country_Id);

        }
    }
}
