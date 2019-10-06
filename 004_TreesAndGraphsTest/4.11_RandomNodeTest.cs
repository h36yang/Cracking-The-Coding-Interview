using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_11_Test
    {
        [TestMethod]
        public void GetRandomNodeTest()
        {
            // Arrange 1
            var bst = new Question_4_11.MyBinarySearchTree();
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);
            bst.Insert(8);
            bst.Insert(6);
            bst.Insert(20);
            Console.WriteLine("Initial Tree:");
            TestHelper.PrintBinaryTree(bst.Root);

            // Act 1
            BinaryTreeNode<int> randomNode1 = bst.GetRandomNode();
            BinaryTreeNode<int> randomNode2 = bst.GetRandomNode();
            BinaryTreeNode<int> randomNode3 = bst.GetRandomNode();
            BinaryTreeNode<int> randomNode4 = bst.GetRandomNodeAlt();
            BinaryTreeNode<int> randomNode5 = bst.GetRandomNodeAlt();
            BinaryTreeNode<int> randomNode6 = bst.GetRandomNodeAlt();
            Console.WriteLine("Randomly Selected Nodes:");
            Console.WriteLine(randomNode1);
            Console.WriteLine(randomNode2);
            Console.WriteLine(randomNode3);
            Console.WriteLine(randomNode4);
            Console.WriteLine(randomNode5);
            Console.WriteLine(randomNode6);

            // Assert 1
            Assert.AreEqual(bst.Find(randomNode1.Data), randomNode1, $"Random node 1 with value {randomNode1} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode2.Data), randomNode2, $"Random node 2 with value {randomNode2} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode3.Data), randomNode3, $"Random node 3 with value {randomNode3} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode4.Data), randomNode4, $"Random node 4 with value {randomNode4} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode5.Data), randomNode5, $"Random node 5 with value {randomNode5} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode6.Data), randomNode6, $"Random node 6 with value {randomNode6} not in the tree.");

            // Arrange 2
            bst.Delete(5);
            bst.Delete(15);
            Console.WriteLine("Second Tree:");
            TestHelper.PrintBinaryTree(bst.Root);

            // Act 2
            BinaryTreeNode<int> findNode5 = bst.Find(5);
            BinaryTreeNode<int> findNode15 = bst.Find(15);
            BinaryTreeNode<int> findNode3 = bst.Find(3);
            BinaryTreeNode<int> findNode6 = bst.Find(6);
            BinaryTreeNode<int> findNode8 = bst.Find(8);
            BinaryTreeNode<int> findNode20 = bst.Find(20);
            randomNode1 = bst.GetRandomNode();
            randomNode2 = bst.GetRandomNode();
            randomNode3 = bst.GetRandomNode();
            randomNode4 = bst.GetRandomNodeAlt();
            randomNode5 = bst.GetRandomNodeAlt();
            randomNode6 = bst.GetRandomNodeAlt();
            Console.WriteLine("Randomly Selected Nodes:");
            Console.WriteLine(randomNode1);
            Console.WriteLine(randomNode2);
            Console.WriteLine(randomNode3);
            Console.WriteLine(randomNode4);
            Console.WriteLine(randomNode5);
            Console.WriteLine(randomNode6);

            // Assert 2
            Assert.IsNull(findNode5, "Node 5 should have been deleted.");
            Assert.IsNull(findNode15, "Node 15 should have been deleted.");
            Assert.AreEqual(3, findNode3.Data, "Node 3 is found correctly.");
            Assert.AreEqual(6, findNode6.Data, "Node 6 is found correctly.");
            Assert.AreEqual(8, findNode8.Data, "Node 8 is found correctly.");
            Assert.AreEqual(20, findNode20.Data, "Node 20 is found correctly.");
            Assert.AreEqual(bst.Find(randomNode1.Data), randomNode1, $"Random node 1 with value {randomNode1} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode2.Data), randomNode2, $"Random node 2 with value {randomNode2} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode3.Data), randomNode3, $"Random node 3 with value {randomNode3} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode4.Data), randomNode4, $"Random node 4 with value {randomNode4} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode5.Data), randomNode5, $"Random node 5 with value {randomNode5} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode6.Data), randomNode6, $"Random node 6 with value {randomNode6} not in the tree.");

            // Arrange 3
            bst.Delete(10);
            Console.WriteLine("Third Tree:");
            TestHelper.PrintBinaryTree(bst.Root);

            // Act 3
            BinaryTreeNode<int> findNode10 = bst.Find(10);
            findNode3 = bst.Find(3);
            findNode6 = bst.Find(6);
            findNode8 = bst.Find(8);
            findNode20 = bst.Find(20);
            randomNode1 = bst.GetRandomNode();
            randomNode2 = bst.GetRandomNode();
            randomNode3 = bst.GetRandomNode();
            randomNode4 = bst.GetRandomNodeAlt();
            randomNode5 = bst.GetRandomNodeAlt();
            randomNode6 = bst.GetRandomNodeAlt();
            Console.WriteLine("Randomly Selected Nodes:");
            Console.WriteLine(randomNode1);
            Console.WriteLine(randomNode2);
            Console.WriteLine(randomNode3);
            Console.WriteLine(randomNode4);
            Console.WriteLine(randomNode5);
            Console.WriteLine(randomNode6);

            // Assert 3
            Assert.IsNull(findNode10, "Node 10 should have been deleted.");
            Assert.AreEqual(3, findNode3.Data, "Node 3 is found correctly.");
            Assert.AreEqual(6, findNode6.Data, "Node 6 is found correctly.");
            Assert.AreEqual(8, findNode8.Data, "Node 8 is found correctly.");
            Assert.AreEqual(20, findNode20.Data, "Node 20 is found correctly.");
            Assert.AreEqual(bst.Find(randomNode1.Data), randomNode1, $"Random node 1 with value {randomNode1} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode2.Data), randomNode2, $"Random node 2 with value {randomNode2} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode3.Data), randomNode3, $"Random node 3 with value {randomNode3} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode4.Data), randomNode4, $"Random node 4 with value {randomNode4} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode5.Data), randomNode5, $"Random node 5 with value {randomNode5} not in the tree.");
            Assert.AreEqual(bst.Find(randomNode6.Data), randomNode6, $"Random node 6 with value {randomNode6} not in the tree.");
        }

        [DataTestMethod]
        [DataRow(100000)]
        [DataRow(1000000)]
        public void GetRandomNodeDistributionTest(int totalTestNumber)
        {
            // Arrange
            var bst = new Question_4_11.MyBinarySearchTree();
            bst.Insert(10);
            bst.Insert(5);
            bst.Insert(15);
            bst.Insert(3);
            bst.Insert(8);
            bst.Insert(6);
            bst.Insert(20);
            Console.WriteLine("Tree:");
            TestHelper.PrintBinaryTree(bst.Root);

            var distributionMap = new Dictionary<int, (int, int)>()
            {
                { 3, (0, 0) },
                { 5, (0, 0) },
                { 6, (0, 0) },
                { 8, (0, 0) },
                { 10, (0, 0) },
                { 15, (0, 0) },
                { 20, (0, 0) }
            };

            // Act & Assert
            BinaryTreeNode<int> randomNode;
            BinaryTreeNode<int> randomNodeAlt;
            for (int i = 0; i < totalTestNumber; i++)
            {
                randomNode = bst.GetRandomNode();
                randomNodeAlt = bst.GetRandomNodeAlt();
                Assert.AreEqual(bst.Find(randomNode.Data), randomNode, $"Random node with value {randomNode} not in the tree.");
                Assert.AreEqual(bst.Find(randomNodeAlt.Data), randomNodeAlt, $"Random node with value {randomNodeAlt} not in the tree.");
                distributionMap[randomNode.Data] = (distributionMap[randomNode.Data].Item1 + 1, distributionMap[randomNode.Data].Item2);
                distributionMap[randomNodeAlt.Data] = (distributionMap[randomNodeAlt.Data].Item1, distributionMap[randomNodeAlt.Data].Item2 + 1);
            }

            // Print Distribution
            Console.WriteLine("Random Nodes Distribution:");
            foreach (KeyValuePair<int, (int, int)> pair in distributionMap)
            {
                Console.WriteLine($"Node {pair.Key} randomly selected {(double)pair.Value.Item1 / totalTestNumber * 100}% by Method 1 and {(double)pair.Value.Item2 / totalTestNumber * 100}% by Method 2");
            }
        }
    }
}
