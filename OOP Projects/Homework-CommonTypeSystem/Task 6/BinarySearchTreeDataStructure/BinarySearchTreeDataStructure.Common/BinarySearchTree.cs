using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeDataStructure.Common
{
    public struct BinarySearchTree<TKey, TValue> : ICloneable, IEnumerable<TKey>
        where TKey : IComparable<TKey>
    {
        #region Private instance field
        private TreeNode<TKey, TValue> root;
        #endregion

        #region Methods
        // Inserting an element to the tree
        public void Add(TKey key, TValue value)
        {
            if (key == null)
            {
                throw new ArgumentException("Cannot insert a node with a null key!");
            }
            if (value == null)
            {
                throw new ArgumentException("Cannot insert a node with a null value!");
            }
            this.root = Insert(key, value, null, this.root);
        }
        private TreeNode<TKey, TValue> Insert(TKey key, TValue value, TreeNode<TKey, TValue> parentNode, TreeNode<TKey, TValue> currentNode)
        {
            if (currentNode == null) // Current node is a leaf or empty tree
            {
                currentNode = new TreeNode<TKey, TValue>(key, value);
                currentNode.Parent = parentNode;
            }
            else
            {
                if (key.CompareTo(currentNode.Key) < 0) // New node's key is less than current node's key -> left subtree
                {
                    currentNode.LeftChild = Insert(key, value, currentNode, currentNode.LeftChild);
                }
                else if (key.CompareTo(currentNode.Key) > 0) // New node's key is greater than current node's key -> right subtree
                {
                    currentNode.RightChild = Insert(key, value, currentNode, currentNode.RightChild);
                }
                else // The new node's key is equal to the current node's key -> just updating the value
                {
                    currentNode.Value = value;
                }
            }
            return currentNode;
        }

        // Searching an element from the tree (this is binary search)
        private TreeNode<TKey, TValue> Search(TKey key)
        {
            TreeNode<TKey, TValue> currentNode = this.root;
            while (currentNode != null)
            {
                if (key.CompareTo(currentNode.Key) < 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (key.CompareTo(currentNode.Key) > 0)
                {
                    currentNode = currentNode.RightChild;
                }
                else
                {
                    break;
                }
            }
            return currentNode;
        }

        // Indexer that uses the search and add methods
        public TValue this[TKey key]
        {
            get
            {
                TreeNode<TKey, TValue> node = this.Search(key);
                if (node == null)
                {
                    throw new KeyNotFoundException();
                }
                return node.Value;
            }
            set
            {
                this.Add(key, value);
            }
        }

        // Deleting an element from the tree
        public void Remove(TKey key)
        {
            TreeNode<TKey, TValue> nodeToDelete = Search(key);
            if (nodeToDelete == null) // There's no such a node in the tree
            {
                return;
            }
            else
            {
                Remove(nodeToDelete);
            }
        }
        private void Remove(TreeNode<TKey, TValue> nodeToDelete)
        {
            // The node to be deleted has two children
            if (nodeToDelete.LeftChild != null && nodeToDelete.RightChild != null)
            {
                // The minimal node from the right subtree replaces the tree node to be deleted
                // (comes from the definition of binary search tree)
                TreeNode<TKey, TValue> replacementNode = nodeToDelete.RightChild;
                replacementNode = FindMinimalElement(replacementNode);
                nodeToDelete.Key = replacementNode.Key;
                nodeToDelete.Value = replacementNode.Value;
                nodeToDelete = replacementNode;
            }
            // The node to be deleted has at most 1 child
            TreeNode<TKey, TValue> tempNode = nodeToDelete.LeftChild != null ? nodeToDelete.LeftChild : nodeToDelete.RightChild;
            if (tempNode != null) // The node to be deleted has 1 child
            {
                tempNode.Parent = nodeToDelete.Parent;
                if (nodeToDelete.Parent == null) // The node is the root of the tree
                {
                    this.root = tempNode;
                }
                else // Replacing the node to be deleted with its child subtree
                {
                    if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                    {
                        nodeToDelete.Parent.LeftChild = tempNode;
                    }
                    else
                    {
                        nodeToDelete.Parent.RightChild = tempNode;
                    }
                }
            }
            else // The node to be deleted has no children
            {
                if (nodeToDelete.Parent == null) // The node to be deleted is the root
                {
                    this.root = null;
                }
                else // The element to be deleted is a leaf
                {
                    if (nodeToDelete.Parent.LeftChild == nodeToDelete)
                    {
                        nodeToDelete.Parent.LeftChild = null;
                    }
                    else
                    {
                        nodeToDelete.Parent.RightChild = null;
                    }
                }
            }
        }

        // Finding the minimal element from a tree
        private TreeNode<TKey, TValue> FindMinimalElement(TreeNode<TKey, TValue> node)
        {
            while (node.LeftChild != null)
            {
                node = node.LeftChild;
            }
            return node;
        }

        // Implementing Clone() from ICloneable interface
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        public BinarySearchTree<TKey, TValue> Clone()
        {
            BinarySearchTree<TKey, TValue> clonedTree = new BinarySearchTree<TKey, TValue>();
            clonedTree.Add(this.root.Key, this.root.Value);
            foreach (TreeNode<TKey, TValue> node in Traversal(this.root))
            {
                clonedTree.Add(node.Key, node.Value);
            }
            return clonedTree;
        }

        // Implementing GetEnumerator() from IEnumerable<T> interface 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        // Returning the key so we can use it with the defined indexer to get the value of the node
        public IEnumerator<TKey> GetEnumerator()
        {
            foreach (TreeNode<TKey, TValue> node in Traversal(this.root))
            {
                yield return node.Key;
            }
        }
        // Performing inorder tree traversal (left-root-right)
        private IEnumerable<TreeNode<TKey, TValue>> Traversal(TreeNode<TKey, TValue> node)
        {
            // Traversing the left subtree
            if (node.LeftChild != null)
            {
                foreach (TreeNode<TKey, TValue> currentNode in Traversal(node.LeftChild))
                {
                    yield return currentNode;
                }
            }

            // Traversing the root of the tree
            yield return node;

            // Traversing the right subtree
            if (node.RightChild != null)
            {
                foreach (TreeNode<TKey, TValue> currentNode in Traversal(node.RightChild))
                {
                    yield return currentNode;
                }
            }
        }

        // Overriding the methods from Object class and operators == and !=
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (TreeNode<TKey, TValue> node in Traversal(this.root))
            {
                result.AppendLine(node.ToString());
            }
            return result.ToString();
        }
        public override bool Equals(object other)
        {
            if (!(other is BinarySearchTree<TKey, TValue>))
            {
                return false;
            }

            BinarySearchTree<TKey, TValue> otherTree = (BinarySearchTree<TKey, TValue>)other;

            // Filling two lists of the keys in each tree
            List<TreeNode<TKey, TValue>> currentTreeNodes = new List<TreeNode<TKey, TValue>>();
            List<TreeNode<TKey, TValue>> otherTreeNodes = new List<TreeNode<TKey, TValue>>();
            foreach (TreeNode<TKey, TValue> node in Traversal(this.root))
            {
                currentTreeNodes.Add(node);
            }
            foreach (TreeNode<TKey, TValue> node in Traversal(otherTree.root))
            {
                otherTreeNodes.Add(node);
            }
            // Comparing the lenghts of the lists -> if not equal trees are not equal
            if (currentTreeNodes.Count != otherTreeNodes.Count)
            {
                return false;
            }
            // Comparing the key values in the trees
            int allNodesCount = currentTreeNodes.Count; // == otherTreeKeys.Count
            for (int index = 0; index < allNodesCount; index++)
            {
                if (!(currentTreeNodes[index].Equals(otherTreeNodes[index])))
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator ==(BinarySearchTree<TKey, TValue> first, BinarySearchTree<TKey, TValue> second)
        {
            return BinarySearchTree<TKey, TValue>.Equals(first, second);
        }
        public static bool operator !=(BinarySearchTree<TKey, TValue> first, BinarySearchTree<TKey, TValue> second)
        {
            return !BinarySearchTree<TKey, TValue>.Equals(first, second);
        }
        public override int GetHashCode()
        {
            int hash = 1;
            // Using "unchecked" to deal overflow of int type
            unchecked
            {
                foreach (TreeNode<TKey, TValue> node in Traversal(this.root))
                {
                    hash = 19 * node.GetHashCode();
                }
            }
            return hash;
        }
        #endregion
    }
}
