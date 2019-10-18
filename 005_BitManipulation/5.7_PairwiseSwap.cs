namespace _005_BitManipulation
{
    /// <summary>
    /// 5.7) Pariwise Swap:
    /// Write a program to swap odd and even bits in an integer with as few instructions as possible
    /// (e.g., bit 0 and bit 1 are swapped, bit 2 and bit 3 are swapped, and so on).
    /// </summary>
    public static class Question_5_7
    {
        /// <summary>
        /// Use hardcoded masks to extract even and odd portions of the number, shift one to left/right accordingly and combine back.
        /// 5 instructions in total.
        /// <para>Time Complexity: O(1)</para>
        /// <para>Space Complexity: O(b), where b is number of bits</para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int PairwiseSwap(int number)
        {
            // Hardcoded masks for 32-bit int (first bit reserved for sign)
            int eMask = 0b01010101010101010101010101010101;
            int oMask = 0b00101010101010101010101010101010;

            // Separate even and odd portion out
            int evenPortion = number & eMask;
            int oddPortion = number & oMask;

            // Shift bits accordingly and combine 2 portions back
            return (evenPortion << 1) | (oddPortion >> 1);
        }
    }
}
