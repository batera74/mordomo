using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class City : EntityBase
    {
        public string Name { get; set; }
        public virtual State State { get; set; }
        public int State_Id { get; set; }
    }
}
