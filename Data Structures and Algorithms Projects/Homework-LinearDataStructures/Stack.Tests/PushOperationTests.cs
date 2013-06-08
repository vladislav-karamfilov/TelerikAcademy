namespace Stack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Stack.Common;

    [TestClass]
    public class PushOperationTests
    {
        [TestMethod]
        public void PushOneElementTest()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(55);

            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void PushTwoElementsTest()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(55);
            stack.Push(1);

            Assert.AreEqual(2, stack.Count);
        }

        [TestMethod]
        public void PushExactlyCapacityCountElementsTest()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(55);
            stack.Push(1);
            stack.Push(111);
            stack.Push(11);

            Assert.AreEqual(4, stack.Count);
        }

        [TestMethod]
        public void PushFiftySameElementsTest()
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 50; i++)
            {
                stack.Push(55);
            }

            Assert.AreEqual(50, stack.Count);
        }
    }
}
