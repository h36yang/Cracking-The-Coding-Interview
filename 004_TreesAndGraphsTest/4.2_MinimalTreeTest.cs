using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_2_Test
    {
        [DataTestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 2, 2)]
        [DataRow(new int[] { 1, 2, 3, 4 }, 2, 3)]
        [DataRow(new int[] { 1, 2, 3, 4, 5 }, 3, 3)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 }, 3, 3)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 4, 3)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 6, 4)]
        public void CreateMinimalHeightBSTTest(int[] testArray, int expectedRootNode, int expectedHeight)
        {
            // Act
            BinaryTreeNode<int> resultTree = Question_4_2.CreateMinimalHeightBST(testArray);
            Helper.PrintBinaryTree(resultTree);
            List<int> resultTreeInOrder = resultTree.ToListInOrder();

            // Assert
            Assert.AreEqual(expectedRootNode, resultTree.Data, "Incorrect root node returned.");
            Assert.AreEqual(expectedHeight, resultTree.Height, "Incorrect height returned.");
            Assert.AreEqual(testArray.Length, resultTreeInOrder.Count, "Incorrect number of nodes returned.");
            for (int i = 0; i < testArray.Length; i++)
            {
                Assert.AreEqual(testArray[i], resultTreeInOrder[i], $"Element at index {i} does not match.");
            }
        }
    }
}
