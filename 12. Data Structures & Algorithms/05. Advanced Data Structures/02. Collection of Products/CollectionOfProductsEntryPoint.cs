/*
 *  2. Write a program to read a large collection 
 *  of products (name + price) and efficiently find 
 *  the first 20 products in the price range [a … b]. 
 *  Test for 500 000 products and 10 000 price searches.
 *  
	Hint: you may use OrderedBag<T> and sub-ranges.
 */
namespace _02.Collection_of_Products
{
    using System;
    using System.Diagnostics;

    class CollectionOfProductsEntryPoint
    {
        private static readonly Random RandomGenerator = new Random();
        static void Main()
        {
            var products = new Store();
            var timer = new Stopwatch();

            timer.Start();
            for (int i = 0; i < 500000; i++)
            {
                var product = new Product("Name" + i, RandomGenerator.Next(0, 250000));
                products.AddProduct(product);
            }
            timer.Stop();
            Console.WriteLine("{0} products are added for {1}", products.Count, timer.Elapsed);

            timer.Restart();
            for (int i = 0; i < 10000; i++)
            {
                products.SearchInPriceRange(1111, 2222);
            }
            timer.Stop();
            Console.WriteLine("10 000 searches computed for {0}", timer.Elapsed);
        }
    }
}
