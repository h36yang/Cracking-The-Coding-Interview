using _008_RecursionAndDynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_11_Test
    {
        [DataTestMethod]
        [DataRow(0, 1)]
        [DataRow(1, 1)]
        [DataRow(2, 1)]
        [DataRow(5, 2)]
        [DataRow(10, 4)]
        [DataRow(25, 13)]
        [DataRow(26, 13)]
        public void CountPossibleCombinationsTest(int nCents, long expectedWays)
        {
            // Act
            var time1 = DateTime.Now;
            long resultRecursion = Question_8_11.CountPossibleCombinationsRecursion(nCents);
            var time2 = DateTime.Now;
            long resultMemoization = Question_8_11.CountPossibleCombinationsMemoization(nCents);
            var time3 = DateTime.Now;

            Console.WriteLine($"Recursion method took {time2.Subtract(time1).TotalMilliseconds} ms.");
            Console.WriteLine($"Memoization method took {time3.Subtract(time2).TotalMilliseconds} ms.");

            // Assert
            Assert.AreEqual(expectedWays, resultRecursion, "CountPossibleWays test failed - Recursion.");
            Assert.AreEqual(expectedWays, resultMemoization, "CountPossibleWays test failed - Memoization.");
        }
    }
}
