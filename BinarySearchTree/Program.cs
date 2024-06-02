using System;

public class Program
{
    public static void Main(string[] args)
    {
        TurboBinarySearchTree<int> tree = new TurboBinarySearchTree<int>();

        for (int i = 0; i < 1000000; i += 2)
        {
            tree.Insert(i);
        }

        Console.WriteLine("Found 50000: " + tree.Search(50000)); // should return true
        Console.WriteLine("Deleted 50000: " + tree.Delete(50000)); // should return true
        Console.WriteLine("Found 50000: " + tree.Search(50000)); // should return false
        Console.WriteLine("Found 50001: " + tree.Search(50001)); // should return false
        Console.WriteLine("Deleted 50001: " + tree.Delete(50001)); // should return false
        Console.WriteLine("Found 50001: " + tree.Search(50001)); // should return false

        tree.Insert(50002);
        Console.WriteLine("Found 50002: " + tree.Search(50002)); // should return true
        Console.WriteLine("Deleted 50002: " + tree.Delete(50002)); // should return true
        Console.WriteLine("Found 50002: " + tree.Search(50002)); // should return true
        Console.WriteLine("Deleted 50002: " + tree.Delete(50002)); // should return true
        Console.WriteLine("Found 50002: " + tree.Search(50002)); // should return false

        foreach (var value in tree)
        {
            Console.WriteLine(value);
        }
    }
}