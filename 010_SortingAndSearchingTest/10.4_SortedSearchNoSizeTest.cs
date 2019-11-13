using Microsoft.VisualStudio.TestTools.UnitTesting;
using static _010_SortingAndSearching.Question_10_4;

namespace _010_SortingAndSearchingTest
{
    [TestClass]
    public class Question_10_4_Test
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 3, 4, 5, 7, 10, 14, 15, 16, 19, 20, 25 }, 4, 2)]
        [DataRow(new int[] { 1, 3, 4, 5, 7, 10, 14, 15, 16, 19, 20, 25 }, 25, 11)]
        [DataRow(new int[] { 1, 3, 4, 5, 7, 10, 14, 15, 16, 19, 20, 25 }, 10, 5)]
        [DataRow(new int[] { 2, 2, 2, 2, 3 }, 3, 4)]
        public void SearchWithNoSizeTest(int[] testArray, int testItem, int expectedIndex)
        {
            // Arrange
            var testListy = new Listy(testArray);

            // Act
            int resultIndex = SearchWithNoSize(testListy, testItem);

            // Assert
            Assert.AreEqual(expectedIndex, resultIndex, "SearchWithNoSize test failed.");
        }
    }
}
