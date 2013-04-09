using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class CartaoCredito : EntityBase
    {
        public Usuario Usuario { get; set; }
        public string NumeroCarao { get; set; }
        public string DigitoVerificador { get; set; }
        public int MesExpricao { get; set; }
        public int AnoExpiracao { get; set; }
        public TipoCartaoCredito TipoCartaoCredito { get; set; }
    }
}
