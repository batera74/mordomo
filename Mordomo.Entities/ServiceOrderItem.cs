using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class ServiceOrderItem : EntityBase
    {
        public ServiceOrderItem()
        {
            this.ServiceOrders = new List<ServiceOrder>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<ServiceOrder> ServiceOrders { get; set; }
    }
}
