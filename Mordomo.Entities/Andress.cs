using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Andress : EntityBase
    {
        public virtual AndressType AndressType { get; set; }
        public string AndressLine1 { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string PostalCode { get; set; }
        public virtual City City { get; set; }
        public virtual User User { get; set; }
    }
}
