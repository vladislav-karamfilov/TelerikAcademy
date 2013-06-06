namespace SchoolSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem.Common;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void SchoolConstructorTest()
        {
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
            string schoolName = "SOU Vasil Levski";

            School school = new School(schoolName, courses);

            Assert.AreEqual(schoolName, school.Name);
            Assert.AreSame(courses, school.Courses);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetWhitespaceNameTest()
        {
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

            School school = new School("   ", courses);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullCoursesListTest()
        {
            string schoolName = "SOU Vasil Levski";
            School school = new School(schoolName, null);
        }
    }
}
