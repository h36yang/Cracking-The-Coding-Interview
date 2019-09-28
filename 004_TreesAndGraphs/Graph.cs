using System.Collections.Generic;

namespace _004_TreesAndGraphs
{
    public class Graph<T>
    {
        public List<GraphNode<T>> Nodes { get; set; } = new List<GraphNode<T>>();

        public Graph() { }
    }
}
