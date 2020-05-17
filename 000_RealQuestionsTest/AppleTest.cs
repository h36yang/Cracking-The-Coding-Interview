using _000_RealQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _000_RealQuestionsTest
{
    [TestClass]
    public class AppleTest
    {
        [DataTestMethod]
        [DataRow(4)]
        [DataRow(10)]
        [DataRow(12)]
        [DataRow(16)]
        public void RandomInt1toNTest(int n)
        {
            // Act
            var results = new int[n + 1];
            int total = n * 10000;
            for (int i = 0; i < total; i++)
            {
                int k = Apple.RandomInt1toN(n);
                results[k]++;
            }

            // Assert
            for (int k = 1; k <= n; k++)
            {
                Console.WriteLine($"Probability of {k} is {Math.Round((double)results[k] * 100 / total, 1)}%.");
            }
            Assert.IsTrue(true);
        }
    }
}
