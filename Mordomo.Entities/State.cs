﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class State : EntityBase
    {
        public State()
        {
            this.Cities = new List<City>();
        }

        public string Name { get; set; }
        public string Acronym { get; set; }
        public virtual Country Country { get; set; }
        public int Country_Id { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}
