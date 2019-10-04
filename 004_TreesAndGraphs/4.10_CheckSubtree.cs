using System.Text;

namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.10) Check Subtree:
    /// T1 and T2 are two very large binary trees, with T1 much bigger than T2.
    /// Create an algorithm to determine if T2 is a subtree of T1.
    /// A tree T2 is a subtree of T1 if there exists a node n in T1 such that the subtree of n is identical to T2.
    /// That is, if you cut off the tree at node n, the two trees would be identical.
    /// </summary>
    public class Question_4_10
    {
        /// <summary>
        /// Convert both trees to Pre Order strings with placeholder for empty nodes and check if T1 string contains T2 string
        /// <para>Time Complexity: O(N1)</para>
        /// <para>Space Complexity: O(log(N1))</para>
        /// </summary>
        /// <param name="t1">Total number of nodes = N1</param>
        /// <param name="t2">Total number of nodes = N2, where N2 is smaller than N1</param>
        /// <returns></returns>
        public static bool CheckSubtree(BinaryTreeNode<int> t1, BinaryTreeNode<int> t2)
        {
            if (t1 == null || t2 == null)
            {
                return false;
            }

            string preOrderStrT1 = ConvertToStringPreOrder(t1); // Time O(N1); Space O(log(N1))
            string preOrderStrT2 = ConvertToStringPreOrder(t2); // Time O(N2); Space O(log(N2))
            return preOrderStrT1.Contains(preOrderStrT2);
        }

        private static string ConvertToStringPreOrder(BinaryTreeNode<int> node)
        {
            if (node == null)
            {
                return "()";
            }
            else
            {
                var sb = new StringBuilder();
                sb.AppendFormat("({0})", node);
                sb.Append(ConvertToStringPreOrder(node.Left));
                sb.Append(ConvertToStringPreOrder(node.Right));
                return sb.ToString();
            }
        }

        /// <summary>
        /// Recursively check if subtree of T1 is equal to T2
        /// <para>Time Complexity: O(N1*N2)</para>
        /// <para>Space Complexity: O(log(N1)*log(N2))</para>
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool CheckSubtreeRecursive(BinaryTreeNode<int> t1, BinaryTreeNode<int> t2)
        {
            if (t1 == null || t2 == null)
            {
                return false;
            }
            else if (t1.Equals(t2))
            {
                return true;
            }
            else
            {
                bool contains = false;
                if (t1.Left != null)
                {
                    contains |= CheckSubtreeRecursive(t1.Left, t2);
                }
                if (t1.Right != null)
                {
                    contains |= CheckSubtreeRecursive(t1.Right, t2);
                }
                return contains;
            }
        }
    }
}
