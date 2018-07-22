using System;

namespace SortAndSearchApp
{
    public class RankFromStream
    {
        private RankNode _root;

        public RankFromStream() => _root = null;

        public void Track(int x)
        {
            if (_root == null)
            {
                _root = new RankNode(x);
            }
            else
            {
                _root.Insert(x);
            }
        }

        public int GetRankOfNumber(int x)
        {
            return _root.GetRank(x);
        }

        public void PrintNumbersInOrder()
        {
            PrintNumberInOrder(_root);
        }

        private void PrintNumberInOrder(RankNode node)
        {
            if (node != null)
            {
                PrintNumberInOrder(node.Left);
                Console.Write($"{node.Data} -> ");
                PrintNumberInOrder(node.Right);
            }
        }
    }

    public class RankNode
    {
        public RankNode Left { get; set; }
        public RankNode Right { get; set; }
        public int Data { get; private set; }
        private int _leftSize;

        public RankNode(int data)
        {
            this.Data = data;
            this._leftSize = 0;
        }

        public void Insert(int d)
        {
            if (d <= Data)
            {
                if (this.Left == null)
                {
                    this.Left = new RankNode(d);
                }
                else
                {
                    this.Left.Insert(d);
                }
                this._leftSize++;
            }
            else
            {
                if (this.Right == null)
                {
                    this.Right = new RankNode(d);
                }
                else
                {
                    this.Right.Insert(d);
                }
            }
        }

        public int GetRank(int d)
        {
            if (this.Data == d)
            {
                return this._leftSize;
            }
            else if (d < this.Data)
            {
                if (this.Left == null)
                {
                    return -1; // Node not found
                }
                return this.Left.GetRank(d);
            }
            else
            {
                if (this.Right == null)
                {
                    return -1; // Node not found
                }
                int rightRank = this.Right.GetRank(d);
                if (rightRank == -1)
                {
                    return -1; // Bubble the error up
                }
                return this._leftSize + 1 + rightRank;
            }
        }
    }
}
