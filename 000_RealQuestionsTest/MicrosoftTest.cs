using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using static _000_RealQuestions.Microsoft;

namespace _000_RealQuestionsTest
{
    [TestClass]
    public class MicrosoftTest
    {
        [TestMethod]
        public void FindPairsWithSumTest()
        {
            // Arrange
            var root = new BinaryTreeNode<int>(6);
            root.SetLeft(new BinaryTreeNode<int>(4));
            root.Left.SetLeft(new BinaryTreeNode<int>(2));
            root.Left.SetRight(new BinaryTreeNode<int>(5));
            root.Left.Left.SetLeft(new BinaryTreeNode<int>(1));
            root.Left.Left.SetRight(new BinaryTreeNode<int>(3));
            root.SetRight(new BinaryTreeNode<int>(7));
            root.Right.SetRight(new BinaryTreeNode<int>(8));

            var expected1 = new List<(int, int)> { (1, 7), (2, 6), (3, 5) };
            var expected2 = new List<(int, int)> { (1, 6), (2, 5), (3, 4) };
            var expected3 = new List<(int, int)> { (1, 5), (2, 4) };
            var expected4 = new List<(int, int)> { (5, 8), (6, 7) };

            // Act
            List<(int, int)> result1 = FindPairsWithSum(root, 8);
            List<(int, int)> result2 = FindPairsWithSum(root, 7);
            List<(int, int)> result3 = FindPairsWithSum(root, 6);
            List<(int, int)> result4 = FindPairsWithSum(root, 13);

            // Assert
            Assert.AreEqual(expected1.Count, result1.Count);
            Assert.AreEqual(expected2.Count, result2.Count);
            Assert.AreEqual(expected3.Count, result3.Count);
            Assert.AreEqual(expected4.Count, result4.Count);

            Assert.IsTrue(expected1.OrderBy(x => x.Item1).ThenBy(x => x.Item2).SequenceEqual(result1.OrderBy(x => x.Item1).ThenBy(x => x.Item2)));
            Assert.IsTrue(expected2.OrderBy(x => x.Item1).ThenBy(x => x.Item2).SequenceEqual(result2.OrderBy(x => x.Item1).ThenBy(x => x.Item2)));
            Assert.IsTrue(expected3.OrderBy(x => x.Item1).ThenBy(x => x.Item2).SequenceEqual(result3.OrderBy(x => x.Item1).ThenBy(x => x.Item2)));
            Assert.IsTrue(expected4.OrderBy(x => x.Item1).ThenBy(x => x.Item2).SequenceEqual(result4.OrderBy(x => x.Item1).ThenBy(x => x.Item2)));
        }
    }
}
