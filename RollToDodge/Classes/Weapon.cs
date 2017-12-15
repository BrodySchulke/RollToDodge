using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Weapon : IItem
    {
        public Weapon()
        {

        }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public int Weight { get; set; }
    }
}
