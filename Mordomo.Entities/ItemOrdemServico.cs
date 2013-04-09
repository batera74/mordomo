using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class ItemOrdemServico : EntityBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Servico Servico { get; set; }        
        public List<OrdemServico> OrdensServico { get; set; }
    }
}
