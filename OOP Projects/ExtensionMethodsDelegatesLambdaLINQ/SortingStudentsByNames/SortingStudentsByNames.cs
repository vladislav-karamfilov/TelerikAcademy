using System;
using System.Linq;

namespace SortingStudentsByNames
{
    class SortingStudentsByNames
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Sorting students by first and by last name in descending order***");
            Console.Write(decorationLine);

            // Defining the students using random names (using anonymous types)
            var students = new[] {
                new { FirstName = "Pesho", LastName = "Peshov" },
                new { FirstName = "Gosho", LastName = "Goshov" },
                new { FirstName = "Pesho", LastName = "Dimitrov" },
                new { FirstName = "Genka", LastName = "Dimitrova" },
                new { FirstName = "Ivan", LastName = "Petkov" },
                new { FirstName = "Kiro", LastName = "Limuzinov" },
                new { FirstName = "Penka", LastName = "Kirchova" },
                new { FirstName = "Lili", LastName = "Rosenova" },
                new { FirstName = "Aneta", LastName = "Angelova" },
                new { FirstName = "Ivan", LastName = "Ivanov" }
            };

            // Sorting using extension methods + lamba expression
            var sortedStudents =
                students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);

            //// Sorting using LINQ query
            //var sortedStudents =
            //    from student in students
            //    orderby student.FirstName descending, student.LastName descending
            //    select student;

            Console.WriteLine("After sorting the students: ");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }
}
