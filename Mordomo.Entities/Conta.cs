using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Conta : EntityBase
    {
        public Plano Plano { get; set; }
        
        public List<Movimentacao> Movimentacoes { get; set; }

        public List<Credito> Creditos { get; set; }

        public int Saldo
        {
            get
            {
                return (from c in Creditos where c.DataExpiracao <= DateTime.Now && c.Utilizado == false select c).Count();
            }
        }

        public Cliente Cliente { get; set; }
    }
}
