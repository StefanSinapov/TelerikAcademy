using System;
using System.Collections.Generic;

public class TreeNode<T>
{
    private T value;
    private bool hasParent;
    private List<TreeNode<T>> children;

    public TreeNode(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(
                "Cannot insert null value!");
        }
        this.Value = value;
        this.children = new List<TreeNode<T>>();
    }

    public T Value
    {
        get
        {
            return this.value;
        }
        set
        {
            this.value = value;
        }
    }

    public int ChildrenCount
    {
        get
        {
            return this.children.Count;
        }
    }

    public void AddChild(TreeNode<T> child)
    {
        if (child == null)
        {
            throw new ArgumentNullException(
                "Cannot insert null value!");
        }

        if (child.hasParent)
        {
            throw new ArgumentException(
                "The node already has a parent!");
        }

        child.hasParent = true;
        this.children.Add(child);
    }

    public TreeNode<T> GetChild(int index)
    {
        return this.children[index];
    }
}

public class Tree<T>
{
    private TreeNode<T> root;

    public Tree(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(
                "Cannot insert null value!");
        }

        this.Root = new TreeNode<T>(value);
    }

    public Tree(T value, params Tree<T>[] children) : this(value)
    {
        foreach (Tree<T> child in children)
        {
            this.root.AddChild(child.root);
        }
    }

    /// <summary>
    /// The root node or null if the tree is empty
    /// </summary>
    public TreeNode<T> Root
    {
        get
        {
            return this.root;
        }
        private set
        {
            this.root = value;
        }
    }

    private void TraverseDFS(TreeNode<T> root, string spaces)
    {
        if (root == null)
        {
            return;
        }

        Console.WriteLine(spaces + root.Value);

        TreeNode<T> child = null;
        for (int i = 0; i < root.ChildrenCount; i++)
        {
            child = root.GetChild(i);
            this.TraverseDFS(child, spaces + "   ");
        }
    }

    public void TraverseDFS()
    {
        this.TraverseDFS(this.root, string.Empty);
    }

    public void TraverseBFS()
    {
        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
        queue.Enqueue(this.root);
        while (queue.Count > 0)
        {
            TreeNode<T> currentNode = queue.Dequeue();
            Console.Write("{0} ", currentNode.Value);
            for (int i = 0; i < currentNode.ChildrenCount; i++)
            {
                TreeNode<T> childNode = currentNode.GetChild(i);
                queue.Enqueue(childNode);
            }
        }
    }

    public void TraverseDFSWithStack()
    {
        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
        stack.Push(this.root);
        while (stack.Count > 0)
        {
            TreeNode<T> currentNode = stack.Pop();
            Console.Write("{0} ", currentNode.Value);
            for (int i = 0; i < currentNode.ChildrenCount; i++)
            {
                TreeNode<T> childNode = currentNode.GetChild(i);
                stack.Push(childNode);
            }
        }
    }
}

public static class TreeExample
{
    static void Main()
    {
        Tree<int> tree =
        new Tree<int>(7,
                      new Tree<int>(19,
                                    new Tree<int>(1),
                                    new Tree<int>(12),
                                    new Tree<int>(31)),
                      new Tree<int>(21),
                      new Tree<int>(14,
                                    new Tree<int>(23),
                                    new Tree<int>(6)));

        Console.WriteLine("Depth-First Search (DFS) traversal (recursive):");
        tree.TraverseDFS();
        Console.WriteLine();

        Console.WriteLine("Breadth-First Search (BFS) traversal (with queue):");
        tree.TraverseBFS();
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("Depth-First Search (DFS) traversal (with stack):");
        tree.TraverseDFSWithStack();
        Console.WriteLine();
    }
}
