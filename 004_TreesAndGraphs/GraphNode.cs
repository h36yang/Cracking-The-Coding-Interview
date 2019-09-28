using System.Collections.Generic;

namespace _004_TreesAndGraphs
{
    public class GraphNode<T>
    {
        public T Data { get; set; }

        public List<GraphNode<T>> Children { get; set; } = new List<GraphNode<T>>();

        public bool Visited { get; set; }

        public GraphNode(T data)
        {
            Data = data;
            Visited = false;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
