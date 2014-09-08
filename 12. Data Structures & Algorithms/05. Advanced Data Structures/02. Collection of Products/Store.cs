namespace _02.Collection_of_Products
{
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Store
    {
        public OrderedBag<Product> Products { get; set; }

        public Store()
        {
            Products = new OrderedBag<Product>();
        }

        public int Count
        {
            get { return this.Products.Count; }
        }

        public void AddProduct(Product product)
        {
            this.Products.Add(product);
        }

        public void AddProducts(IEnumerable<Product> products)
        {
            this.Products.AddMany(products);
        }

        public ICollection<Product> SearchInPriceRange(decimal minPrice, decimal maxPrice)
        {
            return this.Products.Range(new Product(string.Empty, minPrice), true,
                                     new Product(string.Empty, maxPrice), true).Take(20).ToList();
        }

    }
}