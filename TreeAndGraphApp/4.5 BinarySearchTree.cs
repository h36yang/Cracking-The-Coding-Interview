using System;

namespace TreeAndGraphApp
{
    public static class BinarySearchTree
    {
        public static bool IsBST(TreeNode<int> node)
        {
            if (node == null)
            {
                return true;
            }

            if (GetMax(node.Left) > node.Data || node.Data >= GetMin(node.Right))
            {
                return false;
            }
            else
            {
                return IsBST(node.Left) && IsBST(node.Right);
            }
        }

        private static int GetMin(TreeNode<int> node)
        {
            if (node == null)
            {
                return int.MaxValue;
            }

            int leftData = node.Left == null ? int.MaxValue : GetMax(node.Left);
            int rightData = node.Right == null ? int.MaxValue : GetMin(node.Right);
            return Math.Min(Math.Min(leftData, rightData), node.Data);
        }

        private static int GetMax(TreeNode<int> node)
        {
            if (node == null)
            {
                return int.MinValue;
            }

            int leftData = node.Left == null ? int.MinValue : GetMax(node.Left);
            int rightData = node.Right == null ? int.MinValue : GetMin(node.Right);
            return Math.Max(Math.Max(leftData, rightData), node.Data);
        }
    }
}