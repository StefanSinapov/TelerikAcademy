namespace _03.Online_Market
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    class OnlineMarket
    {
        static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

            var market = new Market();

            var input = Console.ReadLine();

            while (input != "end")
            {
                input += " ";
                var indexOfFirstSpace = input.IndexOf(' ');
                var command = input.Substring(0, indexOfFirstSpace);
                var arguments = input.Substring(indexOfFirstSpace + 1, input.Length - indexOfFirstSpace - 1);
                var values = arguments.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (command == "add" && values.Length == 3)
                {
                    var name = values[0];
                    var price = double.Parse(values[1]);
                    var type = values[2];

                    market.Add(new Product(name, price, type));
                }

                if (command == "filter")
                {
                    var commandType = values[1];

                    if (commandType == "type")
                    {
                        if (values.Length > 2)
                        {
                            var type = values[2];
                            market.FilterByType(type);
                        }
                        else
                        {
                            market.Filter();
                        }

                    }
                    else if (commandType == "price")
                    {

                        if (values.Count() > 5)
                        {
                            double fromPrice = double.Parse(values[3]);
                            double toPrice = double.Parse(values[5]);

                            market.FilterByPrice(fromPrice, toPrice);
                        }
                        else if (values.Length > 3)
                        {
                            var filterType = values[2];

                            if (filterType == "from")
                            {
                                double fromPrice = double.Parse(values[3]);
                                market.FilterByMinPrice(fromPrice);
                            }
                            else if (filterType == "to")
                            {
                                double toPrice = double.Parse(values[3]);
                                market.FilterByMaxPrice(toPrice);
                            }
                        }
                        //                        else
                        //                        {
                        //                            market.Filter();
                        //                        }
                        //                        }
                        //
                        //                        if (commandType == "*")
                        //                        {
                        //                            market.Filter();
                        //                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(market.Result());
        }
    }

    public class Market
    {
        private OrderedBag<Product> productsByPrice;
        private Dictionary<string, OrderedSet<Product>> productsByType;
        private StringBuilder sb;

        public Market()
        {
            this.productsByPrice = new OrderedBag<Product>(((x, y) => x.Price.CompareTo(y.Price)));
            this.productsByType = new Dictionary<string, OrderedSet<Product>>();
            this.sb = new StringBuilder();
        }

        public void Add(Product product)
        {
            if (!this.productsByType.ContainsKey(product.Type))
            {
                this.productsByType.Add(product.Type, new OrderedSet<Product>());
            }

            if (this.productsByType[product.Type].Contains(product))
            {
                this.sb.AppendLine(string.Format("Error: Product {0} already exists", product.Name));
                return;
            }

            this.productsByType[product.Type].Add(product);
            this.productsByPrice.Add(product);
            this.sb.AppendLine(string.Format("Ok: Product {0} added successfully", product.Name));
        }

        public void Filter()
        {
            var foundProducts = this.productsByPrice.OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Type)
                .Take(10);

            this.sb.AppendLine("Ok: " + string.Join(", ", foundProducts));
        }

        public void FilterByType(string type)
        {
            if (!productsByType.ContainsKey(type))
            {
                this.sb.AppendLine(string.Format("Error: Type {0} does not exists", type));
                return;
            }

            var foundProducts = this.productsByType[type]
                .OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Type)
                .Take(10);

            this.sb.AppendLine("Ok: " + string.Join(", ", foundProducts));

        }

        public void FilterByPrice(double fromPrice, double toPrice)
        {
            var foundProducts = this.productsByPrice.Range(new Product(string.Empty, fromPrice, string.Empty), true,
                new Product(string.Empty, toPrice, string.Empty), true).OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Type)
                .Take(10);

            this.sb.AppendLine("Ok: " + string.Join(", ", foundProducts));
        }

        public void FilterByMinPrice(double fromPrice)
        {
            var foundProducts = this.productsByPrice.Range(new Product(string.Empty, fromPrice, string.Empty), true,
                new Product(string.Empty, double.MaxValue, string.Empty), true).OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Type)
                .Take(10);

            if (!foundProducts.Any())
            {
                this.sb.AppendLine("Ok:");
                return;
            }

            this.sb.AppendLine("Ok: " + string.Join(", ", foundProducts));
        }

        public void FilterByMaxPrice(double toPrice)
        {
            var foundProducts = this.productsByPrice.Range(new Product(string.Empty, double.MinValue, string.Empty), true,
                new Product(string.Empty, toPrice, string.Empty), true).OrderBy(x => x.Price)
                .ThenBy(x => x.Name)
                .ThenBy(x => x.Type)
                .Take(10);

            this.sb.AppendLine("Ok: " + string.Join(", ", foundProducts));
        }


        public string Result()
        {
            return this.sb.ToString();
        }
    }

    public class Product : IComparable<Product>, IEquatable<Product>
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public int CompareTo(Product other)
        {
            return String.Compare(this.Name, other.Name, StringComparison.InvariantCulture);
        }

        public bool Equals(Product other)
        {
            return this.Name.Equals(other.Name);
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
    }
}
