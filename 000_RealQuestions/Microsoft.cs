using _004_TreesAndGraphs;
using System.Collections.Generic;

namespace _000_RealQuestions
{
    public static class Microsoft
    {
        /// <summary>
        /// Given a binary search tree, find all the pair of values that sum up to a particular value.
        /// Assuming no duplicated values in the BST.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static List<(int, int)> FindPairsWithSum(BinaryTreeNode<int> root, int sum)
        {
            var result = new List<(int, int)>();
            FindPairsWithSum(root, sum, result);
            return result;
        }

        private static void FindPairsWithSum(BinaryTreeNode<int> node, int sum, List<(int, int)> result)
        {
            if (node == null)
            {
                return;
            }

            int target = sum - node.Data;
            BinaryTreeNode<int> temp = node;
            while (temp != null)
            {
                if (Search(temp, target, node.Data))
                {
                    result.Add((node.Data, target));
                    break;
                }
                temp = temp.Parent;
            }

            FindPairsWithSum(node.Left, sum, result);
            FindPairsWithSum(node.Right, sum, result);
        }

        private static bool Search(BinaryTreeNode<int> node, int target, int first)
        {
            if (node == null || node.Data < first)
            {
                return false;
            }

            if (node.Data == target)
            {
                return node.Data != first;
            }
            else if (node.Data > target)
            {
                return false;
            }
            else
            {
                return Search(node.Right, target, first);
            }
        }
    }
}
