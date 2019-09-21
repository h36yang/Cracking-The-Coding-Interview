using System.Collections.Generic;
using System.Text;

namespace _002_LinkedLists
{
    public class LinkedList
    {
        public LinkedListNode Head { get; set; }

        public LinkedList() { }

        public LinkedList(LinkedListNode head)
        {
            Head = head;
        }

        public LinkedList(IList<int> dataList)
        {
            if (dataList == null || dataList.Count <= 0)
            {
                return;
            }

            Head = new LinkedListNode(dataList[0]);
            LinkedListNode temp = Head;
            for (int i = 1; i < dataList.Count; i++)
            {
                temp.Next = new LinkedListNode(dataList[i]);
                temp = temp.Next;
            }
        }

        public LinkedList(Stack<int> stack)
        {
            if (stack == null || stack.Count <= 0)
            {
                return;
            }

            Head = new LinkedListNode(stack.Pop());
            LinkedListNode temp = Head;
            while (stack.Count > 0)
            {
                temp.Next = new LinkedListNode(stack.Pop());
                temp = temp.Next;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            LinkedListNode temp = Head;
            while (temp != null)
            {
                builder.Append(temp.Data);
                if (temp.Next != null)
                {
                    builder.Append(" --> ");
                }
                temp = temp.Next;
            }
            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is LinkedList that))
            {
                return false;
            }

            return ToString().Equals(that.ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public (int length, LinkedListNode tail) GetLengthAndTail()
        {
            int length = 1;
            LinkedListNode tail = Head;
            while (tail.Next != null)
            {
                length++;
                tail = tail.Next;
            }
            return (length, tail);
        }
    }
}
