using System;

namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.3) Magic Index:
    /// A magic index in an array A[0...n-1] is defined to be an index such that A[i] = i.
    /// Given a sorted array of distinct integers, write a method to find a magic index, if one exists, in array A.
    /// FOLLOW UP
    /// What if the values are not distinct?
    /// </summary>
    public static class Question_8_3
    {
        /// <summary>
        /// Given a sorted array of distinct integers, write a method to find a magic index, if one exists, in array A.
        /// <para>Time Complexity: O(log(n))</para>
        /// <para>Space Complexity: O(log(n))</para>
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindMagicIndexDistinct(int[] arr)
        {
            if (arr.Length == 0 || arr[0] > 0 || arr[^1] < arr.Length - 1)
            {
                return -1;
            }

            return FindMagicIndexDistinctInner(arr, 0, arr.Length - 1);
        }

        private static int FindMagicIndexDistinctInner(int[] arr, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;
            if (arr[mid] == mid)
            {
                return mid;
            }
            else if (arr[mid] > mid)
            {
                return FindMagicIndexDistinctInner(arr, start, mid - 1);
            }
            else
            {
                return FindMagicIndexDistinctInner(arr, mid + 1, end);
            }
        }

        /// <summary>
        /// FOLLOW UP: What if the values are not distinct?
        /// <para>Time Complexity: average O(log(n)), worst case O(n)</para>
        /// <para>Space Complexity: O(log(n))</para>
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindMagicIndexNotDistinct(int[] arr)
        {
            return FindMagicIndexNotDistinctInner(arr, 0, arr.Length - 1);
        }

        private static int FindMagicIndexNotDistinctInner(int[] arr, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;
            if (arr[mid] == mid)
            {
                return mid;
            }

            // Search Left
            int left = FindMagicIndexNotDistinctInner(arr, start, Math.Min(mid - 1, arr[mid]));
            if (left > -1)
            {
                return left;
            }

            // Search Right
            int right = FindMagicIndexNotDistinctInner(arr, Math.Max(mid + 1, arr[mid]), end);
            return right;
        }
    }
}
