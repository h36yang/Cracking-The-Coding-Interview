namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.1) Triple Step:
    /// A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3 steps at a time.
    /// Implement a method to count how many possible ways the child can run up the stairs.
    /// </summary>
    public static class Question_8_1
    {
        /// <summary>
        /// Using pure recursion
        /// <para>Time Complexity: O(3^n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="nStairs"></param>
        /// <returns></returns>
        public static long CountPossibleWaysRecursion(int nStairs)
        {
            if (nStairs < 0)
            {
                return 0;
            }
            else if (nStairs == 0)
            {
                return 1;
            }
            else
            {
                return CountPossibleWaysRecursion(nStairs - 1) + CountPossibleWaysRecursion(nStairs - 2) + CountPossibleWaysRecursion(nStairs - 3);
            }
        }

        /// <summary>
        /// Using memoization
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="nStairs"></param>
        /// <returns></returns>
        public static long CountPossibleWaysMemoization(int nStairs)
        {
            return CountPossibleWaysMemoizationInner(nStairs, new long[nStairs + 1]);
        }

        private static long CountPossibleWaysMemoizationInner(int nStairs, long[] memo)
        {
            if (nStairs < 0)
            {
                return 0;
            }
            else if (nStairs == 0)
            {
                return 1;
            }
            else
            {
                if (memo[nStairs] == 0)
                {
                    memo[nStairs] = CountPossibleWaysMemoizationInner(nStairs - 1, memo) + CountPossibleWaysMemoizationInner(nStairs - 2, memo) + CountPossibleWaysMemoizationInner(nStairs - 3, memo);
                }
                return memo[nStairs];
            }
        }
    }
}
