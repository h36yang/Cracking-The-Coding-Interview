using System.Collections.Generic;

namespace _004_TreesAndGraphs
{
    /// <summary>
    /// 4.9) BST Sequences:
    /// A binary search tree was created by traversing through an array from left to right and inserting each element.
    /// Given a binary search tree with distinct elements, print all possible arrays that could have led to this tree.
    /// </summary>
    public class Question_4_9
    {
        /// <summary>
        /// Double recursive logic to generate all possible arrays for both Left and Right subtrees, and weave them together
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(log(n))</para>
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<LinkedList<int>> GeneratePossibleArrays(BinaryTreeNode<int> root)
        {
            var resultArrays = new List<LinkedList<int>>();
            if (root == null)
            {
                resultArrays.Add(new LinkedList<int>());
                return resultArrays;
            }

            var prefix = new LinkedList<int>();
            prefix.AddLast(root.Data);

            // Recurse on Left and Right subtrees
            var leftArrays = GeneratePossibleArrays(root.Left);
            var rightArrays = GeneratePossibleArrays(root.Right);

            // Weave together each list from Left and Right sides
            foreach (LinkedList<int> left in leftArrays)
            {
                foreach (LinkedList<int> right in rightArrays)
                {
                    var weaved = new List<LinkedList<int>>();
                    WeaveLists(left, right, weaved, prefix);
                    resultArrays.AddRange(weaved);
                }
            }
            return resultArrays;
        }

        private static void WeaveLists(LinkedList<int> left, LinkedList<int> right, List<LinkedList<int>> weaved, LinkedList<int> prefix)
        {
            if (left.Count == 0 || right.Count == 0)
            {
                var newArray = new LinkedList<int>(prefix);
                newArray.AddRange(left);
                newArray.AddRange(right);
                weaved.Add(newArray);
            }
            else
            {
                // Remove Head from Left and append to Prefix
                int temp = left.First.Value;
                left.RemoveFirst();
                prefix.AddLast(temp);
                WeaveLists(left, right, weaved, prefix);
                // Revert changes
                prefix.RemoveLast();
                left.AddFirst(temp);

                // Remove Head from Right and append to Prefix
                temp = right.First.Value;
                right.RemoveFirst();
                prefix.AddLast(temp);
                WeaveLists(left, right, weaved, prefix);
                // Revert changes
                prefix.RemoveLast();
                right.AddFirst(temp);
            }
        }
    }
}
