using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPractice
{
    // Time complexity - Big O notation
    // https://www.geeksforgeeks.org/analysis-algorithms-big-o-analysis/
    class Program
    {
        static void Main(string[] args)
        {
            Random numberGenerator = new Random();
            int[] arRandomNumbers = new int[10];
            // Fill my array with random numbers

            for (int i = 0; i < 10; i++)
            {
                arRandomNumbers[i] = numberGenerator.Next(1, 10);
            }

            Console.WriteLine(System.DateTime.Now.TimeOfDay.ToString());

            // Sort using Array.Sort
            // https://docs.microsoft.com/en-us/dotnet/api/system.array.sort?view=netframework-4.8
            // If the partition size is fewer than 16 elements, it uses and insertion sort algorithm
            // If the number of partitions exceeds 2 * Log ^ N, it uses Heapsort
            // Otherwise it uses a Quicksort (more than 16 elements)
            // Worst case for this method is an O(n log n) where n is the length of the array
            Array.Sort(arRandomNumbers);

            BinarySearch(6, arRandomNumbers).ToString();

            // Implementing Quick Sort
            SortArray(arRandomNumbers, 0, arRandomNumbers.Length - 1);

            HeapSort(arRandomNumbers);

            Console.WriteLine(System.DateTime.Now.TimeOfDay.ToString());

            LinkedListOperations();

            HashTableOperations();

            BinarySearchTreeOperations();

            BinarySearchTreeBalancedOperations();

            BinaryMinHeapOperations();

            Console.ReadKey();


        }


        // https://www.youtube.com/watch?v=wygsfgtpApI
        // https://danielsimionescu.com/#hi-there
        private static void SortArray(int[] arRandomNumbers, int left, int right)
        {
            QuickSort(arRandomNumbers, left, right);
        }

        private static void QuickSort(int[] arRandomNumbers, int left, int right)
        {
            // Create index variables for comparison
            int i = left;
            int j = right;

            // get pivot value in the middle of the array
            // Indexes having the same value is the stopping point of recursion
            int pivot = arRandomNumbers[(left + right) / 2];

            // Iterate until until both left and right meet
            while (i <= j)
            {
                // values to the left must be lesser than the pivot, keep searching the array
                while (arRandomNumbers[i] < pivot)
                    i++;
                // values to the right must be greater than the pivot, keep searching the array
                while (arRandomNumbers[j] > pivot)
                    j--;
                // I found a value pair that must be swapped
                if (i <= j)
                {
                    // swap numbers
                    var tmp = arRandomNumbers[i];
                    arRandomNumbers[i] = arRandomNumbers[j];
                    arRandomNumbers[j] = tmp;

                    // increment left and decrement right
                    // this partitions the array
                    i++;
                    j--;
                }
            }

            // Go left? or Go Right?
            // Initial left index lesser than new right index > Go to the left side of the array
            if (left < j)
                QuickSort(arRandomNumbers, left, j);
            // Initial right index greater than new left index > Go to the right side of the array
            if (i < right)
                QuickSort(arRandomNumbers, i, right);
        }

        private static void HeapSort(int[] arRandomNumbers)
        {
            return;
        }

        private static void BinaryMinHeapOperations()
        {
            return;
        }

        private static void BinarySearchTreeBalancedOperations()
        {
            return;
        }

        private static void BinarySearchTreeOperations()
        {
            return;
        }

        // More info on https://www.tutorialspoint.com/csharp/csharp_hashtable.htm
        // More examples on https://www.geeksforgeeks.org/c-sharp-hashtable-with-examples/
        // Avg time complexity O(1) constant time
        // Worst case time complexity O(n) linear time
        private static void HashTableOperations()
        {
            // Hashtable is a collection of key/value pairs arranged based on the hash code of the key
            // Keys cannot be null, must be immutable and unique
            // In C# it implements IDictionary, ICollection, IEnumerable
            // These can contain elements of different types
            // Systems.Collections

            Hashtable myHashTable = new Hashtable();
            // Insert using Add()
            myHashTable.Add(1001, "Jon Doe");
            myHashTable.Add(1002, "Mark Doe");

            // Delete using Remove() by key
            myHashTable.Remove(1001);

            // Clear all contents
            myHashTable.Clear();

            // Search
            // Contains (key), ContainsKey, ContainstValue
            bool findKey = myHashTable.Contains(1001);
            findKey = myHashTable.ContainsKey(1001);
            bool findValue = myHashTable.ContainsValue("Jon Doe");

            string name = "NOT FOUND";
            // get value by key
            if (findKey)
                name = myHashTable[1001].ToString();

            Console.WriteLine("Name : " + name);

            foreach (DictionaryEntry pair in myHashTable)
                Console.WriteLine(pair.Key.ToString() + " " + pair.Value.ToString());

            // Showing all values
            var allValues = myHashTable.Values;
            foreach (var val in allValues)
                Console.WriteLine(val.ToString());

            return;
        }

        // LinkedList https://www.geeksforgeeks.org/c-sharp-linkedlist-class/
        // Operations - Time Complexity
        //  Operation   Average                 Worst Case
        //  insert      O(1) or constant time   O(1) or constant time
        //  search      O(n) or linear time     O(n) or linear time
        //  delete      O(n) or linear time     O(n) or linear time
        //  update      O(n) or linear time     O(n) or linear time
        private static void LinkedListOperations()
        {
            // This is just an array and a wrapper
            // Faster access by index, slow when inserting/deleting at the start or within the list
            List<string> myNameList = new List<string>();

            // This one is a doubly-linked list
            // Uses more memory due to references to next and previous
            // Slow access by index, faster when inserting within the list
            LinkedList<string> myNameLinkedList = new LinkedList<string>();

            myNameLinkedList.AddFirst("First Person");
            myNameLinkedList.AddLast("Last person");
            myNameLinkedList.AddAfter(myNameLinkedList.First, "Second Person");
            myNameLinkedList.AddBefore(myNameLinkedList.Last, "Third Person");

            // Search
            LinkedListNode<string> personNode = myNameLinkedList.Find("Second Person");
            var firstElement = myNameLinkedList.ElementAt<string>(0);
            bool elementExists = myNameLinkedList.Contains("Third Person");

            // Remove
            myNameLinkedList.RemoveFirst();
            myNameLinkedList.Remove("Second Person");
            myNameLinkedList.RemoveLast();
            myNameLinkedList.Clear();
        }


        // Search algorithms
        // More info https://cooervo.github.io/Algorithms-DataStructures-BigONotation/algorithms.html
        // Performs a binary search in a given sorted array and returns the index value of the first element that matches
        private static int BinarySearch(int searchVal, int[] sortedArray)
        {
            int lowestIndex = 0;
            int highestIndex = sortedArray.Length - 1;

            while (lowestIndex <= highestIndex)
            {
                int midIndex = lowestIndex + (highestIndex - lowestIndex) / 2;

                // search value is in the left side of the array
                // modify index values for next iteration
                if (searchVal < sortedArray[midIndex])
                    highestIndex = midIndex - 1;
                // search value is in the right side of the array
                else if (sortedArray[midIndex] < searchVal)
                    lowestIndex = midIndex + 1;
                // value has been found!
                else if (searchVal == sortedArray[midIndex])
                {
                    Console.WriteLine("Value : " + searchVal.ToString() + " found at position " + midIndex.ToString());
                    return midIndex;
                }
            }

            // Nothing found
            Console.WriteLine("Value : " + searchVal.ToString() + " not found in the given array");
            return -1;
        }

        // Performs a linear search in a given sorted array and returns the index value of the first element that matches

        private static int LinearSearch(int searchVal, int[] sortedArray)
        {

            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (searchVal == sortedArray[i])
                    return i;
            }

            return -1;
        }


    }
}
