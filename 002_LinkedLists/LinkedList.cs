using System.Collections.Generic;
using System.Text;

namespace _002_LinkedLists
{
    public class LinkedList
    {
        public Node Head { get; set; }

        public LinkedList() { }

        public LinkedList(Node head)
        {
            Head = head;
        }

        public LinkedList(IList<int> dataList)
        {
            Head = new Node(dataList[0]);
            Node temp = Head;
            for (int i = 1; i < dataList.Count; i++)
            {
                temp.Next = new Node(dataList[i]);
                temp = temp.Next;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            Node temp = Head;
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
    }
}
