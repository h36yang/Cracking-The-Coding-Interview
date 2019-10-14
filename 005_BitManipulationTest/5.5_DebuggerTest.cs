using _005_BitManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _005_BitManipulationTest
{
    [TestClass]
    public class Question_5_5_Test
    {
        [DataTestMethod]
        [DataRow(0, true)]
        [DataRow(1, true)]
        [DataRow(2, true)]
        [DataRow(4, true)]
        [DataRow(8, true)]
        [DataRow(16, true)]
        [DataRow(3, false)]
        [DataRow(5, false)]
        [DataRow(6, false)]
        [DataRow(7, false)]
        [DataRow(9, false)]
        [DataRow(10, false)]
        public void IsNumberPowerOfTwoTest(int testNumber, bool expectedResult)
        {
            // Act
            bool actualResult = Question_5_5.IsNumberPowerOfTwo(testNumber);

            // Assert
            Assert.AreEqual(expectedResult, actualResult, $"Failed to check if {testNumber} is power of 2.");
        }
    }
}
