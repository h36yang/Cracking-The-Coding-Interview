namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.8) First Common Ancestor:
    /// Design an algorithm and write code to find the first common ancestor of two nodes in a binary tree.
    /// Avoid storing additional nodes in a data structure.
    /// NOTE: This is not necessarily a binary search tree.
    /// </summary>
    public class Question_4_8
    {
        /// <summary>
        /// Starting from root, if both nodes are under the same side of the subtree,
        /// keep traversing down that side until both nodes are under different sides.
        /// <para>Assuming node has no link to its parent.</para>
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="root"></param>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public static BinaryTreeNode<T> FindFirstCommonAncestor<T>(BinaryTreeNode<T> root, BinaryTreeNode<T> node1, BinaryTreeNode<T> node2)
        {
            if (root == null || node1 == null || node2 == null)
            {
                return null;
            }

            if (node1 == node2)
            {
                return node1;
            }

            SubtreeSide node1Side;
            SubtreeSide node2Side;
            BinaryTreeNode<T> temp = root;
            // Traverse down from root until found 2 nodes are under different sides of the subtree - time O(n)
            while (true)
            {
                node1Side = CheckSubtreeSide(temp, node1);
                node2Side = CheckSubtreeSide(temp, node2);

                if (node1Side == SubtreeSide.ERROR || node2Side == SubtreeSide.ERROR)
                {
                    return null;
                }

                if (node1Side == node2Side && node1Side == SubtreeSide.LEFT)
                {
                    temp = temp.Left;
                }
                else if (node1Side == node2Side && node1Side == SubtreeSide.RIGHT)
                {
                    temp = temp.Right;
                }
                else
                {
                    return temp;
                }
            }
        }

        private enum SubtreeSide
        {
            SELF,
            LEFT,
            RIGHT,
            ERROR
        }

        private static SubtreeSide CheckSubtreeSide<T>(BinaryTreeNode<T> parent, BinaryTreeNode<T> child)
        {
            if (parent == child)
            {
                return SubtreeSide.SELF;
            }
            else if (parent.Left?.HasChild(child) ?? false)
            {
                return SubtreeSide.LEFT;
            }
            else if (parent.Right?.HasChild(child) ?? false)
            {
                return SubtreeSide.RIGHT;
            }
            else
            {
                return SubtreeSide.ERROR;
            }
        }
    }
}
