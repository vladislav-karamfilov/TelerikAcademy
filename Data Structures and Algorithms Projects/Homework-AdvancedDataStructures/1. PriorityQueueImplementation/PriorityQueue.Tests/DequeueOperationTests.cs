namespace PriorityQueue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PriorityQueue.Common;

    [TestClass]
    public class DequeueOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueFromEmptyPriorityQueueTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();

            queue.Peek();
        }

        [TestMethod]
        public void DequeueFirstAndOnlyElementTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();
            queue.Enqueue("Pesho");

            string dequeued = queue.Dequeue();

            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual("Pesho", dequeued);
        }

        [TestMethod]
        public void DequeueFromTwoElementsTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();
            queue.Enqueue("Pesho");
            queue.Enqueue("Gosho");

            string dequeued = queue.Dequeue();

            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual("Pesho", dequeued);
        }

        [TestMethod]
        public void DequeueFromMultipleElementsTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();
            queue.Enqueue("Gosho");
            queue.Enqueue("Lili");
            queue.Enqueue("Marin");
            queue.Enqueue("Mitko");
            queue.Enqueue("Pesho");
            queue.Enqueue("Elena");
            queue.Enqueue("Ivana");

            string dequeued = queue.Dequeue();

            Assert.AreEqual(6, queue.Count);
            Assert.AreEqual("Pesho", dequeued);
        }
    }
}
