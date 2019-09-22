using System;

namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.2) Minimal Tree:
    /// Given a sorted (increasing order) array with unique integer elements, write an algorithm to create a binary search tree with minimal height.
    /// </summary>
    public class Question_4_2
    {
        /// <summary>
        /// Use the middle element as root node, recursively divide the array and construct the left/right subtree
        /// <para>Time Complexity: O(log(n))</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="uniqueSortedArray"></param>
        /// <returns></returns>
        public static BinaryTreeNode<int> CreateMinimalHeightBST(int[] uniqueSortedArray)
        {
            if (uniqueSortedArray == null || uniqueSortedArray.Length == 0)
            {
                throw new ArgumentNullException(nameof(uniqueSortedArray));
            }
            return CreateBST(uniqueSortedArray, 0, uniqueSortedArray.Length - 1);
        }

        private static BinaryTreeNode<int> CreateBST(int[] uniqueSortedArray, int startIndex, int endIndex)
        {
            int midIndex = (endIndex - startIndex) / 2 + startIndex;
            var node = new BinaryTreeNode<int>(uniqueSortedArray[midIndex]);

            if (midIndex > startIndex)
            {
                node.Left = CreateBST(uniqueSortedArray, startIndex, midIndex - 1);
            }

            if (midIndex < endIndex)
            {
                node.Right = CreateBST(uniqueSortedArray, midIndex + 1, endIndex);
            }

            return node;
        }
    }
}
