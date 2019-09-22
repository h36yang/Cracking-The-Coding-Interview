using System;
using System.Collections.Generic;

namespace _004_TreesAndGraphs
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public int Height
        {
            get
            {
                return 1 + Math.Max(Left?.Height ?? 0, Right?.Height ?? 0);
            }
        }

        public List<T> ToListInOrder()
        {
            var result = new List<T>();
            if (Left != null)
            {
                result.AddRange(Left.ToListInOrder());
            }
            result.Add(Data);
            if (Right != null)
            {
                result.AddRange(Right.ToListInOrder());
            }
            return result;
        }
    }
}
