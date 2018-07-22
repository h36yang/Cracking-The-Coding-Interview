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

            #region 10.4

            // 10.4 Test Case 1
            var listy1041 = new Listy();
            for (int i = 0; i < 97; i += 2)
            {
                listy1041.Add(i);
            }
            var result1041_1 = SortedSearchNoSize.Find(listy1041, 30);
            Console.WriteLine($"Index of 30 in Listy: {result1041_1}");
            var result1041_2 = SortedSearchNoSize.Find(listy1041, 0);
            Console.WriteLine($"Index of 0 in Listy: {result1041_2}");
            var result1041_3 = SortedSearchNoSize.Find(listy1041, 96);
            Console.WriteLine($"Index of 96 in Listy: {result1041_3}");
            var result1041_4 = SortedSearchNoSize.Find(listy1041, 1);
            Console.WriteLine($"Index of 1 in Listy: {result1041_4}\n");

            #endregion

            #region 10.5

            // 10.5 Test Case 1
            var a1051 = new string[]
            {
                "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", ""
            };
            Console.Write("Sparse Array: ");
            foreach (string i in a1051) { Console.Write($"\"{i}\" -> "); }
            Console.WriteLine();

            var result1051_1 = SparseSearch.Find(a1051, "at");
            Console.WriteLine($"Index of 'at' in the array: {result1051_1}");
            var result1051_2 = SparseSearch.Find(a1051, "ball");
            Console.WriteLine($"Index of 'ball' in the array: {result1051_2}");
            var result1051_3 = SparseSearch.Find(a1051, "car");
            Console.WriteLine($"Index of 'car' in the array: {result1051_3}");
            var result1051_4 = SparseSearch.Find(a1051, "dad");
            Console.WriteLine($"Index of 'dad' in the array: {result1051_4}\n");

            #endregion

            #region 10.7

            // 10.7 Test Case 1
            var file1071 = new int[20000];
            for (int i = 0; i < 20000; i++)
            {
                if (i != 12345)
                {
                    file1071[i] = i;
                }
            }
            MissingInt.PrintMissingInt(file1071, 19999);
            Console.WriteLine();

            #endregion

            #region 10.9

            // 10.9 Test Case 1
            var m1091 = new int[,]
            {
                { 15, 20, 40, 85 },
                { 20, 35, 80, 95 },
                { 30, 55, 95, 105 },
                { 40, 80, 100, 120 },
                { 50, 110, 135, 198 }
            };
            for (int x = 0; x < m1091.GetLength(0); x++)
            {
                Console.Write("[ ");
                for (int y = 0; y < m1091.GetLength(1); y++)
                {
                    Console.Write($"{FormatInt(m1091[x, y], 3)} ");
                }
                Console.WriteLine("]");
            }

            var result1091_1 = SortedMatrixSearch.Find(m1091, 55);
            Console.WriteLine($"Element 55 is located at ( {result1091_1.Value.Key}, {result1091_1.Value.Value} )");
            var result1091_2 = SortedMatrixSearch.Find(m1091, 15);
            Console.WriteLine($"Element 15 is located at ( {result1091_2.Value.Key}, {result1091_2.Value.Value} )");
            var result1091_3 = SortedMatrixSearch.Find(m1091, 198);
            Console.WriteLine($"Element 198 is located at ( {result1091_3.Value.Key}, {result1091_3.Value.Value} )\n");

            #endregion
        
            #region 10.10

            // 10.10 Test Case 1
            var stream = new RankFromStream();
            stream.Track(5);
            stream.Track(1);
            stream.Track(4);
            stream.Track(4);
            stream.Track(5);
            stream.Track(9);
            stream.Track(7);
            stream.Track(13);
            stream.Track(3);
            stream.PrintNumbersInOrder();
            Console.WriteLine();

            var rank10101_1 = stream.GetRankOfNumber(1);
            Console.WriteLine($"Rank of number 1 is {rank10101_1}.");
            var rank10101_2 = stream.GetRankOfNumber(3);
            Console.WriteLine($"Rank of number 3 is {rank10101_2}.");
            var rank10101_3 = stream.GetRankOfNumber(4);
            Console.WriteLine($"Rank of number 4 is {rank10101_3}.");
            var rank10101_4 = stream.GetRankOfNumber(13);
            Console.WriteLine($"Rank of number 13 is {rank10101_4}.\n");

            #endregion
        
            #region 10.11

            // 10.11 Test Case 1
            var a10111 = new int[]
            {
                5, 3, 1, 2, 3
            };
            Console.Write("Original: ");
            foreach (int i in a10111) { Console.Write($"{i} -> "); }
            Console.WriteLine();

            PeaksAndValleys.Rearrange_v2(a10111);
            Console.Write("Peaks and Valleys: ");
            foreach (int i in a10111) { Console.Write($"{i} -> "); }
            Console.WriteLine("\n");

            // 10.11 Test Case 2
            var a10112 = new int[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 0
            };
            Console.Write("Original: ");
            foreach (int i in a10112) { Console.Write($"{i} -> "); }
            Console.WriteLine();

            PeaksAndValleys.Rearrange_v2(a10112);
            Console.Write("Peaks and Valleys: ");
            foreach (int i in a10112) { Console.Write($"{i} -> "); }
            Console.WriteLine();

            #endregion
        }

        private static string FormatInt(int value, int digits)
        {
            string result = value.ToString();
            if (result.Length < digits)
            {
                for (int i = 0; i < digits - result.Length; i++)
                {
                    result = $"0{result}";
                }
            }
            return result;
        }
    }
}
