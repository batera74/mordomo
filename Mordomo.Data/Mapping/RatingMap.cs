using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mordomo.Data.Mapping
{
    public class RatingMap : EntityTypeConfiguration<Rating>
    {
        public RatingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Rating");
            this.Property(t => t.Id).HasColumnName("Rating_Id");
            this.Property(t => t.Commentary).HasColumnName("Commentary");
            this.Property(t => t.RatingValue).HasColumnName("RatingValue");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
            this.Property(t => t.Provider_Id).HasColumnName("Provider_Id");
            this.Property(t => t.Client_Id).HasColumnName("Client_Id");

            // Relationships
            this.HasOptional(t => t.Client)
                .WithMany(t => t.Ratings)
                .HasForeignKey(d => d.Client_Id);
            this.HasOptional(t => t.Provider)
                .WithMany(t => t.Ratings)
                .HasForeignKey(d => d.Provider_Id);

        }
    }
}
