namespace BinarySearchTree;

public class TurboBinarySearchTree<T> where T : IComparable<T>
{
    private class Node
    {
        public T Value;
        public Node Right;
        public Node Left;

        public Node(T value)
        {
            Value = value;
            Right = null;
            Left = null;
        }
    }

    private Node root;

    public TurboBinarySearchTree()
    {
        root = null;
    }
    
    public void Insert(T value)
    {
        root = Insert(root, value);
    }

    private Node Insert(Node node, T value)
    {
        if (node == null)
        {
            return new Node(value);
        }

        int compare = value.CompareTo(node.Value);

        if (compare < 0)
        {
            node.Left = Insert(node.Left, value);
        }
        else if (compare > 0)
        {
            node.Right = Insert(node.Right, value);
        }

        return node;
    }

    public bool Search(T value)
    {
        
    }

    public bool Delete(T value)
    {
        
    }

    public IEnumerator<T> GetEnumerator()
    {
        
    }



}