using _016_Moderate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _016_ModerateTest
{
    [TestClass]
    public class Question_16_05_Test
    {
        [DataTestMethod]
        [DataRow(1, 0)]
        [DataRow(2, 0)]
        [DataRow(5, 1)]
        [DataRow(9, 1)]
        [DataRow(10, 2)]
        [DataRow(14, 2)]
        [DataRow(15, 3)]
        [DataRow(20, 4)]
        public void FindFactorialTrailingZerosTest(int testNumber, int expectedZeros)
        {
            // Act
            int resultZeros = Question_16_05.FindFactorialTrailingZeros(testNumber);

            // Assert
            Assert.AreEqual(expectedZeros, resultZeros, "Number of trailing zeros does not match.");
        }
    }
}
