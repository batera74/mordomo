using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Movimentacao : EntityBase
    {
        public Conta Conta { get; set; }
        public Cliente Cliente { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public OrdemServico OrdemServico { get; set; }
    }
}
