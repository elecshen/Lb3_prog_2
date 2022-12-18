using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb3_prog_2
{
    internal class TrainFactory : Factory
    {
        public override Vehicle CreateVehicle()
        {
            List<Product.CategoryConteiner> c = new List<Product.CategoryConteiner>()
            {
                InformationSystem.CategoriesList[0],
                InformationSystem.CategoriesList[1],
                InformationSystem.CategoriesList[2]
            };
            return new Train(15, 300, "Поезд", c);
        }
    }
}
