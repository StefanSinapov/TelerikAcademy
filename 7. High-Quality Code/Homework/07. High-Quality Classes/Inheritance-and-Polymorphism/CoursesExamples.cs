﻿namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class CoursesExamples
    {
        public static void Main()
        {
            LocalCourse localCourse = new LocalCourse("Databases", "Nakov", "Ultimate");
            Console.WriteLine(localCourse);

            localCourse.AddStudents("Peter", "Maria");
            Console.WriteLine(localCourse);

            localCourse.AddStudents("Milena");
            localCourse.AddStudents("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse("PHP Development", "Mario Peshev", "Enterprise");
            offsiteCourse.AddStudents("Thomas", "Ani", "Steve");
            Console.WriteLine(offsiteCourse);
        }
    }
}
