namespace TreeAndGraphApp
{
    public static class SuccessorTree
    {
        public static TreeNode<T> FindSuccessor<T>(TreeNode<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Right != null)
            {
                return GetLeftmostNode(node.Right);
            }
            else
            {
                while (node.Parent != null)
                {
                    if (node.Parent.Left == node)
                    {
                        return node.Parent;
                    }
                    node = node.Parent;
                }
                return null;
            }
        }

        private static TreeNode<T> GetLeftmostNode<T>(TreeNode<T> node)
        {
            if (node.Left != null)
            {
                return GetLeftmostNode<T>(node.Left);
            }
            else
            {
                return node;
            }
        }
    }
}
