using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Plano : EntityBase
    {
        public string Nome { get; set; }
        public int OrdemServicoPorMes { get; set; }
    }
}
