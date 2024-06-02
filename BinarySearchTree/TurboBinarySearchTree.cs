using System;
using System.Collections;
using System.Collections.Generic;

public class TurboBinarySearchTree<T> : IEnumerable where T : IComparable<T>
{
    private class Node
    {
        public T Value;
        public Node Left;
        public Node Right;

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
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
            return new Node(value);

        int compare = value.CompareTo(node.Value);

        if (compare < 0)
            node.Left = Insert(node.Left, value);
        else if (compare > 0)
            node.Right = Insert(node.Right, value);
        return node;
    }

    public bool Search(T value)
    {
        return Search(root, value) != null;
    }

    private Node Search(Node node, T value)
    {
        if (node == null)
            return null;

        int compare = value.CompareTo(node.Value);

        if (compare < 0)
            return Search(node.Left, value);
        else if (compare > 0)
            return Search(node.Right, value);
        else
            return node;
    }

    public bool Delete(T value)
    {
        bool found;
        (root, found) = Delete(root, value);
        return found;
    }

    private (Node, bool) Delete(Node node, T value)
    {
        if (node == null)
            return (null, false);

        int compare = value.CompareTo(node.Value);

        if (compare < 0)
        {
            (node.Left, var found) = Delete(node.Left, value);
            return (node, found);
        }
        else if (compare > 0)
        {
            (node.Right, var found) = Delete(node.Right, value);
            return (node, found);
        }
        else
        {
            if (node.Left == null)
                return (node.Right, true);
            else if (node.Right == null)
                return (node.Left, true);

            Node minNode = FindMin(node.Right);
            node.Value = minNode.Value;
            (node.Right, _) = Delete(node.Right, minNode.Value);
            return (node, true);
        }
    }

    private Node FindMin(Node node)
    {
        while (node.Left != null)
            node = node.Left;
        return node;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return InOrderTraversal(root).GetEnumerator();
    }

    private IEnumerable<T> InOrderTraversal(Node node)
    {
        if (node != null)
        {
            foreach (var value in InOrderTraversal(node.Left))
                yield return value;

            yield return node.Value;

            foreach (var value in InOrderTraversal(node.Right))
                yield return value;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}