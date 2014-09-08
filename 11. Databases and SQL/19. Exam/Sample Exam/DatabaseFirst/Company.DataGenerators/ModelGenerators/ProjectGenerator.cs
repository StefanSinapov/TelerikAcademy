namespace Company.DataGenerators.ModelGenerators
{
    using Abstract;
    using Common;
    using Contracts;
    using Data;

    public class ProjectGenerator : DataGenerator
    {
        private const int MinNameLength = 5;
        private const int MaxNameLength = 50;
        private const int MinEmployeesCount = 2;
        private const int MaxEmployeesCount = 20;

        public ProjectGenerator(CompanyEntities companyEntities, int seedDataCount, ILogger logger)
            : base(companyEntities, seedDataCount, logger)
        {
        }

        public override void Seed()
        {
            this.Logger.Log("\nSeeding Projects\n");

            for (int i = 0; i < this.SeedDataCount; i++)
            {

                var project = new Project
                {
                    Name = RandomDataGenerator.Instance.GetRandomString(MinNameLength, MaxNameLength)
                };

                this.CompanyEntities.Projects.Add(project);

                if (i%100 == 0)
                {
                    this.Logger.Log(".");
                    this.CompanyEntities.SaveChanges();
                }
            }

            this.CompanyEntities.SaveChanges();
            this.Logger.Log("\nProjects Seeded!\n");
        }
    }
}