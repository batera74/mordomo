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
        }

        public MenuItem(Menu menu)
        {
            this.Menu = menu;
            this.SubItems = new List<MenuItem>();
        }

        public string ItemText { get; set; }
        public virtual Page Page { get; set; }
        public int Page_Id { get; set; }
        public virtual List<MenuItem> SubItems { get; set; }
        public virtual Menu Menu { get; set; }
        public int Menu_Id { get; set; }
        public virtual MenuItem ParentMenuItem { get; set; }
        public int? ParentMenuItem_Id { get; set; }
    }
}
