namespace HashSet.Tests
{
    using System;
    using HashSet.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ContainsOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContainsNullItemTest()
        {
            HashSet<string> names = new HashSet<string>();
            names.Add("Pesho");
            names.Add("Gosho");
            names.Add("Lili");
            names.Add("Ani");

            names.Contains(null);
        }

        [TestMethod]
        public void ContainsItemTest()
        {
            HashSet<int> years = new HashSet<int>();
            years.Add(1990);
            years.Add(1892);
            years.Add(2013);
            years.Add(2014);

            bool contains = years.Contains(2013);

            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void DoesNotContainItemTest()
        {
            HashSet<int> years = new HashSet<int>();
            years.Add(1990);
            years.Add(1892);
            years.Add(2013);
            years.Add(2014);

            bool contains = years.Contains(2022);

            Assert.IsFalse(contains);
        }
    }
}
