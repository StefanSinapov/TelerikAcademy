namespace InheritanceAndPolymorphism.Interfaces
{
    using System;

    public interface ICourse
    {
        string Name { get; set; }

        string TeacherName { get; set; }

        void AddStudents(params string[] studentNames);

        string ToString();
    }
}
