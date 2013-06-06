namespace SchoolSystem.UI
{
    using System;
    using System.Collections.Generic;
    using SchoolSystem.Common;

    public class SchoolSystemUI
    {
        public static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Presenting the functionality of the school system***");
            Console.Write(decorationLine);

            Student[] students = new Student[]
            {
                new Student("Ivan", "Ivanov", 12551),
                new Student("Peter", "Petrov", 51512),
                new Student("Georgi", "Georgiev", 51211),
                new Student("Lili", "Konstantinova", 91251),
                new Student("Qvor", "Marinov", 21512),
                new Student("Dimitar", "Dimitrov", 15122)
            };

            List<Course> courses = new List<Course>()
            {
                new Course("Informatics", new List<Student>() { students[0], students[2], students[4] }),
                new Course("Mathematics", new List<Student>() { students[1], students[3], students[5] }),
                new Course("History", new List<Student>() { students[1], students[2], students[4] })
            };

            School school = new School("SOU Vasil Levski", courses);

            PrintSchoolInformation(school);
        }

        private static void PrintSchoolInformation(School school)
        {
            Console.WriteLine("School name: {0}", school.Name);
            foreach (Course course in school.Courses)
            {
                Console.WriteLine("- Course name: {0}", course.Name);
                foreach (Student student in course.Students)
                {
                    Console.WriteLine("--- Student: {0} {1} ID - {2}", student.FirstName, student.LastName, student.UniqueNumber);
                }
            }
        }
    }
}
