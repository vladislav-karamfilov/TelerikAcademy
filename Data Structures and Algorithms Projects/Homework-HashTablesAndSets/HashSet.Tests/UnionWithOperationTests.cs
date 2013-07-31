namespace HashSet.Tests
{
    using System;
    using HashSet.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnionWithOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UnionWithNullTest()
        {
            HashSet<string> names = new HashSet<string>();
            names.Add("Pesho");
            names.Add("Gosho");

            names.UnionWith(null);
        }

        [TestMethod]
        public void UnionWithIListCollectionTest()
        {
            System.Collections.Generic.IList<string> namesToUnion =
                new System.Collections.Generic.List<string>()
            {
                "Marin", "Pesho", "Lili", "Robin"
            };
            HashSet<string> names = new HashSet<string>();
            names.Add("Pesho");
            names.Add("Gosho");

            names.UnionWith(namesToUnion);

            Assert.AreEqual(5, names.Count);
            Assert.IsTrue(names.Contains("Pesho"));
            Assert.IsTrue(names.Contains("Gosho"));
            Assert.IsTrue(names.Contains("Lili"));
            Assert.IsTrue(names.Contains("Marin"));
            Assert.IsTrue(names.Contains("Robin"));
        }

        [TestMethod]
        public void UnionWithIHashSetCollectionTest()
        {
            IHashSet<string> namesToUnion = new HashSet<string>()
            {
                "Marin", "Pesho", "Lili", "Robin"
            };
            HashSet<string> names = new HashSet<string>();
            names.Add("Pesho");
            names.Add("Gosho");

            names.UnionWith(namesToUnion);

            Assert.AreEqual(5, names.Count);
            Assert.IsTrue(names.Contains("Pesho"));
            Assert.IsTrue(names.Contains("Gosho"));
            Assert.IsTrue(names.Contains("Lili"));
            Assert.IsTrue(names.Contains("Marin"));
            Assert.IsTrue(names.Contains("Robin"));
        }
    }
}
