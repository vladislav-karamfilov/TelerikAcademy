namespace Stack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Stack.Common;

    [TestClass]
    public class PopOperationTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStackTest()
        {
            Stack<string> stack = new Stack<string>();

            stack.Pop();
        }

        [TestMethod]
        public void PopFirstAndOnlyElementTest()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("Hello!");

            string element = stack.Pop();

            Assert.AreEqual("Hello!", element);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void PopFromMultipleElementsStackTest()
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("Hello!");
            stack.Push("Two");
            stack.Push("Three");
            stack.Push("Eleven");
            stack.Push("Twenty");

            string element = stack.Pop();

            Assert.AreEqual("Twenty", element);
            Assert.AreEqual(4, stack.Count);
        }
    }
}
