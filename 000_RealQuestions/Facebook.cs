using System;

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
    }
}
