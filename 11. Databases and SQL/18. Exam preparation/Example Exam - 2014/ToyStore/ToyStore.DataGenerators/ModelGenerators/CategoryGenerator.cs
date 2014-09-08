namespace ToyStore.DataGenerators
{
    using System;
    using Abstract;
    using Contracts;
    using Data;

    public class CategoryGenerator : DataGenerator
    {
        private const int MinLenght = 4;
        private const int MaxLenght = 10;

        public CategoryGenerator(ToyStoreEntities toyStoreEntities, int seedDataCount, ILogger logger)
            : base(toyStoreEntities, seedDataCount, logger)
        {
        }

        public override void Seed()
        {
            this.Logger.Log("\nSeeding Categories ");

            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var category = new Category
                {
                    Name = RandomDataGenerator.Instance.GetRandomString(MinLenght, MaxLenght)
                };

                this.ToyStoreEntities.Categories.Add(category);

                if (i%100 == 0)
                {
                    this.Logger.Log(".");
                    this.ToyStoreEntities.SaveChanges();
                }
            }

            this.ToyStoreEntities.SaveChanges();
            this.Logger.Log("\nCategories Seeded!");
            this.Logger.Log(Environment.NewLine);
        }
    }
}