using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Primary Key
            this.HasKey(c => c.Id);

            // Table & Column Mappings
            this.ToTable("Account");
            this.Property(c => c.Id).HasColumnName("Account_Id");

            // Relationships
            this.HasRequired(a => a.Plan)
                .WithMany(p => p.Accounts);

            this.HasMany(a => a.AccountMovements)
                .WithRequired(am => am.Account);

            this.HasMany(a => a.Credits)
                .WithRequired(c => c.Account);
        }
    }
}
