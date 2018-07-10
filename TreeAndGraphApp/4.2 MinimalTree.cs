namespace TreeAndGraphApp
{
    public static class MinimalTree
    {
        public static TreeNode<int> CreateBST(int[] sortedUniqueArray) =>
            CreateMinimalBST(sortedUniqueArray, 0, sortedUniqueArray.Length - 1);

        private static TreeNode<int> CreateMinimalBST(int[] sortedUniqueArray, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int midIndex = (start + end) / 2;
            var node = new TreeNode<int>(sortedUniqueArray[midIndex]);
            node.Left = CreateMinimalBST(sortedUniqueArray, start, midIndex - 1);
            node.Right = CreateMinimalBST(sortedUniqueArray, midIndex + 1, end);
            return node;
        }
    }
}
