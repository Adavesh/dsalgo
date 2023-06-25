namespace BinaryTrees;

public interface IBinaryTree<T>
{
    void Build(T[] items);
    void Display(TraverseMode mode);
    void DisplayLeaves();
    void DisplayOuterRing();
    void DisplayHeight();
    void Add(T item);
    void Remove(T item);
}