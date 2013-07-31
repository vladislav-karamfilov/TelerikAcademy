namespace HashTable.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HashTable.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KeysPropertyTests
    {
        [TestMethod]
        public void GetKeysOfEmptyHashTableTest()
        {
            HashTable<string, int> studentMarks = new HashTable<string, int>();
            
            ICollection<string> keys = studentMarks.Keys;

            List<string> expected = new List<string>();
            CollectionAssert.AreEqual(expected, keys.ToList());
        }

        [TestMethod]
        public void GetKeysOfNonEmptyHashTableTest()
        {
            HashTable<string, int> studentMarks = new HashTable<string, int>();
            studentMarks.Add("Ivan", 5);
            studentMarks.Add("Pesho", 4);
            studentMarks.Add("Lili", 6);
            studentMarks.Add("Gosho", 3);

            ICollection<string> keys = studentMarks.Keys;

            Assert.IsTrue(keys.Contains("Ivan"));
            Assert.IsTrue(keys.Contains("Pesho"));
            Assert.IsTrue(keys.Contains("Lili"));
            Assert.IsTrue(keys.Contains("Gosho"));
        }
    }
}
