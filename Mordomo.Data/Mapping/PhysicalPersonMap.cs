using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mordomo.Data.Mapping
{
    public class PhysicalPersonMap : EntityTypeConfiguration<PhysicalPerson>
    {
        public PhysicalPersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CPF)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("PhysicalPerson");
            this.Property(t => t.Id).HasColumnName("PhysicalPerson_Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.BirthDate).HasColumnName("BirthDate");
            this.Property(t => t.CPF).HasColumnName("CPF");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");

            // Relationships
            this.HasRequired(t => t.User)
                .WithOptional(t => t.PhysicalPerson);

        }
    }
}
