using System;
using System.Linq;

namespace ExtractStudentsByNames
{
    class ExtractStudentsByNamesDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Finding all students with first name alphabetically before his/her last name using LINQ query***");
            Console.Write(decorationLine);

            // Defining the students using random names (using anonymous types)
            var students = new[] {
            new { FirstName = "Pesho", LastName = "Peshov" },
            new { FirstName = "Gosho", LastName = "Goshov" },
            new { FirstName = "Pesho", LastName = "Dimitrov" },
            new { FirstName = "Gosho", LastName = "Dimitrov" },
            new { FirstName = "Smesho", LastName = "Petkov" },
            new { FirstName = "Kiro", LastName = "Limuzinov" },
            new { FirstName = "Kiro", LastName = "Kirchov" },
            new { FirstName = "Lili", LastName = "Rosenova" },
            new { FirstName = "Aneta", LastName = "Angelova" },
            new { FirstName = "Ivan", LastName = "Ivanov" }
            };

            // Getting all students whose first name is alphabetically before his/her last name
            var studentsByNames =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            Console.WriteLine("All students that have first name before his/her last name alphabetically are: ");
            foreach (var student in studentsByNames)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }
    }
}
