using System;

namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.5) Validate BST:
    /// Implement a function to check if a binary tree is a binary search tree.
    /// </summary>
    public class Question_4_5
    {
        /// <summary>
        /// Convert tree to list in order and check if the list is sorted
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsBST(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            // Convert tree to a list in order recursively - time O(n), space O(n)
            var inOrderList = root.ToListInOrder();

            // Check if the list is sorted - time O(n)
            return Helper.IsListSorted(inOrderList);
        }

        /// <summary>
        /// Check if left subtree is smaller than root and root is smaller than right substree recursively
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(log(n))</para>
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsBST2(BinaryTreeNode<int> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            return CheckSubtreeValue(root) != int.MinValue;
        }

        private static int CheckSubtreeValue(BinaryTreeNode<int> node)
        {
            if (node.Left == null && node.Right == null)
            {
                return node.Data;
            }
            else
            {
                bool isInOrder = true;
                int maxValue = node.Data;
                if (node.Left != null)
                {
                    int leftValue = CheckSubtreeValue(node.Left);
                    if (leftValue == int.MinValue)
                    {
                        return int.MinValue;
                    }
                    isInOrder &= (leftValue <= node.Data);
                }

                if (node.Right != null)
                {
                    int rightValue = CheckSubtreeValue(node.Right);
                    if (rightValue == int.MinValue)
                    {
                        return int.MinValue;
                    }
                    isInOrder &= (rightValue > node.Data);
                    maxValue = rightValue;
                }

                if (!isInOrder)
                {
                    return int.MinValue;
                }
                return maxValue;
            }
        }
    }
}
