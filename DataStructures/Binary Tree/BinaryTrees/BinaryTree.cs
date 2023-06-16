namespace BinaryTrees;

public class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
{
    protected Node<T> _rootNode;

    public virtual void Add(T item)
    {
        if (_rootNode == null)
        {
            _rootNode = new Node<T>(item);
            return;
        }

        var queue = new Queue<Node<T>>();
        queue.Enqueue(_rootNode);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node.Left == null)
            {
                node.Left = new Node<T>(item);
                break;
            }
            else if (node.Right == null)
            {
                node.Right = new Node<T>(item);
                break;
            }
            else
            {
                queue.Enqueue(node.Left);
                queue.Enqueue(node.Right);
            }
        }
    }

    public virtual void Build(T[] items)
    {
        var queue = new Queue<Node<T>>();
        _rootNode = new Node<T>(items[0]);

        queue.Enqueue(_rootNode);

        for (int i = 1; i < items.Length; i++)
        {
            while (queue.Count > 0)
            {
                var currentNode = queue.Peek();

                if (currentNode.Left == null)
                {
                    currentNode.Left = new Node<T>(items[i]);
                    queue.Enqueue(currentNode.Left);
                    break;
                }
                else if (currentNode.Right == null)
                {
                    currentNode.Right = new Node<T>(items[i]);
                    queue.Enqueue(currentNode.Right);
                    break;
                }
                else
                {
                    queue.Dequeue();
                }
            }
        }
    }

    public virtual void Remove(T item)
    {
        var targetNode = FindNode(_rootNode, item);
        Remove(ref targetNode, item);
    }

    public void Display(TraverseMode mode)
    {
        Display(_rootNode, mode);
    }

    public void DisplayLeaves()
    {
        var leaves = GetLeaves(_rootNode);

        foreach (var leave in leaves)
        {
            Console.Write($" {leave.Data} ");
        }
    }

    public void DisplayHeight()
    {
        var height = GetHeight(_rootNode);
        Console.Write(height);
    }

    public void DisplayOuterLeaves()
    {
        var outerNodes = GetOuterNodes(_rootNode);

        foreach (var node in outerNodes)
        {
            Console.Write($" {node.Data} ");
        }
    }

    protected virtual Node<T> FindNode(Node<T> root, T item)
    {
        if (root == null) return null;

        if (root.Data.CompareTo(item) == 0)
        {
            return root;
        }

        return FindNode(root.Left, item) ?? FindNode(root.Right, item);
    }

    protected virtual void Display(Node<T> root, TraverseMode traverseMode)
    {
        if (root == null) return;

        switch (traverseMode)
        {
            case TraverseMode.PreOrder:
                {
                    Display(root.Left, traverseMode);
                    Console.Write($" {root.Data} ");
                    Display(root.Right, traverseMode);
                    break;
                }

            case TraverseMode.PostOrder:
                {
                    Display(root.Right, traverseMode);
                    Console.Write($" {root.Data} ");
                    Display(root.Left, traverseMode);
                    break;
                }

            case TraverseMode.InOrder:
                {
                    Console.Write($" {root.Data} ");
                    Display(root.Left, traverseMode);
                    Display(root.Right, traverseMode);
                    break;
                }

            case TraverseMode.BreadFirst:
                {
                    var queue = new Queue<Node<T>>();
                    queue.Enqueue(root);

                    while (queue.Count > 0)
                    {
                        var node = queue.Dequeue();
                        Console.Write($" {node.Data} ");

                        if (node.Left != null) queue.Enqueue(node.Left);
                        if (node.Right != null) queue.Enqueue(node.Right);
                    }

                    break;
                }
        }
    }

    protected virtual void Remove(ref Node<T> root, T item)
    {
        if (root == null) return;

        if (root.Left == null && root.Right == null)
        {
            root = null;
        }
        else if (root.Left == null)
        {
            root = root.Right;
        }
        else if (root.Right == null)
        {
            root = root.Left;
        }
        else
        {
            root.Data = root.Left.Data;
            Remove(ref root.Left, item);
        }
    }

    protected virtual List<Node<T>> GetLeaves(Node<T> rootNode)
    {
        if (rootNode == null) return null;

        var result = new List<Node<T>>();

        if (rootNode.Left == null && rootNode.Right == null)
        {
            result.Add(rootNode);
        }
        else
        {
            var leftTreeLeaves = GetLeaves(rootNode.Left);
            var rightTreeLeaves = GetLeaves(rootNode.Right);

            if(leftTreeLeaves!=null)
            result.AddRange(leftTreeLeaves);
            
            if(rightTreeLeaves!=null)
            result.AddRange(rightTreeLeaves);
        }

        return result;
    }

    protected virtual int GetHeight(Node<T> rootNode)
    {
        if (rootNode == null) return -1;

        var leftHeight = GetHeight(rootNode.Left) + 1;
        var rightHeight = GetHeight(rootNode.Right) + 1;

        return Math.Max(leftHeight, rightHeight);
    }

    protected virtual List<Node<T>> GetOuterNodes(Node<T> rootNode)
    {
        if (rootNode == null) return null;

        HashSet<Node<T>> nodes = new HashSet<Node<T>>
        {
            rootNode
        };

        var leftNode = rootNode.Left;

        while (leftNode != null)
        {
            nodes.Add(leftNode);
            leftNode = leftNode.Left;
        }

        var leafNodes = GetLeaves(rootNode);

        foreach (var leaf in leafNodes)
        {
            if(!nodes.Contains(leaf))
            {
                nodes.Add(leaf);
            }
        }

        var rightNode = rootNode.Right;
        while (rightNode != null)
        {
            if (!nodes.Contains(rightNode))
            {
                nodes.Add(rightNode);
            }

            rightNode = rightNode.Right;
        }

        return nodes.ToList();
    }
}
