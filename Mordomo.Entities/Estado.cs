using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Estado : EntityBase
    {
        public string Nome { get; set; }
        public virtual List<Cidade> Cidades { get; set; }
    }
}
