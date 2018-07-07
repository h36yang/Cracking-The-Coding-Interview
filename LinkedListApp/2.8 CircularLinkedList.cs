using System.Collections.Generic;

namespace LinkedListApp
{
    public static class CircularLinkedList
    {
        public static Node GetLoopStartsAt(Node head)
        {
            var tempBuffer = new Dictionary<Node, int>();
            var node = head;
            while (node != null)
            {
                if (!tempBuffer.ContainsKey(node))
                {
                    tempBuffer.Add(node, 1);
                }
                else
                {
                    return node;
                }
                node = node.Next;
            }
            return null;
        }
    }
}
