using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Fornecedor : Pessoa
    {        
        public List<Servico> Servicos { get; set; }
        public string Logo { get; set; }
    }
}
