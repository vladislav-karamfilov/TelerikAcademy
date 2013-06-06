namespace SchoolSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem.Common;
    
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void CourseConstructorTest()
        {
            IList<Student> students = new List<Student>()
            {
                new Student("Ivan", "Ivanov", 12512),
                new Student("Pesho", "Peshov", 15122),
                new Student("Milena", "Georgieva", 61222)
            };
            string courseName = "Unit testing course";
            
            Course course = new Course(courseName, students);

            Assert.AreEqual(courseName, course.Name);
            Assert.AreSame(students, course.Students);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetNullNameTest()
        {
            Student student = new Student("Ivan", "Ivanov", 12414);
            Course course = new Course(null, new List<Student>() { student });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullStudentsListTest()
        {
            string courseName = "Unit testing course";
            Course course = new Course(courseName, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetListOfMoreThanMaxStudentsAllowedTest()
        {
            IList<Student> students = new List<Student>()
            {
                new Student("Ivan", "Ivanov", 12512),
                new Student("Pesho", "Peshov", 15122),
                new Student("Milena", "Georgieva", 61212),
                new Student("Ivan", "Ivanov", 12212),
                new Student("Pesho", "Peshov", 11122),
                new Student("Milena", "Georgieva", 61112),
                new Student("Ivan", "Ivanov", 12516),
                new Student("Pesho", "Peshov", 15121),
                new Student("Milena", "Georgieva", 11212),
                new Student("Ivan", "Ivanov", 17512),
                new Student("Pesho", "Peshov", 15882),
                new Student("Milena", "Georgieva", 61822),
                new Student("Ivan", "Ivanov", 12712),
                new Student("Pesho", "Peshov", 15772),
                new Student("Milena", "Georgieva", 71772),
                new Student("Ivan", "Ivanov", 13452),
                new Student("Pesho", "Peshov", 10122),
                new Student("Milena", "Georgieva", 61202),
                new Student("Ivan", "Ivanov", 10012),
                new Student("Pesho", "Peshov", 15022),
                new Student("Milena", "Georgieva", 61000),
                new Student("Ivan", "Ivanov", 12000),
                new Student("Pesho", "Peshov", 15182),
                new Student("Milena", "Georgieva", 61245),
                new Student("Ivan", "Ivanov", 14412),
                new Student("Pesho", "Peshov", 14822),
                new Student("Milena", "Georgieva", 64152),
                new Student("Ivan", "Ivanov", 11212),
                new Student("Pesho", "Peshov", 17722),
                new Student("Milena", "Georgieva", 67722)
            };
            string courseName = "Unit testing course";

            Course course = new Course(courseName, students);
        }

        [TestMethod]
        public void AddStudentToCourseTest()
        {
            IList<Student> students = new List<Student>()
            {
                new Student("Ivan", "Ivanov", 12512),
                new Student("Pesho", "Peshov", 15122),
                new Student("Milena", "Georgieva", 61222)
            };
            string courseName = "Unit testing course";
            int expectedStudentsCount = students.Count + 1;

            Course course = new Course(courseName, students);
            course.AddStudent(new Student("Lili", "Marinova", 21221));

            Assert.AreEqual(expectedStudentsCount, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddStudentToFullCourseTest()
        {
            IList<Student> students = new List<Student>()
            {
                new Student("Ivan", "Ivanov", 12512),
                new Student("Pesho", "Peshov", 15122),
                new Student("Milena", "Georgieva", 61212),
                new Student("Ivan", "Ivanov", 12212),
                new Student("Pesho", "Peshov", 11122),
                new Student("Milena", "Georgieva", 61112),
                new Student("Ivan", "Ivanov", 12516),
                new Student("Pesho", "Peshov", 15121),
                new Student("Milena", "Georgieva", 11212),
                new Student("Ivan", "Ivanov", 17512),
                new Student("Pesho", "Peshov", 15882),
                new Student("Milena", "Georgieva", 61822),
                new Student("Ivan", "Ivanov", 12712),
                new Student("Pesho", "Peshov", 15772),
                new Student("Milena", "Georgieva", 71772),
                new Student("Ivan", "Ivanov", 13452),
                new Student("Pesho", "Peshov", 10122),
                new Student("Milena", "Georgieva", 61202),
                new Student("Ivan", "Ivanov", 10012),
                new Student("Pesho", "Peshov", 15022),
                new Student("Milena", "Georgieva", 61000),
                new Student("Ivan", "Ivanov", 12000),
                new Student("Pesho", "Peshov", 15182),
                new Student("Milena", "Georgieva", 61245),
                new Student("Ivan", "Ivanov", 14412),
                new Student("Pesho", "Peshov", 14822),
                new Student("Milena", "Georgieva", 64152),
                new Student("Ivan", "Ivanov", 11212),
                new Student("Pesho", "Peshov", 17722)
            };
            string courseName = "Unit testing course";

            Course course = new Course(courseName, students);
            course.AddStudent(new Student("Milena", "Georgieva", 67722));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullToCourseTest()
        {
            IList<Student> students = new List<Student>()
            {
                new Student("Ivan", "Ivanov", 12512),
                new Student("Pesho", "Peshov", 15122),
            };
            string courseName = "Unit testing course";

            Course course = new Course(courseName, students);
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddDuplicateStudentTest()
        {
            IList<Student> students = new List<Student>()
            {
                new Student("Ivan", "Ivanov", 12512),
                new Student("Pesho", "Peshov", 15122),
                new Student("Milena", "Georgieva", 61222)
            };
            string courseName = "Unit testing course";
            
            Course course = new Course(courseName, students);
            course.AddStudent(new Student("Pesho", "Peshov", 15122));
        }

        [TestMethod]
        public void RemoveExistingStudentFromCourseTest()
        {
            Student peshoStudent = new Student("Pesho", "Peshov", 15122);
            IList<Student> students = new List<Student>()
            {
                new Student("Ivan", "Ivanov", 12512),
                peshoStudent,
                new Student("Milena", "Georgieva", 61222)
            };
            string courseName = "Unit testing course";
            
            Course course = new Course(courseName, students);
            bool removed = course.RemoveStudent(peshoStudent);

            Assert.IsTrue(removed);
        }

        [TestMethod]
        public void RemoveNonExistingStudentFromCourseTest()
        {
            Student peshoStudent = new Student("Pesho", "Peshov", 15122);
            IList<Student> students = new List<Student>()
            {
                new Student("Ivan", "Ivanov", 12512),
                new Student("Milena", "Georgieva", 61222)
            };
            string courseName = "Unit testing course";

            Course course = new Course(courseName, students);
            bool removed = course.RemoveStudent(peshoStudent);

            Assert.IsFalse(removed);
        }
    }
}
