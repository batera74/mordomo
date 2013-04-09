using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public abstract class Pessoa : EntityBase
    {
        public PessoaFisica PessoaFisica { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public List<OrdemServico> OrdensServico { get; set; }
    }
}
