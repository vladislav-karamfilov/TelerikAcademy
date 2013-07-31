namespace HashTable.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HashTable.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValuesPropertyTests
    {
        [TestMethod]
        public void GetValuesOfEmptyHashTableTest()
        {
            HashTable<string, int> studentMarks = new HashTable<string, int>();

            ICollection<int> values = studentMarks.Values;

            List<int> expected = new List<int>();
            CollectionAssert.AreEqual(expected, values.ToList());
        }

        [TestMethod]
        public void GetValuesOfNonEmptyHashTableTest()
        {
            HashTable<string, int> studentMarks = new HashTable<string, int>();
            studentMarks.Add("Ivan", 5);
            studentMarks.Add("Pesho", 4);
            studentMarks.Add("Lili", 6);
            studentMarks.Add("Gosho", 3);

            ICollection<int> values = studentMarks.Values;

            Assert.IsTrue(values.Contains(5));
            Assert.IsTrue(values.Contains(3));
            Assert.IsTrue(values.Contains(3));
            Assert.IsTrue(values.Contains(6));
        }
    }
}
