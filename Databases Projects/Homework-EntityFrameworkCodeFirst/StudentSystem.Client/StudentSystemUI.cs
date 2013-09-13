namespace StudentSystem.Client
{
    using System;
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Data.Migrations;

    class StudentSystemUI
    {
        static StudentSystemContext context = new StudentSystemContext();

        static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Presenting some data from the Student System database");
            Console.WriteLine("created with Code First approach***");
            Console.Write(decorationLine);

            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());
            context.Database.Initialize(true);

            AddHomeworks();

            Console.WriteLine("---Printing all courses---");
            PrintCourses();
            Console.WriteLine();

            Console.WriteLine("---Printing all students---");
            PrintStudents();
        }

        static void PrintStudents()
        {
            foreach (var student in context.Students.Include("Courses").Include("Homeworks"))
            {
                Console.WriteLine("Name: {0}; Faculty number: {1}; Courses: {2}; Homeworks: {3}",
                    student.Name, student.FacultyNumber,
                    string.Join(", ", student.Courses.Select(c => c.Name)),
                    string.Join(", ", student.Homeworks.Select(h => new { Name = h.Name, TimeSent = h.TimeSent })));
            }
        }

        static void PrintCourses()
        {
            foreach (var course in context.Courses.Include("Students").Include("Materials").Include("Homeworks"))
            {
                Console.WriteLine("Name: {0}; Description: {1}; Materials: {2}; Students: {3}; Homeworks: {4}",
                    course.Name, course.Description,
                    string.Join(", ", course.Materials.Select(m => m.Name)),
                    string.Join(", ", course.Students.Select(s => s.Name)),
                    string.Join(", ", course.Homeworks.Select(h => h.Name)));
            }
        }

        static void AddHomeworks()
        {
            Homework firstCourseFirstHomework = new Homework() { Name = "Homework 1" };
            context.Courses.First().Homeworks.Add(firstCourseFirstHomework);

            Homework firstCourseSecondHomework = new Homework() { Name = "Homework 2" };
            context.Courses.First().Homeworks.Add(firstCourseSecondHomework);

            Homework secondCourseFirstHomework = new Homework() { Name = "Homework 1" };
            context.Courses.OrderBy(c => c.ID).Skip(1).First().Homeworks.Add(secondCourseFirstHomework);
            
            Homework secondCourseSecondHomework = new Homework() { Name = "Homework 2" };
            context.Courses.OrderBy(c => c.ID).Skip(1).First().Homeworks.Add(secondCourseSecondHomework);

            firstCourseFirstHomework.TimeSent = DateTime.Now.Subtract(new TimeSpan(5, 0, 0));
            secondCourseSecondHomework.TimeSent = DateTime.Now.Subtract(new TimeSpan(2, 0, 0));
            firstCourseSecondHomework.TimeSent = DateTime.Now.Subtract(new TimeSpan(3, 0, 0));

            context.Students.First().Homeworks.Add(firstCourseFirstHomework);
            context.Students.First().Homeworks.Add(firstCourseSecondHomework);
            context.Students.OrderBy(s => s.ID).Skip(2).First().Homeworks.Add(secondCourseSecondHomework);
        }
    }
}
