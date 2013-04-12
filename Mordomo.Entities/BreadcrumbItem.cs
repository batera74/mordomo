using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class BreadcrumbItem : EntityBase
    {
        public BreadcrumbItem()
        {
        }

        public BreadcrumbItem(Breadcrumb breadcrumb)
        {
            this.Breadcrumb = breadcrumb;
        }

        public virtual Breadcrumb Breadcrumb { get; set; }
        public int Order { get; set; }
        public virtual Page Page { get; set; }
    }
}
