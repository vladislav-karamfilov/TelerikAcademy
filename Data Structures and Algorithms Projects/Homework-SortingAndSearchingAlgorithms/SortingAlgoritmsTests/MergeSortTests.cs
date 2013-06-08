namespace SortingAlgoritmsTests
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;

    [TestClass]
    public class MergeSortTests
    {
        private static MergeSorter<int> sorter;

        [ClassInitialize]
        public static void InitilizeMergeSorter(TestContext context)
        {
            sorter = new MergeSorter<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortNullCollectionTest()
        {
            sorter.Sort(null);
        }

        [TestMethod]
        public void SortRandomCollectionTest()
        {
            IList<int> collection = 
                IntegerCollectionsProvider.GetRandomIntegers(1000);
            
            sorter.Sort(collection);

            Assert.IsTrue(IsSorted(collection));
        }

        [TestMethod]
        public void SortSortedCollectionTest()
        {
            IList<int> collection =
                IntegerCollectionsProvider.GetSortedIntegers(1000);

            sorter.Sort(collection);

            Assert.IsTrue(IsSorted(collection));
        }

        [TestMethod]
        public void SortReversedCollectionTest()
        {
            IList<int> collection =
                IntegerCollectionsProvider.GetReversedIntegers(1000);

            sorter.Sort(collection);

            Assert.IsTrue(IsSorted(collection));
        }

        private static bool IsSorted(IList<int> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                if (collection[i] > collection[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
