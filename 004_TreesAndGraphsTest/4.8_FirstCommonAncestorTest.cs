using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_8_Test
    {
        [TestMethod]
        public void FindFirstCommonAncestorTest()
        {
            // Arrange
            var root = new BinaryTreeNode<int>(20);
            var node10 = new BinaryTreeNode<int>(10);
            var node30 = new BinaryTreeNode<int>(30);
            var node5 = new BinaryTreeNode<int>(5);
            var node15 = new BinaryTreeNode<int>(15);
            var node3 = new BinaryTreeNode<int>(3);
            var node7 = new BinaryTreeNode<int>(7);
            var node17 = new BinaryTreeNode<int>(17);

            root.Left = node10;
            root.Right = node30;
            node10.Left = node5;
            node10.Right = node15;
            node5.Left = node3;
            node5.Right = node7;
            node15.Right = node17;

            TestHelper.PrintBinaryTree(root);

            // Act
            var result10 = Question_4_8.FindFirstCommonAncestor(root, node10, node10);
            var result10_2 = Question_4_8.FindFirstCommonAncestor(root, node5, node17);
            var result10_3 = Question_4_8.FindFirstCommonAncestor(root, node3, node17);
            var resultRoot = Question_4_8.FindFirstCommonAncestor(root, node10, node30);
            var resultRoot2 = Question_4_8.FindFirstCommonAncestor(root, root, node5);
            var resultRoot3 = Question_4_8.FindFirstCommonAncestor(root, node7, node30);
            var result5 = Question_4_8.FindFirstCommonAncestor(root, node3, node7);

            // Assert
            Assert.AreEqual(node10, result10, "Incorrect first common ancestor found for nodes 10 and 10.");
            Assert.AreEqual(node10, result10_2, "Incorrect first common ancestor found for nodes 5 and 17.");
            Assert.AreEqual(node10, result10_3, "Incorrect first common ancestor found for nodes 3 and 17.");
            Assert.AreEqual(root, resultRoot, "Incorrect first common ancestor found for nodes 10 and 30.");
            Assert.AreEqual(root, resultRoot2, "Incorrect first common ancestor found for nodes 20 and 5.");
            Assert.AreEqual(root, resultRoot3, "Incorrect first common ancestor found for nodes 7 and 30.");
            Assert.AreEqual(node5, result5, "Incorrect first common ancestor found for nodes 3 and 7.");
        }

        [TestMethod]
        public void FindFirstCommonAncestorTest_InvalidCases()
        {
            // Arrange
            var root = new BinaryTreeNode<int>(20);
            var node1 = new BinaryTreeNode<int>(10);
            var node2 = new BinaryTreeNode<int>(30);
            var node3 = new BinaryTreeNode<int>(5);
            var node4 = new BinaryTreeNode<int>(15);
            var node5 = new BinaryTreeNode<int>(3);
            var node6 = new BinaryTreeNode<int>(7);
            var node7 = new BinaryTreeNode<int>(17);

            root.Left = node1;
            root.Right = node2;
            node1.Left = node3;
            node1.Right = node4;
            node3.Left = node5;
            node3.Right = node6;
            node4.Right = node7;

            TestHelper.PrintBinaryTree(root);

            // Act
            var result1 = Question_4_8.FindFirstCommonAncestor(root, node1, null);
            var result2 = Question_4_8.FindFirstCommonAncestor(root, null, node2);
            var result3 = Question_4_8.FindFirstCommonAncestor(null, node1, node2);
            var result4 = Question_4_8.FindFirstCommonAncestor(root, node1, new BinaryTreeNode<int>(0));

            // Assert
            Assert.IsNull(result1, "Test 1 failed.");
            Assert.IsNull(result2, "Test 2 failed.");
            Assert.IsNull(result3, "Test 3 failed.");
            Assert.IsNull(result4, "Test 4 failed.");
        }
    }
}
