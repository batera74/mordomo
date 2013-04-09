using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class MenuItem : EntityBase
    {
        public MenuItem()
        {
            this.SubItems = new List<MenuItem>();
        }

        public string ItemText { get; set; }
        public string Hyperlink { get; set; }
        public virtual List<MenuItem> SubItems { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual MenuItem ParentMenuItem { get; set; }
    }
}
