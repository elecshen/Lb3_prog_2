using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lb3_prog_2
{
    internal class Order
    {
        public string Id { get; }
        public string ShortId { get; }
        public List<ProductsConteiner> Products { get; }
        public string Destination { get; }
        public double Weight { get; }
        public HashSet<Product.CategoryConteiner> Categories { get; }

        public Order(List<ProductsConteiner> productsList, string destination)
        {
            Products = new List<ProductsConteiner>(productsList);
            Id = "#" + DateTime.Now.Date.Day +
                DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond;
            ShortId = Id.Substring(Id.Length-4);
            Destination = destination;
            Weight = 0;
            Categories = new HashSet<Product.CategoryConteiner>();
            foreach (ProductsConteiner product in Products)
            {
                Weight += product.Product.Weight * product.Count;
                Categories.Add(product.Product.Category);
            }
        }
    }
}
