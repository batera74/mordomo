using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Rating : EntityBase
    {
        public virtual Provider Provider { get; set; }
        public virtual Client Client { get; set; }
        public string Commentary { get; set; }
        public double Rating { get; set; }
    }
}
