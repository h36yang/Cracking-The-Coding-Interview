using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_5_Test
    {
        [TestMethod]
        public void IsBSTTest_ReturnTrue()
        {
            // Arrange
            var testRoot = new BinaryTreeNode<int>(8)
            {
                Left = new BinaryTreeNode<int>(4)
                {
                    Left = new BinaryTreeNode<int>(2),
                    Right = new BinaryTreeNode<int>(6)
                },
                Right = new BinaryTreeNode<int>(10)
                {
                    Right = new BinaryTreeNode<int>(20)
                }
            };
            var testRoot2 = new BinaryTreeNode<int>(20)
            {
                Left = new BinaryTreeNode<int>(10)
                {
                    Left = new BinaryTreeNode<int>(5)
                    {
                        Left = new BinaryTreeNode<int>(3),
                        Right = new BinaryTreeNode<int>(7)
                    },
                    Right = new BinaryTreeNode<int>(15)
                    {
                        Right = new BinaryTreeNode<int>(17)
                    }
                },
                Right = new BinaryTreeNode<int>(30)
            };
            Console.WriteLine("Input:");
            TestHelper.PrintBinaryTree(testRoot);
            TestHelper.PrintBinaryTree(testRoot2);

            // Act
            bool result11 = Question_4_5.IsBST(testRoot);
            bool result12 = Question_4_5.IsBST(testRoot2);
            bool result21 = Question_4_5.IsBST2(testRoot);
            bool result22 = Question_4_5.IsBST2(testRoot2);

            // Assert
            Assert.IsTrue(result11, "IsBST returned False for test data 1.");
            Assert.IsTrue(result12, "IsBST returned False for test data 2.");
            Assert.IsTrue(result21, "IsBST2 returned False for test data 1.");
            Assert.IsTrue(result22, "IsBST2 returned False for test data 2.");
        }

        [TestMethod]
        public void IsBSTTest_ReturnFalse()
        {
            // Arrange
            var testRoot = new BinaryTreeNode<int>(8)
            {
                Left = new BinaryTreeNode<int>(4)
                {
                    Left = new BinaryTreeNode<int>(2),
                    Right = new BinaryTreeNode<int>(12)
                },
                Right = new BinaryTreeNode<int>(10)
                {
                    Right = new BinaryTreeNode<int>(20)
                }
            };
            Console.WriteLine("Input:");
            TestHelper.PrintBinaryTree(testRoot);

            // Act
            bool result = Question_4_5.IsBST(testRoot);
            bool result2 = Question_4_5.IsBST2(testRoot);

            // Assert
            Assert.IsFalse(result, "IsBST returned True.");
            Assert.IsFalse(result2, "IsBST2 returned True.");
        }
    }
}
