using System;

namespace LinkedListApp
{
    public static class SumLinkedList
    {
        public static Node SumBackward(Node head1, Node head2)
        {
            Node sumHead = null;
            Node n = null;
            int carryforward = 0;
            while (head1 != null || head2 != null)
            {
                int sum = 0;
                if (head1 != null)
                {
                    sum += head1.Data;
                    head1 = head1.Next;
                }
                if (head2 != null)
                {
                    sum += head2.Data;
                    head2 = head2.Next;
                }
                sum += carryforward;

                if (sumHead == null)
                {
                    sumHead = new Node(sum % 10);
                    n = sumHead;
                }
                else
                {
                    n.Next = new Node(sum % 10);
                    n = n.Next;
                }
                carryforward = sum / 10;
            }
            return sumHead;
        }
    }
}
