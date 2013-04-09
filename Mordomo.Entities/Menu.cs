using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Menu : EntityBase
    {
        public Menu()
        {
            this.MenuItems = new List<MenuItem>();
        }

        public string Name { get; set; }
        public virtual List<MenuItem> MenuItems { get; set; }
    }
}
