using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class AccountMovement : EntityBase
    {
        public virtual Account Account { get; set; }
        public virtual ServiceOrder ServiceOrder { get; set; }
    }
}
