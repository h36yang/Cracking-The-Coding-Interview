using _016_Moderate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _016_ModerateTest
{
    [TestClass]
    public class Question_16_05_Test
    {
        [DataTestMethod]
        [DataRow(-1, -1)]
        [DataRow(0, 0)]
        [DataRow(1, 0)]
        [DataRow(2, 0)]
        [DataRow(5, 1)]
        [DataRow(9, 1)]
        [DataRow(10, 2)]
        [DataRow(14, 2)]
        [DataRow(15, 3)]
        [DataRow(20, 4)]
        [DataRow(25, 6)]
        public void FindFactorialTrailingZerosTest(int testNumber, int expectedZeros)
        {
            // Act
            var time1 = DateTime.Now;
            int resultZeros1 = Question_16_05.CountFactorialTrailingZeros(testNumber);
            var time2 = DateTime.Now;
            int resultZeros2 = Question_16_05.CountFactorialTrailingZerosOptimized(testNumber);
            var time3 = DateTime.Now;

            Console.WriteLine($"Runtime 1: {time2.Subtract(time1).TotalMilliseconds} ms");
            Console.WriteLine($"Runtime 2: {time3.Subtract(time2).TotalMilliseconds} ms");

            // Assert
            Assert.AreEqual(expectedZeros, resultZeros1, "Number of trailing zeros does not match.");
            Assert.AreEqual(expectedZeros, resultZeros2, "Number of trailing zeros does not match - optimized.");
        }
    }
}
