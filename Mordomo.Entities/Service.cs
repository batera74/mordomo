using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Service : EntityBase
    {
        public Service()
        {
            this.Providers = new List<Provider>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public virtual List<Provider> Providers { get; set; }
        public List<ServiceOrder> ServiceOrders { get; set; }
    }
}
