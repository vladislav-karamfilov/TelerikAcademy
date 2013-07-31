namespace PriorityQueue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PriorityQueue.Common;

    [TestClass]
    public class PeekOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromEmptyPriorityQueueTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();

            queue.Peek();
        }

        [TestMethod]
        public void PeekFirstAndOnlyElementTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();
            queue.Enqueue("Pesho");

            string peeked = queue.Peek();

            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual("Pesho", peeked);
        }

        [TestMethod]
        public void PeekFromMultipleElementsTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();
            queue.Enqueue("Gosho");
            queue.Enqueue("Lili");
            queue.Enqueue("Marin");
            queue.Enqueue("Mitko");
            queue.Enqueue("Pesho");
            queue.Enqueue("Elena");
            queue.Enqueue("Ivana");

            string peeked = queue.Peek();

            Assert.AreEqual(7, queue.Count);
            Assert.AreEqual("Pesho", peeked);
        }
    }
}
