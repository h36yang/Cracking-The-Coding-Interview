using System;

namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.6) Successor:
    /// Write an algorithm to find the "next" node (i.e. in-order successor) of a given node in a binary search tree.
    /// You may assume that each node has a link to its parent.
    /// </summary>
    public class Question_4_6
    {
        /// <summary>
        /// The in-order successor node in BST is either the Left most child of the Right subtree
        /// or the next Parent on the Right side
        /// <para>Time Complexity: O(log(n))</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static BinaryTreeNode<T> FindSuccessorNode<T>(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            // if the node has a Right subtree, traverse down to find the Left most child - time O(log(n))
            if (node.Right != null)
            {
                BinaryTreeNode<T> n1 = node.Right;
                while (n1.Left != null)
                {
                    n1 = n1.Left;
                }
                return n1;
            }

            // otherwise, traverse to Parent and check if it is a Left child of its Parent - time O(log(n))
            BinaryTreeNode<T> n2 = node;
            while (n2.Parent != null)
            {
                if (n2.Parent.Left != null && n2.Parent.Left == n2)
                {
                    return n2.Parent;
                }
                n2 = n2.Parent;
            }

            // if none of the above 2 cases are met, the node is the last node (no successor)
            return null;
        }
    }
}
