using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Cidade : EntityBase
    {
        public string Nome { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
