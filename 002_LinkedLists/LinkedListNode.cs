namespace _002_LinkedLists
{
    public class LinkedListNode
    {
        public int Data { get; set; }

        public LinkedListNode Next { get; set; } = null;

        public LinkedListNode(int data)
        {
            Data = data;
        }
    }
}
