namespace Company.DataGenerators.ModelGenerators
{
    using System.Linq;
    using Abstract;
    using Common;
    using Contracts;
    using Data;

    public class EmployeeGenerator : DataGenerator
    {
        private const int NameMinLenght = 5;
        private const int NameMaxLenght = 20;
        private const int SalaryMin = 50000;
        private const int SalaryMax = 200000;
        private const int PercentageForManager = 95;


        public EmployeeGenerator(CompanyEntities companyEntities, int seedDataCount, ILogger logger)
            : base(companyEntities, seedDataCount, logger)
        {
        }

        public override void Seed()
        {
            this.Logger.Log("\nSeeding Employees");

            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var employee = new Employee()
                {
                    FirstName = RandomDataGenerator.Instance.GetRandomString(NameMinLenght, NameMaxLenght),
                    LastName = RandomDataGenerator.Instance.GetRandomString(NameMinLenght, NameMaxLenght),
                    DepartmentId = this.GetRandomDepartment(),
                    ManagerId = this.GetRandomManagerOrNull(),
                    YearSalary = RandomDataGenerator.Instance.GetRandomInt(SalaryMin, SalaryMax)
                };

                this.CompanyEntities.Employees.Add(employee);
                if (employee.ManagerId == null)
                {
                    this.CompanyEntities.SaveChanges();
                }

                if (i % 100 == 0)
                {
                    this.Logger.Log(".");
                    this.CompanyEntities.SaveChanges();
                }
            }

            this.CompanyEntities.SaveChanges();
            this.Logger.Log("\nEmployees seeded!\n");
        }

        private int? GetRandomManagerOrNull()
        {
            if (!RandomDataGenerator.Instance.GetChance(PercentageForManager))
            {
                return null;
            }

            var employeesWithoutManager = this.CompanyEntities.Employees.Where(e => e.ManagerId == null);

            int numbersOfEmployeesToSkip = RandomDataGenerator.Instance.GetRandomInt(0,
                employeesWithoutManager.Count() - 1);

            int randomEmpoyeeId = employeesWithoutManager.OrderBy(e => e.Id)
                                                            .Skip(numbersOfEmployeesToSkip)
                                                            .Select(e => e.Id)
                                                            .FirstOrDefault();

            if (randomEmpoyeeId == 0)
            {
                return null;
            }

            return randomEmpoyeeId;
        }

        private int GetRandomDepartment()
        {
            var departments = this.CompanyEntities.Departments;

            int numberOfDepartmentsToSkip = RandomDataGenerator.Instance.GetRandomInt(0, departments.Count() - 1);

            int randomDepartmentId = departments.OrderBy(d => d.Id)
                                                .Skip(numberOfDepartmentsToSkip)
                                                .Select(d => d.Id)
                                                .First();

            return randomDepartmentId;
        }
    }
}