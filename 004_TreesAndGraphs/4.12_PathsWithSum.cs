using System.Collections.Generic;

namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.12) Paths with Sum:
    /// You are given a binary tree in which each node contains an integer value (which might be positive or negative).
    /// Design an algorithm to count the number of paths that sum to a given value.
    /// The path does not need to start or end at the root or a leaf, but it must go downwards (traveling only from parent nodes to child nodes).
    /// </summary>
    public class Question_4_12
    {
        /// <summary>
        /// Traverse down each node recursively and pass down the list of sums to the next level.
        /// At each node, it calculates the count of matching sums and pass back the count.
        /// <para>Time Complexity: O(n*log(n))</para>
        /// <para>Space Complexity: O(log(n))</para>
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static int CountPathsWithSum(BinaryTreeNode<int> root, int sum)
        {
            if (root == null)
            {
                return 0;
            }

            return (root.Data == sum ? 1 : 0) + CountChildrenSums(root, new List<int>(1) { root.Data }, sum);
        }

        /// <summary>
        /// <para>Time Complexity: O(n*log(n))</para>
        /// <para>Space Complexity: O(log(n))</para>
        /// </summary>
        /// <param name="node"></param>
        /// <param name="sumList"></param>
        /// <param name="sumRef"></param>
        /// <returns></returns>
        private static int CountChildrenSums(BinaryTreeNode<int> node, List<int> sumList, int sumRef)
        {
            int count = 0;
            if (node.Left != null)
            {
                var leftSumList = new List<int>(sumList);
                count += CountNodeSums(node.Left, leftSumList, sumRef) + CountChildrenSums(node.Left, leftSumList, sumRef);
            }

            if (node.Right != null)
            {
                var rightSumList = new List<int>(sumList);
                count += CountNodeSums(node.Right, rightSumList, sumRef) + CountChildrenSums(node.Right, rightSumList, sumRef);
            }
            return count;
        }

        /// <summary>
        /// <para>Time Complexity: O(h), where h = height of the current node</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="node"></param>
        /// <param name="baseSumList"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        private static int CountNodeSums(BinaryTreeNode<int> node, List<int> baseSumList, int sum)
        {
            int count = node.Data == sum ? 1 : 0;
            for (int i = 0; i < baseSumList.Count; i++)
            {
                baseSumList[i] += node.Data;
                if (baseSumList[i] == sum)
                {
                    count++;
                }
            }
            baseSumList.Add(node.Data);
            return count;
        }

        /// <summary>
        /// Keep track of running sums and counts recursively and use math calculations to determine the path counts
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static int CountPathsWithSumOptimized(BinaryTreeNode<int> root, int sum)
        {
            return CountPathsWithSumOptimized(root, sum, 0, new Dictionary<int, int>());
        }

        private static int CountPathsWithSumOptimized(BinaryTreeNode<int> node, int sumRef, int runningSum, Dictionary<int, int> pathCounts)
        {
            if (node == null)
            {
                return 0;
            }

            runningSum += node.Data;
            int sum = runningSum - sumRef;
            int count = pathCounts.ContainsKey(sum) ? pathCounts[sum] : 0;

            if (runningSum == sumRef)
            {
                count++;
            }

            IncrementDictionary(pathCounts, runningSum, 1);
            count += CountPathsWithSumOptimized(node.Left, sumRef, runningSum, pathCounts);
            count += CountPathsWithSumOptimized(node.Right, sumRef, runningSum, pathCounts);
            IncrementDictionary(pathCounts, runningSum, -1);

            return count;
        }

        private static void IncrementDictionary(Dictionary<int, int> dict, int key, int delta)
        {
            int value = (dict.ContainsKey(key) ? dict[key] : 0) + delta;
            if (value == 0)
            {
                dict.Remove(key);
            }
            else
            {
                if (dict.ContainsKey(key))
                {
                    dict[key] = value;
                }
                else
                {
                    dict.Add(key, value);
                }
            }
        }
    }
}
