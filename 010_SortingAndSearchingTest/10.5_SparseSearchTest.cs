using _010_SortingAndSearching;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _010_SortingAndSearchingTest
{
    [TestClass]
    public class Question_10_5_Test
    {
        [DataTestMethod]
        [DataRow(null, "test", -1)]
        [DataRow(new string[0], "test", -1)]
        [DataRow(new string[] { "test" }, "", -1)]
        [DataRow(new string[] { "test" }, "not_exist", -1)]
        [DataRow(new string[] { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" }, "ball", 4)]
        [DataRow(new string[] { "", "at", "", "", "", "", "", "", "", "", "", "", "" }, "at", 1)]
        [DataRow(new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "" }, "anything", -1)]
        public void SearchSparseTest(string[] testArray, string testItem, int expectedIndex)
        {
            // Act
            int resultIndex = Question_10_5.SearchSparse(testArray, testItem);

            // Assert
            Assert.AreEqual(expectedIndex, resultIndex, "SearchSparse test failed.");
        }
    }
}
