using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Page : EntityBase
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public virtual List<BreadcrumbItem> BreadcrumbItems { get; set; }
        public virtual List<MenuItem> MenuItems { get; set; }
    }
}
