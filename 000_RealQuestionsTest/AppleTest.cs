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
            var resultsV2 = new int[n + 1];
            int total = n * 100000;
            for (int i = 0; i < total; i++)
            {
                int k = Apple.RandomInt1toN(n);
                int k2 = Apple.RandomInt1toN_v2(n);
                results[k]++;
                resultsV2[k2]++;
            }

            // Assert
            double expectedProbability = (double)100 / n;
            double threshold = 0.2;
            for (int k = 1; k <= n; k++)
            {
                double probabilityV1 = (double)results[k] * 100 / total;
                Console.WriteLine($"V1 - Probability of {k} is {Math.Round(probabilityV1, 2)}%.");

                double probabilityV2 = (double)resultsV2[k] * 100 / total;
                Console.WriteLine($"V2 - Probability of {k} is {Math.Round(probabilityV2, 2)}%.");

                Assert.AreEqual(expectedProbability, probabilityV1, threshold);
                Assert.AreEqual(expectedProbability, probabilityV2, threshold);
            }
        }
    }
}
