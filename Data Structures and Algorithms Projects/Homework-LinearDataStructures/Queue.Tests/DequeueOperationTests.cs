namespace Queue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Queue.Common;

    [TestClass]
    public class DequeueOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueFromEmptyQueueTest()
        {
            Queue<string> queue = new Queue<string>();

            queue.Peek();
        }

        [TestMethod]
        public void DequeueFirstAndOnlyElementTest()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Pesho");

            string dequeued = queue.Dequeue();

            Assert.AreEqual(0, queue.Count);
            Assert.AreEqual("Pesho", dequeued);
        }

        [TestMethod]
        public void DequeueFromTwoElementsTest()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Pesho");
            queue.Enqueue("Gosho");

            string dequeued = queue.Dequeue();

            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual("Pesho", dequeued);
        }

        [TestMethod]
        public void DequeueFromMultipleElementsTest()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Pesho");
            queue.Enqueue("Gosho");
            queue.Enqueue("Lili");
            queue.Enqueue("Marin");
            queue.Enqueue("Mitko");
            queue.Enqueue("Elena");
            queue.Enqueue("Ivana");

            string dequeued = queue.Dequeue();

            Assert.AreEqual(6, queue.Count);
            Assert.AreEqual("Pesho", dequeued);
        }
    }
}
