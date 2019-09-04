using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _001_ArraysAndStringsTest
{
    public class TestHelper
    {
        public static T[,] GenerateMatrix<T>(int rows, int cols, T value)
        {
            var matrix = new T[rows, cols];
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    matrix[x, y] = value;
                }
            }
            return matrix;
        }

        public static void AssertMatricesAreEqual(int[,] expectedMatrix, int[,] actualMatrix)
        {
            Assert.AreEqual(expectedMatrix.GetLength(0), actualMatrix.GetLength(0), "Matrices have different number of rows.");
            Assert.AreEqual(expectedMatrix.GetLength(1), actualMatrix.GetLength(1), "Matrices have different number of columns.");

            for (int x = 0; x < expectedMatrix.GetLength(0); x++)
            {
                for (int y = 0; y < expectedMatrix.GetLength(1); y++)
                {
                    Assert.AreEqual(expectedMatrix[x, y], actualMatrix[x, y], $"Values are not equal at location ({x}, {y}).");
                }
            }
        }
    }
}
