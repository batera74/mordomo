using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Plan : EntityBase
    {
        public Plan()
        {
            this.Accounts = new List<Account>();
        }

        public string Name { get; set; }
        public int ServiceOrdersPerMonth { get; set; }
        public string CryptImage { get; set; }
        public virtual List<Account> Accounts { get; set; }
    }
}
