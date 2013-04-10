using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Country : EntityBase
    {
        public Country()
        {
            this.States = new List<State>();
        }

        public string Name { get; set; }
        public virtual List<State> States { get; set; }
    }
}
