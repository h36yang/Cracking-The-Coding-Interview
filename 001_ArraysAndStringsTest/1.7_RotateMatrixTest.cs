using _001_ArraysAndStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _001_ArraysAndStringsTest
{
    [TestClass]
    public class Question_1_7_Test
    {
        [TestMethod]
        public void RotateMatrixTest_2x2()
        {
            int[,] testMatrix = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };
            int[,] expectedMatrix = new int[2, 2]
            {
                { 2, 4 },
                { 1, 3 }
            };

            int[,] resultMatrix = Question_1_7.RotateMatrix(testMatrix);
            AssertMatricesAreEqual(expectedMatrix, resultMatrix);
        }

        [TestMethod]
        public void RotateMatrixInplaceTest_2x2()
        {
            int[,] testMatrix = new int[2, 2]
            {
                { 1, 2 },
                { 3, 4 }
            };
            int[,] expectedMatrix = new int[2, 2]
            {
                { 2, 4 },
                { 1, 3 }
            };

            Question_1_7.RotateMatrixInplace(testMatrix);
            AssertMatricesAreEqual(expectedMatrix, testMatrix);
        }

        [TestMethod]
        public void RotateMatrixTest_3x3()
        {
            int[,] testMatrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int[,] expectedMatrix = new int[3, 3]
            {
                { 3, 6, 9 },
                { 2, 5, 8 },
                { 1, 4, 7 }
            };

            int[,] resultMatrix = Question_1_7.RotateMatrix(testMatrix);
            AssertMatricesAreEqual(expectedMatrix, resultMatrix);
        }

        [TestMethod]
        public void RotateMatrixInplaceTest_3x3()
        {
            int[,] testMatrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int[,] expectedMatrix = new int[3, 3]
            {
                { 3, 6, 9 },
                { 2, 5, 8 },
                { 1, 4, 7 }
            };

            Question_1_7.RotateMatrixInplace(testMatrix);
            AssertMatricesAreEqual(expectedMatrix, testMatrix);
        }

        [TestMethod]
        public void RotateMatrixTest_4x4()
        {
            int[,] testMatrix = new int[4, 4]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };
            int[,] expectedMatrix = new int[4, 4]
            {
                { 4, 8, 12, 16 },
                { 3, 7, 11, 15 },
                { 2, 6, 10, 14 },
                { 1, 5, 9, 13 }
            };

            int[,] resultMatrix = Question_1_7.RotateMatrix(testMatrix);
            AssertMatricesAreEqual(expectedMatrix, resultMatrix);
        }

        [TestMethod]
        public void RotateMatrixInplaceTest_4x4()
        {
            int[,] testMatrix = new int[4, 4]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };
            int[,] expectedMatrix = new int[4, 4]
            {
                { 4, 8, 12, 16 },
                { 3, 7, 11, 15 },
                { 2, 6, 10, 14 },
                { 1, 5, 9, 13 }
            };

            Question_1_7.RotateMatrixInplace(testMatrix);
            AssertMatricesAreEqual(expectedMatrix, testMatrix);
        }

        private void AssertMatricesAreEqual(int[,] expectedMatrix, int[,] actualMatrix)
        {
            for (int x = 0; x < expectedMatrix.GetLength(0); x++)
            {
                for (int y = 0; y < expectedMatrix.GetLength(1); y++)
                {
                    Assert.AreEqual(expectedMatrix[x, y], actualMatrix[x, y], $"Value {expectedMatrix[x, y]} and {actualMatrix[x, y]} are not equal at location ({x}, {y}).");
                }
            }
        }
    }
}
