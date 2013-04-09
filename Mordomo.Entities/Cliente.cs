using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class Cliente : Pessoa
    {
        public Conta Conta { get; set; }
    }
}
