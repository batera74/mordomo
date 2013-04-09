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
        public virtual Provider Provider { get; set; }
        public virtual Service Service { get; set; }        
        public virtual Status Status { get; set; }
        public virtual List<ServiceOrderItem> ServiceOrderItems { get; set; }
        public decimal TotalAmount { get; set; }        
    }
}
