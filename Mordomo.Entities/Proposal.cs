using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Proposal : EntityBase
    {
        public Proposal()
        {
            this.ServiceOrders = new List<ServiceOrder>();
        }

        public virtual Client Client { get; set; }
        public virtual List<ServiceOrder> ServiceOrders { get; set; }
        public virtual Status Status { get; set; }
    }
}
