﻿namespace StudentSystem.Data
{
    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;
    using System;
    using System.Collections.Generic;

    public class StudentsSystemData : IStudentSystemData
    {
        private IStudentSystemDbContext context;
        private IDictionary<Type, object> repositories;

        public StudentsSystemData()
            : this(new StudentSystemDbContext())
        {
        }

        public IGenericRepository<Course> Courses
        {
            get
            {
                return this.GetRepository<Course>();
            }
        }

        public IGenericRepository<Test> Tests
        {
            get
            {
                return this.GetRepository<Test>();
            }
        }

        public StudentsRepository Students
        {
            get
            {
                return (StudentsRepository)this.GetRepository<Student>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public StudentsSystemData(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Student)))
                {
                    type = typeof(StudentsRepository);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
