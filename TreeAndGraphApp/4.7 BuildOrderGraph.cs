using System.Collections.Generic;

namespace TreeAndGraphApp
{
    public static class BuildOrderGraph
    {
        public static List<string> FindBuildOrder(string[] projects, KeyValuePair<string, string>[] dependencies)
        {
            var graph = BuildGraph(projects, dependencies);
            var result = new List<string>();
            while (graph.Nodes.Count > 0)
            {
                for (int i = 0; i < projects.Length; i++)
                {
                    if (graph.Nodes.ContainsKey(projects[i]))
                    {
                        List<string> edges = graph.Nodes[projects[i]];
                        if (edges.Count == 0)
                        {
                            result.Add(projects[i]);
                            graph.Nodes.Remove(projects[i]);
                            for (int j = 0; j < dependencies.Length; j++)
                            {
                                if (dependencies[j].Key == projects[i])
                                {
                                    graph.RemoveEdge(dependencies[j].Value, projects[i]);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        private static Graph_v2<string> BuildGraph(string[] projects, KeyValuePair<string, string>[] dependencies)
        {
            var graph = new Graph_v2<string>();
            for (int i = 0; i < projects.Length; i++)
            {
                graph.AddNode(projects[i]);
            }

            for (int j = 0; j < dependencies.Length; j++)
            {
                string u = dependencies[j].Value;
                string v = dependencies[j].Key;
                graph.AddEdge(u, v);
            }
            return graph;
        }
    }
}
