using System;
using System.Collections.Generic;

namespace TreeAndGraphApp
{
    public class Graph_v2<T>
    {
        public Dictionary<T, List<T>> Nodes { get; private set; }

        public Graph_v2() => this.Nodes = new Dictionary<T, List<T>>();

        public void AddNode(T u)
        {
            if (u == null)
            {
                throw new ArgumentNullException($"Invalid node.");
            }

            if (Nodes.ContainsKey(u))
            {
                throw new Exception($"Node {u} already exists.");
            }

            Nodes.Add(u, new List<T>());
        }

        public void AddEdge(T u, T v)
        {
            if (u == null || v == null)
            {
                throw new ArgumentNullException($"Invalid node(s).");
            }

            if (!Nodes.ContainsKey(u))
            {
                AddNode(u);
            }
            Nodes[u].Add(v);
        }

        public void RemoveEdge(T u, T v)
        {
            if (u == null || v == null)
            {
                throw new ArgumentNullException($"Invalid node(s).");
            }

            if (Nodes.ContainsKey(u))
            {
                Nodes[u].Remove(v);
            }
        }
    }
}
