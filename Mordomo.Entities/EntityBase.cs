using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
