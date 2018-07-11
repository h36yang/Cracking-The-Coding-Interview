using System;

namespace TreeAndGraphApp
{
    public class TreeNode<T>
    {
        public T Data { get; private set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public TreeNode<T> Parent { get; set; }
        public int LeftDepth { get; set; }
        public int RightDepth { get; set; }

        public TreeNode(T data) => this.Data = data;

        public override string ToString() => $"{Data}";

        public static void PrintTreeInOrder(TreeNode<T> node)
        {
            if (node != null)
            {
                PrintTreeInOrder(node.Left);
                Console.Write($"{node} --> ");
                PrintTreeInOrder(node.Right);
            }
        }

        public static void PrintTreePreOrder(TreeNode<T> node)
        {
            if (node != null)
            {
                Console.Write($"{node} --> ");
                PrintTreePreOrder(node.Left);
                PrintTreePreOrder(node.Right);
            }
        }

        public static void PrintTreePostOrder(TreeNode<T> node)
        {
            if (node != null)
            {
                PrintTreePostOrder(node.Left);
                PrintTreePostOrder(node.Right);
                Console.Write($"{node} --> ");
            }
        }
    }
}
