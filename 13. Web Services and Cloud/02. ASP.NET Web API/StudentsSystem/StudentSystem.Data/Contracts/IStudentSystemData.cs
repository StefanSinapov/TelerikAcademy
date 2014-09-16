namespace StudentSystem.Data.Contracts
{
    using Models;

    public interface IStudentSystemData
    {
        IRepository<Course> Courses { get; }

        IRepository<Homework> Homeworks { get; }

        IRepository<Material> Materials { get; }

        IRepository<Student> Students { get; } 

        int SaveChanges(); 
    }
}