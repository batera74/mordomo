using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mordomo.Data.Mapping
{
    public class AndressMap : EntityTypeConfiguration<Andress>
    {
        public AndressMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.AndressLine1)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Complement)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.PostalCode)
                .IsRequired()
                .HasMaxLength(8);

            // Table & Column Mappings
            this.ToTable("Andress");
            this.Property(t => t.Id).HasColumnName("Andress_Id");
            this.Property(t => t.AndressLine1).HasColumnName("AndressLine1");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.Complement).HasColumnName("Complement");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
            this.Property(t => t.User_Id).HasColumnName("User_Id");

            // Relationships            
            this.HasRequired(t => t.User)
                .WithMany(t => t.Andresses)
                .HasForeignKey(d => d.User_Id);

        }
    }
}
