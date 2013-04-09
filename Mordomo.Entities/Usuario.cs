using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Usuario : EntityBase
    {
        public Usuario()
        {
            this.CartoesCredito = new List<CartaoCredito>();
        }

        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime UltimoLogin { get; set; }
        public string Telefone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Cliente Cliente { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public List<CartaoCredito> CartoesCredito { get; set; }
        public bool Verificado { get; set; }
    }
}
