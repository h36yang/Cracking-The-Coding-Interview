using _010_SortingAndSearching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _010_SortingAndSearchingTest
{
    [TestClass]
    public class Question_10_3_Test
    {
        [DataTestMethod]
        [DataRow(null, 0, -1)]
        [DataRow(new int[0], 1, -1)]
        [DataRow(new int[] { 5, 7, 10, 14, 15, 16, 19, 20, 25, 1, 3, 4 }, 4, 11)]
        [DataRow(new int[] { 5, 7, 10, 14, 15, 16, 19, 20, 25, 1, 3, 4 }, 5, 0)]
        [DataRow(new int[] { 5, 7, 10, 14, 15, 16, 19, 20, 25, 1, 3, 4 }, 1, 9)]
        [DataRow(new int[] { 15, 16, 19, 20, 25, 1, 3, 4, 5, 7, 10, 14 }, 5, 8)]
        [DataRow(new int[] { 25, 1, 3, 4, 5, 7, 10, 14, 15, 16, 19, 20 }, 25, 0)]
        [DataRow(new int[] { 2, 2, 2, 2, 3, 4 }, 4, 5)]
        [DataRow(new int[] { 2, 2, 2, 3, 4, 2 }, 4, 4)]
        public void SearchRotatedTest(int[] testArray, int testItem, int expectedIndex)
        {
            // Act
            int resultIndex = Question_10_3.SearchRotated(testArray, testItem);

            // Assert
            Assert.AreEqual(expectedIndex, resultIndex, "SearchRotated test failed.");
        }
    }
}
