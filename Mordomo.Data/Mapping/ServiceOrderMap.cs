using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Mordomo.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace Mordomo.Data.Mapping
{
    public class ServiceOrderMap : EntityTypeConfiguration<ServiceOrder>
    {
        public ServiceOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ServiceOrder");
            this.Property(t => t.Id).HasColumnName("ServiceOrder_Id");
            this.Property(t => t.TotalAmount).HasColumnName("TotalAmount");
            this.Property(t => t.CreationTime).HasColumnName("CreationTime");
            this.Property(t => t.LastUpdate).HasColumnName("LastUpdate");
            this.Property(t => t.Proposal_Id).HasColumnName("Proposal_Id");
            this.Property(t => t.Provider_Id).HasColumnName("Provider_Id");
            this.Property(t => t.Service_Id).HasColumnName("Service_Id");
            this.Property(t => t.Status_Id).HasColumnName("Status_Id");
            this.Property(t => t.PaymentMethod_Id).HasColumnName("PaymentMethod_Id");

            // Relationships
            this.HasMany(t => t.ServiceOrderItems)
                .WithMany(t => t.ServiceOrders)
                .Map(m =>
                    {
                        m.ToTable("ServiceOrderServiceOrderItem");
                        m.MapLeftKey("ServiceOrder_Id");
                        m.MapRightKey("ServiceOrderItem_Id");
                    });

            this.HasRequired(t => t.PaymentMethod)
                .WithMany(t => t.ServiceOrders)
                .HasForeignKey(d => d.PaymentMethod_Id);
            this.HasRequired(t => t.Proposal)
                .WithMany(t => t.ServiceOrders)
                .HasForeignKey(d => d.Proposal_Id);
            this.HasRequired(t => t.Provider)
                .WithMany(t => t.ServiceOrders)
                .HasForeignKey(d => d.Provider_Id);
            this.HasRequired(t => t.Service)
                .WithMany(t => t.ServiceOrders)
                .HasForeignKey(d => d.Service_Id);
            this.HasRequired(t => t.Status)
                .WithMany(t => t.ServiceOrders)
                .HasForeignKey(d => d.Status_Id);

        }
    }
}
