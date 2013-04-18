using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class PhysicalPerson : EntityBase
    {
        public PhysicalPerson()
        {
        }

        public PhysicalPerson(User user)
        {
            this.User = user;
        }

        public virtual User User { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
        public string Gender { get; set; }
    }
}
