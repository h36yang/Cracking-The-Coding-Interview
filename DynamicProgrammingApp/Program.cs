using System;
using System.Collections.Generic;

namespace DynamicProgrammingApp
{
    class Program
    {
        private static DateTime _start;
        private static DateTime _end;

        static void Main(string[] args)
        {
            #region 8.1

            // 8.1 Test Case 1
            var c811_1 = TripleStep.CountWaysRecursive(1);
            var c811_2 = TripleStep.CountWaysDynamic(1);
            Console.WriteLine($"There are {c811_1} way(s) the child can run up 1 stair - Recursive");
            Console.WriteLine($"There are {c811_2} way(s) the child can run up 1 stair - Dynamic Prog");

            // 8.1 Test Case 2
            var c812_1 = TripleStep.CountWaysRecursive(2);
            var c812_2 = TripleStep.CountWaysDynamic(2);
            Console.WriteLine($"There are {c812_1} way(s) the child can run up 2 stairs - Recursive");
            Console.WriteLine($"There are {c812_2} way(s) the child can run up 2 stairs - Dynamic Prog");

            // 8.1 Test Case 3
            var c813_1 = TripleStep.CountWaysRecursive(3);
            var c813_2 = TripleStep.CountWaysDynamic(3);
            Console.WriteLine($"There are {c813_1} way(s) the child can run up 3 stairs - Recursive");
            Console.WriteLine($"There are {c813_2} way(s) the child can run up 3 stairs - Dynamic Prog");

            // 8.1 Test Case 4
            var c814_1 = TripleStep.CountWaysRecursive(10);
            var c814_2 = TripleStep.CountWaysDynamic(10);
            Console.WriteLine($"There are {c814_1} way(s) the child can run up 10 stairs - Recursive");
            Console.WriteLine($"There are {c814_2} way(s) the child can run up 10 stairs - Dynamic Prog");

            #endregion

            #region 8.2

            // 8.2 Test Case 1
            var maze821 = new bool[,]
            {
                { true, false, true, true },
                { true, true, true, true },
                { true, false, false, true },
                { false, true, true, true }
            };
            var result821 = RobotInGrid.FindPath(maze821);
            if (result821 != null)
            {
                Console.Write("\nRobot Path 1: ");
                foreach (var point in result821)
                {
                    Console.Write($"[{point.Key},{point.Value}] -> ");
                }
                Console.WriteLine();
            }

            // 8.2 Test Case 2
            var maze822 = new bool[,]
            {
                { true, false, true, true },
                { true, true, false, true },
                { true, false, false, true },
                { false, true, true, true }
            };
            var result822 = RobotInGrid.FindPath(maze822);
            if (result822 != null)
            {
                Console.Write("Robot Path 2: ");
                foreach (var point in result822)
                {
                    Console.Write($"[{point.Key},{point.Value}] -> ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No path found for Test Case 2.");
            }
            Console.WriteLine();

            #endregion

            #region 8.3

            // 8.3 Test Case 1
            var a831 = new int[100];
            for (int i = 0; i < 99; i++)
            {
                a831[i] = i - 1;
            }
            a831[99] = 99;
            _start = DateTime.Now;
            var result831_1 = MagicIndex.Find_BruteForce(a831);
            _end = DateTime.Now;
            Console.WriteLine($"(Brute Force) Magic Index is at {result831_1} - Runtime {_end.Subtract(_start).TotalSeconds}s");

            _start = DateTime.Now;
            var result831_2 = MagicIndex.Find_BinarySearch(a831);
            _end = DateTime.Now;
            Console.WriteLine($"(Binary Search) Magic Index is at {result831_2} - Runtime {_end.Subtract(_start).TotalSeconds}s");
            Console.WriteLine();

            // 8.3 Test Case 2
            var a832 = new int[]
            {
                -10, -5, 2, 2, 2, 3, 4, 7, 9, 12, 13
            };
            _start = DateTime.Now;
            var result832_2 = MagicIndex.Find_BinarySearch_v2(a832);
            _end = DateTime.Now;
            Console.WriteLine($"(Binary Search) Magic Index is at {result832_2} - Runtime {_end.Subtract(_start).TotalSeconds}s");
            Console.WriteLine();

            #endregion

            #region 8.4

            // 8.4 Test Case 1
            var s841 = new int[]
            {
                1, 2, 3
            };
            Console.Write("Full Set: { ");
            foreach (var i in s841) { Console.Write($"{i}, "); }
            Console.WriteLine("}");

            var result841 = PowerSet.GetAllSubsets(s841);
            Console.WriteLine("Subsets:");
            foreach (var s in result841)
            {
                Console.Write("{ ");
                foreach (var i in s)
                {
                    Console.Write($"{i}, ");
                }
                Console.WriteLine("}");
            }
            Console.WriteLine();

            #endregion

            #region 8.5

            // 8.5 Test Case 1
            var result851 = RecursiveMultiply.Multiply(9, 7);
            Console.WriteLine($"7 * 9 = {result851}");

            // 8.5 Test Case 2
            var result852 = RecursiveMultiply.Multiply(8, 9);
            Console.WriteLine($"8 * 9 = {result852}");

            // 8.5 Test Case 3
            var result853 = RecursiveMultiply.Multiply(13579, 24680);
            Console.WriteLine($"13579 * 24680 = {result853}\n");

            #endregion

            #region 8.6

            // 8.6 Test Case 1
            var t861_1 = new Stack<int>();
            var t861_2 = new Stack<int>();
            var t861_3 = new Stack<int>();
            t861_1.Push(3);
            t861_1.Push(2);
            t861_1.Push(1);
            Console.WriteLine("Initial State:");
            Console.Write("Tower 1: ");
            foreach (int i in t861_1) { Console.Write($"{i} -> "); }
            Console.Write("\nTower 2: ");
            foreach (int i in t861_2) { Console.Write($"{i} -> "); }
            Console.Write("\nTower 3: ");
            foreach (int i in t861_3) { Console.Write($"{i} -> "); }

            TowersOfHanoi.Move(3, t861_1, t861_3, t861_2);
            Console.WriteLine("\nFinal State:");
            Console.Write("Tower 1: ");
            foreach (int i in t861_1) { Console.Write($"{i} -> "); }
            Console.Write("\nTower 2: ");
            foreach (int i in t861_2) { Console.Write($"{i} -> "); }
            Console.Write("\nTower 3: ");
            foreach (int i in t861_3) { Console.Write($"{i} -> "); }
            Console.WriteLine("\n");

            // 8.6 Test Case 2
            var t862_1 = new Stack<int>();
            var t862_2 = new Stack<int>();
            var t862_3 = new Stack<int>();
            t862_1.Push(4);
            t862_1.Push(3);
            t862_1.Push(2);
            t862_1.Push(1);
            Console.WriteLine("Initial State:");
            Console.Write("Tower 1: ");
            foreach (int i in t862_1) { Console.Write($"{i} -> "); }
            Console.Write("\nTower 2: ");
            foreach (int i in t862_2) { Console.Write($"{i} -> "); }
            Console.Write("\nTower 3: ");
            foreach (int i in t862_3) { Console.Write($"{i} -> "); }

            TowersOfHanoi.Move(4, t862_1, t862_3, t862_2);
            Console.WriteLine("\nFinal State:");
            Console.Write("Tower 1: ");
            foreach (int i in t862_1) { Console.Write($"{i} -> "); }
            Console.Write("\nTower 2: ");
            foreach (int i in t862_2) { Console.Write($"{i} -> "); }
            Console.Write("\nTower 3: ");
            foreach (int i in t862_3) { Console.Write($"{i} -> "); }
            Console.WriteLine("\n");

            #endregion
        
            #region 8.7

            // 8.7 Test Case 1
            var s871 = "ABC";
            Console.WriteLine($"Original String: {s871}");

            var result871 = PermutationsWithoutDups.FindAllPermutations(s871);
            Console.WriteLine("All Permutations:");
            foreach (var s in result871) { Console.WriteLine(s); }
            Console.WriteLine();

            #endregion
        
            #region 8.8

            // 8.8 Test Case 1
            var s881 = "AAAA";
            Console.WriteLine($"Original String: {s881}");

            var result881 = PermutationsWithDups.FindAllPermutations(s881);
            Console.WriteLine("All Permutations:");
            foreach (var s in result881) { Console.WriteLine(s); }
            Console.WriteLine();

            #endregion
        }
    }
}
