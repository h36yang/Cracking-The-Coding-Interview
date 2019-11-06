using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static _008_RecursionAndDynamicProgramming.Question_8_13;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_13_Test
    {
        [DataTestMethod]
        [DataRow(1, 20)]
        [DataRow(2, 15)]
        [DataRow(3, 60)]
        [DataRow(4, 45)]
        [DataRow(5, 0)]
        [DataRow(6, -1)]
        public void CalculateTallestStackHeightTest(int testCase, int expectedHeight)
        {
            // Arrange
            Box[] testBoxes = GenerateTestBoxes(testCase);

            // Act
            var time1 = DateTime.Now;
            int resultHeightRecursion = CalculateTallestStackHeightRecursion(testBoxes);
            var time2 = DateTime.Now;
            int resultHeightMemoization = CalculateTallestStackHeightMemoization(testBoxes);
            var time3 = DateTime.Now;

            Console.WriteLine($"Recursion method took {time2.Subtract(time1).TotalMilliseconds} ms.");
            Console.WriteLine($"Memoization method took {time3.Subtract(time2).TotalMilliseconds} ms.");

            // Assert
            Assert.AreEqual(expectedHeight, resultHeightRecursion, "CalculateTallestStackHeight test failed - Recursion.");
            Assert.AreEqual(expectedHeight, resultHeightMemoization, "CalculateTallestStackHeight test failed - Memoization.");
        }

        private Box[] GenerateTestBoxes(int testCase)
        {
            if (testCase == 1)
            {
                // Several boxes with exact same size - cannot stack
                return new Box[]
                {
                    new Box { Width = 10, Height = 20, Depth = 5 },
                    new Box { Width = 10, Height = 20, Depth = 5 },
                    new Box { Width = 10, Height = 20, Depth = 5 }
                };
            }
            else if (testCase == 2)
            {
                // Several boxes with different sizes but can't be stacked
                return new Box[]
                {
                    new Box { Width = 10, Height = 15, Depth = 8 },
                    new Box { Width = 11, Height = 5, Depth = 5 },
                    new Box { Width = 9, Height = 10, Depth = 10 }
                };
            }
            else if (testCase == 3)
            {
                // Several boxes that can all be stacked
                return new Box[]
                {
                    new Box { Width = 10, Height = 10, Depth = 5 },
                    new Box { Width = 11, Height = 20, Depth = 6 },
                    new Box { Width = 12, Height = 30, Depth = 7 }
                };
            }
            else if (testCase == 4)
            {
                // Several boxes with multiple ways to be stacked
                return new Box[]
                {
                    new Box { Width = 9, Height = 5, Depth = 20 },
                    new Box { Width = 10, Height = 10, Depth = 5 },
                    new Box { Width = 11, Height = 25, Depth = 10 },
                    new Box { Width = 12, Height = 15, Depth = 7 },
                    new Box { Width = 13, Height = 20, Depth = 9 }
                };
            }
            else if (testCase == 5)
            {
                // Empty array of no boxes
                return Array.Empty<Box>();
            }
            return null;
        }
    }
}
