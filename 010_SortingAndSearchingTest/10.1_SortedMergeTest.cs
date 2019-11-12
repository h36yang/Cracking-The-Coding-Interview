using _010_SortingAndSearching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace _010_SortingAndSearchingTest
{
    [TestClass]
    public class Question_10_1_Test
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 3, 5, 7, 0, 0, 0 }, new int[] { 2, 4, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [DataRow(new int[] { 4, 5, 6, 7, 0, 0, 0 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [DataRow(new int[] { 1, 2, 3, 4, 0, 0, 0 }, new int[] { 5, 6, 7 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [DataRow(new int[] { 1, 2, 3, 4, 0, 0, 0 }, new int[] { 1, 2, 3 }, new int[] { 1, 1, 2, 2, 3, 3, 4 })]
        public void MergeSortedTest(int[] testA, int[] testB, int[] expectedA)
        {
            // Act
            Question_10_1.MergeSorted(testA, testB);

            // Assert
            Assert.IsTrue(expectedA.SequenceEqual(testA), "MergeSorted test failed.");
        }
    }
}
