using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb3_prog_2
{
    internal class CarFactory : Factory
    {
        public override Vehicle CreateVehicle()
        {
            List<Product.CategoryConteiner> c = new List<Product.CategoryConteiner>()
            {
                InformationSystem.CategoriesList[0],
                InformationSystem.CategoriesList[1],
                InformationSystem.CategoriesList[2],
                InformationSystem.CategoriesList[3]
            };
            return new Car(30, 100, "Машина", c);
        }
    }
}
