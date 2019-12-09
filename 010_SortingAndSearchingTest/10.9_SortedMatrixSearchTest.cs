using _010_SortingAndSearching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _010_SortingAndSearchingTest
{
    [TestClass]
    public class Question_10_9_Test
    {
        [DataTestMethod]
        [DataRow(0, -1, -1)]
        [DataRow(30, 2, 0)]
        [DataRow(55, 2, 1)]
        [DataRow(85, 0, 3)]
        [DataRow(100, 3, 2)]
        public void FindElementInSortedMatrixTest(int testElement, int expectedRow, int expectedCol)
        {
            // Arrange
            var testMatrix = new int[,]
            {
                { 15, 20, 40, 85 },
                { 20, 35, 80, 95 },
                { 30, 55, 95, 105 },
                { 40, 80, 100, 120 }
            };

            // Act
            (int resultRow, int resultCol) = Question_10_9.FindElementInSortedMatrix(testMatrix, testElement);

            // Assert
            Assert.AreEqual(expectedRow, resultRow, "Row number not equal.");
            Assert.AreEqual(expectedCol, resultCol, "Column number not equal.");
        }
    }
}
