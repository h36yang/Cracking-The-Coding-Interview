using _004_TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _004_TreesAndGraphsTest
{
    public class TestHelper
    {
        public static void PrintBinaryTree<T>(BinaryTreeNode<T> root)
        {
            PrintBinaryTreeInner(new List<BinaryTreeNode<T>>() { root }, 1, root.Height);
        }

        private static void PrintBinaryTreeInner<T>(List<BinaryTreeNode<T>> nodes, int level, int maxLevel)
        {
            if (nodes.Count == 0 || !nodes.Any(n => n != null))
            {
                return;
            }

            int floor = maxLevel - level;
            int edgeLines = (int)Math.Pow(2, Math.Max(floor - 1, 0));
            int firstSpaces = (int)Math.Pow(2, floor) - 1;
            int betweenSpaces = (int)Math.Pow(2, floor + 1) - 1;

            PrintWhitespaces(firstSpaces);

            var newNodes = new List<BinaryTreeNode<T>>();
            foreach (BinaryTreeNode<T> node in nodes)
            {
                if (node != null)
                {
                    Console.Write(node);
                    newNodes.Add(node.Left);
                    newNodes.Add(node.Right);
                }
                else
                {
                    newNodes.Add(null);
                    newNodes.Add(null);
                    PrintWhitespaces(1);
                }
                PrintWhitespaces(betweenSpaces);
            }
            Console.WriteLine();

            for (int i = 1; i <= edgeLines; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    PrintWhitespaces(firstSpaces - i);
                    if (nodes[j] == null)
                    {
                        PrintWhitespaces(edgeLines * 2 + i + 1);
                        continue;
                    }

                    if (nodes[j].Left != null)
                    {
                        Console.Write("/");
                    }
                    else
                    {
                        PrintWhitespaces(1);
                    }
                    PrintWhitespaces(i * 2 - 1);

                    if (nodes[j].Right != null)
                    {
                        Console.Write(@"\");
                    }
                    else
                    {
                        PrintWhitespaces(1);
                    }
                    PrintWhitespaces(edgeLines * 2 - i);
                }
                Console.WriteLine();
            }

            PrintBinaryTreeInner(newNodes, level + 1, maxLevel);
        }

        public static void PrintWhitespaces(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(" ");
            }
        }
    }
}
