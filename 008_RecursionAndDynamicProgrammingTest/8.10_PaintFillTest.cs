using Microsoft.VisualStudio.TestTools.UnitTesting;
using static _008_RecursionAndDynamicProgramming.Question_8_10;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_10_Test
    {
        [DataTestMethod]
        [DataRow(2, 4, Color.Red, 1)]
        [DataRow(0, 0, Color.Yellow, 2)]
        [DataRow(1, 3, Color.Yellow, 2)]
        [DataRow(1, 3, Color.Black, 3)]
        [DataRow(-1, 3, Color.Blue, 3)]
        [DataRow(0, -2, Color.Blue, 3)]
        [DataRow(2, 6, Color.Blue, 3)]
        [DataRow(9, 2, Color.Blue, 3)]
        public void PaintFillTest(int x, int y, Color newColor, int testCase)
        {
            // Arrange
            var screen = new Color[,]
            {
                { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black }
            };

            var expectedScreen = GenerateExpectedScreen(testCase);

            // Act
            PaintFill(screen, x, y, newColor);

            // Assert
            TestHelper.AssertMatricesAreEqual(expectedScreen, screen);
        }

        private Color[,] GenerateExpectedScreen(int testCase)
        {
            if (testCase == 1)
            {
                return new Color[,]
                {
                    { Color.Black, Color.Black, Color.Red, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Red, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Red, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Red, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Red, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Red, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Red, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Red, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Red, Color.Red, Color.Yellow, Color.Black }
                };
            }
            else if (testCase == 2)
            {
                return new Color[,]
                {
                    { Color.Yellow, Color.Yellow, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Yellow, Color.Yellow, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Yellow, Color.Yellow, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Yellow, Color.Yellow, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Yellow, Color.Yellow, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Yellow, Color.Yellow, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Yellow, Color.Yellow, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Yellow, Color.Yellow, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Yellow, Color.Yellow, Color.Blue, Color.Red, Color.Yellow, Color.Black }
                };
            }
            else if (testCase == 3)
            {
                return new Color[,]
                {
                    { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black },
                    { Color.Black, Color.Black, Color.Blue, Color.Red, Color.Yellow, Color.Black }
                };
            }
            return null;
        }
    }
}
