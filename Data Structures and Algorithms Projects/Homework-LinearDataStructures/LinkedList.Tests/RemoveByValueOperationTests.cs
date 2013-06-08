namespace LinkedList.Tests
{
    using System;
    using LinkedList.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveByValueOperationTests
    {
        [TestMethod]
        public void RemoveFromEmptyListTest()
        {
            LinkedList<double> list = new LinkedList<double>();

            bool isRemoved = list.Remove(12.55);

            Assert.AreEqual(0, list.Count);
            Assert.IsFalse(isRemoved);
        }

        [TestMethod]
        public void RemoveOneAndOnlyElementTest()
        {
            LinkedList<double> list = new LinkedList<double>();
            list.Add(12.25);

            bool isRemoved = list.Remove(12.25);

            Assert.AreEqual(0, list.Count);
            Assert.IsTrue(isRemoved);
        }

        [TestMethod]
        public void RemoveFirstElementTest()
        {
            LinkedList<double> list = new LinkedList<double>();
            list.Add(12.25);
            list.Add(12.44);

            bool isRemoved = list.Remove(12.25);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(12.44, list.First);
            Assert.AreEqual(12.44, list.Last);
            Assert.IsTrue(isRemoved);
        }

        [TestMethod]
        public void RemoveMiddleElementTest()
        {
            LinkedList<double> list = new LinkedList<double>();
            list.Add(4.5);
            list.Add(5.5);
            list.Add(515.512);
            list.Add(515.577);
            list.Add(1551.2);
            list.Add(99.9);
            list.Add(1.1);

            bool isRemoved = list.Remove(515.577);

            Assert.AreEqual(6, list.Count);
            Assert.AreEqual(4.5, list.First);
            Assert.AreEqual(1.1, list.Last);
            Assert.IsTrue(isRemoved);
        }

        [TestMethod]
        public void RemoveLastElementTest()
        {
            LinkedList<double> list = new LinkedList<double>();
            list.Add(12.25);
            list.Add(12.44);

            bool isRemoved = list.Remove(12.44);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(12.25, list.First);
            Assert.AreEqual(12.25, list.Last);
            Assert.IsTrue(isRemoved);
        }

        [TestMethod]
        public void RemoveNonExistingElementTest()
        {
            LinkedList<double> list = new LinkedList<double>();
            list.Add(12.25);
            list.Add(12.44);

            bool isRemoved = list.Remove(12.55);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(12.25, list.First);
            Assert.AreEqual(12.44, list.Last);
            Assert.IsFalse(isRemoved);
        }
    }
}
