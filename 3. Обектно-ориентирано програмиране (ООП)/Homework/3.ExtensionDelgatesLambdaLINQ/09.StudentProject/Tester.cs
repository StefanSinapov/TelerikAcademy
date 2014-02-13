using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject
{
    ////09.Create a class student with properties FirstName, LastName, FN, Tel, Email, Marks (a List<int>), GroupNumber.
    //Create a List<Student> with sample students. Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
    class Tester
    {
        static void Print(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// 09.Select only the students that are from group number 2. Use LINQ query. Order the students by FirstName.
        /// </summary>
        static void FindStudentsFromSecondGroupWithLinq()
        {
            var studentsFromSecondGroupWithLinq =
                from student in students
                where student.GroupNumber == 2
                orderby student.FirstName
                select student;

            Print(studentsFromSecondGroupWithLinq);
        }

        /// <summary>
        /// 10.Implement the previous using the same query expressed with extension methods.
        /// </summary>
        static void FindStudentsFromSecondGroupWithLambda()
        {
            var studentsFromSecondGroupWithLambda = students.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);

            Print(studentsFromSecondGroupWithLambda);
        }

        /// <summary>
        /// 11.Extract all students that have email in abv.bg. Use string methods and LINQ.
        /// </summary>
        static void FindStudentsWithEmailInAbv()
        {
            var studentWithEmailInAbv =
                from student in students
                where student.Email.EndsWith("abv.bg")
                select student;

            // solution with lambda expression
            // var studentsWithEmailInAbvLambda = students.Where(st => st.Email.EndsWith("abv.bg"));
            // Print(studentsWithEmailInAbvLambda);

            Print(studentWithEmailInAbv);
        }

        /// <summary>
        /// 12.Extract all students with phones in Sofia. Use LINQ.
        /// </summary>
        static void FindStudentsWithSofiaPhoneNumber()
        {
            var studentsWithSofiaPhoneNumbers =
                from student in students
                where student.Tel.StartsWith("02")
                select student;

            // studentsWithSofiaPhoneNumbersLambda = students.Where(st => st.Tel.StartsWith("02"));
            // Print(studentsWithSofiaPhoneNumbersLambda);

            Print(studentsWithSofiaPhoneNumbers);
        }

        /// <summary>
        /// 13.Select all students that have at least one mark Excellent (6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
        /// </summary>
        static void FindStudentsWithAtLeastOneExcellentMark()
        {
            var studentsWithExcellentMark =
                from student in students
                where student.ContainMark(6)
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.GetMarks() };

            //solution with lambda expression
            //var studentsWithExcellentMarkLambda = students.Where(st => st.ContainMark(6)).Select(st => new { FullName = st.FirstName + " " + st.LastName, Marks = st.GetMarks() });

            //foreach (var student in studentsWithExcellentMarkLambda)
            //{
            //    Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);
            //}

            foreach (var student in studentsWithExcellentMark)
            {
                Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);
            }
        }

        /// <summary>
        /// 14.Write down a similar program that extracts the students with exactly  two marks "2". Use extension methods.
        /// </summary>
        static void FindStudentsWithExactlyTwoMarks2()
        {
            const int markToFind = 2;
            const int markAppearences = 2;

            var studentsWithExactlyTwoMarks2 =
                from student in students
                where student.Marks.Count(x => x == markToFind) == markAppearences
                select new { FullName = student.FirstName + " " + student.LastName, Marks = student.GetMarks() };

            //solution with lambda expressions
            //var studentsWithExactlyTwoMarks2Lambda = students.Where(st => st.Marks.Count(m => m == markToFind) == markAppearences).Select(st => new { FullName = st.FirstName + " " + st.LastName, Marks = st.GetMarks() });

            //foreach (var student in studentsWithExactlyTwoMarks2Lambda)
            //{
            //    Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);
            //}

            foreach (var student in studentsWithExactlyTwoMarks2)
            {
                Console.WriteLine("{0} -> {1}", student.FullName, student.Marks);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// 15.Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
        /// substring from element on position 4 (not position 5) because the indeces start from 0
        /// </summary>
        static void FindStudentMarksEnrolledIn2006()
        {
            var studentsEnrolledIn2006 =
                from student in students
                where student.FN.Substring(4, 2) == "06"
                select new { FullName = student.FirstName + " " + student.LastName, FN = student.FN, Marks = student.GetMarks() };

            //solution with lambda expressions
            //var studentsEnrolledIn2006Lambda = students.Where(st => st.FN.Substring(4, 2) == "06").Select(st => new { FullName = st.FirstName + " " + st.LastName, FN = st.FN, Marks = st.GetMarks() });

            //foreach (var student in studentsEnrolledIn2006Lambda)
            //{
            //    Console.WriteLine("{0} - FN: {1} -> {2}", student.FullName, student.FN, student.Marks);
            //}
            //Console.WriteLine();

            foreach (var student in studentsEnrolledIn2006)
            {
                Console.WriteLine("{0} - FN: {1} -> {2}", student.FullName, student.FN, student.Marks);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 16*. Create a class Group with properties GroupNumber and DepartmentName.
        /// Introduce a property Group in the Student class. Extract all students from "Mathematics" department. Use the Join operator.
        /// </summary>
        static void FindStudentsInMathematicsDepartment()
        {
            Group[] groups = new Group[]
            {
                new Group(15, "Mathematics"),
                new Group(11, "Medicine"),
                new Group(3, "Physics"),
                new Group(1, "Chemistry")
            };

            var result =
                from g in groups
                join s in students on g.DepartmentName equals s.Group.DepartmentName
                where g.DepartmentName == "Mathematics"
                select new { Dep = s.Group.DepartmentName, Name = s.FirstName + " " + s.LastName };

            foreach (var item in result)
            {
                Console.WriteLine(item.Name + " -> " + item.Dep);
            }
        }
        static List<Student> students;
        static void Main()
        {
            students = new List<Student>()
            {
                new Student("Grigor", "Petrov", "316106", "02876455", "grigor@abv.bg", new List<int> {3, 4}, 2, new Group(15, "Physics")),
                new Student("Petar", "Marinov", "316206", "02899123", "petar@gmail.com", new List<int> {6, 5, 6, 6}, 2, new Group(3, "Mathematics")),
                new Student("Dobri", "Gospodinov", "324806", "73654789", "dobri@abv.bg", new List<int> {6, 5, 6}, 4, new Group(9, "Medicine")),
                new Student("Anna", "Dimova", "395103", "52999999", "anna@gmail.com", new List<int> {6, 6}, 2, new Group(11, "Mathematics")),
                new Student("Penka", "Stoicheva", "318206", "0899111111", "penka@abv.bg", new List<int>{2, 2, 3, 3}, 5, new Group(22, "Mathematics")),
                new Student("Anna", "Dimova", "395103", "52999999", "anna@gmail.com", new List<int> {2, 2, 3, 3, 4}, 1, new Group(11, "Chemistry"))

            };

            FindStudentsFromSecondGroupWithLinq();

            FindStudentsFromSecondGroupWithLambda();

            FindStudentsWithEmailInAbv();

            FindStudentsWithSofiaPhoneNumber();

            FindStudentsWithAtLeastOneExcellentMark();

            FindStudentsWithExactlyTwoMarks2();

            FindStudentMarksEnrolledIn2006();

            FindStudentsInMathematicsDepartment();
        }
    }
}
