using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mordomo.Entities
{
    public class DropDownData
    {
        public DropDownData()
        {

        }

        public DropDownData(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
