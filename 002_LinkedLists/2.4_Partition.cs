namespace _002_LinkedLists
{
    /// <summary>
    /// 2.4) Partition:
    /// Write code to partition a linked list around a value x, such that all nodes less than x come before all nodes greater than or equal to x.
    /// If x is contained within the list, the values of x only need to be after the elements less than x.
    /// The partition element x can appear anywhere in the "right partition"; it does not need to appear between the left and right partitions.
    /// </summary>
    public class Question_2_4
    {
        /// <summary>
        /// Loop through the list and move nodes smaller than partition to the front
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="partition"></param>
        /// <returns></returns>
        public static bool Partition(LinkedList list, int partition)
        {
            if (list == null || list.Head == null)
            {
                return false;
            }

            Node temp = list.Head.Next;
            bool headBiggerThanPartition = (list.Head.Data >= partition);
            while (temp.Next != null)
            {
                if (temp.Next.Data < partition)
                {
                    Node next = temp.Next.Next;

                    // Insert the node right after Head node
                    var current = temp.Next;
                    current.Next = list.Head.Next;
                    list.Head.Next = current;

                    // Pop the node from original location
                    temp.Next = next;
                }
                else
                {
                    temp = temp.Next;
                }
            }

            // Move Head to Tail if Head is bigger than partition
            if (headBiggerThanPartition)
            {
                temp.Next = new Node(list.Head.Data);
                list.Head = list.Head.Next;
            }
            return true;
        }

        /// <summary>
        /// Compose 2 lists and merge after
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="partition"></param>
        /// <returns></returns>
        public static bool Partition2(LinkedList list, int partition)
        {
            if (list == null || list.Head == null)
            {
                return false;
            }

            Node beforeHead = null;
            Node beforeTail = null;
            Node afterHead = null;
            Node afterTail = null;

            while (list.Head != null)
            {
                Node next = list.Head.Next;
                list.Head.Next = null;
                if (list.Head.Data < partition)
                {
                    if (beforeHead == null)
                    {
                        beforeHead = list.Head;
                        beforeTail = beforeHead;
                    }
                    else
                    {
                        beforeTail.Next = list.Head;
                        beforeTail = beforeTail.Next;
                    }
                }
                else
                {
                    if (afterHead == null)
                    {
                        afterHead = list.Head;
                        afterTail = afterHead;
                    }
                    else
                    {
                        afterTail.Next = list.Head;
                        afterTail = afterTail.Next;
                    }
                }
                list.Head = next;
            }

            // Merge 2 lists
            if (beforeHead == null)
            {
                list.Head = afterHead;
            }
            else
            {
                beforeTail.Next = afterHead;
                list.Head = beforeHead;
            }
            return true;
        }

        /// <summary>
        /// Compose a new list by appending smaller to head and bigger to tail
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="partition"></param>
        /// <returns></returns>
        public static bool Partition3(LinkedList list, int partition)
        {
            if (list == null || list.Head == null)
            {
                return false;
            }

            Node newHead = null;
            Node newTail = null;

            while (list.Head != null)
            {
                Node next = list.Head.Next;
                list.Head.Next = null;
                if (list.Head.Data < partition)
                {
                    if (newHead == null)
                    {
                        newHead = list.Head;
                        newTail = newHead;
                    }
                    else
                    {
                        list.Head.Next = newHead;
                        newHead = list.Head;
                    }
                }
                else
                {
                    if (newTail == null)
                    {
                        newTail = list.Head;
                        newHead = newTail;
                    }
                    else
                    {
                        newTail.Next = list.Head;
                        newTail = list.Head;
                    }
                }
                list.Head = next;
            }

            list.Head = newHead;
            return true;
        }
    }
}
