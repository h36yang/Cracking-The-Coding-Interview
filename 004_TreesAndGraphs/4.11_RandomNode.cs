using System;
using System.Collections.Generic;
using System.Linq;

namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.11) Random Node:
    /// You are implementing a binary tree class from scratch which, in addition to insert, find, and delete, has a method getRandomNode() which returns a random node from the tree.
    /// All nodes should be equally likely to be chosen. Design and implement an algorithm getRandomNode, and explain how you would implement the rest of the methods.
    /// </summary>
    public class Question_4_11
    {
        public class MyBinarySearchTree
        {
            private static Random _randomGenerator;

            public Random RandomGenerator
            {
                get
                {
                    if (_randomGenerator == null)
                    {
                        _randomGenerator = new Random();
                    }
                    return _randomGenerator;
                }
            }

            /// <summary>
            /// Storing all nodes in a dictionary for random node generation and O(1) Find
            /// <para>Space Complexity: O(n)</para>
            /// </summary>
            private readonly Dictionary<int, BinaryTreeNode<int>> _nodesMap = new Dictionary<int, BinaryTreeNode<int>>();

            public BinaryTreeNode<int> Root { get; set; }

            /// <summary>
            /// <para>Time Complexity: O(log(n))</para>
            /// <para>Space Complexity: O(log(n))</para>
            /// </summary>
            /// <param name="key"></param>
            public void Insert(int key)
            {
                // Only insert if the same key doesn't exist yet
                if (!_nodesMap.ContainsKey(key))
                {
                    var newNode = new BinaryTreeNode<int>(key);
                    if (Root == null)
                    {
                        Root = newNode;
                    }
                    else
                    {
                        InsertInner(Root, newNode);
                    }
                    _nodesMap.Add(key, newNode);
                }
            }

            private void InsertInner(BinaryTreeNode<int> node, BinaryTreeNode<int> newNode)
            {
                node.Size++;
                if (newNode.Data <= node.Data)
                {
                    if (node.Left == null)
                    {
                        node.Left = newNode;
                        newNode.Parent = node;
                    }
                    else
                    {
                        InsertInner(node.Left, newNode);
                    }
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = newNode;
                        newNode.Parent = node;
                    }
                    else
                    {
                        InsertInner(node.Right, newNode);
                    }
                }
            }

            /// <summary>
            /// <para>Time Complexity: O(1)</para>
            /// <para>Space Complexity: O(1)</para>
            /// </summary>
            /// <param name="key"></param>
            public BinaryTreeNode<int> Find(int key)
            {
                if (_nodesMap.ContainsKey(key))
                {
                    return _nodesMap[key];
                }
                return null;
            }

            /// <summary>
            /// <para>Time Complexity: O(log(n))</para>
            /// <para>Space Complexity: O(log(n))</para>
            /// </summary>
            /// <param name="key"></param>
            public void Delete(int key)
            {
                if (_nodesMap.ContainsKey(key))
                {
                    FindAndDeleteKey(Root, key);
                    _nodesMap.Remove(key);
                }
            }

            private void FindAndDeleteKey(BinaryTreeNode<int> node, int key)
            {
                node.Size--;
                if (key < node.Data)
                {
                    FindAndDeleteKey(node.Left, key);
                }
                else if (key > node.Data)
                {
                    FindAndDeleteKey(node.Right, key);
                }
                else
                {
                    DeleteNode(node);
                }
            }

            private void DeleteNode(BinaryTreeNode<int> node)
            {
                // Case 1 - the current node is a leaf node (no children)
                if (node.Left == null && node.Right == null)
                {
                    ExecuteSimpleDeletion(node, null);
                }
                // Case 2 - the current node has only 1 child node
                else if (node.Left == null || node.Right == null)
                {
                    ExecuteSimpleDeletion(node, node.Left ?? node.Right);
                }
                // Case 3 - the current node has 2 child nodes
                else
                {
                    BinaryTreeNode<int> replaceNode = FindMaxNode(node.Left);
                    int deleteData = node.Data;
                    node.Data = replaceNode.Data;
                    replaceNode.Data = deleteData;
                    _nodesMap[node.Data] = node;
                    FindAndDeleteKey(node.Left, deleteData);
                }
            }

            private void ExecuteSimpleDeletion(BinaryTreeNode<int> sourceNode, BinaryTreeNode<int> targetNode)
            {
                if (sourceNode.Parent == null)
                {
                    Root = targetNode;
                }
                else
                {
                    if (sourceNode.Parent.Left == sourceNode)
                    {
                        sourceNode.Parent.Left = targetNode;
                    }
                    else
                    {
                        sourceNode.Parent.Right = targetNode;
                    }
                }

                if (targetNode != null)
                {
                    targetNode.Parent = sourceNode.Parent;
                }
            }

            private BinaryTreeNode<int> FindMaxNode(BinaryTreeNode<int> node)
            {
                if (node.Right == null)
                {
                    return node;
                }
                else
                {
                    return FindMaxNode(node.Right);
                }
            }

            /// <summary>
            /// Keep track of a dictionary for random selection
            /// <para>Time Complexity: O(1)</para>
            /// <para>Space Complexity: O(n)</para>
            /// </summary>
            /// <returns></returns>
            public BinaryTreeNode<int> GetRandomNode()
            {
                if (_nodesMap.Count <= 1)
                {
                    return Root;
                }

                int rdmIdx = RandomGenerator.Next(_nodesMap.Count);
                return _nodesMap.ElementAt(rdmIdx).Value;
            }

            /// <summary>
            /// Keep track of the size on each node for random selection
            /// <para>Time Complexity: O(log(n))</para>
            /// <para>Space Complexity: O(log(n))</para>
            /// </summary>
            /// <returns></returns>
            public BinaryTreeNode<int> GetRandomNodeAlt()
            {
                if (Root == null || Root.Size == 1)
                {
                    return Root;
                }

                int i = RandomGenerator.Next(Root.Size);
                return Root.GetIthNode(i);
            }
        }
    }
}
