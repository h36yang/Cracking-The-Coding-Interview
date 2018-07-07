using System;

namespace LinkedListApp
{
    public static class PalindromeLinkedList
    {
        public static bool IsPalindrome(Node head)
        {
            Node reverseHead = CloneAndReverse(head);
            while (head != null && reverseHead != null)
            {
                if (head.Data != reverseHead.Data)
                {
                    return false;
                }
                head = head.Next;
                reverseHead = reverseHead.Next;
            }
            return head == null && reverseHead == null;
        }

        private static Node CloneAndReverse(Node head)
        {
            Node reverseHead = null;
            while (head != null)
            {
                Node tmp = new Node(head.Data);
                tmp.Next = reverseHead;
                reverseHead = tmp;
                head = head.Next;
            }
            return reverseHead;
        }
    }
}
