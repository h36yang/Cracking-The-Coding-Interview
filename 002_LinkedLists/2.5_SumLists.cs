using System.Collections.Generic;

namespace _002_LinkedLists
{
    /// <summary>
    /// 2.5) Sum Lists:
    /// You have two numbers represented by a linked list, where each node contains a single digit.
    /// The digits are stored in reverse order, such that the 1's digit is at the head of the list.
    /// Write a function that adds the two numbers and returns the sum as a linked list.
    /// FOLLOW UP:
    /// Suppose the digits are stored in forward order. Repeat the above problem.
    /// </summary>
    public class Question_2_5
    {
        /// <summary>
        /// Write a function that adds the two numbers and returns the sum as a linked list.
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static LinkedList SumListsReverse(LinkedList list1, LinkedList list2)
        {
            if (!Helper.IsValidList(list1))
            {
                return list2;
            }

            if (!Helper.IsValidList(list2))
            {
                return list1;
            }

            LinkedListNode temp1 = list1.Head;
            LinkedListNode temp2 = list2.Head;
            int carry = 0;
            var resultList = new LinkedList();
            LinkedListNode resultTemp = null;
            while (temp1 != null || temp2 != null || carry > 0)
            {
                int digit1 = temp1 != null ? temp1.Data : 0;
                int digit2 = temp2 != null ? temp2.Data : 0;
                int sum = digit1 + digit2 + carry;

                carry = 0;
                if (sum >= 10)
                {
                    carry = sum / 10;
                    sum %= 10;
                }

                if (resultList.Head == null)
                {
                    resultList.Head = new LinkedListNode(sum);
                    resultTemp = resultList.Head;
                }
                else
                {
                    resultTemp.Next = new LinkedListNode(sum);
                    resultTemp = resultTemp.Next;
                }

                if (temp1 != null)
                {
                    temp1 = temp1.Next;
                }
                if (temp2 != null)
                {
                    temp2 = temp2.Next;
                }
            }
            return resultList;
        }

        /// <summary>
        /// Recursive solution
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static LinkedList SumListsReverseRecursive(LinkedList list1, LinkedList list2)
        {
            if (!Helper.IsValidList(list1))
            {
                return list2;
            }

            if (!Helper.IsValidList(list2))
            {
                return list1;
            }

            int sum = SumListsReverseRecursiveInner(list1, list2, 0);
            return Helper.ConvertIntToListOfDigitsReverse(sum);
        }

        private static int SumListsReverseRecursiveInner(LinkedList list1, LinkedList list2, int carry)
        {
            if (list1.Head == null && list2.Head == null && carry == 0)
            {
                return 0; // base case
            }
            else
            {
                int digit1 = list1.Head != null ? list1.Head.Data : 0;
                int digit2 = list2.Head != null ? list2.Head.Data : 0;
                int sum = digit1 + digit2 + carry;
                carry = 0;
                if (sum >= 10)
                {
                    carry = sum / 10;
                    sum %= 10;
                }

                if (list1.Head != null)
                {
                    list1.Head = list1.Head.Next;
                }
                if (list2.Head != null)
                {
                    list2.Head = list2.Head.Next;
                }
                return sum + 10 * SumListsReverseRecursiveInner(list1, list2, carry);
            }
        }

        /// <summary>
        /// Suppose the digits are stored in forward order. Repeat the above problem.
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static LinkedList SumListsForward(LinkedList list1, LinkedList list2)
        {
            if (!Helper.IsValidList(list1))
            {
                return list2;
            }

            if (!Helper.IsValidList(list2))
            {
                return list1;
            }

            // Push both input lists into stacks - time O(n) * 2
            var stack1 = Helper.ConvertLinkedListToStack(list1);
            var stack2 = Helper.ConvertLinkedListToStack(list2);

            // Calculate and store into another stack - time O(n)
            var resultStack = new Stack<int>();
            int carry = 0;
            while (stack1.Count > 0 || stack2.Count > 0 || carry > 0)
            {
                int digit1 = stack1.Count > 0 ? stack1.Pop() : 0;
                int digit2 = stack2.Count > 0 ? stack2.Pop() : 0;
                int sum = digit1 + digit2 + carry;

                carry = 0;
                if (sum >= 10)
                {
                    carry = sum / 10;
                    sum %= 10;
                }
                resultStack.Push(sum);
            }

            // Convert result stack back to linked list - time O(n)
            return new LinkedList(resultStack);
        }
    }
}
