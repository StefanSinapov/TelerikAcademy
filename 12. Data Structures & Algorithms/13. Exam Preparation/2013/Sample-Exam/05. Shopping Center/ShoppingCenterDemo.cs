namespace _05.Shopping_Center
{
    using System;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class ShoppingCenterDemo
    {
        static void Main()
        {

#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
            var shoppingCenter = new ShoppingCenter();


            var numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                var input = Console.ReadLine();
                int indexOfFirstSpace = input.IndexOf(' ');

                var command = input.Substring(0, indexOfFirstSpace);
                var arguments = input.Substring(indexOfFirstSpace + 1, input.Length - indexOfFirstSpace - 1);

                if (command == "AddProduct")
                {
                    var values = arguments.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var name = values[0];
                    var price = double.Parse(values[1]);
                    var producer = values[2];


                    var product = new Product(name, price, producer);
                    shoppingCenter.AddProduct(product);
                }
                else if (command == "FindProductsByName")
                {
                    var name = arguments.Trim();
                    shoppingCenter.FindProductsByName(name);
                }
                else if (command == "FindProductsByProducer")
                {
                    var producer = arguments.Trim();
                    shoppingCenter.FindProductsByProducer(producer);
                }
                else if (command == "FindProductsByPriceRange")
                {
                    var values = arguments.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(double.Parse).ToArray();
                    var fromPrice = values[0];
                    var toPrice = values[1];

                    shoppingCenter.FindProductsByPriceRange(fromPrice, toPrice);
                }
                else if (command == "DeleteProducts")
                {
                    var values = arguments.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length == 1)
                    {
                        var producer = values[0];
                        shoppingCenter.DeleteProducts(producer);
                    }
                    else if (values.Length == 2)
                    {
                        var name = values[0];
                        var producer = values[1];
                        shoppingCenter.DeleteProducts(name, producer);
                    }
                }

            }

            Console.WriteLine(shoppingCenter.GetResult());
        }

    }


    public class ShoppingCenter
    {
        private readonly OrderedBag<Product> productsByPrice = new OrderedBag<Product>();
        private readonly OrderedMultiDictionary<string, Product> productsByName = new OrderedMultiDictionary<string, Product>(true);
        private readonly OrderedMultiDictionary<string, Product> productsByProducer = new OrderedMultiDictionary<string, Product>(true);
        private readonly StringBuilder output = new StringBuilder();

        public void AddProduct(Product product)
        {
            productsByName.Add(product.Name, product);
            productsByProducer.Add(product.Producer, product);
            productsByPrice.Add(product);
            output.AppendLine("Product added");
        }

        public void DeleteProducts(string name, string producer)
        {
            if (!productsByProducer.ContainsKey(producer) && !productsByName.ContainsKey(name))
            {
                output.AppendLine("No products found");
                return;
            }

            var productsToRemove = productsByName[name].Where(product => product.Producer == producer).ToList();

            var count = productsToRemove.Count;
            if (count == 0)
            {
                output.AppendLine("No products found");
                return;
            }

            foreach (var product in productsToRemove)
            {
                productsByName.Remove(product.Name, product);
                productsByProducer.Remove(product.Producer, product);
                productsByPrice.Remove(product);
            }

            this.output.AppendLine(string.Format("{0} products deleted", count));
        }

        public void DeleteProducts(string producer)
        {
            if (!productsByProducer.ContainsKey(producer))
            {
                output.AppendLine("No products found");
                return;
            }

            var productsToDelete = productsByProducer[producer];
            var count = productsToDelete.Count;

            foreach (var product in productsToDelete)
            {
                productsByPrice.Remove(product);
                productsByName.Remove(product.Name, product);
            }

            productsByProducer.Remove(producer);


            output.AppendLine(string.Format("{0} products deleted", count));
        }

        public void FindProductsByName(string name)
        {
            if (!productsByName.ContainsKey(name))
            {
                output.AppendLine("No products found");
                return;
            }

            foreach (var product in productsByName[name].OrderBy(x => x.Name))
            {
                output.AppendLine(product.ToString());
            }
        }

        public void FindProductsByProducer(string producer)
        {
            if (!productsByProducer.ContainsKey(producer))
            {
                output.AppendLine("No products found");
                return;
            }

            var products = productsByProducer[producer].OrderBy(p => p.Name);

            foreach (var product in products)
            {
                output.AppendLine(product.ToString());
            }
        }

        public void FindProductsByPriceRange(double fromPrice, double toPrice)
        {
            var products = productsByPrice.Range(new Product(String.Empty, fromPrice, String.Empty), true,
                new Product(String.Empty, toPrice, String.Empty), true);

            if (products.Count == 0)
            {
                output.AppendLine("No products found");
                return;
            }

            foreach (var product in products.OrderBy(p => p.Name))
            {
                output.AppendLine(product.ToString());
            }
        }

        public string GetResult()
        {
            return this.output.ToString();
        }
    }

    public class Product : IComparable
    {
        public Product(string name, double price, string producer)
        {
            Name = name;
            Producer = producer;
            Price = price;
        }

        public string Name { get; set; }

        public string Producer { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1};{2};{3:f2}{4}", "{", this.Name, this.Producer, this.Price, "}");
        }

        public int CompareTo(Object other)
        {
            return this.Price.CompareTo((other as Product).Price);
        }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}