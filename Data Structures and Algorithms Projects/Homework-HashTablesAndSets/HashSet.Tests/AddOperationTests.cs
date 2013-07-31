namespace HashSet.Tests
{
    using System;
    using HashSet.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class AddOperationTests
    {
        [TestMethod]
        public void AddOneItemTest()
        {
            HashSet<string> names = new HashSet<string>();

            names.Add("Pesho");

            Assert.AreEqual(1, names.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullItemTest()
        {
            HashSet<string> names = new HashSet<string>();

            names.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddDuplicateItemTest()
        {
            HashSet<string> names = new HashSet<string>();

            names.Add("Pesho");
            names.Add("Pesho");
        }

        [TestMethod]
        public void AddMultipleItemsTest()
        {
            HashSet<string> names = new HashSet<string>(4);

            names.Add("Pesho");
            names.Add("Gosho");
            names.Add("Lili");
            names.Add("Robin");
            names.Add("Marin");

            Assert.AreEqual(5, names.Count);
        }

        [TestMethod]
        public void AddMultipleItemsWithConstructorTest()
        {
            System.Collections.Generic.IList<string> collection = new System.Collections.Generic.List<string>();
            collection.Add("Pesho");
            collection.Add("Gosho");
            collection.Add("Lili");
            collection.Add("Marin");

            HashSet<string> names = new HashSet<string>(collection);

            Assert.AreEqual(4, names.Count);
        }
    }
}
