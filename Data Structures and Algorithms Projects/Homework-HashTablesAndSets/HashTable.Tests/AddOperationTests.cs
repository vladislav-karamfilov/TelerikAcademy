namespace HashTable.Tests
{
    using System;
    using HashTable.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class AddOperationTests
    {
        [TestMethod]
        public void AddOneElementTest()
        {
            HashTable<int, char> alphabet = new HashTable<int, char>();
            
            alphabet.Add(1, 'A');

            Assert.AreEqual(1, alphabet.Count);
            Assert.AreEqual('A', alphabet[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddDuplicateKeyElementsTest()
        {
            HashTable<int, char> alphabet = new HashTable<int, char>();

            alphabet.Add(1, 'A');
            alphabet.Add(1, 'a');
        }

        [TestMethod]
        public void AddMultipleElementsTest()
        {
            HashTable<int, char> alphabet = new HashTable<int, char>();

            alphabet.Add(1, 'A');
            alphabet.Add(2, 'B');
            alphabet.Add(26, 'Z');
            alphabet.Add(5, 'E');

            Assert.AreEqual(4, alphabet.Count);
            Assert.AreEqual('A', alphabet[1]);
            Assert.AreEqual('B', alphabet[2]);
            Assert.AreEqual('E', alphabet[5]);
            Assert.AreEqual('Z', alphabet[26]);
        }

        [TestMethod]
        public void AddMultipleElementsWithCollisionsTest()
        {
            HashTable<Point, int> pointsCounts = new HashTable<Point, int>(3);

            pointsCounts.Add(new Point(3, 2), 1);
            pointsCounts.Add(new Point(-3, 2), 1);
            pointsCounts.Add(new Point(3, -2), 1);
            pointsCounts.Add(new Point(2, 3), 1);
            pointsCounts.Add(new Point(-2, -3), 1);
            pointsCounts.Add(new Point(3, 1), 1);
            pointsCounts.Add(new Point(1, 2), 15);
            pointsCounts.Add(new Point(1, 22), 1);
            pointsCounts.Add(new Point(3, 222), 1);
            pointsCounts.Add(new Point(5, 2), 4);
            pointsCounts.Add(new Point(5, 12), 1);
            pointsCounts.Add(new Point(3, 5), 1);
            pointsCounts.Add(new Point(5, 3), 1);
            pointsCounts.Add(new Point(1, 1), 2);
            pointsCounts.Add(new Point(14, 1), 3);
            pointsCounts.Add(new Point(144, 1), 1);
            pointsCounts.Add(new Point(1, 14), 11);
            pointsCounts.Add(new Point(11, 14), 11);
            pointsCounts.Add(new Point(1, 114), 11);

            Assert.AreEqual(19, pointsCounts.Count);
            Assert.AreEqual(1, pointsCounts[new Point(3, 2)]);
            Assert.AreEqual(1, pointsCounts[new Point(-3, 2)]);
            Assert.AreEqual(1, pointsCounts[new Point(3, -2)]);
            Assert.AreEqual(1, pointsCounts[new Point(2, 3)]);
            Assert.AreEqual(1, pointsCounts[new Point(-2, -3)]);
            Assert.AreEqual(1, pointsCounts[new Point(3, 1)]);
            Assert.AreEqual(15, pointsCounts[new Point(1, 2)]);
            Assert.AreEqual(1, pointsCounts[new Point(1, 22)]);
            Assert.AreEqual(1, pointsCounts[new Point(3, 222)]);
            Assert.AreEqual(4, pointsCounts[new Point(5, 2)]);
            Assert.AreEqual(1, pointsCounts[new Point(5, 12)]);
            Assert.AreEqual(1, pointsCounts[new Point(3, 5)]);
            Assert.AreEqual(1, pointsCounts[new Point(5, 3)]);
            Assert.AreEqual(2, pointsCounts[new Point(1, 1)]);
            Assert.AreEqual(3, pointsCounts[new Point(14, 1)]);
            Assert.AreEqual(1, pointsCounts[new Point(144, 1)]);
            Assert.AreEqual(11, pointsCounts[new Point(1, 14)]);
            Assert.AreEqual(11, pointsCounts[new Point(11, 14)]);
            Assert.AreEqual(11, pointsCounts[new Point(1, 114)]);
        }
    }
}
