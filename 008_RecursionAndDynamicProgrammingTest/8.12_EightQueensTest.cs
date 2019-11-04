using _008_RecursionAndDynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_12_Test
    {
        [TestMethod]
        public void GenerateAllEightQueensTest()
        {
            // Act
            List<(int, int)[]> allEightQueens = Question_8_12.GenerateAllEightQueens();

            // Assert
            Assert.AreEqual(92, allEightQueens.Count, "Number of solutions does not match.");

            foreach ((int x, int y)[] solution in allEightQueens)
            {
                for (int i = 0; i < solution.Length; i++)
                {
                    for (int j = 0; j < solution.Length; j++)
                    {
                        if (i != j)
                        {
                            Assert.IsTrue(
                                Question_8_12.ValidatePoints(solution[i].x, solution[i].y, solution[j].x, solution[j].y),
                                $"Queen ({solution[i].x}, {solution[i].y}) is on the same row/column/diagonal as Queen ({solution[j].x}, {solution[j].y})."
                            );
                        }
                    }
                }
            }
        }
    }
}
