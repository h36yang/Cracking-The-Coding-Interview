using _016_Moderate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _016_ModerateTest
{
    [TestClass]
    public class Question_16_01_Test
    {
        [DataTestMethod]
        [DataRow(1, 2, 2, 1)]
        [DataRow(2, 1, 1, 2)]
        [DataRow(3, 10, 10, 3)]
        [DataRow(5, -4, -4, 5)]
        public void SwapNumberTest(int testNum1, int testNum2, int expectedNum1, int expectedNum2)
        {
            // Act
            Question_16_01.SwapNumber(ref testNum1, ref testNum2);

            // Assert
            Assert.AreEqual(expectedNum1, testNum1, "Num1 is incorrect.");
            Assert.AreEqual(expectedNum2, testNum2, "Num2 is incorrect.");
        }
    }
}
