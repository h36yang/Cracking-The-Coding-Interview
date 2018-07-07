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
