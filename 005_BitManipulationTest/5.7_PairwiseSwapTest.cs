using _005_BitManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _005_BitManipulationTest
{
    [TestClass]
    public class Question_5_7_Test
    {
        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(0b01, 0b10)]
        [DataRow(0b1001, 0b0110)]
        [DataRow(0b11001, 0b100110)]
        public void PairwiseSwapTest(int testNumber, int expectedResult)
        {
            // Act
            int actualResult = Question_5_7.PairwiseSwap(testNumber);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, $"Failed to pairwise swap {testNumber}.");
        }
    }
}
