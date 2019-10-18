using _005_BitManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace _005_BitManipulationTest
{
    [TestClass]
    public class Question_5_8_Test
    {
        [DataTestMethod]
        [DataRow(3, 13, 0, new byte[] { 0b_0001_1111, 0b_1111_1100, 0, 0, 0, 0, 0, 0, 0 })]
        [DataRow(3, 13, 1, new byte[] { 0, 0, 0, 0b_0001_1111, 0b_1111_1100, 0, 0, 0, 0 })]
        [DataRow(3, 17, 2, new byte[] { 0, 0, 0, 0, 0, 0, 0b_0001_1111, 0b_1111_1111, 0b_1100_0000 })]
        [DataRow(3, 5, 2, new byte[] { 0, 0, 0, 0, 0, 0, 0b_0001_1100, 0, 0 })]
        public void DrawLineTest(int x1, int x2, int y, byte[] expectedScreen)
        {
            // Arrange
            var screen = new byte[9];
            int width = 24;

            // Act
            Question_5_8.DrawLine(screen, width, x1, x2, y);

            // Assert
            Assert.IsTrue(expectedScreen.SequenceEqual(screen), "Draw line test failed.");
        }

        [DataTestMethod]
        [DataRow(new byte[] { 0 }, 7, 0, 0, 0, "Incompatible screen array length 8 and width 7.")]
        [DataRow(new byte[] { 0 }, 16, 0, 0, 0, "Incompatible screen array length 8 and width 16.")]
        [DataRow(new byte[] { 0 }, 8, -1, 0, 0, "x1")]
        [DataRow(new byte[] { 0 }, 8, 8, 0, 0, "x1")]
        [DataRow(new byte[] { 0 }, 8, 0, -1, 0, "x2")]
        [DataRow(new byte[] { 0 }, 8, 0, 8, 0, "x2")]
        [DataRow(new byte[] { 0 }, 8, 0, 0, -1, "y")]
        [DataRow(new byte[] { 0 }, 8, 0, 0, 1, "y")]
        [DataRow(new byte[] { 0 }, 8, 2, 1, 0, "x2 cannot be smaller than x1.")]
        public void DrawLineTest_InvalidInputs(byte[] screen, int width, int x1, int x2, int y, string exception)
        {
            try
            {
                // Act
                Question_5_8.DrawLine(screen, width, x1, x2, y);

                // Assert
                Assert.Fail("Validate input parameters failed.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                // Assert
                Assert.AreEqual(exception, e.ParamName);
            }
            catch (ArgumentException e)
            {
                // Assert
                Assert.AreEqual(exception, e.Message);
            }
        }
    }
}
