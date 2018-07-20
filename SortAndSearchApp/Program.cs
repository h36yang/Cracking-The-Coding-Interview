using System;

namespace SortAndSearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 10.1

            // 10.1 Test Case 1
            var a = new int[19];
            for (int i = 0; i < 14; i++)
            {
                a[i] = i * 2 + 1;
            }
            var b = new int[]
            {
                2, 8, 14, 24, 30
            };

            Console.Write("A: ");
            foreach (int i in a) { Console.Write($"{i} -> "); }
            Console.Write("\nB: ");
            foreach (int j in b) { Console.Write($"{j} -> "); }
            Console.WriteLine();

            SortedMerge.Merge(a, b, 14);
            Console.Write("Merged: ");
            foreach (int i in a) { Console.Write($"{i} -> "); }
            Console.WriteLine("\n");

            #endregion

            #region 10.2

            // 10.2 Test Case 1
            var s1021 = new string[]
            {
                "abcd", "1234", "dcab", "2341", "asdf", "fdsa", "dcba", "4231"
            };
            Console.Write("Original: ");
            foreach (string s in s1021) { Console.Write($"{s} -> "); }
            Console.WriteLine();

            GroupAnagrams.Sort(s1021);
            Console.Write("Sorted: ");
            foreach (string s in s1021) { Console.Write($"{s} -> "); }
            Console.WriteLine("\n");

            #endregion

            #region 10.3

            // 10.3 Test Case 1
            var a1031 = new int[]
            {
                15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14
            };
            Console.Write("Rotated Array: ");
            foreach (int i in a1031) { Console.Write($"{i} -> "); }
            Console.WriteLine();

            var result1031_1a = SearchInRotatedArray.Find(a1031, 5);
            var result1031_1b = SearchInRotatedArray.Find_v2(a1031, 5, 0, a1031.Length - 1);
            Console.WriteLine($"Index of 5 in the array: {result1031_1a}");
            Console.WriteLine($"Index of 5 in the array (v2): {result1031_1b}");

            var result1031_2a = SearchInRotatedArray.Find(a1031, 16);
            var result1031_2b = SearchInRotatedArray.Find_v2(a1031, 16, 0, a1031.Length - 1);
            Console.WriteLine($"Index of 16 in the array: {result1031_2a}");
            Console.WriteLine($"Index of 16 in the array (v2): {result1031_2b}");

            var result1031_3a = SearchInRotatedArray.Find(a1031, 1);
            var result1031_3b = SearchInRotatedArray.Find_v2(a1031, 1, 0, a1031.Length - 1);
            Console.WriteLine($"Index of 1 in the array: {result1031_3a}");
            Console.WriteLine($"Index of 1 in the array (v2): {result1031_3b}\n");

            #endregion
        }
    }
}
