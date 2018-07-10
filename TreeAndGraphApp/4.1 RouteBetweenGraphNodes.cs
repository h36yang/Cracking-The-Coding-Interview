using System.Collections.Generic;

namespace TreeAndGraphApp
{
    public static class RouteBetweenGraphNodes
    {
        public static bool IsThereRouteBetweenNodes<T>(GraphNode<T> node1, GraphNode<T> node2)
        {
            if (node1 == null || node2 == null)
            {
                return false;
            }

            var queue = new Queue<GraphNode<T>>();
            node1.BfsMarked = true;
            queue.Enqueue(node1);

            while (queue.Count > 0)
            {
                GraphNode<T> node = queue.Dequeue();
                if (node == node2)
                {
                    return true;
                }

                for (int i = 0; i < node.Adjacent.Count; i++)
                {
                    GraphNode<T> adjNode = node.Adjacent[i];
                    if (!adjNode.BfsMarked)
                    {
                        adjNode.BfsMarked = true;
                        queue.Enqueue(adjNode);
                    }
                }
            }
            return false;
        }
    }
}
