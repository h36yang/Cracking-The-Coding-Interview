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
            if (!Helper.IsValidList(list))
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
            if (!Helper.IsValidList(list))
            {
                return list;
            }

            Node current = list.Head;
            while (current != null)
            {
                Node runner = current;
                while (runner.Next != null)
                {
                    if (current.Data == runner.Next.Data)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
                current = current.Next;
            }
            return list;
        }
    }
}
