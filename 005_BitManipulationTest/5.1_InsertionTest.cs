using _005_BitManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _005_BitManipulationTest
{
    [TestClass]
    public class Question_5_1_Test
    {
        [DataTestMethod]
        [DataRow(0b10000000000, 0b10011, 2, 6, 0b10001001100)]
        [DataRow(0b11111, 0b10, 1, 2, 0b11101)]
        public void InsertBinaryNumberTest(int n, int m, int i, int j, int expected)
        {
            // Act
            int actual = Question_5_1.InsertBinaryNumber(n, m, i, j);

            // Assert
            Assert.AreEqual(expected, actual, "Failed to insert M into N.");
        }
    }
}
