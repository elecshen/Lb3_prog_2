﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lb3_prog_2
{
    internal class Plane : Vehicle
    {
        public Plane(double distR, double sCost, string typeName, List<Product.CategoryConteiner> categories)
        {
            costRatio = distR;
            startCost = sCost;
            TypeName = typeName;
            Categories= categories;
        }
    }
}
