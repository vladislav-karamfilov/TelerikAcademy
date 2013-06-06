namespace Stack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Stack.Common;

    [TestClass]
    public class PeekOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromEmptyStackTest()
        {
            Stack<string> stack = new Stack<string>();

            stack.Peek();
        }

        [TestMethod]
        public void PeekFirstAndOnlyElementTest()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("Hello!");

            string element = stack.Peek();

            Assert.AreEqual("Hello!", element);
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]
        public void PeekFromMultipleElementsStackTest()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("Hello!");
            stack.Push("Two");
            stack.Push("Three");
            stack.Push("Eleven");
            stack.Push("Twenty");

            string element = stack.Peek();

            Assert.AreEqual("Twenty", element);
            Assert.AreEqual(5, stack.Count);
        }
    }
}
