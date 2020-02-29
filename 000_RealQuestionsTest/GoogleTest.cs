using _000_RealQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _000_RealQuestionsTest
{
    [TestClass]
    public class GoogleTest
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 4, 9, 3, 4, 1 }, 2, 2, 4)]
        public void MinDaysBloomTest(int[] roses, int k, int n, int expected)
        {
            // Act
            int result = Google.MinDaysBloom(roses, k, n);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
