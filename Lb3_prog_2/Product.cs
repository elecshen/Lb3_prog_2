using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb3_prog_2
{
    internal class Product
    {
        public string Name { get; }
        public double Weight { get; }
        public string Destination { get; }
        public string Category { get; }

        Product(string name, double weight, string destination, string category)
        {
            Name = name;
            Weight = weight;
            Destination = destination;
            Category = category;
        }
    }
}
