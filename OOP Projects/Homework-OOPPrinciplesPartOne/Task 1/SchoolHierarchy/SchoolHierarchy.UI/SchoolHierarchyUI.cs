using System;
using System.Collections.Generic;
using SchoolHierarchy.Common;

namespace SchoolHierarchy.UI
{
    class SchoolHierarchyUI
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Testing the functionality of a school system***");
            Console.Write(decorationLine);
            
            // Defining the school
            School school = new School();

            // Random students
            List<Student> students = new List<Student>() 
            {
                new Student("Gosho Goshov", 1),
                new Student("Ivan Ivanov", 2),
                new Student("Lili Petrova", 3)
            };
            students.Add(new Student("Pesho Peshov", 4));
            students[0].Comment = "I love programming!";
            
            // Random disciplines
            List<Discipline> disciplines = new List<Discipline>()
            {
                new Discipline("Chemistry", 2, 3),
                new Discipline("Biology", 2, 2),
                new Discipline("Physics", 3, 3),
                new Discipline("Mathematics", 4, 5),
                new Discipline("Programming languages", 5, 10),
            };

            // Random teachers
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher("Dimityr Dimitrov", new List<Discipline>() { disciplines[2], disciplines[3] }),
                new Teacher("Stoqn Stoqnov", new List<Discipline>() { disciplines[0], disciplines[1] }),
                new Teacher("Svetlin Nakov", new List<Discipline>() { disciplines[4] })
            };

            // Random classes
            SchoolClass eleventhA = new SchoolClass("11A", students, teachers);
            
            // Adding the random classes to the school
            school.AddClass(eleventhA);
            
            //// This will cause exception
            // school.AddClass(eleventhA);

            // Printing all the information about the school on the console
            Console.Write(school);
        }
    }
}
