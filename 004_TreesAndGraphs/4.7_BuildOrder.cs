using System.Collections.Generic;

namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.7) Build Order:
    /// You are given a list of projects and a list of dependencies (which is a list of pairs of projects, where the second project is dependent on the first project).
    /// All of a project's dependencies must be built before the project is. Find a build order that will allow the projects to be built.
    /// If there is no valid build order, return an error.
    /// </summary>
    public class Question_4_7
    {
        /// <summary>
        /// Convert projects and dependencies to graph representation
        /// <para>Time Complexity: O(N + D)</para>
        /// <para>Space Complexity: O(N + D)</para>
        /// </summary>
        /// <param name="projects">Number of projects = N</param>
        /// <param name="dependencies">Number of dependencies = D</param>
        /// <returns></returns>
        public static List<string> GetProjectsBuildOrder(string[] projects, (string, string)[] dependencies)
        {
            var buildOrder = new List<string>();
            var buildQueue = new Queue<ProjectNode>(); // Space Complexity O(log(N))

            // Convert projects and dependencies to Graph
            var graph = new ProjectGraph();
            // Runtime O(N)
            foreach (string projectName in projects)
            {
                graph.AddOrGetProject(projectName);
            }
            // Runtime O(D)
            foreach ((string start, string end) in dependencies)
            {
                graph.AddEdge(start, end);
            }

            // Add projects with 0 dependencies to build queue first - runtime O(N)
            foreach (ProjectNode project in graph.Nodes)
            {
                if (project.Dependencies == 0)
                {
                    buildQueue.Enqueue(project);
                }
            }

            // Traverse through the rest of the graph via BFS - runtime O(N)
            while (buildQueue.Count > 0)
            {
                ProjectNode temp = buildQueue.Dequeue();
                buildOrder.Add(temp.Name);
                foreach (ProjectNode tempChild in temp.Children)
                {
                    tempChild.Dependencies--;
                    if (tempChild.Dependencies == 0)
                    {
                        buildQueue.Enqueue(tempChild);
                    }
                }
            }
            return buildOrder;
        }

        public class ProjectNode
        {
            public string Name { get; set; }

            public int Dependencies { get; set; } = 0;

            public List<ProjectNode> Children { get; set; } = new List<ProjectNode>();

            public Dictionary<string, ProjectNode> ChildrenMap { get; set; } = new Dictionary<string, ProjectNode>();

            public ProjectNode(string name)
            {
                Name = name;
            }

            /// <summary>
            /// Runtime O(1)
            /// </summary>
            /// <param name="childProject"></param>
            public void AddChildProject(ProjectNode childProject)
            {
                if (!ChildrenMap.ContainsKey(childProject.Name))
                {
                    Children.Add(childProject);
                    ChildrenMap.Add(childProject.Name, childProject);
                    childProject.Dependencies++;
                }
            }
        }

        public class ProjectGraph
        {
            /// <summary>
            /// Space Complexity O(N) - N projects
            /// </summary>
            public List<ProjectNode> Nodes { get; set; } = new List<ProjectNode>();

            /// <summary>
            /// Space Complexity O(D) - D dependencies
            /// </summary>
            public Dictionary<string, ProjectNode> NodesMap { get; set; } = new Dictionary<string, ProjectNode>();

            public ProjectGraph() { }

            /// <summary>
            /// Runtime O(1)
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public ProjectNode AddOrGetProject(string name)
            {
                if (!NodesMap.ContainsKey(name))
                {
                    var node = new ProjectNode(name);
                    Nodes.Add(node);
                    NodesMap.Add(name, node);
                }
                return NodesMap[name];
            }

            /// <summary>
            /// Runtime O(1)
            /// </summary>
            /// <param name="startName"></param>
            /// <param name="endName"></param>
            public void AddEdge(string startName, string endName)
            {
                ProjectNode startNode = AddOrGetProject(startName);
                ProjectNode endNode = AddOrGetProject(endName);
                startNode.AddChildProject(endNode);
            }
        }
    }
}
