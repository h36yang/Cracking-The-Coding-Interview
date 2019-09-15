using System;
using System.Collections.Generic;

namespace _002_LinkedLists
{
    /// <summary>
    /// 2.8) Loop Detection:
    /// Given a circular linked list, implement an algorithm that returns the node at the beginning of the loop.
    /// </summary>
    public class Question_2_8
    {
        /// <summary>
        /// Use a dictionary to check repeated node - the first repeated node is the beginning of the circular node
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Node FindCircularStartNode(LinkedList list)
        {
            if (!Helper.IsValidList(list))
            {
                return null;
            }

            var buffer = new Dictionary<Node, bool>();
            Node temp = list.Head;
            while (temp != null)
            {
                if (buffer.ContainsKey(temp))
                {
                    return temp;
                }
                buffer.Add(temp, true);
                temp = temp.Next;
            }
            return null;
        }

        /// <summary>
        /// Runner technique - when 2 pointers collide, the colliding node is exactly the same distance away as the head from the start node
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Node FindCircularStartNodeInplace(LinkedList list)
        {
            if (!Helper.IsValidList(list))
            {
                return null;
            }

            Node faster = list.Head;
            Node slower = list.Head;
            while (faster != null && faster.Next != null)
            {
                faster = faster.Next.Next;
                slower = slower.Next;
                if (faster == slower)
                {
                    break;
                }
            }

            if (faster == null || faster.Next == null)
            {
                // No loop
                return null;
            }

            faster = list.Head;
            while (faster != slower)
            {
                faster = faster.Next;
                slower = slower.Next;
            }
            return faster;
        }
    }
}
