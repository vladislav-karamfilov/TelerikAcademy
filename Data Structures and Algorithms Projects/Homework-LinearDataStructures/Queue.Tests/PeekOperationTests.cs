namespace Queue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Queue.Common;

    [TestClass]
    public class PeekOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromEmptyQueueTest()
        {
            Queue<string> queue = new Queue<string>();

            queue.Peek();
        }

        [TestMethod]
        public void PeekFirstAndOnlyElementTest()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Pesho");

            string peeked = queue.Peek();

            Assert.AreEqual(1, queue.Count);
            Assert.AreEqual("Pesho", peeked);
        }

        [TestMethod]
        public void PeekFromMultipleElementsTest()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Pesho");
            queue.Enqueue("Gosho");
            queue.Enqueue("Lili");
            queue.Enqueue("Marin");
            queue.Enqueue("Mitko");
            queue.Enqueue("Elena");
            queue.Enqueue("Ivana");

            string peeked = queue.Peek();

            Assert.AreEqual(7, queue.Count);
            Assert.AreEqual("Pesho", peeked);
        }
    }
}
