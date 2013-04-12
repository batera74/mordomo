using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Breadcrumb : EntityBase
    {
        public Breadcrumb()
        {
            this.BreadcrumbItems = new List<BreadcrumbItem>();
        }

        public string Name { get; set; }
        public virtual List<BreadcrumbItem> BreadcrumbItems { get; set; }
    }
}
