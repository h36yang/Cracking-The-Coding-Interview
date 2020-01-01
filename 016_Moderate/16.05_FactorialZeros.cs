using System;

namespace _016_Moderate
{
    /// <summary>
    /// 16.5) Factorial Zeros:
    /// Write an algorithm which computes the number of trailing zeros in n factorial.
    /// </summary>
    public static class Question_16_05
    {
        /// <summary>
        /// Loop through numbers and count the number of zeros/twos/fives
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int FindFactorialTrailingZeros(int n)
        {
            int zeroCounter = 0;
            int twoCounter = 0;
            int fiveCounter = 0;
            for (int i = n; i > 1; i--)
            {
                int lastDigit = i % 10;
                switch (lastDigit)
                {
                    case 0:
                        zeroCounter++;
                        break;
                    case 2:
                        twoCounter++;
                        break;
                    case 5:
                        fiveCounter++;
                        break;
                    default:
                        break;
                }
            }
            return zeroCounter + Math.Min(twoCounter, fiveCounter);
        }
    }
}
