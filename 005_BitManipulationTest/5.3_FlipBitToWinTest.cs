using _005_BitManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _005_BitManipulationTest
{
    [TestClass]
    public class Question_5_3_Test
    {
        [DataTestMethod]
        [DataRow(0b11011101111, 8)]
        [DataRow(0b1111011110011111, 9)]
        [DataRow(0, 1)]
        [DataRow(int.MaxValue, 32)]
        public void FindLongestSequenceTest(int testNumber, int expectedLength)
        {
            // Act
            int resultLength1 = Question_5_3.FindLongestSequence(testNumber);
            int resultLength2 = Question_5_3.FindLongestSequenceOptimal(testNumber);

            // Assert
            Assert.AreEqual(expectedLength, resultLength1, $"Failed to find the longest sequence of 1s for {testNumber}.");
            Assert.AreEqual(expectedLength, resultLength2, $"Failed to find the longest sequence of 1s for {testNumber} - Optimal.");
        }
    }
}
