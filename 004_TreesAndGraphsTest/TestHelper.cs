using _004_TreesAndGraphs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace _004_TreesAndGraphsTest
{
    public static class TestHelper
    {
        public static void PrintCollection<T>(ICollection<T> collection)
        {
            if (collection == null || collection.Count == 0)
            {
                return;
            }

            var sb = new StringBuilder();
            sb.Append("{ ");
            foreach (T item in collection)
            {
                sb.Append(item).Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(" }");
            Console.WriteLine(sb.ToString());
        }

        public static void PrintBinaryTree<T>(BinaryTreeNode<T> root)
        {
            PrintBinaryTreeInner(new List<BinaryTreeNode<T>>() { root }, 1, root.GetHeight());
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

    public class LinkedListComparerHelper : IComparer<LinkedList<int>>, IEqualityComparer<LinkedList<int>>
    {
        public int Compare([AllowNull] LinkedList<int> x, [AllowNull] LinkedList<int> y)
        {
            string xStr = ConvertLinkedListToString(x);
            string yStr = ConvertLinkedListToString(y);
            return xStr.CompareTo(yStr);
        }

        public bool Equals([AllowNull] LinkedList<int> x, [AllowNull] LinkedList<int> y)
        {
            string xStr = ConvertLinkedListToString(x);
            string yStr = ConvertLinkedListToString(y);
            return xStr.Equals(yStr);
        }

        public int GetHashCode([DisallowNull] LinkedList<int> obj)
        {
            return ConvertLinkedListToString(obj).GetHashCode();
        }

        private string ConvertLinkedListToString(LinkedList<int> list)
        {
            if (list == null || list.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            foreach (int item in list)
            {
                sb.Append(item).Append("->");
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
    }
}
