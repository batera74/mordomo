﻿using Mordomo.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Mordomo.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(u => u.Id);

            // Properties
            this.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(u => u.Active)
                .IsRequired();

            this.Property(u => u.LastLogin)
                .IsRequired();

            this.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(u => u.Password)
                .IsRequired();

            this.Property(u => u.Verified)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("User");
            this.Property(u => u.Id).HasColumnName("User_Id");
            this.Property(u => u.Email).HasColumnName("Email");
            this.Property(u => u.Active).HasColumnName("Active");
            this.Property(u => u.LastLogin).HasColumnName("UltimoLogin");
            this.Property(u => u.Phone).HasColumnName("Phone");
            this.Property(u => u.Login).HasColumnName("Login");
            this.Property(u => u.Password).HasColumnName("Password");
            this.Property(u => u.Verified).HasColumnName("Verified");

            //Relationships
            this.HasMany(u => u.Andresses)
                .WithRequired(a => a.User)
                .WillCascadeOnDelete();
        }
    }
}
