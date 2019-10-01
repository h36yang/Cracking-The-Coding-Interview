using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_9_Test
    {
        [TestMethod]
        public void GeneratePossibleArraysTest()
        {
            // Arrange
            var root = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(1)
                    {
                        Left = new BinaryTreeNode<int>(0)
                    },
                    Right = new BinaryTreeNode<int>(3)
                },
                Right = new BinaryTreeNode<int>(5)
                {
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            Console.WriteLine("Input:");
            TestHelper.PrintBinaryTree(root);

            // Act
            List<LinkedList<int>> resultArrays = Question_4_9.GeneratePossibleArrays(root);

            // Assert
            Assert.AreEqual(45, resultArrays.Count, "Total number of possible arrays generated does not match.");
            Console.WriteLine("Output:");
            foreach (LinkedList<int> array in resultArrays)
            {
                TestHelper.PrintCollection(array);
                Assert.AreEqual(7, array.Count, "Total elements in each array generated does not match.");
                Assert.AreEqual(4, array.First.Value, "First element in each array generated does not match.");
            }
        }
    }
}
