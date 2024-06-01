using System.Collections;

public class TurboBinarySearchTree<T> where T : IComparable<T>
{
    private class TreeNode
    {
        public T Value;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    private TreeNode root;

    public TurboBinarySearchTree()
    {
        root = null;
    }

    public void Insert(T value)
    {
        root = Insert(root, value);
    }

    private TreeNode Insert(TreeNode node, T value)
    {
        if (node == null)
        {
            return new TreeNode(value);
        }

        int comparison = value.CompareTo(node.Value);
        if (comparison < 0)
        {
            node.Left = Insert(node.Left, value);
        }
        else if (comparison > 0)
        {
            node.Right = Insert(node.Right, value);
        }
        else
        {
            // Value already exists, handle duplicate as needed
        }

        return node;
    }

    public bool Search(T value)
    {
        return Search(root, value) != null;
    }

    private TreeNode Search(TreeNode node, T value)
    {
        if (node == null)
        {
            return null;
        }

        int comparison = value.CompareTo(node.Value);
        if (comparison < 0)
        {
            return Search(node.Left, value);
        }
        else if (comparison > 0)
        {
            return Search(node.Right, value);
        }
        else
        {
            return node;
        }
    }

    public bool Delete(T value)
    {
        bool found = Search(value);
        if (found)
        {
            root = Delete(root, value);
        }
        return found;
    }

    private TreeNode Delete(TreeNode node, T value)
    {
        if (node == null)
        {
            return null;
        }

        int comparison = value.CompareTo(node.Value);
        if (comparison < 0)
        {
            node.Left = Delete(node.Left, value);
        }
        else if (comparison > 0)
        {
            node.Right = Delete(node.Right, value);
        }
        else
        {
            if (node.Left == null)
            {
                return node.Right;
            }
            else if (node.Right == null)
            {
                return node.Left;
            }
            else
            {
                TreeNode minRight = GetMin(node.Right);
                node.Value = minRight.Value;
                node.Right = Delete(node.Right, minRight.Value);
            }
        }

        return node;
    }

    private TreeNode GetMin(TreeNode node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return InOrderTraversal(root).GetEnumerator();
    }

    private IEnumerable<T> InOrderTraversal(TreeNode node)
    {
        if (node != null)
        {
            foreach (var value in InOrderTraversal(node.Left))
            {
                yield return value;
            }

            yield return node.Value;

            foreach (var value in InOrderTraversal(node.Right))
            {
                yield return value;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
