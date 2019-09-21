namespace _002_LinkedLists
{
    /// <summary>
    /// 2.6) Palindrome:
    /// Implement a function to check if a linked list is a palindrome.
    /// </summary>
    public class Question_2_6
    {
        /// <summary>
        /// Reverse and compare using a stack
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsPalindrome(LinkedList list)
        {
            if (!Helper.IsValidList(list))
            {
                return false;
            }

            if (list.Head != null && list.Head.Next == null)
            {
                // if the list contains only 1 node
                return true;
            }

            // push each node into stack - time O(n)
            var stack = Helper.ConvertLinkedListToStack(list);

            // compare each node on pop - time O(n)
            LinkedListNode temp = list.Head;
            while (temp != null)
            {
                if (stack.Pop() != temp.Data)
                {
                    return false;
                }
                temp = temp.Next;
            }
            return true;
        }

        /// <summary>
        /// Check recursively
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsPalindromeRecursive(LinkedList list)
        {
            if (!Helper.IsValidList(list))
            {
                return false;
            }

            if (list.Head != null && list.Head.Next == null)
            {
                // if the list contains only 1 node
                return true;
            }

            // get the length of the list - time O(n)
            (int length, _) = list.GetLengthAndTail();

            // check if palindrome recursively - time O(n)
            return IsPalindromeRecursiveInner(list.Head, length).yes;
        }

        private static (LinkedListNode nodeToCompare, bool yes) IsPalindromeRecursiveInner(LinkedListNode n, int length)
        {
            if (length == 0)
            {
                return (n, true);
            }
            else if (length == 1)
            {
                return (n.Next, true);
            }
            else
            {
                (LinkedListNode nodeToCompare, bool yes) = IsPalindromeRecursiveInner(n.Next, length - 2);
                if (!yes)
                {
                    return (null, false);
                }
                else
                {
                    return (nodeToCompare.Next, n.Data == nodeToCompare.Data);
                }
            }
        }
    }
}
