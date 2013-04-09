using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Credit : EntityBase
    {
        public virtual Account Account { get; set; }
        public DateTime CreditDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Used { get; set; }
        public string CreditReason { get; set; }
    }
}
