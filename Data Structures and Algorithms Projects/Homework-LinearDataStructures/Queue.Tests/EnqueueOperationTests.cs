namespace Queue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Queue.Common;

    [TestClass]
    public class EnqueueOperationTests
    {
        [TestMethod]
        public void EnqueueSingleElementTest()
        {
            Queue<string> queue = new Queue<string>();
            
            queue.Enqueue("Pesho");

            Assert.AreEqual(1, queue.Count);
        }

        [TestMethod]
        public void EnqueueTwoElementsTest()
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("Pesho");
            queue.Enqueue("Gosho");

            Assert.AreEqual(2, queue.Count);
        }

        [TestMethod]
        public void EnqueueFiftySameElementsTest()
        {
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < 50; i++)
            {
                queue.Enqueue("Pesho");                
            }

            Assert.AreEqual(50, queue.Count);
        }
    }
}
