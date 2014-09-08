namespace ToyStore.DataGenerators.ModelGenerators
{
    using System;
    using Abstract;
    using Contracts;
    using Data;

    public class AgeRangeGenerator : DataGenerator
    {
        public AgeRangeGenerator(ToyStoreEntities toyStoreEntities, int seedDataCount, ILogger logger)
            : base(toyStoreEntities, seedDataCount, logger)
        {
        }

        public override void Seed()
        {
            this.Logger.Log("\nSeeding AgeRanges");

            int lowerBound = 1;
            int upperBound = 5;
            var minAge = 1;

            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var ageRange = new AgeRanx
                {
                    MinAge = minAge,
                    MaxAge = upperBound
                };

                this.ToyStoreEntities.AgeRanges.Add(ageRange);

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.ToyStoreEntities.SaveChanges();
                }


                if (minAge++ + 2 >= upperBound)
                {
                    lowerBound++;
                    upperBound += lowerBound - 2;
                    minAge = lowerBound;
                }
            }

            this.ToyStoreEntities.SaveChanges();
            this.Logger.Log("\nAgeRanges Seeded!");
            this.Logger.Log(Environment.NewLine);
        }
    }
}