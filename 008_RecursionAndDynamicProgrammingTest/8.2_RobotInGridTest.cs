using _008_RecursionAndDynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_2_Test
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        public void FindPathTest(int testCase)
        {
            // Arrange
            bool[,] testMaze = GenerateTestMaze(testCase);
            (int r, int c)[] expectedPath = GenerateExpectedPath(testCase);

            if (testMaze == null)
            {
                Console.WriteLine("Invalid maze.");
            }
            else
            {
                Console.WriteLine("Maze:");
                for (int r = 0; r < testMaze.GetLength(0); r++)
                {
                    for (int c = 0; c < testMaze.GetLength(1); c++)
                    {
                        Console.Write(testMaze[r, c] ? 1 : 0);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
            }

            // Act
            var time1 = DateTime.Now;
            List<(int r, int c)> resultPathRecursion = Question_8_2.FindPathRecursion(testMaze);
            var time2 = DateTime.Now;
            List<(int r, int c)> resultPathMemoization = Question_8_2.FindPathMemoization(testMaze);
            var time3 = DateTime.Now;

            Console.WriteLine($"Recursion method took {time2.Subtract(time1).TotalMilliseconds} ms.");
            Console.WriteLine($"Memoization method took {time3.Subtract(time2).TotalMilliseconds} ms.");

            // Assert
            if (expectedPath == null)
            {
                Assert.IsNull(resultPathRecursion, "FindPath test failed - Recursion.");
                Assert.IsNull(resultPathMemoization, "FindPath test failed - Memoization.");
            }
            else
            {
                Assert.IsTrue(expectedPath.SequenceEqual(resultPathRecursion), "FindPath test failed - Recursion.");
                Assert.IsTrue(expectedPath.SequenceEqual(resultPathMemoization), "FindPath test failed - Memoization.");
            }
        }

        private bool[,] GenerateTestMaze(int testCase)
        {
            if (testCase == 1)
            {
                return new bool[,]
                {
                    { true, true, true, true, false, true, true, true },
                    { false, false, false, true, false, true, true, true },
                    { true, true, false, true, true, false, true, true },
                    { true, true, false, false, true, true, true, false },
                    { true, true, true, true, true, false, true, true },
                    { true, true, true, true, true, false, true, false },
                    { true, true, true, true, true, false, true, true }
                };
            }
            else if (testCase == 2)
            {
                return new bool[,]
                {
                    { true, true, true, true, false, true, true, true },
                    { false, false, false, true, false, true, true, true },
                    { true, true, false, true, true, false, true, true },
                    { true, true, false, false, true, false, true, false },
                    { true, true, true, true, true, false, true, true },
                    { true, true, true, true, true, true, true, false },
                    { true, true, true, true, true, false, true, true }
                };
            }
            else if (testCase == 3)
            {
                return new bool[,]
                {
                    { true, true, true, true, false, true, true, true },
                    { false, false, false, true, false, true, true, true },
                    { true, true, false, true, true, false, true, true },
                    { true, true, false, false, true, false, true, false },
                    { true, true, true, true, true, false, true, true },
                    { true, true, true, true, true, false, true, false },
                    { true, true, true, true, true, false, true, true }
                };
            }
            else if (testCase == 4)
            {
                return new bool[,]
                {
                    { false, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true }
                };
            }
            else if (testCase == 5)
            {
                return new bool[,]
                {
                    { true, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, true },
                    { true, true, true, true, true, true, true, false }
                };
            }
            return null;
        }

        private (int r, int c)[] GenerateExpectedPath(int testCase)
        {
            if (testCase == 1)
            {
                return new (int r, int c)[]
                {
                    (0, 0), (0, 1), (0, 2), (0, 3), (1, 3), (2, 3), (2, 4), (3, 4), (3, 5), (3, 6), (4, 6), (5, 6), (6, 6), (6, 7)
                };
            }
            else if (testCase == 2)
            {
                return new (int, int)[]
                {
                    (0, 0), (0, 1), (0, 2), (0, 3), (1, 3), (2, 3), (2, 4), (3, 4), (4, 4), (5, 4), (5, 5), (5, 6), (6, 6), (6, 7)
                };
            }
            return null;
        }
    }
}
