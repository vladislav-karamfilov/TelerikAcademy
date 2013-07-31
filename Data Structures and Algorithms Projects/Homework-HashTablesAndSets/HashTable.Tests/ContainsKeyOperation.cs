namespace HashTable.Tests
{
    using System;
    using HashTable.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ContainsKeyOperation
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNullKeyElementTest()
        {
            HashTable<Point, int> pointsCounts = new HashTable<Point, int>();
            pointsCounts.Add(new Point(3, 2), 11);

            pointsCounts.Remove(null);
        }

        [TestMethod]
        public void ContainsKeyTrueTest()
        {
            HashTable<string, int> studentMarks = new HashTable<string, int>();
            studentMarks.Add("Ivan", 5);
            studentMarks.Add("Pesho", 4);
            studentMarks.Add("Lili", 6);
            studentMarks.Add("Gosho", 3);

            bool containsIvanStudent = studentMarks.ContainsKey("Ivan");

            Assert.IsTrue(containsIvanStudent);
        }

        [TestMethod]
        public void ContainsKeyFalseTest()
        {
            HashTable<string, int> studentMarks = new HashTable<string, int>();
            studentMarks.Add("Pesho", 4);
            studentMarks.Add("Lili", 6);
            studentMarks.Add("Gosho", 3);

            bool containsIvanStudent = studentMarks.ContainsKey("Ivan");

            Assert.IsFalse(containsIvanStudent);
        }
    }
}
