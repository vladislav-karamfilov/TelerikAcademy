namespace HashTable.Tests
{
    using System;
    using HashTable.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FindWithNullKeyTest()
        {
            HashTable<string, int> studentMarks = new HashTable<string, int>();
            studentMarks.Add("Ivan", 5);
            studentMarks.Add("Pesho", 4);
            studentMarks.Add("Lili", 6);
            studentMarks.Add("Gosho", 3);

            studentMarks.Find(null);
        }

        [TestMethod]
        public void FindExistingEntryTest()
        {
            HashTable<string, int> studentMarks = new HashTable<string, int>();
            studentMarks.Add("Ivan", 5);
            studentMarks.Add("Pesho", 4);
            studentMarks.Add("Lili", 6);
            studentMarks.Add("Gosho", 3);

            KeyValuePair<string, int> ivanMark = studentMarks.Find("Ivan");

            Assert.AreEqual("Ivan", ivanMark.Key);
            Assert.AreEqual(5, ivanMark.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
        public void FindNonExistingEntryTest()
        {
            HashTable<string, int> studentMarks = new HashTable<string, int>();
            studentMarks.Add("Ivan", 5);
            studentMarks.Add("Pesho", 4);
            studentMarks.Add("Lili", 6);
            studentMarks.Add("Gosho", 3);

            studentMarks.Find("Marin");
        }
    }
}
