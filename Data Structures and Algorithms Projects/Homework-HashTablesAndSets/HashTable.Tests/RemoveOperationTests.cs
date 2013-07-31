namespace HashTable.Tests
{
    using System;
    using HashTable.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNullKeyElementTest()
        {
            HashTable<Point, int> pointsCounts = new HashTable<Point, int>();
            pointsCounts.Add(new Point(3, 2), 11);

            pointsCounts.Remove(null);
        }

        [TestMethod]
        public void RemoveOneAndOnlyElementTest()
        {
            HashTable<Point, int> pointsCounts = new HashTable<Point, int>();
            pointsCounts.Add(new Point(3, 2), 11);

            bool isRemoved = pointsCounts.Remove(new Point(3, 2));

            Assert.AreEqual(0, pointsCounts.Count);
            Assert.IsTrue(isRemoved);
        }

        [TestMethod]
        public void RemoveNonExistingElementTest()
        {
            HashTable<Point, int> pointsCounts = new HashTable<Point, int>();
            pointsCounts.Add(new Point(3, 2), 11);

            bool isRemoved = pointsCounts.Remove(new Point(3, 11));

            Assert.AreEqual(1, pointsCounts.Count);
            Assert.IsFalse(isRemoved);
        }

        [TestMethod]
        public void RemoveFromElementsTest()
        {
            HashTable<Point, int> pointsCounts = new HashTable<Point, int>();
            pointsCounts.Add(new Point(3, 2), 51);
            pointsCounts.Add(new Point(2, 2), 21);
            pointsCounts.Add(new Point(3, 3), 1);
            pointsCounts.Add(new Point(3, 11), 111);
            pointsCounts.Add(new Point(3, 15), 1);

            bool isRemoved = pointsCounts.Remove(new Point(3, 11));

            Assert.AreEqual(4, pointsCounts.Count);
            Assert.IsTrue(isRemoved);
        }
    }
}
