using System;

namespace TreeAndGraphApp
{
    public static class BalancedTree
    {
        public static bool IsTreeBalanced<T>(TreeNode<T> node)
        {
            if (node == null)
            {
                return true;
            }

            bool leftBalanced = IsTreeBalanced<T>(node.Left);
            bool rightBalanced = IsTreeBalanced<T>(node.Right);
            if (!leftBalanced || !rightBalanced)
            {
                return false;
            }
            else
            {
                node.LeftDepth = node.Left == null ? 0 : Math.Max(node.Left.LeftDepth, node.Left.RightDepth) + 1;
                node.RightDepth = node.Right == null ? 0 : Math.Max(node.Right.LeftDepth, node.Right.RightDepth) + 1;
                return Math.Abs(node.LeftDepth - node.RightDepth) <= 1;
            }
        }
    }
}
