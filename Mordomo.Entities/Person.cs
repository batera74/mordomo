using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public abstract class Person : EntityBase
    {
        public virtual User User { get; set; }
    }
}
