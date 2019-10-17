namespace _005_BitManipulation
{
    /// <summary>
    /// 5.6) Conversion:
    /// Write a function to determine the number of bits you would need to flip to convert integer A to integer B.
    /// </summary>
    public static class Question_5_6
    {
        /// <summary>
        /// Iterate through and compare each bit
        /// <para>Time Complexity: O(b), where b is the max number of bits</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int FlipBitsToConvert(int a, int b)
        {
            int diff = 0;
            if (a == b)
            {
                return diff;
            }

            while (a != 0 || b != 0)
            {
                int bitA = a & 1;
                int bitB = b & 1;

                if (bitA != bitB)
                {
                    diff++;
                }

                a >>= 1;
                b >>= 1;
            }

            return diff;
        }

        /// <summary>
        /// XOR 2 numbers and count number of 1s
        /// <para>Time Complexity: O(b), where b is the max number of bits</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int FlipBitsToConvertXOR(int a, int b)
        {
            int diff = 0;
            int xor = a ^ b;
            while (xor != 0)
            {
                diff += xor & 1;
                xor >>= 1;
            }
            return diff;
        }
    }
}
