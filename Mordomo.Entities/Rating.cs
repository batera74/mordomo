using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Rating : EntityBase
    {
        public virtual Provider Provider { get; set; }
        public int Provider_Id { get; set; }
        public virtual Client Client { get; set; }
        public int Client_Id { get; set; }
        public string Commentary { get; set; }
        public double RatingValue { get; set; }
    }
}
