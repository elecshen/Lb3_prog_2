namespace Lb3_prog_2
{
    internal class Product
    {
        public struct CategoryConteiner
        {
            public CategoryConteiner(string abbreviation, string category)
            {
                Abbreviation = abbreviation;
                Category = category;
            }
            public string Abbreviation { get; }
            public string Category { get; }
        }

        public string Name { get; }
        public double Weight { get; }
        public CategoryConteiner Category { get; }

        public Product(string name, double weight, CategoryConteiner category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }
    }
}
