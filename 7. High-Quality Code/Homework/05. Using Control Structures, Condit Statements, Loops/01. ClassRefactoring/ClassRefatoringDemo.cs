namespace Cooking
{
    using System;
    using System.Linq;
    using Cooking.Food;

    public class ClassRefatoringDemo
    {
        public static void Main(string[] args)
        {
            Chef chef = new Chef();
            Potato potato = new Potato();
            if (potato == null)
            {
                throw new ArgumentNullException("Potato cannot be null");
            }
            else if (potato.IsPeeled && !potato.IsRotten)
            {
                chef.CookByProducts(potato);
            }
        }
    }
}
