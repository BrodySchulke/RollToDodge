using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public interface IItem
    {
        string Description { get; set; }
        int Quantity { get; set; }
        string Name { get; set; }
        int Weight { get; set; }
    }
}
