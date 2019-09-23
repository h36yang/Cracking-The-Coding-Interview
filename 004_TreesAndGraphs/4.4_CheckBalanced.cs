using System;

namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.4) Check Balanced:
    /// Implement a function to check if a binary tree is balanced.
    /// For the purposes of this question, a balanced tree is defined to be a tree such that the heights of the two subtrees of any node never differ by more than one.
    /// </summary>
    public class Question_4_4
    {
        /// <summary>
        /// Check the height of left and right subtree recursively
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(log(n))</para>
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsBalanced<T>(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            return CheckHeight(root) != int.MinValue;
        }

        private static int CheckHeight<T>(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int leftHeight = CheckHeight(node.Left);
                if (leftHeight == int.MinValue)
                {
                    return int.MinValue;
                }

                int rightHeight = CheckHeight(node.Right);
                if (rightHeight == int.MinValue)
                {
                    return int.MinValue;
                }

                if (Math.Abs(leftHeight - rightHeight) > 1)
                {
                    return int.MinValue;
                }
                return 1 + Math.Max(leftHeight, rightHeight);
            }
        }
    }
}
