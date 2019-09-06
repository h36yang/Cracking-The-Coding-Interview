using System;

namespace _002_LinkedLists
{
    /// <summary>
    /// 2.2) Return Kth to Last:
    /// Implement an algorithm to find the kth to last element of a singly linked list.
    /// Assumption: k = 1 will return the last element, k = 2 will return the second last element, etc.
    /// </summary>
    public class Question_2_2
    {
        /// <summary>
        /// Brute force - loop to the end to find total and loop again
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int ReturnKthToLast(LinkedList list, int k)
        {
            if (list == null || list.Head == null)
            {
                throw new ArgumentNullException("Invalid Linked List passed in.");
            }

            // first pass to get total length of the linked list - time O(n)
            Node temp = list.Head;
            int total = 0;
            while (temp != null)
            {
                total++;
                temp = temp.Next;
            }

            int pos = total - k + 1;
            if (pos > total || pos < 1)
            {
                throw new ArgumentOutOfRangeException($"k={k} is not a valid position in the list.");
            }

            // second pass to return the kth to the last - time O(n)
            temp = list.Head;
            for (int i = 1; i < pos; i++)
            {
                temp = temp.Next;
            }
            return temp.Data;
        }

        /// <summary>
        /// Recursively find kth to the last element
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int ReturnKthToLastRecursive(LinkedList list, int k)
        {
            if (list == null || list.Head == null)
            {
                throw new ArgumentNullException("Invalid Linked List passed in.");
            }

            if (k < 1)
            {
                throw new ArgumentOutOfRangeException($"k={k} is not a valid position in the list.");
            }

            var (reversePos, data) = GetReversePositionAndData(list.Head, k);
            if (reversePos != k)
            {
                throw new ArgumentOutOfRangeException($"k={k} is not a valid position in the list.");
            }
            return data;
        }

        private static (int reversePos, int data) GetReversePositionAndData(Node n, int k)
        {
            if (n.Next == null)
            {
                return (reversePos: 1, data: n.Data);
            }
            else
            {
                var posDataPair = GetReversePositionAndData(n.Next, k);
                if (posDataPair.reversePos == k)
                {
                    return posDataPair;
                }
                return (reversePos: posDataPair.reversePos + 1, n.Data);
            }
        }

        /// <summary>
        /// Loop with 2 pointers and return in one pass
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int ReturnKthToLastOnePass(LinkedList list, int k)
        {
            if (list == null || list.Head == null)
            {
                throw new ArgumentNullException("Invalid Linked List passed in.");
            }

            if (k < 1)
            {
                throw new ArgumentOutOfRangeException($"k={k} is not a valid position in the list.");
            }

            Node current = list.Head;
            Node runner = list.Head;
            // move current k nodes into the list - time O(k)
            for (int i = 0; i < k; i++)
            {
                if (current == null)
                {
                    throw new ArgumentOutOfRangeException($"k={k} is not a valid position in the list.");
                }
                current = current.Next;
            }

            // move both current and runner at the same pace - time O(n - k)
            while (current != null)
            {
                current = current.Next;
                runner = runner.Next;
            }
            return runner.Data;
        }
    }
}
