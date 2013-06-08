namespace LinkedList.Tests
{
    using System;
    using LinkedList.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IndexerTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InvalidGetTest()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Lili");

            string invalidName = list[4];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InvalidSetTest()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Lili");

            list[4] = "Robin";
        }

        [TestMethod]
        public void GetOneAndOnlyElementTest()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Pesho");

            Assert.AreEqual("Pesho", list[0]);
        }

        [TestMethod]
        public void SetOneAndOnlyElementTest()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Pesho");

            list[0] = "Gosho";

            Assert.AreEqual("Gosho", list[0]);
        }

        [TestMethod]
        public void GetFirstFromMultipleElementsTest()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Lili");
            list.Add("Robin");

            Assert.AreEqual("Pesho", list[0]);
        }

        [TestMethod]
        public void SetFirstFromMultipleElementsTest()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Lili");
            list.Add("Robin");

            list[0] = "Ivan";

            Assert.AreEqual("Ivan", list[0]);
        }

        [TestMethod]
        public void GetLastFromMultipleElementsTest()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Lili");
            list.Add("Robin");

            Assert.AreEqual("Robin", list[list.Count - 1]);
        }

        [TestMethod]
        public void SetLastFromMultipleElementsTest()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Lili");
            list.Add("Robin");

            list[list.Count - 1] = "Ivan";

            Assert.AreEqual("Ivan", list[list.Count - 1]);
        }

        [TestMethod]
        public void GetMiddleElementTest()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Robin");

            Assert.AreEqual("Gosho", list[list.Count / 2]);    
        }

        [TestMethod]
        public void SetMiddleElementTest()
        {
            LinkedList<string> list = new LinkedList<string>();
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Robin");

            list[list.Count / 2] = "Ivan";

            Assert.AreEqual("Ivan", list[list.Count / 2]);    
        }
    }
}
