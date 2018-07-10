using System;
using System.Collections;
using System.Collections.Generic;

namespace TreeAndGraphApp
{
    public class Graph<T>
    {
        public List<GraphNode<T>> Nodes { get; set; }

        public Graph() => Nodes = new List<GraphNode<T>>();

        public static void PrintGraphDepthFirst(GraphNode<T> node)
        {
            if (node != null)
            {
                Console.Write($"{node} --> ");
                node.DfsVisited = true;
                for (int i = 0; i < node.Adjacent.Count; i++)
                {
                    var adjNode = node.Adjacent[i];
                    if (!adjNode.DfsVisited)
                    {
                        PrintGraphDepthFirst(adjNode);
                    }
                }
            }
        }

        public static void PrintGraphBreadthFirst(GraphNode<T> root)
        {
            var queue = new Queue<GraphNode<T>>();
            if (root != null)
            {
                root.BfsMarked = true;
                queue.Enqueue(root);

                while (queue.Count > 0)
                {
                    GraphNode<T> node = queue.Dequeue();
                    Console.Write($"{node} --> ");
                    for (int i = 0; i < node.Adjacent.Count; i++)
                    {
                        var adjNode = node.Adjacent[i];
                        if (!adjNode.BfsMarked)
                        {
                            adjNode.BfsMarked = true;
                            queue.Enqueue(adjNode);
                        }
                    }
                }
            }
        }
    }

    public class GraphNode<T>
    {
        public T Data { get; private set; }
        public List<GraphNode<T>> Adjacent { get; set; }
        public bool DfsVisited { get; set; }
        public bool BfsMarked { get; set; }

        public GraphNode(T data)
        {
            this.Data = data;
            this.Adjacent = new List<GraphNode<T>>();
            this.DfsVisited = false;
            this.BfsMarked = false;
        }

        public override string ToString() => $"{Data}";
    }
}
