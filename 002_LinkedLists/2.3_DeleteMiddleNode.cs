namespace _002_LinkedLists
{
    /// <summary>
    /// 2.3) Delete Middle Node:
    /// Implement an algorithm to delete a node in the middle (i.e., any node but the first and last node, not necessarily the exact middle) of a singly linked list, given only access to that node.
    /// </summary>
    public class Question_2_3
    {
        /// <summary>
        /// Make the node passed in look like the next node and remove the next node
        /// <para>Time Complexity: O(1)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool DeleteMiddleNode(Node n)
        {
            if (n == null || n.Next == null)
            {
                return false;
            }

            n.Data = n.Next.Data;
            n.Next = n.Next.Next;
            return true;
        }
    }
}
