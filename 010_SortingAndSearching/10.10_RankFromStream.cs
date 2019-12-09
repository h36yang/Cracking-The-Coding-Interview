using _004_TreesAndGraphs;

namespace _010_SortingAndSearching
{
    /// <summary>
    /// 10.10) Rank from Stream:
    /// Imagine you are reading in a stream of integers.
    /// Periodically, you wish to be able to look up the rank of a number x (the number of values less than or equal to x).
    /// Implement the data structures and algorithms to support these operations.
    /// That is, implement the method track (int x), which is called when each number is generated, 
    /// and the method getRankOfNumber(int x), which returns the number of values less than or equal to x (not including x itself).
    /// </summary>
    public static class Question_10_10
    {
        /// <summary>
        /// Data Structure used: Binary Search Tree
        /// </summary>
        public class RankStream
        {
            private class ModifiedInt
            {
                public int Value { get; private set; }

                public int Occurrence { get; set; } = 1;

                public int NumberOfLeftChildren { get; set; } = 0;

                public ModifiedInt(int value)
                {
                    Value = value;
                }
            }

            private BinaryTreeNode<ModifiedInt> _root;

            /// <summary>
            /// <para>Time Complexity: O(log(n)) on average and O(n) on worst case</para>
            /// <para>Space Complexity: O(log(n)) on average and O(n) on worst case</para>
            /// </summary>
            /// <param name="x"></param>
            public void Track(int x)
            {
                if (_root == null)
                {
                    _root = new BinaryTreeNode<ModifiedInt>(new ModifiedInt(x));
                }
                else
                {
                    Track(x, _root);
                }
            }

            private void Track(int x, BinaryTreeNode<ModifiedInt> node)
            {
                if (node.Data.Value == x)
                {
                    node.Data.Occurrence++;
                }
                else if (node.Data.Value > x)
                {
                    node.Data.NumberOfLeftChildren++;
                    if (node.Left != null)
                    {
                        Track(x, node.Left);
                    }
                    else
                    {
                        node.Left = new BinaryTreeNode<ModifiedInt>(new ModifiedInt(x));
                    }
                }
                else
                {
                    if (node.Right != null)
                    {
                        Track(x, node.Right);
                    }
                    else
                    {
                        node.Right = new BinaryTreeNode<ModifiedInt>(new ModifiedInt(x));
                    }
                }
            }

            /// <summary>
            /// <para>Time Complexity: O(log(n)) on average and O(n) on worst case</para>
            /// <para>Space Complexity: O(log(n)) on average and O(n) on worst case</para>
            /// </summary>
            /// <param name="x"></param>
            /// <returns></returns>
            public int GetRankOfNumber(int x)
            {
                return GetRankOfNumber(x, _root);
            }

            private int GetRankOfNumber(int x, BinaryTreeNode<ModifiedInt> node)
            {
                if (node == null)
                {
                    return -1;
                }

                if (node.Data.Value == x)
                {
                    return node.Data.NumberOfLeftChildren + node.Data.Occurrence - 1;
                }
                else if (node.Data.Value > x)
                {
                    return GetRankOfNumber(x, node.Left);
                }
                else
                {
                    int rank = GetRankOfNumber(x, node.Right);
                    if (rank <= -1)
                    {
                        return -1;
                    }
                    return node.Data.NumberOfLeftChildren + node.Data.Occurrence + rank;
                }
            }
        }
    }
}
