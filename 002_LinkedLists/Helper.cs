using System.Collections.Generic;

namespace _002_LinkedLists
{
    public class Helper
    {
        public static bool IsValidList(LinkedList list)
        {
            return list != null && list.Head != null;
        }

        public static LinkedList ConvertIntToListOfDigitsReverse(int? value)
        {
            var result = new LinkedList();
            if (!value.HasValue)
            {
                return result;
            }

            string strValue = value.Value.ToString();
            LinkedListNode temp = null;
            for (int i = strValue.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(strValue[i].ToString());
                if (result.Head == null)
                {
                    result.Head = new LinkedListNode(digit);
                    temp = result.Head;
                }
                else
                {
                    temp.Next = new LinkedListNode(digit);
                    temp = temp.Next;
                }
            }
            return result;
        }

        public static LinkedList ConvertIntToListOfDigitsForward(int? value)
        {
            var result = new LinkedList();
            if (!value.HasValue)
            {
                return result;
            }

            string strValue = value.Value.ToString();
            LinkedListNode temp = null;
            for (int i = 0; i < strValue.Length; i++)
            {
                int digit = int.Parse(strValue[i].ToString());
                if (result.Head == null)
                {
                    result.Head = new LinkedListNode(digit);
                    temp = result.Head;
                }
                else
                {
                    temp.Next = new LinkedListNode(digit);
                    temp = temp.Next;
                }
            }
            return result;
        }

        public static Stack<int> ConvertLinkedListToStack(LinkedList list)
        {
            var stack = new Stack<int>();
            LinkedListNode temp = list.Head;
            while (temp != null)
            {
                stack.Push(temp.Data);
                temp = temp.Next;
            }
            return stack;
        }
    }
}
