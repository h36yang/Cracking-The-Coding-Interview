namespace LinkedListApp
{
    public static class PartitionLinkedList
    {
        public static Node Partition(Node head, int partition)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }
            
            Node newHead = head;
            Node newTail = head;

            while (head != null)
            {
                Node next = head.Next;
                if (head.Data < partition)
                {
                    head.Next = newHead;
                    newHead = head;
                }
                else
                {
                    newTail.Next = head;
                    newTail = head;
                }
                head = next;
            }
            newTail.Next = null;

            return newHead;
        }

        public static Node Partition_old(Node head, int partition)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }

            Node leftStart = null;
            Node leftEnd = null;
            Node rightStart = null;
            Node rightEnd = null;

            while (head != null)
            {
                Node next = head.Next;
                head.Next = null;

                if (head.Data < partition)
                {
                    if (leftEnd == null)
                    {
                        leftStart = head;
                        leftEnd = leftStart;
                    }
                    else
                    {
                        leftEnd.Next = head;
                        leftEnd = leftEnd.Next;
                    }
                }
                else
                {
                    if (rightEnd == null)
                    {
                        rightStart = head;
                        rightEnd = rightStart;
                    }
                    else
                    {
                        rightEnd.Next = head;
                        rightEnd = rightEnd.Next;
                    }
                }
                head = next;
            }

            leftEnd.Next = rightStart;
            return leftStart;
        }
    }
}
