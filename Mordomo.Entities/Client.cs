using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Client : User
    {
        public Client()
        {
            this.Proposals = new List<Proposal>();
            this.Ratings = new List<Rating>();
        }

        public virtual Account Account { get; set; }        
        public virtual List<Proposal> Proposals { get; set; }
        public virtual List<Rating> Ratings { get; set; }
    }
}
