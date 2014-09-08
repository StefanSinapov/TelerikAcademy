namespace _02.Collection_of_Products
{
    using System;

    public class Product: IComparable<Product>
    {

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(Product obj)
        {
            return (int) (this.Price - obj.Price);
        }
    }
}