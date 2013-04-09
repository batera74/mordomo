using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class CreditCard : EntityBase
    {
        public virtual User User { get; set; }
        public string CreditCardNumber { get; set; }
        public string SecurityCode { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public virtual CreditCardType CreditCardType { get; set; }
    }
}
