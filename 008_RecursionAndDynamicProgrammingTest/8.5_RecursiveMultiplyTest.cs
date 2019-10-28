using _008_RecursionAndDynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_5_Test
    {
        private static Random _randomGenerator;

        [TestInitialize]
        public void Initialize()
        {
            if (_randomGenerator == null)
            {
                _randomGenerator = new Random();
            }
        }

        [TestMethod]
        public void MultiplyTest()
        {
            int tests = 1000;
            for (int i = 1; i <= tests; i++)
            {
                // Arrange
                var num1 = (uint)_randomGenerator.Next(tests);
                var num2 = (uint)_randomGenerator.Next(tests * tests);
                uint expected = num1 * num2;

                // Act
                uint result = Question_8_5.Multiply(num1, num2);

                // Assert
                Assert.AreEqual(expected, result, $"Multiply test failed - iteration {i}.");
            }
        }
    }
}
