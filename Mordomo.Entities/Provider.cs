using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Provider : User
    {
        public Provider()
        {
            this.Ratings = new List<Rating>();
        }

        public virtual List<Service> Services { get; set; }
        public virtual List<ServiceOrder> ServiceOrders { get; set; }
        public string EncryptedLogo { get; set; }
        public List<Rating> Ratings { get; set; }
        
        public double RatingAVG 
        {
            get
            {
                return (from r in Ratings select r.Rating).Average();
            }
        }
    }
}
