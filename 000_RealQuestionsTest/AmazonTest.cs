using _000_RealQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _000_RealQuestionsTest
{
    [TestClass]
    public class AmazonTest
    {
        [DataTestMethod]
        [DataRow("[1,0,1,1,1,0,0,1][1,0,0,0,1,1,1,1][1,0,0,0,0,0,0,0][1,0,1,0,9,0,1,1][1,1,1,0,1,0,0,1][1,0,1,0,1,1,0,1][1,0,0,0,0,1,0,1][1,1,1,1,1,1,1,1]", true)]
        [DataRow("[1,0,1,1,1,0,0,1][1,0,0,0,1,1,1,1][1,0,0,0,0,0,0,0][1,0,1,0,9,0,1,1][1,1,1,0,0,0,0,1][1,0,1,0,1,1,0,1][1,0,0,0,0,1,0,1][1,1,1,1,1,1,1,1]", false)]
        public void IsCheeseReachableInMazeTest(string mazeString, bool expected)
        {
            // Arrange
            int[,] maze = ConvertMazeString(mazeString);

            // Act
            bool result = Amazon.IsCheeseReachableInMaze(maze);

            // Assert
            Assert.AreEqual(expected, result, mazeString);
        }

        private int[,] ConvertMazeString(string maze)
        {
            int[,] res = null;
            string[] rows = maze.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            for (int r = 0; r < rows.Length; r++)
            {
                string[] cols = rows[r].Split(',');
                if (res == null)
                {
                    res = new int[rows.Length, cols.Length];
                }

                for (int c = 0; c < cols.Length; c++)
                {
                    res[r, c] = int.Parse(cols[c]);
                }
            }
            return res;
        }

        [TestMethod]
        public void GroupNumbersTest()
        {
            // Arrange
            var testInput = new List<KeyValuePair<int, char[]>>
            {
                new KeyValuePair<int, char[]>(8, new char[]{ 'z', 'x', 'y' }),
                new KeyValuePair<int, char[]>(5, new char[]{ 'y', 'u' }),
                new KeyValuePair<int, char[]>(3, new char[]{ 'm' }),
                new KeyValuePair<int, char[]>(6, new char[]{ 'u', 'd' }),
                new KeyValuePair<int, char[]>(9, new char[]{ 'm', 'n' }),
                new KeyValuePair<int, char[]>(7, new char[]{ 'a' })
            };

            // Act
            var result = Amazon.GroupNumbers(testInput);

            // Assert
            Assert.AreEqual(3, result.Count);
            foreach (List<int> group in result)
            {
                Console.WriteLine(string.Join(",", group));
            }
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 4, 6)]
        [DataRow(new int[] { 13, 16, 16, 15, 9, 16, 2, 7, 6, 17, 3, 9 }, 65, 36)]
        public void CountGoodSubArraysTest(int[] A, int B, int expected)
        {
            // Act
            int result = Amazon.CountGoodSubArrays(A, B);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
