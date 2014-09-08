namespace ToyStore.DataGenerators.ModelGenerators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Abstract;
    using Contracts;
    using Data;

    public class ToyGenerator : DataGenerator
    {
        private const int MinLenght = 4;
        private const int MaxLength = 10;
        private const int PercentageForNull = 20;

        public ToyGenerator(ToyStoreEntities toyStoreEntities, int seedDataCount, ILogger logger)
            : base(toyStoreEntities, seedDataCount, logger)
        {
        }

        public override void Seed()
        {
            this.Logger.Log(Environment.NewLine);
            this.Logger.Log("Seeding Toys ");

            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var toy = new Toy
                {
                    Name = RandomDataGenerator.Instance.GetRandomString(MinLenght, MaxLength),
                    Type = RandomDataGenerator.Instance.GetRandomStringOrNull(MinLenght, MaxLength, PercentageForNull),
                    Price = (decimal)Math.Round(RandomDataGenerator.Instance.GetRandomDouble(1, 50), 2),
                    Color = RandomDataGenerator.Instance.GetRandomString(MinLenght, MaxLength),
                    AgeRangeId = this.GetRandomAgeRangeFromDatabase(),
                    ManufacturerId = this.GetRandomManufacturerFromDatabase(),
                    Categories = this.GetRandomCategoriesFromDatabase()
                };

                this.ToyStoreEntities.Toys.Add(toy);

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.ToyStoreEntities.SaveChanges();
                }
            }

            this.ToyStoreEntities.SaveChanges();
            this.Logger.Log("\nToys seeded!");
            this.Logger.Log(Environment.NewLine);
        }

        private ICollection<Category> GetRandomCategoriesFromDatabase()
        {
            var categories = this.ToyStoreEntities.Categories;
            var categoriesToSkip = RandomDataGenerator.Instance.GetRandomInt(0, categories.Count() - 1);
            var categoriesToTake = RandomDataGenerator.Instance.GetRandomInt(1, 3);

            var randomCategories = categories.OrderBy(c => c.Id)
                                            .Skip(categoriesToSkip)
                                            .Take(categoriesToTake)
                                            .ToList();

            return randomCategories;
        }

        private int GetRandomManufacturerFromDatabase()
        {
            var manufacturers = this.ToyStoreEntities.Manufacturers;
            var numberOfManufacturersToSkip = RandomDataGenerator.Instance.GetRandomInt(0, manufacturers.Count() - 1);

            var randomManufacturerId = manufacturers.OrderBy(m => m.Id)
                                            .Skip(numberOfManufacturersToSkip)
                                            .Select(m => m.Id)
                                            .First();

            return randomManufacturerId;
        }

        private int GetRandomAgeRangeFromDatabase()
        {
            var ageRanges = this.ToyStoreEntities.AgeRanges;
            var numberOfAgeRangesToSkip = RandomDataGenerator.Instance.GetRandomInt(0, ageRanges.Count() - 1);

            var randomAgeRangeId = ageRanges.OrderBy(a => a.Id)
                                            .Skip(numberOfAgeRangesToSkip)
                                            .Select(a => a.Id)
                                            .First();
            return randomAgeRangeId;
        }
    }
}