namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.11) Coins:
    /// Given an infinite number of quarters (25 cents), dimes (10 cents), nickels (5 cents), and pennies (1 cent), write code to calculate the number of ways of representing n cents.
    /// </summary>
    public static class Question_8_11
    {
        private const int Quarter = 25;
        private const int Dime = 10;
        private const int Nickel = 5;
        private const int Penny = 1;

        private static readonly int[] _coinValues = new int[] { Quarter, Dime, Nickel, Penny };

        /// <summary>
        /// Using pure recursion
        /// <para>Time Complexity: O(4^n), where n is number of cents</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="nCents"></param>
        /// <returns></returns>
        public static long CountPossibleCombinationsRecursion(int nCents)
        {
            return CountPossibleCombinationsRecursionInner(nCents, 0);
        }

        private static long CountPossibleCombinationsRecursionInner(int nCents, int coinIndex)
        {
            if (nCents < 0)
            {
                return 0;
            }
            else if (nCents == 0 || coinIndex >= _coinValues.Length - 1)
            {
                // Base case - either we have nothing left or we are down to the smallest coin value
                return 1;
            }

            long ways = 0;
            for (int i = coinIndex; i < _coinValues.Length; i++)
            {
                // To avoid duplicated combinations, we only use smaller coin values as we recurse down
                int centsRemaining = nCents - _coinValues[i];
                ways += CountPossibleCombinationsRecursionInner(centsRemaining, i);
            }
            return ways;
        }

        /// <summary>
        /// Using memoization
        /// <para>Time Complexity: O(n), where n is number of cents</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="nCents"></param>
        /// <returns></returns>
        public static long CountPossibleCombinationsMemoization(int nCents)
        {
            if (nCents < 0)
            {
                return 0;
            }

            var memo = new long[nCents + 1, _coinValues.Length];
            return CountPossibleCombinationsMemoizationInner(nCents, 0, memo);
        }

        private static long CountPossibleCombinationsMemoizationInner(int nCents, int coinIndex, long[,] memo)
        {
            if (nCents < 0)
            {
                return 0;
            }
            else if (nCents == 0 || coinIndex >= _coinValues.Length - 1)
            {
                // Base case - either we have nothing left or we are down to the smallest coin value
                return 1;
            }

            if (memo[nCents, coinIndex] > 0)
            {
                return memo[nCents, coinIndex];
            }

            long ways = 0;
            for (int i = coinIndex; i < _coinValues.Length; i++)
            {
                // To avoid duplicated combinations, we only use smaller coin values as we recurse down
                int centsRemaining = nCents - _coinValues[i];
                ways += CountPossibleCombinationsRecursionInner(centsRemaining, i);
            }

            // Cache result before returning
            memo[nCents, coinIndex] = ways;
            return ways;
        }
    }
}
