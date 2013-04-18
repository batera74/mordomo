using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class ServiceOrder : EntityBase
    {
        public ServiceOrder()
        {
            this.ServiceOrderItems = new List<ServiceOrderItem>();
        }

        public virtual Proposal Proposal { get; set; }
        public int Proposal_Id { get; set; } 
        public virtual Provider Provider { get; set; }
        public int Provider_Id { get; set; }
        public virtual Service Service { get; set; }
        public int Service_Id { get; set; }
        public virtual Status Status { get; set; }
        public int Status_Id { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public int PaymentMethod_Id { get; set; }
        public virtual List<ServiceOrderItem> ServiceOrderItems { get; set; }
        public virtual AccountMovement AccountMovement { get; set; }
        public decimal TotalAmount { get; set; }        
    }
}
