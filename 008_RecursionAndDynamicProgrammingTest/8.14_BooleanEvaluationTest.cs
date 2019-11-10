using _008_RecursionAndDynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_14_Test
    {
        [DataTestMethod]
        [DataRow("", true, 0)]
        [DataRow("", false, 0)]
        [DataRow("1|0", true, 1)]
        [DataRow("1&0", false, 1)]
        [DataRow("1^0|0|1", false, 2)]
        [DataRow("0&0&0&1^1|0", true, 10)]
        public void CountEvalTest(string testExpression, bool testExpectedResult, int expectedCount)
        {
            // Act
            var time1 = DateTime.Now;
            int resultCountRecursion = Question_8_14.CountEvalRecursion(testExpression, testExpectedResult);
            var time2 = DateTime.Now;
            int resultCountMemoization = Question_8_14.CountEvalMemoization(testExpression, testExpectedResult);
            var time3 = DateTime.Now;

            Console.WriteLine($"Recursion method took {time2.Subtract(time1).TotalMilliseconds} ms.");
            Console.WriteLine($"Memoization method took {time3.Subtract(time2).TotalMilliseconds} ms.");

            // Assert
            Assert.AreEqual(expectedCount, resultCountRecursion, "CountEval test failed - Recursion.");
            Assert.AreEqual(expectedCount, resultCountMemoization, "CountEval test failed - Memoization.");
        }
    }
}
