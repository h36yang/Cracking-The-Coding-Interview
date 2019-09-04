using _001_ArraysAndStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _001_ArraysAndStringsTest
{
    [TestClass]
    public class Question_1_8_Test
    {
        [TestMethod]
        public void ZeroMatrixTest_3x3()
        {
            int[,] testMatrix = new int[3, 3]
            {
                { 1, 0, 1 },
                { 1, 1, 1 },
                { 0, 1, 1 }
            };
            int[,] expectedMatrix = new int[3, 3]
            {
                { 0, 0, 0 },
                { 0, 0, 1 },
                { 0, 0, 0 }
            };

            // Question_1_8.ZeroMatrix(testMatrix);
            Question_1_8.ZeroMatrixMemoryImproved(testMatrix);
            TestHelper.AssertMatricesAreEqual(expectedMatrix, testMatrix);
        }

        [TestMethod]
        public void ZeroMatrixTest_3x4()
        {
            int[,] testMatrix = new int[3, 4]
            {
                { 1, 1, 1, 1 },
                { 1, 0, 1, 0 },
                { 1, 1, 1, 1 }
            };
            int[,] expectedMatrix = new int[3, 4]
            {
                { 1, 0, 1, 0 },
                { 0, 0, 0, 0 },
                { 1, 0, 1, 0 }
            };

            // Question_1_8.ZeroMatrix(testMatrix);
            Question_1_8.ZeroMatrixMemoryImproved(testMatrix);
            TestHelper.AssertMatricesAreEqual(expectedMatrix, testMatrix);
        }

        [TestMethod]
        public void ZeroMatrixTest_4x4()
        {
            int[,] testMatrix = new int[4, 4]
            {
                { 1, 1, 1, 1 },
                { 1, 0, 1, 1 },
                { 1, 0, 1, 1 },
                { 1, 1, 1, 0 }
            };
            int[,] expectedMatrix = new int[4, 4]
            {
                { 1, 0, 1, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };

            // Question_1_8.ZeroMatrix(testMatrix);
            Question_1_8.ZeroMatrixMemoryImproved(testMatrix);
            TestHelper.AssertMatricesAreEqual(expectedMatrix, testMatrix);
        }
    }
}
