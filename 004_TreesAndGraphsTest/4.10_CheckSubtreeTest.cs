using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_10_Test
    {
        [TestMethod]
        public void CheckSubtreeTest_ReturnTrue()
        {
            // Arrange
            var testTree = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(1)
                    {
                        Left = new BinaryTreeNode<int>(0)
                    },
                    Right = new BinaryTreeNode<int>(3)
                    {
                        Left = new BinaryTreeNode<int>(3)
                    }
                },
                Right = new BinaryTreeNode<int>(5)
                {
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            Console.WriteLine("Input:");
            TestHelper.PrintBinaryTree(testTree);

            var subtree1 = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(1)
                    {
                        Left = new BinaryTreeNode<int>(0)
                    },
                    Right = new BinaryTreeNode<int>(3)
                    {
                        Left = new BinaryTreeNode<int>(3)
                    }
                },
                Right = new BinaryTreeNode<int>(5)
                {
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            var subtree2 = new BinaryTreeNode<int>(2)
            {
                Left = new BinaryTreeNode<int>(1)
                {
                    Left = new BinaryTreeNode<int>(0)
                },
                Right = new BinaryTreeNode<int>(3)
                {
                    Left = new BinaryTreeNode<int>(3)
                }
            };
            var subtree3 = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(0)
            };
            var subtree4 = new BinaryTreeNode<int>(3)
            {
                Left = new BinaryTreeNode<int>(3)
            };
            var subtree5 = new BinaryTreeNode<int>(5)
            {
                Right = new BinaryTreeNode<int>(6)
            };
            var subtree6 = new BinaryTreeNode<int>(0);
            var subtree7 = new BinaryTreeNode<int>(3);
            var subtree8 = new BinaryTreeNode<int>(6);

            // Act
            bool result1 = Question_4_10.CheckSubtree(testTree, subtree1);
            bool result2 = Question_4_10.CheckSubtree(testTree, subtree2);
            bool result3 = Question_4_10.CheckSubtree(testTree, subtree3);
            bool result4 = Question_4_10.CheckSubtree(testTree, subtree4);
            bool result5 = Question_4_10.CheckSubtree(testTree, subtree5);
            bool result6 = Question_4_10.CheckSubtree(testTree, subtree6);
            bool result7 = Question_4_10.CheckSubtree(testTree, subtree7);
            bool result8 = Question_4_10.CheckSubtree(testTree, subtree8);

            // Assert
            Assert.IsTrue(result1, "Check 1 failed.");
            Assert.IsTrue(result2, "Check 2 failed.");
            Assert.IsTrue(result3, "Check 3 failed.");
            Assert.IsTrue(result4, "Check 4 failed.");
            Assert.IsTrue(result5, "Check 5 failed.");
            Assert.IsTrue(result6, "Check 6 failed.");
            Assert.IsTrue(result7, "Check 7 failed.");
            Assert.IsTrue(result8, "Check 8 failed.");
        }

        [TestMethod]
        public void CheckSubtreeTest_ReturnFalse()
        {
            // Arrange
            var testTree = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(1)
                    {
                        Left = new BinaryTreeNode<int>(0)
                    },
                    Right = new BinaryTreeNode<int>(3)
                    {
                        Left = new BinaryTreeNode<int>(3)
                    }
                },
                Right = new BinaryTreeNode<int>(5)
                {
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            Console.WriteLine("Input:");
            TestHelper.PrintBinaryTree(testTree);

            var subtree1 = new BinaryTreeNode<int>(2)
            {
                Left = new BinaryTreeNode<int>(1),
                Right = new BinaryTreeNode<int>(3)
            };
            var subtree2 = new BinaryTreeNode<int>(4)
            {
                Right = new BinaryTreeNode<int>(5)
                {
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            var subtree3 = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(2),
                Right = new BinaryTreeNode<int>(5)
            };
            var subtree4 = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(1),
                    Right = new BinaryTreeNode<int>(3)
                },
                Right = new BinaryTreeNode<int>(5)
                {
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            var subtree5 = new BinaryTreeNode<int>(5)
            {
                Left = new BinaryTreeNode<int>(6)
            };
            var subtree6 = new BinaryTreeNode<int>(3)
            {
                Right = new BinaryTreeNode<int>(3)
            };

            // Act
            bool result1 = Question_4_10.CheckSubtree(testTree, subtree1);
            bool result2 = Question_4_10.CheckSubtree(testTree, subtree2);
            bool result3 = Question_4_10.CheckSubtree(testTree, subtree3);
            bool result4 = Question_4_10.CheckSubtree(testTree, subtree4);
            bool result5 = Question_4_10.CheckSubtree(testTree, subtree5);
            bool result6 = Question_4_10.CheckSubtree(testTree, subtree6);

            // Assert
            Assert.IsFalse(result1, "Check 1 failed.");
            Assert.IsFalse(result2, "Check 2 failed.");
            Assert.IsFalse(result3, "Check 3 failed.");
            Assert.IsFalse(result4, "Check 4 failed.");
            Assert.IsFalse(result5, "Check 5 failed.");
            Assert.IsFalse(result6, "Check 6 failed.");
        }

        [TestMethod]
        public void CheckSubtreeRecursiveTest_ReturnTrue()
        {
            // Arrange
            var testTree = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(1)
                    {
                        Left = new BinaryTreeNode<int>(0)
                    },
                    Right = new BinaryTreeNode<int>(3)
                    {
                        Left = new BinaryTreeNode<int>(3)
                    }
                },
                Right = new BinaryTreeNode<int>(5)
                {
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            Console.WriteLine("Input:");
            TestHelper.PrintBinaryTree(testTree);

            var subtree1 = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(1)
                    {
                        Left = new BinaryTreeNode<int>(0)
                    },
                    Right = new BinaryTreeNode<int>(3)
                    {
                        Left = new BinaryTreeNode<int>(3)
                    }
                },
                Right = new BinaryTreeNode<int>(5)
                {
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            var subtree2 = new BinaryTreeNode<int>(2)
            {
                Left = new BinaryTreeNode<int>(1)
                {
                    Left = new BinaryTreeNode<int>(0)
                },
                Right = new BinaryTreeNode<int>(3)
                {
                    Left = new BinaryTreeNode<int>(3)
                }
            };
            var subtree3 = new BinaryTreeNode<int>(1)
            {
                Left = new BinaryTreeNode<int>(0)
            };
            var subtree4 = new BinaryTreeNode<int>(3)
            {
                Left = new BinaryTreeNode<int>(3)
            };
            var subtree5 = new BinaryTreeNode<int>(5)
            {
                Right = new BinaryTreeNode<int>(6)
            };
            var subtree6 = new BinaryTreeNode<int>(0);
            var subtree7 = new BinaryTreeNode<int>(3);
            var subtree8 = new BinaryTreeNode<int>(6);

            // Act
            bool result1 = Question_4_10.CheckSubtreeRecursive(testTree, subtree1);
            bool result2 = Question_4_10.CheckSubtreeRecursive(testTree, subtree2);
            bool result3 = Question_4_10.CheckSubtreeRecursive(testTree, subtree3);
            bool result4 = Question_4_10.CheckSubtreeRecursive(testTree, subtree4);
            bool result5 = Question_4_10.CheckSubtreeRecursive(testTree, subtree5);
            bool result6 = Question_4_10.CheckSubtreeRecursive(testTree, subtree6);
            bool result7 = Question_4_10.CheckSubtreeRecursive(testTree, subtree7);
            bool result8 = Question_4_10.CheckSubtreeRecursive(testTree, subtree8);

            // Assert
            Assert.IsTrue(result1, "Check 1 failed.");
            Assert.IsTrue(result2, "Check 2 failed.");
            Assert.IsTrue(result3, "Check 3 failed.");
            Assert.IsTrue(result4, "Check 4 failed.");
            Assert.IsTrue(result5, "Check 5 failed.");
            Assert.IsTrue(result6, "Check 6 failed.");
            Assert.IsTrue(result7, "Check 7 failed.");
            Assert.IsTrue(result8, "Check 8 failed.");
        }

        [TestMethod]
        public void CheckSubtreeRecursiveTest_ReturnFalse()
        {
            // Arrange
            var testTree = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(1)
                    {
                        Left = new BinaryTreeNode<int>(0)
                    },
                    Right = new BinaryTreeNode<int>(3)
                    {
                        Left = new BinaryTreeNode<int>(3)
                    }
                },
                Right = new BinaryTreeNode<int>(5)
                {
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            Console.WriteLine("Input:");
            TestHelper.PrintBinaryTree(testTree);

            var subtree1 = new BinaryTreeNode<int>(2)
            {
                Left = new BinaryTreeNode<int>(1),
                Right = new BinaryTreeNode<int>(3)
            };
            var subtree2 = new BinaryTreeNode<int>(4)
            {
                Right = new BinaryTreeNode<int>(5)
                {
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            var subtree3 = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(2),
                Right = new BinaryTreeNode<int>(5)
            };
            var subtree4 = new BinaryTreeNode<int>(4)
            {
                Left = new BinaryTreeNode<int>(2)
                {
                    Left = new BinaryTreeNode<int>(1),
                    Right = new BinaryTreeNode<int>(3)
                },
                Right = new BinaryTreeNode<int>(5)
                {
                    Right = new BinaryTreeNode<int>(6)
                }
            };
            var subtree5 = new BinaryTreeNode<int>(5)
            {
                Left = new BinaryTreeNode<int>(6)
            };
            var subtree6 = new BinaryTreeNode<int>(3)
            {
                Right = new BinaryTreeNode<int>(3)
            };

            // Act
            bool result1 = Question_4_10.CheckSubtreeRecursive(testTree, subtree1);
            bool result2 = Question_4_10.CheckSubtreeRecursive(testTree, subtree2);
            bool result3 = Question_4_10.CheckSubtreeRecursive(testTree, subtree3);
            bool result4 = Question_4_10.CheckSubtreeRecursive(testTree, subtree4);
            bool result5 = Question_4_10.CheckSubtreeRecursive(testTree, subtree5);
            bool result6 = Question_4_10.CheckSubtreeRecursive(testTree, subtree6);

            // Assert
            Assert.IsFalse(result1, "Check 1 failed.");
            Assert.IsFalse(result2, "Check 2 failed.");
            Assert.IsFalse(result3, "Check 3 failed.");
            Assert.IsFalse(result4, "Check 4 failed.");
            Assert.IsFalse(result5, "Check 5 failed.");
            Assert.IsFalse(result6, "Check 6 failed.");
        }
    }
}
