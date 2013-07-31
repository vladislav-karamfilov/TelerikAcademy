namespace PriorityQueue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PriorityQueue.Common;

    [TestClass]
    public class EnqueueOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EnqueueNullElementTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();

            queue.Enqueue(null);
        }

        [TestMethod]
        public void EnqueueSingleElementTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();

            queue.Enqueue("Pesho");

            Assert.AreEqual(1, queue.Count);
        }

        [TestMethod]
        public void EnqueueTwoElementsTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();

            queue.Enqueue("Pesho");
            queue.Enqueue("Gosho");

            Assert.AreEqual(2, queue.Count);
        }

        [TestMethod]
        public void EnqueueFiftySameElementsTest()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();

            for (int i = 0; i < 50; i++)
            {
                queue.Enqueue("Pesho");
            }

            Assert.AreEqual(50, queue.Count);
        }

        [TestMethod]
        public void CorrectPriorityTest1()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();

            queue.Enqueue(-12);
            queue.Enqueue(512);
            queue.Enqueue(77);
            queue.Enqueue(-1);
            queue.Enqueue(82);
            queue.Enqueue(92);
            queue.Enqueue(-111);
            queue.Enqueue(-151);
            queue.Enqueue(512);
            queue.Enqueue(55);

            Assert.AreEqual(10, queue.Count);
            Assert.AreEqual(512, queue.Dequeue());
            Assert.AreEqual(512, queue.Dequeue());
            Assert.AreEqual(92, queue.Dequeue());
            Assert.AreEqual(82, queue.Dequeue());
            Assert.AreEqual(77, queue.Dequeue());
            Assert.AreEqual(55, queue.Dequeue());
            Assert.AreEqual(-1, queue.Dequeue());
            Assert.AreEqual(-12, queue.Dequeue());
            Assert.AreEqual(-111, queue.Dequeue());
            Assert.AreEqual(-151, queue.Dequeue());
        }

        [TestMethod]
        public void CorrectPriorityTest2()
        {
            PriorityQueue<int> queue = new PriorityQueue<int>();

            queue.Enqueue(4);
            queue.Enqueue(1);
            queue.Enqueue(3);
            queue.Enqueue(2);
            queue.Enqueue(16);
            queue.Enqueue(9);
            queue.Enqueue(10);
            queue.Enqueue(14);
            queue.Enqueue(8);
            queue.Enqueue(7);

            Assert.AreEqual(10, queue.Count);
            Assert.AreEqual(16, queue.Dequeue());
            Assert.AreEqual(14, queue.Dequeue());
            Assert.AreEqual(10, queue.Dequeue());
            Assert.AreEqual(9, queue.Dequeue());
            Assert.AreEqual(8, queue.Dequeue());
            Assert.AreEqual(7, queue.Dequeue());
            Assert.AreEqual(4, queue.Dequeue());
            Assert.AreEqual(3, queue.Dequeue());
            Assert.AreEqual(2, queue.Dequeue());
            Assert.AreEqual(1, queue.Dequeue());
        }
    }
}
