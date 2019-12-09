namespace _016_Moderate
{
    /// <summary>
    /// 16.1) Number Swapper:
    /// Write a function to swap a number in place (that is, without temporary variables).
    /// </summary>
    public static class Question_16_01
    {
        /// <summary>
        /// Iterate from the end of the sorted arrays and merge
        /// <para>Time Complexity: O(1)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static void SwapNumber(ref int num1, ref int num2)
        {
            // Store diff in num1
            num1 = num2 - num1;

            // Set num2 to original num1 by minus the diff
            num2 -= num1;

            // Set num1 to original num2 by plus the diff
            num1 += num2;
        }
    }
}
