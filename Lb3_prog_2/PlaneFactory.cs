using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb3_prog_2
{
    internal class PlaneFactory : Factory
    {
        public override Vehicle CreateVehicle()
        {
            List<Product.CategoryConteiner> c = new List<Product.CategoryConteiner>()
            {
                InformationSystem.CategoriesList[0]
            };
            return new Plane(50, 1000, "Самолёт", c);
        }
    }
}
