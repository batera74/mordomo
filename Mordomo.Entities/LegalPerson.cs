﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class LegalPerson : EntityBase
    {
        public LegalPerson()
        {
        }

        public LegalPerson(User user)
        {
            this.User = user;
        }

        public virtual User User { get; set; }
        public string FancyName { get; set; }
        public string CorporateName { get; set; }
        public string CNPJ { get; set; }
    }
}
