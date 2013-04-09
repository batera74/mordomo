using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Credito : EntityBase
    {
        public DateTime DataCredito { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool Utilizado { get; set; }
        public string MotivoCredito { get; set; }
    }
}
