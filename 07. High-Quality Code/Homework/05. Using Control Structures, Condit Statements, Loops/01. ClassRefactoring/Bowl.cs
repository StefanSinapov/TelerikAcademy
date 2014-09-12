namespace Cooking
{
    using System;
    using System.Collections.Generic;
    using Cooking.Food;

    public class Bowl
    {
        private IEnumerable<NaturalFood> products;

        public Bowl()
        {
            this.products = new List<NaturalFood>();
        }

        public void Add(NaturalFood product)
        {
            throw new NotImplementedException();
        }
    }
}
