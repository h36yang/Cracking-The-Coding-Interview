using System;
using System.Collections.Generic;

namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.4) Power Set:
    /// Write a method to return all subsets of a set.
    /// </summary>
    public static class Question_8_4
    {
        /// <summary>
        /// Resursively build up subsets of { a, b, c } with subsets of { a, b } + c
        /// <para>Time Complexity: O(n * 2^n)</para>
        /// <para>Space Complexity: O(n * 2^n)</para>
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public static List<HashSet<T>> FindAllSubsets<T>(List<T> set)
        {
            var subsets = new List<HashSet<T>>();
            if (set == null)
            {
                return subsets;
            }
            else if (set.Count == 0)
            {
                // Add empty set for base case
                subsets.Add(new HashSet<T>());
            }
            else
            {
                // Remove last item from the list/set
                T lastItem = set[^1];
                set.RemoveAt(set.Count - 1);

                // Find the subsets of the remaining items recursively
                List<HashSet<T>> childSubsets = FindAllSubsets(set);
                subsets.AddRange(childSubsets);

                // Append the last item to the resulted subsets of the remaining items to form new subsets
                foreach (HashSet<T> childSubset in childSubsets)
                {
                    subsets.Add(new HashSet<T>(childSubset) { lastItem });
                }
            }
            return subsets;
        }

        /// <summary>
        /// Using Combinatorics
        /// <para>Time Complexity: O(n * 2^n)</para>
        /// <para>Space Complexity: O(n * 2^n)</para>
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public static List<HashSet<T>> FindAllSubsetsCombinatorics<T>(List<T> set)
        {
            if (set == null)
            {
                return new List<HashSet<T>>(0);
            }

            var upperBound = (int)Math.Pow(2, set.Count);
            var subsets = new List<HashSet<T>>(upperBound);
            for (int k = 0; k < upperBound; k++)
            {
                subsets.Add(ConvertBinaryToSet(k, set));
            }
            return subsets;
        }

        private static HashSet<T> ConvertBinaryToSet<T>(int binaryNumber, List<T> superset)
        {
            var subset = new HashSet<T>();
            int index = 0;
            for (int n = binaryNumber; n > 0; n >>= 1)
            {
                if ((n & 1) == 1)
                {
                    subset.Add(superset[index]);
                }
                index++;
            }
            return subset;
        }
    }
}
