using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_6_Test
    {
        [TestMethod]
        public void FindSuccessorNodeTest()
        {
            // Arrange
            var node1 = new BinaryTreeNode<int>(3);
            var node2 = new BinaryTreeNode<int>(5);
            var node3 = new BinaryTreeNode<int>(7);
            var node4 = new BinaryTreeNode<int>(10);
            var node5 = new BinaryTreeNode<int>(12);
            var node6 = new BinaryTreeNode<int>(15);
            var node7 = new BinaryTreeNode<int>(17);
            var node8 = new BinaryTreeNode<int>(20);
            var node9 = new BinaryTreeNode<int>(30);

            node8.Left = node4; node4.Parent = node8;
            node8.Right = node9; node9.Parent = node8;
            node4.Left = node2; node2.Parent = node4;
            node4.Right = node6; node6.Parent = node4;
            node2.Left = node1; node1.Parent = node2;
            node2.Right = node3; node3.Parent = node2;
            node6.Left = node5; node5.Parent = node6;
            node6.Right = node7; node7.Parent = node6;
            Console.WriteLine("Input:");
            TestHelper.PrintBinaryTree(node8);

            // Act
            var successor1 = Question_4_6.FindSuccessorNode(node1);
            var successor2 = Question_4_6.FindSuccessorNode(node2);
            var successor3 = Question_4_6.FindSuccessorNode(node3);
            var successor4 = Question_4_6.FindSuccessorNode(node4);
            var successor5 = Question_4_6.FindSuccessorNode(node5);
            var successor6 = Question_4_6.FindSuccessorNode(node6);
            var successor7 = Question_4_6.FindSuccessorNode(node7);
            var successor8 = Question_4_6.FindSuccessorNode(node8);
            var successor9 = Question_4_6.FindSuccessorNode(node9);

            // Assert
            Assert.AreEqual(node2, successor1, "Incorrect successor node found.");
            Assert.AreEqual(node3, successor2, "Incorrect successor node found.");
            Assert.AreEqual(node4, successor3, "Incorrect successor node found.");
            Assert.AreEqual(node5, successor4, "Incorrect successor node found.");
            Assert.AreEqual(node6, successor5, "Incorrect successor node found.");
            Assert.AreEqual(node7, successor6, "Incorrect successor node found.");
            Assert.AreEqual(node8, successor7, "Incorrect successor node found.");
            Assert.AreEqual(node9, successor8, "Incorrect successor node found.");
            Assert.IsNull(successor9, "Incorrect successor node found.");
        }
    }
}
