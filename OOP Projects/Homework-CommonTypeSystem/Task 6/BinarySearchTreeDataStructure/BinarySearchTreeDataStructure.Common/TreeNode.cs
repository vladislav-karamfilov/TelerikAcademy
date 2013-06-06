using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTreeDataStructure.Common
{
    internal class TreeNode<TKey, TValue> : IComparable<TreeNode<TKey, TValue>>, IEnumerable<TreeNode<TKey, TValue>>
            where TKey : IComparable<TKey>
    {
        #region Instance fields
        // The key of the tree node
        internal TKey Key { get; set; }
        // The value of the tree node
        internal TValue Value { get; set; }
        // The parent of the current tree node
        internal TreeNode<TKey, TValue> Parent { get; set; }
        // The left child of the current tree node
        internal TreeNode<TKey, TValue> LeftChild { get; set; }
        // The right child of the current tree node
        internal TreeNode<TKey, TValue> RightChild { get; set; }
        #endregion

        #region Constructor
        internal TreeNode(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
            this.Parent = null;
            this.LeftChild = null;
            this.RightChild = null;
        }
        #endregion

        #region Public methods
        // Implementation of CompareTo() from IComparable interface
        public int CompareTo(TreeNode<TKey, TValue> other)
        {
            return this.Key.CompareTo(other.Key);
        }

        // Overriding the methods from Object class
        public override string ToString()
        {
            return string.Format("Key: {0} | Value: {1}", this.Key, this.Value);
        }
        public override int GetHashCode()
        {
            int primeNumber = 19;
            int hash = 11;
            // Using unchecked block to deal with overflow of type int
            unchecked
            {
                hash = hash * primeNumber + this.Key.GetHashCode();
            }
            return hash;
        }
        public override bool Equals(object other)
        {
            TreeNode<TKey, TValue> otherTreeNode = other as TreeNode<TKey, TValue>;
            if ((object)otherTreeNode == null) // The parameter object is not a tree node
            {
                return false;
            }
            return this.Key.CompareTo(otherTreeNode.Key) == 0;
        }
        // Overloading equality and inequality operators
        public static bool operator ==(TreeNode<TKey, TValue> first, TreeNode<TKey, TValue> second)
        {
            return TreeNode<TKey, TValue>.Equals(first, second);
        }
        public static bool operator !=(TreeNode<TKey, TValue> first, TreeNode<TKey, TValue> second)
        {
            return !TreeNode<TKey, TValue>.Equals(first, second);
        }

        // Implementing the methods from IEnumrable<TKey> to use them in BinarySearchTree class
        public IEnumerator<TreeNode<TKey, TValue>> GetEnumerator()
        {
            yield return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
