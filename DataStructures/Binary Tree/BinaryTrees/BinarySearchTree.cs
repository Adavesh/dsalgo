namespace BinaryTrees;

public class BinarySearchTree<T> : BinaryTree<T> where T:IComparable<T>
{
    public override void Add(T item)
    {
        Add(ref _rootNode, item);
    }

    private void Add(ref Node<T> root, T item)
    {
        if(root == null)
        {
            root = new Node<T>(item);
            return;
        }

        if(root.Data.CompareTo(item) > 0)
        {
            Add(ref root.Left, item);
        }
        else
        {
            Add(ref root.Right, item);
        }
    }

    public override void Build(T[] items)
    {
        foreach(T item in items)
        {
            Add(item);
        }
    }
}
