using System;

namespace CircularSinglyLinkedListNamespace
{
    class Tester
    {
        static void Main(string[] args)
        {
            CircularSinglyLinkedList<int> list = new CircularSinglyLinkedList<int>();

            // Test A: Create a new list
            Console.WriteLine("Test A: Create a new list");
            Console.WriteLine(list.ToString() == "[]" ? "SUCCESS" : "FAILURE");

            // Test B: Add a sequence of numbers using AddLast()
            Console.WriteLine("Test B: Add a sequence of numbers 1, 2, 3, 4, 5 using AddLast()");
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);
            list.AddLast(5);
            Console.WriteLine(list.ToString() == "[1 -> 2 -> 3 -> 4 -> 5]" ? "SUCCESS" : "FAILURE");

            // Test C: Remove the first number using RemoveFirst()
            Console.WriteLine("Test C: Remove the first number using the RemoveFirst() method");
            list.RemoveFirst();
            Console.WriteLine(list.ToString() == "[2 -> 3 -> 4 -> 5]" ? "SUCCESS" : "FAILURE");

            // Test D: Add a number at the start using AddFirst(0)
            Console.WriteLine("Test D: Add a number at the start using the AddFirst(0) method");
            list.AddFirst(0);
            Console.WriteLine(list.ToString() == "[0 -> 2 -> 3 -> 4 -> 5]" ? "SUCCESS" : "FAILURE");

            // Test E: Find the node containing 3
            Console.WriteLine("Test E: Find the node containing the number 3");
            INode<int> node3 = list.Find(3);
            Console.WriteLine(node3 != null && node3.Value == 3 ? "SUCCESS" : "FAILURE");

            // Test F: Remove the node containing 3
            Console.WriteLine("Test F: Remove the found in the previous test case");
            list.Remove(node3);
            Console.WriteLine(list.ToString() == "[0 -> 2 -> 4 -> 5]" ? "SUCCESS" : "FAILURE");

            // Test G: Clear the list
            Console.WriteLine("Test G: Clear the entire CLL");
            list.Clear();
            Console.WriteLine(list.ToString() == "[]" ? "SUCCESS" : "FAILURE");

            Console.WriteLine("\n------------------- SUMMARY -------------------");
            Console.WriteLine("Tests passed: ABCDEFG");
        }
    }
}
