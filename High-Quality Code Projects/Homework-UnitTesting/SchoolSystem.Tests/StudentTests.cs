namespace SchoolSystem.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem.Common;
    
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentConstructorTest()
        {
            string firstName = "Ivaylo";
            string lastName = "Petkanov";
            int uniqueNumber = 12522;

            Student student = new Student(firstName, lastName, uniqueNumber);

            Assert.AreEqual(firstName, student.FirstName);
            Assert.AreEqual(lastName, student.LastName);
            Assert.AreEqual(uniqueNumber, student.UniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetWhitespaceFirstNameTest()
        {
            Student student = new Student("   ", "Petkov", 22112);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetShorterThanAllowedFirstNameTest()
        {
            Student student = new Student("A", "Petkov", 22112);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetLongerThanAllowedLastNameTest()
        {
            Student student = new Student("Niko", "Wolllfeschllegelsteinhaussennbergerdorffvoroffovich", 22112);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetNullLastNameTest()
        {
            Student student = new Student("Petko", null, 22112);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetInvalidLastNameTest()
        {
            Student student = new Student("Special", "Some.one", 22112);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetSmallerThanMinUniqueNumberTest()
        {
            Student student = new Student("Ivan", "Petrov", 9999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetBiggerThanMaxUniqueNumberTest()
        {
            Student student = new Student("Ivan", "Petrov", 119999);
        }
    }
}
