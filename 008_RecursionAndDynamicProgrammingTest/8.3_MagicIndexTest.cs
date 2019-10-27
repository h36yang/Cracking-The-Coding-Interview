using _008_RecursionAndDynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_3_Test
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, -1)]
        [DataRow(new int[] { -1, 0, 1, 2, 3, 4 }, -1)]
        [DataRow(new int[] { -1, 1, 3, 4, 5, 6 }, 1)]
        [DataRow(new int[] { -2, -1, 0, 2, 4, 5 }, 4)]
        [DataRow(new int[] { -40, -20, -1, 1, 2, 3, 5, 7, 9, 12, 13 }, 7)]
        public void FindMagicIndexDistinctTest(int[] testArray, int expectedIndex)
        {
            // Act
            int resultIndex = Question_8_3.FindMagicIndexDistinct(testArray);

            // Assert
            Assert.AreEqual(expectedIndex, resultIndex);
        }

        [DataTestMethod]
        [DataRow(new int[] { -1, 0, 0, 2, 5, 6 }, -1)]
        [DataRow(new int[] { 0, 0, 0, 2, 4, 5 }, 0)]
        [DataRow(new int[] { 1, 1, 1, 2, 4, 5 }, 1)]
        [DataRow(new int[] { -1, 0, 0, 2, 4, 5 }, 4)]
        [DataRow(new int[] { -10, -5, 2, 2, 2, 3, 4, 7, 9, 12, 13 }, 2)]
        public void FindMagicIndexNotDistinctTest(int[] testArray, int expectedIndex)
        {
            // Act
            int resultIndex = Question_8_3.FindMagicIndexNotDistinct(testArray);

            // Assert
            Assert.AreEqual(expectedIndex, resultIndex);
        }
    }
}
