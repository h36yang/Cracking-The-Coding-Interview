namespace _016_Moderate
{
    /// <summary>
    /// 16.5) Factorial Zeros:
    /// Write an algorithm which computes the number of trailing zeros in n factorial.
    /// </summary>
    public static class Question_16_05
    {
        /// <summary>
        /// Loop through numbers and count the factors of 5
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CountFactorialTrailingZeros(int n)
        {
            if (n < 0)
            {
                return -1;
            }

            int count = 0;
            for (int i = n; i > 1; i--)
            {
                count += CountFactorsOf5(i);
            }
            return count;
        }

        private static int CountFactorsOf5(int n)
        {
            int count = 0;
            while (n % 5 == 0)
            {
                count++;
                n /= 5;
            }
            return count;
        }

        /// <summary>
        /// Count number of factors of 5, 25, 125, etc.
        /// <para>Time Complexity: O(m) where m is number of multiples of 5 in n</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int CountFactorialTrailingZerosOptimized(int n)
        {
            if (n < 0)
            {
                return -1;
            }

            int count = 0;
            for (int i = 5; n / i > 0; i *= 5)
            {
                count += n / i;
            }
            return count;
        }
    }
}
