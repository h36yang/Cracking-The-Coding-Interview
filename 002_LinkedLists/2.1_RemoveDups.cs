using System.Collections.Generic;

namespace _002_LinkedLists
{
    /// <summary>
    /// 2.1) Remove Dups:
    /// Write code to remove duplicates from an unsorted linked list.
    /// How would you solve this problem if a temporary buffer is not allowed?
    /// </summary>
    public class Question_2_1
    {
        /// <summary>
        /// Write code to remove duplicates from an unsorted linked list.
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static LinkedList RemoveDuplicates(LinkedList list)
        {
            if (list == null || list.Head == null)
            {
                return list;
            }

            var buffer = new Dictionary<int, bool>
            {
                { list.Head.Data, true }
            };
            Node temp = list.Head;
            while (temp.Next != null)
            {
                if (buffer.ContainsKey(temp.Next.Data))
                {
                    temp.Next = temp.Next.Next;
                }
                else
                {
                    buffer.Add(temp.Next.Data, true);
                    temp = temp.Next;
                }
            }
            return list;
        }

        /// <summary>
        /// How would you solve this problem if a temporary buffer is not allowed?
        /// <para>Time Complexity: O(n^2)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static LinkedList RemoveDuplicatesInplace(LinkedList list)
        {
            if (list == null || list.Head == null)
            {
                return list;
            }

            Node temp1 = list.Head;
            while (temp1 != null)
            {
                Node temp2 = temp1;
                while (temp2.Next != null)
                {
                    if (temp1.Data == temp2.Next.Data)
                    {
                        temp2.Next = temp2.Next.Next;
                    }
                    else
                    {
                        temp2 = temp2.Next;
                    }
                }
                temp1 = temp1.Next;
            }
            return list;
        }
    }
}
