namespace HashSet.Tests
{
    using System;
    using HashSet.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveOperationTests
    {
        [TestMethod]
        public void RemoveOneAndOnlyItemTest()
        {
            HashSet<string> names = new HashSet<string>();
            names.Add("Pesho");

            bool isRemoved = names.Remove("Pesho");

            Assert.IsTrue(isRemoved);
            Assert.AreEqual(0, names.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RemoveNullItemTest()
        {
            HashSet<string> names = new HashSet<string>();
            names.Add("Pesho");

            names.Remove(null);
        }

        [TestMethod]
        public void RemoveFromMultipleItemsTest()
        {
            HashSet<string> names = new HashSet<string>(4);
            names.Add("Pesho");
            names.Add("Gosho");
            names.Add("Lili");
            names.Add("Robin");
            names.Add("Marin");

            bool isRemoved = names.Remove("Robin");

            Assert.IsTrue(isRemoved);
            Assert.AreEqual(4, names.Count);
        }

        [TestMethod]
        public void RemoveNonExistingItemTest()
        {
            HashSet<string> names = new HashSet<string>();
            names.Add("Pesho");
            names.Add("Gosho");
            names.Add("Lili");
            names.Add("Marin");

            bool isRemoved = names.Remove("Marshal");

            Assert.IsFalse(isRemoved);
            Assert.AreEqual(4, names.Count);
        }
    }
}
