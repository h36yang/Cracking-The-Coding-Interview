using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_4_Test
    {
        [TestMethod]
        public void IsBalancedTest_ReturnTrue()
        {
            // Arrange
            var testRoot = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(4),
                    Right = new BinaryTreeNode<int>(5)
                },
                Right = new BinaryTreeNode<int>(3)
            };
            Console.WriteLine("Input:");
            TestHelper.PrintBinaryTree(testRoot);

            // Act
            bool result = Question_4_4.IsBalanced(testRoot);

            // Assert
            Assert.IsTrue(result, "IsBalanced returned False.");
        }

        [TestMethod]
        public void IsBalancedTest_ReturnFalse()
        {
            // Arrange
            var testRoot = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(4),
                    Right = new BinaryTreeNode<int>(5)
                    {
                        Left = new BinaryTreeNode<int>(6),
                        Right = new BinaryTreeNode<int>(7)
                    }
                },
                Right = new BinaryTreeNode<int>(3)
            };
            Console.WriteLine("Input:");
            TestHelper.PrintBinaryTree(testRoot);

            // Act
            bool result = Question_4_4.IsBalanced(testRoot);

            // Assert
            Assert.IsFalse(result, "IsBalanced returned True.");
        }
    }
}
