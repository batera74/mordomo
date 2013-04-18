using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mordomo.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("User");
            this.Property(t => t.Id).HasColumnName("User_Id");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.LastLogin).HasColumnName("LastLogin");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.MobilePhone).HasColumnName("MobilePhone");
            this.Property(t => t.Login).HasColumnName("Login");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Verified).HasColumnName("Verified");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
        }
    }
}
