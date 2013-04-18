using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Account : EntityBase
    {
        public Account()
        {
            this.AccountMovements = new List<AccountMovement>();
            this.Credits = new List<Credit>();
        }

        public virtual Plan Plan { get; set; }

        public int Plan_Id { get; set; }

        public virtual List<AccountMovement> AccountMovements { get; set; }

        public virtual List<Credit> Credits { get; set; }

        public int Balance
        {
            get
            {
                return (from c in Credits where c.ExpirationDate <= DateTime.Now && c.Used == false select c).Count();
            }
        }

        public virtual Client Client { get; set; }
    }
}
