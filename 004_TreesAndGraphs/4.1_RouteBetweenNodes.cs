using System;
using System.Collections.Generic;

namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.1) Route Between Nodes:
    /// Given a directed graph, design an algorithm to find out whether there is a route between two nodes.
    /// </summary>
    public class Question_4_1
    {
        /// <summary>
        /// BFS from both nodes to check there is a route from either direction
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graph"></param>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public static bool ExistsRoute<T>(Graph<T> graph, GraphNode<T> node1, GraphNode<T> node2)
        {
            if (graph.Nodes.Count == 0 || node1 == null || node2 == null)
            {
                throw new ArgumentException("Invalid input graph/nodes passed in.");
            }

            if (node1 == node2)
            {
                return true;
            }

            // set all nodes in graph as NOT Visited - time O(n)
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                graph.Nodes[i].Visited = false;
            }

            // BFS from node1 - time O(n)
            bool result1 = RouteExists(node1, node2);
            if (result1)
            {
                return result1;
            }

            // set all nodes in graph as NOT Visited again - time O(n)
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                graph.Nodes[i].Visited = false;
            }

            // BFS from node2 - time O(n)
            return RouteExists(node2, node1);
        }

        private static bool RouteExists<T>(GraphNode<T> start, GraphNode<T> end)
        {
            var bfsQueue = new Queue<GraphNode<T>>();
            start.Visited = true;
            bfsQueue.Enqueue(start);
            while (bfsQueue.Count > 0)
            {
                GraphNode<T> temp = bfsQueue.Dequeue();
                foreach (GraphNode<T> tempChild in temp.Children)
                {
                    if (!tempChild.Visited)
                    {
                        if (tempChild == end)
                        {
                            return true;
                        }
                        tempChild.Visited = true;
                        bfsQueue.Enqueue(tempChild);
                    }
                }
            }
            return false;
        }
    }
}
