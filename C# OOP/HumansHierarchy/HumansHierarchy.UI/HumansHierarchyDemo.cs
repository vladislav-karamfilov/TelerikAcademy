using System;
using System.Linq;
using System.Collections.Generic;
using HumansHierarchy.Common;

namespace HumansHierarchy.UI
{
    class HumansHierarchyDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Performing different sortings of humans***");
            Console.Write(decorationLine);

            // 10 students
            Student[] students = new Student[10]
            {
                new Student("Ivan", "Ivanov", 4.1),
                new Student("Petar", "Kirilov", 3.9),
                new Student("Lili", "Marinova", 5),
                new Student("Aleksandyr", "Kostadinov", 5.4),
                new Student("Ivan", "Marinov", 4.8),
                new Student("Daniel", "Petkov", 5.8),
                new Student("Kostadin", "Hristov", 6),
                new Student("Lili", "Yordanova", 4.5),
                new Student("Viktoria", "Viktorova", 5),
                new Student("Gergana", "Mihaylova")
            };
            students[9].Grade = 4.4;
            // Sorting the students in ascending order by grade and printing on the console
            var sortedByGrade = students.OrderBy(student => student.Grade);
            Console.WriteLine("---Students sorted by their grade---");
            foreach (var student in sortedByGrade)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();

            // 10 workers
            List<Worker> workers = new List<Worker>()
            {
                new Worker("Stefan", "Stefanov"),
                new Worker("Ivan", "Dimitrov", 3200.2m, 16),
                new Worker("Petko", "Dimov", 560.9m, 5),
                new Worker("Nikol", "Kamenova", 1200.4m, 8),
                new Worker("Krasi", "Nikolov", 360.9m, 4),
                new Worker("Elena", "Plamenova", 300m, 3),
                new Worker("Georgi", "Ivanov", 1000.95m, 8),
                new Worker("Sofia", "Ivaylova", 1500.2m, 12),
                new Worker("Plamen", "Georgiev", 900.94m, 8),
                new Worker("Kalin", "Dimov", 500.9m, 4)
            };
            workers[0].WeekSalary = 400.2m;
            workers[0].WorkHoursPerDay = 3;
            // Sorting the workers in descending order by money per hour and printing on the console
            var sortedByMoneyPerHour =
                from worker in workers
                orderby worker.MoneyPerHour() descending
                select worker;
            Console.WriteLine("---Workers sorted by money per hour---");
            foreach (var worker in sortedByMoneyPerHour)
            {
                Console.WriteLine(worker);
            }
            Console.WriteLine();
            
            // Merging them in a list of humans
            List<Human> humans = new List<Human>();
            foreach (Student student in students)
            {
                humans.Add(student);
            }
            foreach (Worker worker in workers)
            {
                humans.Add(worker);
            }
            // Sorting the list of humans by first name and last name and printing on the console
            var sortedByNames = humans.OrderBy(human => human.FirstName).ThenBy(human => human.LastName);
            Console.WriteLine("---Sorted students and workers by first and last names---");
            foreach (var human in sortedByNames)
            {
                Console.WriteLine(human);
            }
        }
    }
}
