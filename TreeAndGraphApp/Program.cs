using System;

namespace TreeAndGraphApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Intro

            // Binary Tree Traversal
            var btRoot = new TreeNode<int>(8);
            btRoot.Left = new TreeNode<int>(5);
            btRoot.Left.Left = new TreeNode<int>(1);
            btRoot.Left.Right = new TreeNode<int>(13);
            btRoot.Right = new TreeNode<int>(10);
            btRoot.Right.Right = new TreeNode<int>(20);
            TreeNode<int>.PrintTreeInOrder(btRoot);
            Console.WriteLine();
            TreeNode<int>.PrintTreePreOrder(btRoot);
            Console.WriteLine();
            TreeNode<int>.PrintTreePostOrder(btRoot);
            Console.WriteLine();

            // Graph Traversal
            var gNode0 = new GraphNode<int>(0);
            var gNode1 = new GraphNode<int>(1);
            var gNode2 = new GraphNode<int>(2);
            var gNode3 = new GraphNode<int>(3);
            var gNode4 = new GraphNode<int>(4);
            var gNode5 = new GraphNode<int>(5);
            gNode0.Adjacent.Add(gNode1);
            gNode0.Adjacent.Add(gNode4);
            gNode0.Adjacent.Add(gNode5);
            gNode1.Adjacent.Add(gNode3);
            gNode1.Adjacent.Add(gNode4);
            gNode2.Adjacent.Add(gNode1);
            gNode3.Adjacent.Add(gNode2);
            gNode3.Adjacent.Add(gNode4);
            Graph<int>.PrintGraphDepthFirst(gNode0);
            Console.WriteLine();
            Graph<int>.PrintGraphBreadthFirst(gNode0);
            Console.WriteLine();

            #endregion

            #region 4.1

            // 4.1 Test Case 1
            var gNode411_0 = new GraphNode<int>(0);
            var gNode411_1 = new GraphNode<int>(1);
            var gNode411_2 = new GraphNode<int>(2);
            var gNode411_3 = new GraphNode<int>(3);
            var gNode411_4 = new GraphNode<int>(4);
            var gNode411_5 = new GraphNode<int>(5);
            gNode411_0.Adjacent.Add(gNode411_1);
            gNode411_0.Adjacent.Add(gNode411_4);
            gNode411_0.Adjacent.Add(gNode411_5);
            gNode411_1.Adjacent.Add(gNode411_3);
            gNode411_1.Adjacent.Add(gNode411_4);
            gNode411_2.Adjacent.Add(gNode411_1);
            gNode411_3.Adjacent.Add(gNode411_2);
            gNode411_3.Adjacent.Add(gNode411_4);
            var result411 = RouteBetweenGraphNodes.IsThereRouteBetweenNodes<int>(gNode411_0, gNode411_2);
            Console.WriteLine($"Route exists? {result411}");

            // 4.1 Test Case 2
            var gNode412_0 = new GraphNode<int>(0);
            var gNode412_1 = new GraphNode<int>(1);
            var gNode412_2 = new GraphNode<int>(2);
            var gNode412_3 = new GraphNode<int>(3);
            var gNode412_4 = new GraphNode<int>(4);
            var gNode412_5 = new GraphNode<int>(5);
            gNode412_0.Adjacent.Add(gNode412_1);
            gNode412_0.Adjacent.Add(gNode412_4);
            gNode412_1.Adjacent.Add(gNode412_3);
            gNode412_1.Adjacent.Add(gNode412_4);
            gNode412_2.Adjacent.Add(gNode412_1);
            gNode412_3.Adjacent.Add(gNode412_2);
            gNode412_3.Adjacent.Add(gNode412_4);
            var result412 = RouteBetweenGraphNodes.IsThereRouteBetweenNodes<int>(gNode412_0, gNode412_5);
            Console.WriteLine($"Route exists? {result412}");

            #endregion

            #region 4.2

            // 4.2 Test Case 1
            var array421 = new int[]
            {
                1, 3, 5, 7, 9, 10, 15
            };
            var tree421 = MinimalTree.CreateBST(array421);
            TreeNode<int>.PrintTreePreOrder(tree421);
            Console.WriteLine();

            // 4.2 Test Case 2
            var array422 = new int[]
            {
                1, 3, 5, 7, 9, 10, 15, 16
            };
            var tree422 = MinimalTree.CreateBST(array422);
            TreeNode<int>.PrintTreePreOrder(tree422);
            Console.WriteLine();

            #endregion

            #region 4.4

            // 4.4 Test Case 1
            var root441 = new TreeNode<string>("Root 4.4-1");
            root441.Left = new TreeNode<string>("L1");
            root441.Left.Left = new TreeNode<string>("LL2");
            root441.Right = new TreeNode<string>("R1");
            root441.Right.Left = new TreeNode<string>("RL2");
            root441.Right.Left.Right = new TreeNode<string>("RLR3");
            root441.Right.Right = new TreeNode<string>("RR2");
            var result441 = BalancedTree.IsTreeBalanced<string>(root441);
            TreeNode<string>.PrintTreePreOrder(root441);
            Console.WriteLine($"\nTree Balanced? {result441}");

            // 4.4 Test Case 2
            var root442 = new TreeNode<string>("Root 4.4-2");
            root442.Left = new TreeNode<string>("L1");
            root442.Left.Left = new TreeNode<string>("LL2");
            root442.Left.Left.Left = new TreeNode<string>("LLL3");
            root442.Right = new TreeNode<string>("R1");
            root442.Right.Right = new TreeNode<string>("RR2");
            var result442 = BalancedTree.IsTreeBalanced<string>(root442);
            TreeNode<string>.PrintTreePreOrder(root442);
            Console.WriteLine($"\nTree Balanced? {result442}");

            #endregion

            #region 4.5

            // 4.5 Test Case 1
            var root451 = new TreeNode<int>(7);
            root451.Left = new TreeNode<int>(3);
            root451.Left.Left = new TreeNode<int>(1);
            root451.Left.Right = new TreeNode<int>(5);
            root451.Right = new TreeNode<int>(10);
            root451.Right.Left = new TreeNode<int>(9);
            root451.Right.Right = new TreeNode<int>(15);
            root451.Right.Right.Right = new TreeNode<int>(16);
            var result451 = BinarySearchTree.IsBST(root451);
            TreeNode<int>.PrintTreePreOrder(root451);
            Console.WriteLine($"\nIs BST? {result451}");

            // 4.5 Test Case 2
            var root452 = new TreeNode<int>(7);
            root452.Left = new TreeNode<int>(8);
            root452.Left.Left = new TreeNode<int>(1);
            root452.Left.Right = new TreeNode<int>(5);
            root452.Right = new TreeNode<int>(10);
            root452.Right.Left = new TreeNode<int>(9);
            root452.Right.Right = new TreeNode<int>(15);
            root452.Right.Right.Right = new TreeNode<int>(16);
            var result452 = BinarySearchTree.IsBST(root452);
            TreeNode<int>.PrintTreePreOrder(root452);
            Console.WriteLine($"\nIs BST? {result452}");

            #endregion
        }
    }
}
