using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class User : EntityBase
    {
        public User()
        {
            this.CreditCards = new List<CreditCard>();
            this.Andresses = new List<Andress>();
        }

        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime LastLogin { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }        
        public bool Verified { get; set; }
        public virtual List<CreditCard> CreditCards { get; set; }
        public virtual List<Andress> Andresses { get; set; }
        public virtual PhysicalPerson PhysicalPerson { get; set; }
        public virtual LegalPerson LegalPerson { get; set; }
    }
}
