using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mordomo.Data.Mapping
{
    public class LegalPersonMap : EntityTypeConfiguration<LegalPerson>
    {
        public LegalPersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.FancyName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CorporateName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CNPJ)
                .IsRequired()
                .HasMaxLength(14);

            // Table & Column Mappings
            this.ToTable("LegalPerson");
            this.Property(t => t.Id).HasColumnName("LegalPerson_Id");
            this.Property(t => t.FancyName).HasColumnName("FancyName");
            this.Property(t => t.CorporateName).HasColumnName("CorporateName");
            this.Property(t => t.CNPJ).HasColumnName("CNPJ");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");

            // Relationships
            this.HasRequired(t => t.User)
                .WithOptional(t => t.LegalPerson);

        }
    }
}
