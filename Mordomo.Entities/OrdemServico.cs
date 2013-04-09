using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class OrdemServico : EntityBase
    {
        public Usuario Cliente { get; set; }
        public Usuario Fornecedor { get; set; }        
        public decimal Valor { get; set; }
        public StatusOrdemServico Status { get; set; }
        public List<ItemOrdemServico> ItemsOrdemServico { get; set; }
    }
}
