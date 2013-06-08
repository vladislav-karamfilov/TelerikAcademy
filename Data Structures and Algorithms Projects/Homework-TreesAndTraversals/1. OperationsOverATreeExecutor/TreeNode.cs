using System;
using System.Collections.Generic;

public class TreeNode<T>
{
    public TreeNode(T value)
    {
        this.Value = value;
        this.ChildNodes = new List<TreeNode<T>>();
        this.ParentNode = null;
    }

    public T Value { get; private set; }

    public IList<TreeNode<T>> ChildNodes { get; private set; }

    public TreeNode<int> ParentNode { get; set; }
}
