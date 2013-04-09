using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class AccountMovementMap : EntityTypeConfiguration<AccountMovement>
    {
        public AccountMovementMap()
        {
            // Primary Key
            this.HasKey(m => m.Id);

            // Table & Column Mappings
            this.ToTable("AccountMovement");
            this.Property(m => m.Id).HasColumnName("AccountMovement_Id");

            // Relationships
            this.HasRequired(m => m.ServiceOrder)
                .WithRequiredDependent();
        }
    }
}
