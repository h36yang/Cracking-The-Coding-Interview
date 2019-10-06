using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_12_Test
    {
        [DataTestMethod]
        [DataRow(18, 3)]
        [DataRow(11, 2)]
        [DataRow(10, 1)]
        [DataRow(8, 3)]
        [DataRow(7, 2)]
        [DataRow(6, 2)]
        [DataRow(3, 3)]
        [DataRow(1, 2)]
        public void CountPathsWithSumTest(int testSum, int expectedCount)
        {
            // Arrange
            var root = new BinaryTreeNode<int>(10)
            {
                Left = new BinaryTreeNode<int>(5)
                {
                    Left = new BinaryTreeNode<int>(3)
                    {
                        Left = new BinaryTreeNode<int>(3),
                        Right = new BinaryTreeNode<int>(-2)
                    },
                    Right = new BinaryTreeNode<int>(2)
                    {
                        Right = new BinaryTreeNode<int>(1)
                    }
                },
                Right = new BinaryTreeNode<int>(-3)
                {
                    Right = new BinaryTreeNode<int>(11)
                }
            };

            // Act
            int resultCount1 = Question_4_12.CountPathsWithSum(root, testSum);
            int resultCount2 = Question_4_12.CountPathsWithSumOptimized(root, testSum);

            // Assert
            Assert.AreEqual(expectedCount, resultCount1, "Count 1 is incorrect.");
            Assert.AreEqual(expectedCount, resultCount2, "Count 2 is incorrect - optimized method.");
        }
    }
}
