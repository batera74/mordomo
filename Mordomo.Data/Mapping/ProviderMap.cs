using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mordomo.Data.Mapping
{
    public class ProviderMap : EntityTypeConfiguration<Provider>
    {
        public ProviderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.EncryptedLogo)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Provider");
            this.Property(t => t.Id).HasColumnName("Provider_Id");
            this.Property(t => t.EncryptedLogo).HasColumnName("EncryptedLogo");

            // Relationships
            this.HasMany(t => t.Services)
                .WithMany(t => t.Providers)
                .Map(m =>
                    {
                        m.ToTable("ProviderService");
                        m.MapLeftKey("Provider_Id");
                        m.MapRightKey("Service_Id");
                    });
            
        }
    }
}
