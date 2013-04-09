using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Endereco : EntityBase
    {
        public TipoEndereco TipoEndereco { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string CodigoPostal { get; set; }
        public Cidade Cidade { get; set; }
    }
}
