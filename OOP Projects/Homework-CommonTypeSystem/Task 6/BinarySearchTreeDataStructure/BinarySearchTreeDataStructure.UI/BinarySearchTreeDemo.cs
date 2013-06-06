using System;
using BinarySearchTreeDataStructure.Common;

namespace BinarySearchTreeDataStructure.UI
{
    class BinarySearchTreeDemo
    {
        static void Main()
        {
            string decorationLine = new string('-', 80);
            Console.Write(decorationLine);
            Console.WriteLine("***Presenting the functionality of a binary search tree***");
            Console.Write(decorationLine);

            // Defining two binary search trees
            BinarySearchTree<int, string> firstTree = new BinarySearchTree<int, string>();
            BinarySearchTree<char, byte> secondTree = new BinarySearchTree<char, byte>();

            // Testing the operation "adding new element"
            firstTree.Add(19, "nineteen");
            firstTree.Add(11, "eleven");
            firstTree.Add(35, "three-five");
            firstTree.Add(7, "seven");
            firstTree.Add(16, "sixteen");
            firstTree.Add(23, "two-tree");
            firstTree.Add(13, "thirteen");
            firstTree.Add(17, "seventeen");
            firstTree.Add(6, "six");

            secondTree.Add('o', 222);
            secondTree.Add('a', 5);
            secondTree.Add('t', 211);
            secondTree.Add('p', 12);
            secondTree.Add('e', 77);

            // Printing the trees on the console
            Console.WriteLine("---The first binary search tree---");
            Console.WriteLine(firstTree);
            Console.WriteLine("---The second binary search tree---");
            Console.WriteLine(secondTree);

            // Testing the operation "searching new element" (used in the indexer of the class)
            Console.WriteLine("---Testing searching an element from a binary search tree---");
            Console.WriteLine("From first tree the value of the key '{0}' is '{1}'", 16, firstTree[16]);
            Console.WriteLine("From second tree the value of the key '{0}' is '{1}'", 'o', secondTree['o']);
            Console.WriteLine();

            // Testing the operation "deleting element"
            Console.WriteLine("---Testing deleting an element from a binary search tree---");
            firstTree.Remove(7);
            Console.WriteLine("After removing the node with key '{0}' the first tree is:\n{1}", 7, firstTree);
            secondTree.Remove('p');
            Console.WriteLine("After removing the node with key '{0}' the second tree is:\n{1}", 'p', secondTree);
            
            // Testing the method GetHashCode
            Console.WriteLine("---Testing the method GetHashCode---");
            Console.WriteLine("The hash code of the first tree is: " + firstTree.GetHashCode());
            Console.WriteLine("The hash code of the second tree is: " + secondTree.GetHashCode());
            Console.WriteLine();

            // Testing the implementation of IEnumerable methods -> foreach uses IEnumerable
            Console.WriteLine("---Testing the implementation of the IEnumerable interface---");
            foreach (int key in firstTree)
            {
                if (key % 2 == 0)
                {
                    Console.WriteLine("The key of the value '{0}' is even.", firstTree[key]);
                }
                else
                {
                    Console.WriteLine("The key of the value '{0}' is odd.", firstTree[key]);
                }
            }
            Console.WriteLine();

            // Testing the Clone method from the interface 'ICloneable'
            Console.WriteLine("---Testing the implementation of the ICloneable interface---");
            BinarySearchTree<char, byte> secondTreeClone = secondTree.Clone();
            secondTreeClone.Add('r', 2);
            Console.WriteLine("After adding node with key '{0}' and value '{1}' to the second tree clone it is:", 'r', 2);
            Console.WriteLine(secondTreeClone);

            // Testing the method Equals which is used in the operators '==' and '!='
            Console.WriteLine("---Testing Equals method which is used in '==' and '!=' operators---");
            Console.WriteLine("The clone of the second tree is equal to the second tree? " + secondTreeClone.Equals(secondTree));
        }
    }
}
