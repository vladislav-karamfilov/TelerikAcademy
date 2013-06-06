using System;
using System.Linq;

namespace ExtractStudentsNamesByAge
{
    class ExtractStudentsNamesByAge
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Finding first and last names of students with age between 18 and 24***");
            Console.Write(decorationLine);

            // Defining the students using random names and ages (using anonymous types)
            var students = new[] {
                new { FirstName = "Pesho", LastName = "Peshov", Age = 19 },
                new { FirstName = "Gosho", LastName = "Goshov", Age = 21 },
                new { FirstName = "Pesho", LastName = "Dimitrov", Age = 26 },
                new { FirstName = "Gosho", LastName = "Dimitrov", Age = 20 },
                new { FirstName = "Smesho", LastName = "Petkov", Age = 18 },
                new { FirstName = "Kiro", LastName = "Limuzinov", Age = 28 },
                new { FirstName = "Kiro", LastName = "Kirchov", Age = 25 },
                new { FirstName = "Lili", LastName = "Rosenova", Age = 30 },
                new { FirstName = "Aneta", LastName = "Angelova", Age = 22 }
            };

            // Getting all students' with age between 18 and 24 first and last names
            var studentsNames =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select student.FirstName + " " + student.LastName;

            Console.WriteLine("All students that are between 18 and 24 years old are: ");
            foreach (var studentNames in studentsNames)
            {
                Console.WriteLine(studentNames);
            }
        }
    }
}
