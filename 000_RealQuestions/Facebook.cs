using System;
using System.Collections.Generic;

namespace _000_RealQuestions
{
    public static class Facebook
    {
        #region One Edit Apart

        /// <summary>
        /// Write a function that returns whether two words are exactly "one edit" away
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool OneEditApart(string str1, string str2)
        {
            if (Math.Abs((str1?.Length ?? 0) - (str2?.Length ?? 0)) > 1)
            {
                return false;
            }

            int i = 0;
            while (i < str1.Length && i < str2.Length && str1[i] == str2[i])
            {
                i++;
            }

            if (str1.Length == str2.Length)
            {
                return string.Equals(str1.Substring(i + 1), str2.Substring(i + 1));
            }
            else if (str1.Length > str2.Length)
            {
                return string.Equals(str1.Substring(i + 1), str2.Substring(i));
            }
            else
            {
                return string.Equals(str1.Substring(i), str2.Substring(i + 1));
            }
        }

        #endregion

        #region Find the Quarter Majority

        public static int FindQuarterMajority(int[] nums)
        {
            int window = nums.Length / 4 + 1;
            int start = 0;
            while (start < nums.Length)
            {
                if (start > 0)
                {
                    start = FindFirst(nums, nums[start], 0, start);
                }

                int end = start + window - 1;
                if (end >= nums.Length)
                {
                    break;
                }

                if (nums[start] == nums[end])
                {
                    return nums[start];
                }
                start = end;
            }
            throw new ArgumentException("Quarter Majority does not exist.");
        }

        private static int FindFirst(int[] nums, int target, int start, int end)
        {
            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] < target)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }
            return start;
        }

        #endregion

        #region Schedule of Tasks

        public static List<int[]> FindOverlappingIntervals(int[][] tasks)
        {
            var res = new List<int[]>();
            int[] prev = null;
            foreach (int[] task in tasks)
            {
                if (prev == null || task[0] >= prev[1])
                {
                    prev = task;
                }
                else
                {
                    res.Add(new int[] { Math.Max(prev[0], task[0]), Math.Min(prev[1], task[1]) });
                    if (task[1] > prev[1])
                    {
                        prev = task;
                    }
                }
            }
            return res;
        }

        #endregion

        #region Number of Subsets

        /// <summary>
        /// For a given list of integers and integer k, find the number of non-empty subsets S such that min(S) + max(S) <= k.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int MinMaxKSubsets(int[] nums, int k)
        {
            Array.Sort(nums);
            int left = 0;
            int right = nums.Length - 1;
            int count = 0;
            while (left <= right)
            {
                if (nums[left] + nums[right] > k)
                {
                    right--;
                }
                else
                {
                    count += (int)Math.Pow(2, right - left);
                    left++;
                }
            }
            return count;
        }

        #endregion

        #region Randomly Generate Mines on a Grid

        public static List<(int r, int c)> GenerateKMinesOnGrid(int m, int n, int k)
        {
            var res = new List<(int, int)>(k);

            int total = m * n;
            for (int r = 0; r < m; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    int candidate = Helper.Next(total);
                    if (candidate < k)
                    {
                        res.Add((r, c));
                        k--;
                    }
                    total--;

                    if (k == 0)
                    {
                        break;
                    }
                }

                if (k == 0)
                {
                    break;
                }
            }

            return res;
        }

        #endregion
    }
}
