using System;

namespace LinkedListApp
{
    public static class IntersectingLinkedList
    {
        private class TailAndLength
        {
            public Node Tail { set; get; }
            public int Length { set; get; }
        }

        public static Node Intersection(Node head1, Node head2)
        {
            var tailAndLength1 = GetTailAndLength(head1);
            var tailAndLength2 = GetTailAndLength(head2);
            if (tailAndLength1.Tail != tailAndLength2.Tail)
            {
                return null;
            }

            int lengthDiff;
            if (tailAndLength1.Length > tailAndLength2.Length)
            {
                lengthDiff = tailAndLength1.Length - tailAndLength2.Length;
                for (int i = 0; i < lengthDiff; i++)
                {
                    head1 = head1.Next;
                }
            }
            else
            {
                lengthDiff = tailAndLength2.Length - tailAndLength1.Length;
                for (int i = 0; i < lengthDiff; i++)
                {
                    head2 = head2.Next;
                }
            }

            while (head1 != null && head2 != null)
            {
                if (head1 == head2)
                {
                    return head1;
                }
                head1 = head1.Next;
                head2 = head2.Next;
            }
            return tailAndLength1.Tail;
        }

        private static TailAndLength GetTailAndLength(Node head)
        {
            int count = 0;
            var node = head;
            while (node != null)
            {
                node = node.Next;
                count++;
            }
            return new TailAndLength { Tail = node, Length = count };
        }
    }
}
