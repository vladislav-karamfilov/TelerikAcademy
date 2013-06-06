namespace LinkedList.Tests
{
    using System;
    using LinkedList.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IndexOfOperationTests
    {
        [TestMethod]
        public void IndexOfElementInEmptyListTest()
        {
            LinkedList<int> list = new LinkedList<int>();

            int index = list.IndexOf(0);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void IndexOfFirstAndOnlyElementTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(0);

            int index = list.IndexOf(0);

            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void IndexOfFirstElementOfMultipleTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(0);
            list.Add(15);
            list.Add(1);

            int index = list.IndexOf(0);

            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void IndexOfElementFromDuplicatesTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(15);
            list.Add(1);
            list.Add(0);
            list.Add(0);
            list.Add(1);
            list.Add(0);
            list.Add(144);

            int index = list.IndexOf(0);

            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void IndexOfLastElementOfMultipleTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(15);
            list.Add(1);
            list.Add(0);
            list.Add(0);
            list.Add(1);
            list.Add(0);
            list.Add(144);

            int index = list.IndexOf(144);

            Assert.AreEqual(6, index);
        }
    }
}
