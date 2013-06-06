using System;
using System.Collections.Generic;
using System.Linq;

public class OperationsOverATreeExecutor
{
    internal static void Main()
    {
        string decorationLine = new string('-', Console.WindowWidth);
        Console.Write(decorationLine);
        Console.WriteLine("***Constructing a tree from pairs of parent node and child node from 0 to N - 1");
        Console.WriteLine("and finding: the root, the leaf nodes, the middle nodes, the longest path, all");
        Console.WriteLine("paths with a given sum S of the nodes, all subtrees with given sum S");
        Console.WriteLine("of their nodes***");
        Console.Write(decorationLine);

        Console.Write("Enter how many nodes the tree has: ");
        int treeNodesCount = int.Parse(Console.ReadLine());

        TreeNode<int>[] tree = GetInputTree(treeNodesCount);

        // a) The root node of the tree
        Console.WriteLine();
        TreeNode<int> root = GetRoot(tree);
        Console.WriteLine("The root of the tree is: {0}", root.Value);

        // b) All leaf nodes of the tree
        Console.WriteLine();
        IEnumerable<TreeNode<int>> leafNodes = GetLeafNodes(tree);
        Console.Write("All the leaf nodes of the tree are: ");
        PrintNodesToConsole(leafNodes);

        // c) All middle nodes of the tree
        Console.WriteLine();
        IEnumerable<TreeNode<int>> middleNodes = GetMiddleNodes(tree);
        Console.Write("All the middle nodes of the tree are: ");
        PrintNodesToConsole(middleNodes);

        // d) The longest path in the tree
        Console.WriteLine();
        IEnumerable<TreeNode<int>> longestPath = GetLongestPath(root);
        Console.Write("The longest path from the root is: ");
        PrintNodesToConsole(longestPath);

        // e)* All paths with given sum S of their nodes
        Console.WriteLine();
        Console.Write("Enter sum S to find all paths with it: ");
        long sumOfPath = long.Parse(Console.ReadLine());
        IEnumerable<IEnumerable<TreeNode<int>>> allPathsWithSumS = GetAllPathsWithSum(tree, sumOfPath);
        Console.WriteLine("All paths with sum {0} are:", sumOfPath);
        foreach (var path in allPathsWithSumS)
        {
            PrintNodesToConsole(path);
        }

        // f)* All subtrees with given sum S of their nodes
        Console.WriteLine();
        Console.Write("Enter sum S to find all subtrees with it: ");
        long sumOfSubtree = long.Parse(Console.ReadLine());
        IEnumerable<IEnumerable<TreeNode<int>>> allSubtreesWithSumS = GetAllSubtreesWithSum(tree, sumOfSubtree);
        Console.WriteLine("All subtrees with sum {0} are:", sumOfSubtree);
        foreach (var path in allSubtreesWithSumS)
        {
            PrintNodesToConsole(path);
        }
    }

    private static IEnumerable<IEnumerable<TreeNode<int>>> GetAllSubtreesWithSum(TreeNode<int>[] tree, long sumOfSubtree)
    {
        IList<HashSet<TreeNode<int>>> subtreesWithSumS = new List<HashSet<TreeNode<int>>>();
        foreach (var node in tree)
        {
            if (node.Value == sumOfSubtree)
            {
                subtreesWithSumS.Add(new HashSet<TreeNode<int>>(new TreeNode<int>[] { node }));
            }
            else
            {
                if (node.ChildNodes.Count > 0)
                {
                    long subtreeSum = 0;
                    HashSet<TreeNode<int>> currentSubtree = new HashSet<TreeNode<int>>();
                    GetCurrentSubtreeSum(node, currentSubtree, ref subtreeSum);
                    if (subtreeSum == sumOfSubtree)
                    {
                        subtreesWithSumS.Add(currentSubtree);
                    }
                }
            }
        }

        return subtreesWithSumS;
    }

    private static void GetCurrentSubtreeSum(TreeNode<int> root, HashSet<TreeNode<int>> currentSubtree, ref long subtreeSum)
    {
        currentSubtree.Add(root);
        subtreeSum += root.Value;
        foreach (var childNode in root.ChildNodes)
        {
            GetCurrentSubtreeSum(childNode, currentSubtree, ref subtreeSum);
        }
    }

    private static IEnumerable<IEnumerable<TreeNode<int>>> GetAllPathsWithSum(TreeNode<int>[] tree, long sum)
    {
        IList<Stack<TreeNode<int>>> paths = new List<Stack<TreeNode<int>>>();
        foreach (var node in tree)
        {
            Stack<TreeNode<int>> currentPath = new Stack<TreeNode<int>>();
            GetPathWithSum(node, currentPath, paths, node.Value, sum);
        }

        return paths;
    }

    private static void GetPathWithSum(
        TreeNode<int> root,
        Stack<TreeNode<int>> currentPath,
        IList<Stack<TreeNode<int>>> paths,
        long currentSum,
        long sum)
    {
        if (!currentPath.Contains(root))
        {
            currentPath.Push(root);
            if (currentSum == sum && currentPath.Count > 1)
            {
                paths.Add(new Stack<TreeNode<int>>(currentPath));
            }

            if (root.ParentNode != null)
            {
                currentSum += root.ParentNode.Value;
                GetPathWithSum(root.ParentNode, currentPath, paths, currentSum, sum);
            }

            foreach (TreeNode<int> childNode in root.ChildNodes)
            {
                currentSum += childNode.Value;
                GetPathWithSum(childNode, currentPath, paths, currentSum, sum);
            }

            currentPath.Pop();
        }
    }

    // The longest path in a tree consists of the two longest paths from its root
    private static IEnumerable<TreeNode<int>> GetLongestPath(TreeNode<int> root)
    {
        IList<Stack<TreeNode<int>>> pathsFromRoot = new List<Stack<TreeNode<int>>>();
        foreach (TreeNode<int> childNode in root.ChildNodes)
        {
            Stack<TreeNode<int>> currentPath = new Stack<TreeNode<int>>();
            GetPath(childNode, currentPath, pathsFromRoot);
        }

        List<TreeNode<int>> longestPathNodes = DefineLongestPath(root, pathsFromRoot);
        return longestPathNodes;
    }

    private static List<TreeNode<int>> DefineLongestPath(
        TreeNode<int> root,
        IList<Stack<TreeNode<int>>> pathsFromRoot)
    {
        List<TreeNode<int>> longestPathNodes = new List<TreeNode<int>>();
        var orderedPathsFromRoot = pathsFromRoot.OrderByDescending(a => a.Count);
        var firstLongestPath = orderedPathsFromRoot.First().Reverse();
        longestPathNodes.AddRange(firstLongestPath);
        longestPathNodes.Add(root);
        IEnumerable<TreeNode<int>> secondLongestPath = null;
        int step = 0;
        do
        {
            step++;
            secondLongestPath = orderedPathsFromRoot.Skip(step).First();
        }
        while (AreIntersectedPaths(firstLongestPath, secondLongestPath));

        longestPathNodes.AddRange(secondLongestPath);
        return longestPathNodes;
    }

    private static bool AreIntersectedPaths(
        IEnumerable<TreeNode<int>> firstPath,
        IEnumerable<TreeNode<int>> secondPath)
    {
        foreach (var node1 in secondPath)
        {
            foreach (var node2 in firstPath)
            {
                if (node1.Value == node2.Value)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static void GetPath(
        TreeNode<int> root,
        Stack<TreeNode<int>> currentPath,
        IList<Stack<TreeNode<int>>> pathsFromRoot)
    {
        currentPath.Push(root);
        if (root.ChildNodes.Count == 0)
        {
            pathsFromRoot.Add(new Stack<TreeNode<int>>(currentPath));
        }
        else
        {
            foreach (TreeNode<int> childNode in root.ChildNodes)
            {
                GetPath(childNode, currentPath, pathsFromRoot);
            }
        }

        currentPath.Pop();
    }

    private static IEnumerable<TreeNode<int>> GetMiddleNodes(TreeNode<int>[] tree)
    {
        IList<TreeNode<int>> middleNodes = new List<TreeNode<int>>();
        foreach (TreeNode<int> node in tree)
        {
            if (node.ParentNode != null && node.ChildNodes.Count > 0)
            {
                middleNodes.Add(node);
            }
        }

        return middleNodes;
    }

    private static IEnumerable<TreeNode<int>> GetLeafNodes(TreeNode<int>[] tree)
    {
        IList<TreeNode<int>> leafNodes = new List<TreeNode<int>>();
        foreach (TreeNode<int> node in tree)
        {
            if (node.ChildNodes.Count == 0)
            {
                leafNodes.Add(node);
            }
        }

        return leafNodes;
    }

    private static TreeNode<int> GetRoot(TreeNode<int>[] tree)
    {
        foreach (TreeNode<int> node in tree)
        {
            if (node.ParentNode == null)
            {
                return node;
            }
        }

        throw new ArgumentException("The provided tree has no root!", "tree");
    }

    private static TreeNode<int>[] GetInputTree(int treeNodesCount)
    {
        TreeNode<int>[] tree = new TreeNode<int>[treeNodesCount];
        // Initialize the tree
        for (int i = 0; i < treeNodesCount; i++)
        {
            tree[i] = new TreeNode<int>(i);
        }

        for (int i = 0; i < treeNodesCount - 1; i++)
        {
            Console.Write("Enter a parent-child pair separated by a space: ");
            string parentChildPair = Console.ReadLine();
            string[] parentAndChildStrings = parentChildPair.Split(' ');

            if (parentAndChildStrings.Length != 2)
            {
                throw new InvalidOperationException(
                    "Input must consist of a parent node value and " +
                    "child node value separated by a single space!");
            }

            int parentNodeValue = int.Parse(parentAndChildStrings[0]);
            int childNodeValue = int.Parse(parentAndChildStrings[1]);

            if (parentNodeValue < 0 || parentNodeValue >= treeNodesCount)
            {
                throw new ArgumentException(
                    "Cannot have parent node value less than 0 and more than N - 1!");
            }

            if (childNodeValue < 0 || childNodeValue >= treeNodesCount)
            {
                throw new ArgumentException(
                    "Cannot have child node value less than 0 and more than N - 1!");
            }

            if (parentNodeValue == childNodeValue)
            {
                throw new ArgumentException(
                    "Cannot have parent node value equal to its child node value in a tree!");
            }

            tree[parentNodeValue].ChildNodes.Add(tree[childNodeValue]);
            tree[childNodeValue].ParentNode = tree[parentNodeValue];
        }

        return tree;
    }

    private static void PrintNodesToConsole(IEnumerable<TreeNode<int>> nodes)
    {
        foreach (TreeNode<int> node in nodes)
        {
            Console.Write("{0} ", node.Value);
        }

        Console.WriteLine();
    }
}