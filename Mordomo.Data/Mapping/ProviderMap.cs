using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class ProviderMap : EntityTypeConfiguration<Provider>
    {
        public ProviderMap()
        {
            // Primary Key
            this.HasKey(p => p.Id);

            // Properties
            this.Property(p => p.EncryptedLogo)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Provider");
            this.Property(p => p.Id).HasColumnName("Provider_Id");
            this.Property(p => p.EncryptedLogo).HasColumnName("EncryptedLogo");

            // Relationships
            this.HasMany(f => f.Services)
                .WithMany(s => s.Providers);
        }
    }
}
