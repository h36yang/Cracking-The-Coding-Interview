using _004_TreesAndGraphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _004_TreesAndGraphsTest
{
    [TestClass]
    public class Question_4_1_Test
    {
        [TestMethod]
        public void ExistsRouteTest()
        {
            var node0 = new GraphNode<int>(0);
            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);
            var node4 = new GraphNode<int>(4);
            var node5 = new GraphNode<int>(5);
            var node6 = new GraphNode<int>(6);

            node0.Children.Add(node1);
            node1.Children.Add(node2);
            node2.Children.Add(node0);
            node2.Children.Add(node3);
            node3.Children.Add(node2);
            node4.Children.Add(node6);
            node5.Children.Add(node4);
            node6.Children.Add(node5);

            var testGraph = new Graph<int>();
            testGraph.Nodes.Add(node0);
            testGraph.Nodes.Add(node1);
            testGraph.Nodes.Add(node2);
            testGraph.Nodes.Add(node3);
            testGraph.Nodes.Add(node4);
            testGraph.Nodes.Add(node5);
            testGraph.Nodes.Add(node6);

            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node0, node1), "Path does not exist between Node 0 and 1.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node0, node2), "Path does not exist between Node 0 and 2.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node0, node3), "Path does not exist between Node 0 and 3.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node1, node2), "Path does not exist between Node 1 and 2.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node1, node3), "Path does not exist between Node 1 and 3.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node2, node3), "Path does not exist between Node 2 and 3.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node4, node5), "Path does not exist between Node 4 and 5.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node4, node6), "Path does not exist between Node 4 and 6.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node5, node6), "Path does not exist between Node 5 and 6.");

            Assert.IsFalse(Question_4_1.ExistsRoute(testGraph, node0, node4), "Path exists between Node 0 and 4.");
            Assert.IsFalse(Question_4_1.ExistsRoute(testGraph, node3, node5), "Path exists between Node 3 and 5.");
            Assert.IsFalse(Question_4_1.ExistsRoute(testGraph, node1, node6), "Path exists between Node 1 and 6.");
        }

        [TestMethod]
        public void ExistsRouteTest_2()
        {
            var node0 = new GraphNode<int>(0);
            var node1 = new GraphNode<int>(1);
            var node2 = new GraphNode<int>(2);
            var node3 = new GraphNode<int>(3);
            var node4 = new GraphNode<int>(4);
            var node5 = new GraphNode<int>(5);

            node0.Children.Add(node1);
            node0.Children.Add(node4);
            node0.Children.Add(node5);
            node1.Children.Add(node3);
            node1.Children.Add(node4);
            node2.Children.Add(node1);
            node3.Children.Add(node2);
            node3.Children.Add(node4);

            var testGraph = new Graph<int>();
            testGraph.Nodes.Add(node0);
            testGraph.Nodes.Add(node1);
            testGraph.Nodes.Add(node2);
            testGraph.Nodes.Add(node3);
            testGraph.Nodes.Add(node4);
            testGraph.Nodes.Add(node5);

            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node0, node1), "Path does not exist between Node 0 and 1.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node0, node2), "Path does not exist between Node 0 and 2.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node0, node3), "Path does not exist between Node 0 and 3.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node0, node4), "Path does not exist between Node 0 and 4.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node0, node5), "Path does not exist between Node 0 and 5.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node1, node2), "Path does not exist between Node 1 and 2.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node1, node3), "Path does not exist between Node 1 and 3.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node1, node4), "Path does not exist between Node 1 and 4.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node2, node3), "Path does not exist between Node 2 and 3.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node2, node4), "Path does not exist between Node 2 and 4.");
            Assert.IsTrue(Question_4_1.ExistsRoute(testGraph, node3, node4), "Path does not exist between Node 3 and 4.");

            Assert.IsFalse(Question_4_1.ExistsRoute(testGraph, node1, node5), "Path exists between Node 1 and 5.");
            Assert.IsFalse(Question_4_1.ExistsRoute(testGraph, node2, node5), "Path exists between Node 2 and 5.");
            Assert.IsFalse(Question_4_1.ExistsRoute(testGraph, node3, node5), "Path exists between Node 3 and 5.");
            Assert.IsFalse(Question_4_1.ExistsRoute(testGraph, node4, node5), "Path exists between Node 4 and 5.");
        }
    }
}
