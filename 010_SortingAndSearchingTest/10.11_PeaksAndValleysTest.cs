using _010_SortingAndSearching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace _010_SortingAndSearchingTest
{
    [TestClass]
    public class Question_10_11_Test
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 1, 3, 2 })]
        [DataRow(new int[] { 5, 3, 1, 2, 3 }, new int[] { 5, 1, 3, 2, 3 })]
        [DataRow(new int[] { 5, 8, 6, 2, 3, 4, 6 }, new int[] { 5, 8, 2, 6, 3, 6, 4 })]
        public void SortArrayWithPeaksAndValleysTest(int[] testArray, int[] expectedArray)
        {
            // Act
            Question_10_11.SortArrayWithPeaksAndValleys(testArray);

            // Assert
            Assert.IsTrue(expectedArray.SequenceEqual(testArray), "SortArrayWithPeaksAndValleys test failed.");
        }
    }
}
