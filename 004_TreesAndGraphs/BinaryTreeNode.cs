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

        public int Size { get; set; } = 1;

        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        public int GetHeight()
        {
            return 1 + Math.Max(Left?.GetHeight() ?? 0, Right?.GetHeight() ?? 0);
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

        public BinaryTreeNode<T> GetIthNode(int i)
        {
            int leftSize = Left?.Size ?? 0;
            if (i < leftSize)
            {
                return Left.GetIthNode(i);
            }
            else if (i == leftSize)
            {
                return this;
            }
            else
            {
                return Right.GetIthNode(i - leftSize - 1);
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BinaryTreeNode<T> other))
            {
                return false;
            }

            if ((Left == null && other.Left != null) || (Right == null && other.Right != null))
            {
                return false;
            }

            if (!Data.Equals(other.Data))
            {
                return false;
            }

            bool leftEqual = (Left == null && other.Left == null) || Left.Equals(other.Left);
            if (!leftEqual)
            {
                return false;
            }

            bool rightEqual = (Right == null && other.Right == null) || Right.Equals(other.Right);
            return rightEqual;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Data.GetHashCode();
                if (Left != null)
                {
                    hash = hash * 23 + Left.GetHashCode();
                }
                if (Right != null)
                {
                    hash = hash * 23 + Right.GetHashCode();
                }
                return hash;
            }
        }
    }
}
