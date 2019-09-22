using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_3_Test
    {
        [TestMethod]
        public void CreateListOfDepthsBFSTest()
        {
            // Arrange
            var testRoot = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Right = new BinaryTreeNode<int>(4)
                    {
                        Left = new BinaryTreeNode<int>(6)
                        {
                            Left = new BinaryTreeNode<int>(8)
                        },
                        Right = new BinaryTreeNode<int>(7)
                        {
                            Left = new BinaryTreeNode<int>(9),
                            Right = new BinaryTreeNode<int>(10)
                        }
                    }
                },
                Right = new BinaryTreeNode<int>(3)
                {
                    Right = new BinaryTreeNode<int>(5)
                }
            };
            var expectedList = new List<LinkedList<int>>()
            {
                new LinkedList<int>(new int[] { 1 }),
                new LinkedList<int>(new int[] { 2, 3 }),
                new LinkedList<int>(new int[] { 4, 5 }),
                new LinkedList<int>(new int[] { 6, 7 }),
                new LinkedList<int>(new int[] { 8, 9, 10 })
            };
            Console.WriteLine("Input:");
            Helper.PrintBinaryTree(testRoot);

            // Act
            var resultList = Question_4_3.CreateListOfDepthsBFS(testRoot);

            // Assert
            Console.WriteLine("Output:");
            Assert.AreEqual(expectedList.Count, resultList.Count, "Lists counts mismatch.");
            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.AreEqual(expectedList[i].Count, resultList[i].Count, $"Linked Lists counts mismatch at Depth {i}.");
                LinkedListNode<int> tempExpected = expectedList[i].First;
                LinkedListNode<int> tempResult = resultList[i].First;
                while (tempExpected != null)
                {
                    Console.Write($"{tempResult.Value} ");
                    Assert.AreEqual(tempExpected.Value, tempResult.Value, "Linked Lists nodes do not match.");
                    tempExpected = tempExpected.Next;
                    tempResult = tempResult.Next;
                }
                Console.WriteLine();
            }
        }

        [TestMethod]
        public void CreateListOfDepthsDFSTest()
        {
            // Arrange
            var testRoot = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Right = new BinaryTreeNode<int>(4)
                    {
                        Left = new BinaryTreeNode<int>(6)
                        {
                            Left = new BinaryTreeNode<int>(8)
                        },
                        Right = new BinaryTreeNode<int>(7)
                        {
                            Left = new BinaryTreeNode<int>(9),
                            Right = new BinaryTreeNode<int>(10)
                        }
                    }
                },
                Right = new BinaryTreeNode<int>(3)
                {
                    Right = new BinaryTreeNode<int>(5)
                }
            };
            var expectedList = new List<LinkedList<int>>()
            {
                new LinkedList<int>(new int[] { 1 }),
                new LinkedList<int>(new int[] { 2, 3 }),
                new LinkedList<int>(new int[] { 4, 5 }),
                new LinkedList<int>(new int[] { 6, 7 }),
                new LinkedList<int>(new int[] { 8, 9, 10 })
            };
            Console.WriteLine("Input:");
            Helper.PrintBinaryTree(testRoot);

            // Act
            var resultList = Question_4_3.CreateListOfDepthsDFS(testRoot);

            // Assert
            Console.WriteLine("Output:");
            Assert.AreEqual(expectedList.Count, resultList.Count, "Lists counts mismatch.");
            for (int i = 0; i < expectedList.Count; i++)
            {
                Assert.AreEqual(expectedList[i].Count, resultList[i].Count, $"Linked Lists counts mismatch at Depth {i}.");
                LinkedListNode<int> tempExpected = expectedList[i].First;
                LinkedListNode<int> tempResult = resultList[i].First;
                while (tempExpected != null)
                {
                    Console.Write($"{tempResult.Value} ");
                    Assert.AreEqual(tempExpected.Value, tempResult.Value, "Linked Lists nodes do not match.");
                    tempExpected = tempExpected.Next;
                    tempResult = tempResult.Next;
                }
                Console.WriteLine();
            }
        }
    }
}
