namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using Contracts;
    using Models;
    using Repositiories;

    public class StudentSystemData : IStudentSystemData
    {
        private readonly DbContext context;

        private readonly IDictionary<Type, object> repositories;

        public StudentSystemData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Course> Courses
        {
            get { return this.GetRepository<Course>(); }
        }

        public IRepository<Homework> Homeworks
        {
            get { return this.GetRepository<Homework>(); }
        }

        public IRepository<Material> Materials
        {
            get { return this.GetRepository<Material>(); }
        }

        public IRepository<Student> Students
        {
            get { return this.GetRepository<Student>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfRepository<T>);

                //// if (typeof(T).IsAssignableFrom(typeof(UserProfile)))
                //// {
                ////     type = typeof(UsersRepository);
                //// }

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}