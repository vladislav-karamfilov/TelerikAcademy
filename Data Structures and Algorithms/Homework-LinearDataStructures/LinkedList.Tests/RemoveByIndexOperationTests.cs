namespace LinkedList.Tests
{
    using System;
    using LinkedList.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveByIndexOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InvalidIndexRemoveTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(4);
            list.Add(14);
            list.Add(666);

            bool isRemoved = list.RemoveAt(5);
        }

        [TestMethod]
        public void RemoveOneAndOnlyElementTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(4);
            
            bool isRemoved = list.RemoveAt(0);

            Assert.IsTrue(isRemoved);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void RemoveFirstFromTwoElementsTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(4);
            list.Add(55);
            
            bool isRemoved = list.RemoveAt(0);

            Assert.IsTrue(isRemoved);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(55, list.First);
            Assert.AreEqual(55, list.Last);
        }

        [TestMethod]
        public void RemoveFirstFromMultipleElementsTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(666);
            list.Add(1561);
            list.Add(6151);
            list.Add(4);
            list.Add(55);

            bool isRemoved = list.RemoveAt(0);

            Assert.IsTrue(isRemoved);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(1561, list.First);
            Assert.AreEqual(55, list.Last);
        }

        [TestMethod]
        public void RemoveLastFromTwoElementsTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(666);
            list.Add(55);

            bool isRemoved = list.RemoveAt(list.Count - 1);

            Assert.IsTrue(isRemoved);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(666, list.First);
            Assert.AreEqual(666, list.Last);
        }

        [TestMethod]
        public void RemoveLastFromMultipleElementsTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(666);
            list.Add(1561);
            list.Add(6151);
            list.Add(4);
            list.Add(55);

            bool isRemoved = list.RemoveAt(list.Count - 1);

            Assert.IsTrue(isRemoved);
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(666, list.First);
            Assert.AreEqual(4, list.Last);
        }
    }
}
