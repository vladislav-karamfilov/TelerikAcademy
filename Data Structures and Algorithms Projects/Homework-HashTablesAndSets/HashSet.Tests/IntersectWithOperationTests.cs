namespace HashSet.Tests
{
    using System;
    using HashSet.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntersectWithOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IntersectWithNullTest()
        {
            HashSet<string> names = new HashSet<string>();
            names.Add("Pesho");
            names.Add("Gosho");

            names.IntersectWith(null);
        }

        [TestMethod]
        public void IntersectWithIListCollectionTest()
        {
            System.Collections.Generic.IList<string> namesToIntersect =
                new System.Collections.Generic.List<string>()
            {
                "Marin", "Pesho", "Lili", "Robin"
            };
            HashSet<string> names = new HashSet<string>();
            names.Add("Pesho");
            names.Add("Gosho");

            names.IntersectWith(namesToIntersect);

            Assert.AreEqual(1, names.Count);
            Assert.IsTrue(names.Contains("Pesho"));
        }

        [TestMethod]
        public void IntersectWithIHashSetCollectionTest()
        {
            IHashSet<string> namesToIntersect = new HashSet<string>()
            {
                "Marin", "Pesho", "Lili", "Robin"
            };
            HashSet<string> names = new HashSet<string>();
            names.Add("Pesho");
            names.Add("Gosho");

            names.IntersectWith(namesToIntersect);

            Assert.AreEqual(1, names.Count);
            Assert.IsTrue(names.Contains("Pesho"));
        }
    }
}
