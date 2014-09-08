namespace Company.DataGenerators.ModelGenerators
{
    using Abstract;
    using Common;
    using Contracts;
    using Data;

    public class DepartmentGenerator : DataGenerator
    {
        private const int MinLenght = 10;
        private const int MaxLenght = 50;

        public DepartmentGenerator(CompanyEntities companyEntities, int seedDataCount, ILogger logger) 
            : base(companyEntities, seedDataCount, logger)
        {

        }

        public override void Seed()
        {
            this.Logger.Log("\nSeeding Departments ");
            var collectionOfUniqueNames = RandomDataGenerator.Instance.GetUniqueStringsCollection(MinLenght, MaxLenght,
                this.SeedDataCount);

            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var department = new Department
                {
                    Name = collectionOfUniqueNames[i]
                };

                this.CompanyEntities.Departments.Add(department);

                if (i%100 == 0)
                {
                    this.Logger.Log(".");
                    this.CompanyEntities.SaveChanges();
                }
            }

            this.CompanyEntities.SaveChanges();
            this.Logger.Log("\nDepartments seeded!\n");
        }
    }
}