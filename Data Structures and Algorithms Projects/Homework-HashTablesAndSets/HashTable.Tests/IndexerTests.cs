namespace HashTable.Tests
{
    using System;
    using HashTable.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IndexerTests
    {
        [TestMethod]
        [ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
        public void GetNonExistingElementTest()
        {
            HashTable<int, char> alphabet = new HashTable<int, char>();
            alphabet.Add(1, 'A');
            alphabet.Add(2, 'B');
            alphabet.Add(3, 'C');

            char dLetter = alphabet[4];
        }

        [TestMethod]
        public void GetExistingElementTest()
        {
            HashTable<int, char> alphabet = new HashTable<int, char>();
            alphabet.Add(1, 'A');
            alphabet.Add(2, 'B');
            alphabet.Add(3, 'C');

            char bLetter = alphabet[2];

            Assert.AreEqual(3, alphabet.Count);
            Assert.AreEqual('B', bLetter);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
        public void SetNonExistingElementTest()
        {
            HashTable<int, char> alphabet = new HashTable<int, char>();
            alphabet.Add(1, 'A');
            alphabet.Add(2, 'B');
            alphabet.Add(3, 'C');

            alphabet[4] = 'D';
        }

        [TestMethod]
        public void SetExistingElementTest()
        {
            HashTable<int, char> alphabet = new HashTable<int, char>();
            alphabet.Add(1, 'A');
            alphabet.Add(2, 'B');
            alphabet.Add(3, 'C');

            alphabet[2] = 'b';

            Assert.AreEqual(3, alphabet.Count);
            Assert.AreEqual('b', alphabet[2]);
        }
    }
}
