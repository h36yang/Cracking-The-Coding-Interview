using System.Text;

namespace LinkedListApp
{
    public class Node
    {
        public Node Next { get; set; }
        public int Data { get; set; }

        public Node(int data)
        {
            this.Data = data;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Data);
            var n = this;
            while (n.Next != null)
            {
                stringBuilder.Append(" --> ");
                stringBuilder.Append(n.Next.Data);
                n = n.Next;
            }
            return stringBuilder.ToString();
        }
    }
}
