namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.5) Recursive Multiply:
    /// Write a recursive function to multiply two positive integers without using the * operator (or / operator).
    /// You can use addition, subtraction, and bit shifting, but you should minimize the number of those operations.
    /// </summary>
    public static class Question_8_5
    {
        /// <summary>
        /// Recursively calculate half of the product and double it.
        /// <para>Time Complexity: O(log(s)) where s is the smaller number</para>
        /// <para>Space Complexity: O(log(s))</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static uint Multiply(uint a, uint b)
        {
            uint bigger = a > b ? a : b;
            uint smaller = a > b ? b : a;
            return MultiplyInner(bigger, smaller);
        }

        private static uint MultiplyInner(uint bigger, uint smaller)
        {
            if (smaller == 0)
            {
                return 0;
            }
            else if (smaller == 1)
            {
                return bigger;
            }

            uint halfProduct = MultiplyInner(bigger, smaller >> 1);

            if (smaller % 2 == 0)
            {
                return halfProduct + halfProduct;
            }
            else
            {
                return halfProduct + halfProduct + bigger;
            }
        }
    }
}
