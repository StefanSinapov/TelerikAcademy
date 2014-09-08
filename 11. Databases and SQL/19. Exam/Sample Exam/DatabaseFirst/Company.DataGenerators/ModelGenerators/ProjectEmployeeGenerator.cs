namespace Company.DataGenerators.ModelGenerators
{
    using System;
    using System.Linq;
    using Abstract;
    using Common;
    using Contracts;
    using Data;

    public class ProjectEmployeeGenerator : DataGenerator
    {
        private const int MinEmployeesCount = 2;
        private const int MaxEmployeesCount = 20;
        private readonly DateTime minStartDate = new DateTime(1990, 01, 01);
        private readonly DateTime maxEndDate = new DateTime(2031, 01, 01);
        private const int MinYearsLength = 0;
        private const int MaxYearsLength = 5;

        public ProjectEmployeeGenerator(CompanyEntities companyEntities, int seedDataCount, ILogger logger)
            : base(companyEntities, seedDataCount, logger)
        {
        }

        public override void Seed()
        {
            this.Logger.Log("\nAdding connections between employees and projects\n");

            for (int i = 0; i < this.SeedDataCount; i++)
            {
                var employeesToAdd = RandomDataGenerator.Instance.GetRandomInt(MinEmployeesCount, MaxEmployeesCount);
                var yearsForProjectLenght = RandomDataGenerator.Instance.GetRandomInt(MinYearsLength, MaxYearsLength);

                for (int j = 0; j < employeesToAdd; j++)
                {
                    var endDate = RandomDataGenerator.Instance.GetRandomDate(minStartDate, maxEndDate);
                    var projectId = this.GetProjectId(i);
                    var employeesProjects = new EmployeesProject
                    {
                        ProjectId = projectId,
                        EmployeeId = this.GetRandomEmployees(),
                        StarDate = RandomDataGenerator.Instance.GetRandomDate(minStartDate, maxEndDate),
                        EndDate = endDate
                    };

                    this.CompanyEntities.EmployeesProjects.Add(employeesProjects);
                }

                if ((i + employeesToAdd)%100 == 0)
                {
                    this.Logger.Log(".");
                    this.CompanyEntities.SaveChanges();
                }
            }

            this.CompanyEntities.SaveChanges();
            this.Logger.Log("\nConnections seeded!");
        }

        private int GetRandomEmployees()
        {
            var employees = this.CompanyEntities.Employees;
            var employeesToSkip = RandomDataGenerator.Instance.GetRandomInt(0, employees.Count() - 1);

            var empoyeeId = employees.OrderBy(e => e.Id)
                .Skip(employeesToSkip)
                .Select(e => e.Id)
                .First();

            return empoyeeId;

        }

        private int GetProjectId(int skip)
        {
            var projects = this.CompanyEntities.Projects;

            int nextProjectId = projects.OrderBy(p => p.Id)
                .Skip(skip)
                .Select(p => p.Id)
                .First();

            return nextProjectId;
        }
    }
}