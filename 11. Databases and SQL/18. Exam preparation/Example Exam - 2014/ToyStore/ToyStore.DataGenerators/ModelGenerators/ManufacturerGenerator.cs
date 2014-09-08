namespace ToyStore.DataGenerators.ModelGenerators
{
    using System;
    using Abstract;
    using Contracts;
    using Data;

    public class ManufacturerGenerator : DataGenerator
    {
        private const int MinLength = 4;
        private const int MaxLength = 10;

        public ManufacturerGenerator(ToyStoreEntities toyStoreEntities, int seedDataCount, ILogger logger)
            : base(toyStoreEntities, seedDataCount, logger)
        {
        }

        public override void Seed()
        {
            this.Logger.Log("\nSeeding Manufacturers ");
            var uniqueNames = RandomDataGenerator.Instance.GetUniqueStringsCollection(MinLength, MaxLength,
                this.SeedDataCount);

            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var manufacturer = new Manufacturer
                {
                    Name = uniqueNames[i],
                    Country = RandomDataGenerator.Instance.GetRandomString(MinLength, MaxLength)
                };

                this.ToyStoreEntities.Manufacturers.Add(manufacturer);

                if (i%100 == 0)
                {
                    this.Logger.Log(".");
                    this.ToyStoreEntities.SaveChanges();
                }
            }

            this.ToyStoreEntities.SaveChanges();
            this.Logger.Log("\nManufacturers seeded!");
            this.Logger.Log(Environment.NewLine);
        }
    }
}