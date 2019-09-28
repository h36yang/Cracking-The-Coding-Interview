using System;
using System.Collections.Generic;

namespace _004_TreesAndGraphs
{
    public class BinaryTreeNode<T>
    {
        public T Data { get; set; }

        public BinaryTreeNode<T> Left { get; set; }

        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode<T> Parent { get; set; }

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

        public bool HasChild(BinaryTreeNode<T> node)
        {
            if (this == node)
            {
                return true;
            }
            else
            {
                bool leftHasChild = Left?.HasChild(node) ?? false;
                bool rightHasChild = Right?.HasChild(node) ?? false;
                return leftHasChild | rightHasChild;
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
