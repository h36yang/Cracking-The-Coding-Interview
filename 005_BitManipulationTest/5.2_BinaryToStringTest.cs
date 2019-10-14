using _005_BitManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _005_BitManipulationTest
{
    [TestClass]
    public class Question_5_2_Test
    {
        [DataTestMethod]
        [DataRow(0.72, "ERROR")]
        [DataRow(0.893, "ERROR")]
        [DataRow(1.2, "ERROR")]
        [DataRow(-0.2, "ERROR")]
        [DataRow(0.5, ".1")]
        [DataRow(0.625, ".101")]
        [DataRow(0.40625, ".01101")]
        public void BinaryToStringTest(double testNumber, string expectedString)
        {
            // Act
            string resultString = Question_5_2.BinaryToString(testNumber);

            // Assert
            Assert.AreEqual(expectedString, resultString, $"Failed to format number {testNumber} as binary string.");
        }
    }
}
