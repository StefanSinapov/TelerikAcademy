namespace Company.DataGenerators
{
    using System.Collections.Generic;
    using Data;
    using Contracts;
    using ModelGenerators;

    public class DatabaseSeederWithRandomData : ISeeder
    {
        /*private const int CategoriesCount = 100;
        private const int ManufacturersCount = 50;
        private const int AgeRangesCount = 100;
        private const int ToysCount = 20000;*/

        private const int DepartmentsCount = 100;
        private const int EmployeesCount = 5000;
        private const int ProjectsCount = 1000;
        private const int ReportsCount = 200000;

        public DatabaseSeederWithRandomData(CompanyEntities companyEntities, ILogger logger)
        {
            this.CompanyEntities = companyEntities;
            this.Logger = logger;
        }

        private CompanyEntities CompanyEntities { get; set; }

        private ILogger Logger { get; set; }

        public void SeedDatabaseWithRandomData()
        {
            var dataGenerators = new HashSet<IDataGenerator>
            {
                new DepartmentGenerator(this.CompanyEntities, DepartmentsCount, this.Logger),
                new EmployeeGenerator(this.CompanyEntities, EmployeesCount, this.Logger),
                new ProjectGenerator(this.CompanyEntities, ProjectsCount, this.Logger),
                // ProjectEmployeeGenerator(this.CompanyEntities, ProjectsCount, this.Logger)
            };

            foreach (var dataGenerator in dataGenerators)
            {
                dataGenerator.Seed();
            }
        }
    }
}