using System;
using System.Collections.Generic;

namespace Mordomo.Entities 
{
    public class Status : EntityBase
    {
        public Status()
        {
            this.Proposals = new List<Proposal>();
            this.ServiceOrders = new List<ServiceOrder>();
        }
                
        public string Description { get; set; }
        public virtual List<Proposal> Proposals { get; set; }
        public virtual List<ServiceOrder> ServiceOrders { get; set; }
    }
}
