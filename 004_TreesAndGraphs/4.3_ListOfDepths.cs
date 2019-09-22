using System.Collections.Generic;

namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.3) List of Depths:
    /// Given a binary tree, design an algorithm which creates a linked list of all the nodes at each depth
    /// (e.g., if you have a tree with depth D, you'll have D linked lists).
    /// </summary>
    public class Question_4_3
    {
        /// <summary>
        /// BFS through the binary tree and use NULL node to indicate end of each depth
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<LinkedList<T>> CreateListOfDepthsBFS<T>(BinaryTreeNode<T> root)
        {
            var resultList = new List<LinkedList<T>>();
            if (root == null)
            {
                return resultList;
            }

            var bfsQueue = new Queue<BinaryTreeNode<T>>();
            bfsQueue.Enqueue(root);
            bfsQueue.Enqueue(null); // using NULL node to indicate the end of the current depth
            var currDepth = new LinkedList<T>();
            while (bfsQueue.Count > 0)
            {
                BinaryTreeNode<T> temp = bfsQueue.Dequeue();
                if (temp != null)
                {
                    currDepth.AddLast(temp.Data);
                    if (temp.Left != null)
                    {
                        bfsQueue.Enqueue(temp.Left);
                    }
                    if (temp.Right != null)
                    {
                        bfsQueue.Enqueue(temp.Right);
                    }
                }
                else
                {
                    resultList.Add(currDepth);
                    currDepth = new LinkedList<T>();
                    if (bfsQueue.Count > 0)
                    {
                        bfsQueue.Enqueue(null);
                    }
                }
            }
            return resultList;
        }

        /// <summary>
        /// DFS through the binary tree recursively
        /// <para>Time Complexity: O(log(n))</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<LinkedList<T>> CreateListOfDepthsDFS<T>(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return new List<LinkedList<T>>(0);
            }

            // Get total height - time O(log(n))
            int height = root.Height;

            // Preallocate list with height number of elements - time O(log(n))
            var resultList = new List<LinkedList<T>>(height);
            for (int i = 0; i < height; i++)
            {
                resultList.Add(new LinkedList<T>());
            }

            // Update list recursively - time O(log(n))
            UpdateListOfDepths(root, resultList, 0);

            return resultList;
        }

        private static void UpdateListOfDepths<T>(BinaryTreeNode<T> node, List<LinkedList<T>> list, int depth)
        {
            if (node == null)
            {
                return;
            }

            list[depth].AddLast(node.Data);
            UpdateListOfDepths(node.Left, list, depth + 1);
            UpdateListOfDepths(node.Right, list, depth + 1);
        }
    }
}
