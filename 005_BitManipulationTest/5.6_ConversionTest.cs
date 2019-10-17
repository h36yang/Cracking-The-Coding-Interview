using _005_BitManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _005_BitManipulationTest
{
    [TestClass]
    public class Question_5_6_Test
    {
        [DataTestMethod]
        [DataRow(1234, 1234, 0)]
        [DataRow(0b11101, 0b01111, 2)]
        [DataRow(0b1001011, 0b1011, 1)]
        [DataRow(0b1001011, 0b1011000, 3)]
        public void FlipBitsToConvertTest(int a, int b, int expectedResult)
        {
            // Act
            int actualResult1 = Question_5_6.FlipBitsToConvert(a, b);
            int actualResult2 = Question_5_6.FlipBitsToConvertXOR(a, b);

            // Assert
            Assert.AreEqual(expectedResult, actualResult1, $"Incorrect number of bits flipped to convert {a} to {b}.");
            Assert.AreEqual(expectedResult, actualResult2, $"Incorrect number of bits flipped to convert {a} to {b} - XOR.");
        }
    }
}
