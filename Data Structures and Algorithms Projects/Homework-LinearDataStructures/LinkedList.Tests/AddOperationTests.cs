namespace LinkedList.Tests
{
    using System;
    using LinkedList.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddOperationTests
    {
        [TestMethod]
        public void AddSingleElementTest()
        {
            LinkedList<string> list = new LinkedList<string>();
            
            list.Add("Pesho");

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("Pesho", list.First);
            Assert.AreEqual("Pesho", list.Last);
        }

        [TestMethod]
        public void AddTwoElementsTest()
        {
            LinkedList<string> list = new LinkedList<string>();

            list.Add("Pesho");
            list.Add("Gosho");

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual("Pesho", list.First);
            Assert.AreEqual("Gosho", list.Last);
        }

        [TestMethod]
        public void AddThreeElementsTest()
        {
            LinkedList<string> list = new LinkedList<string>();

            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Lili");

            Assert.AreEqual(3, list.Count);
            Assert.AreEqual("Pesho", list.First);
            Assert.AreEqual("Lili", list.Last);
        }

        [TestMethod]
        public void AddAHundredElementsTest()
        {
            LinkedList<string> list = new LinkedList<string>();

            for (int i = 1; i <= 100; i++)
            {
                list.Add("Number " + i);
            }

            Assert.AreEqual(100, list.Count);
            Assert.AreEqual("Number 1", list.First);
            Assert.AreEqual("Number 100", list.Last);
        }
    }
}
