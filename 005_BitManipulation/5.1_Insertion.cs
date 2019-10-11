namespace _005_BitManipulation
{
    /// <summary>
    /// 5.1) Insertion:
    /// You are given two 32-bit numbers, N and M, and two bit positions, i and j.
    /// Write a method to insert M into N such that M starts at bit j and ends at bit i.
    /// You can assume that the bits j through i have enough space to fit all of M.
    /// That is, if M = 10011, you can assume that there are at least 5 bits between j and i.
    /// You would not, for example, have j = 3 and i = 2, because M could not fully fit between bit 3 and bit 2.
    /// </summary>
    public static class Question_5_1
    {
        /// <summary>
        /// <para>Time Complexity: O(1)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static int InsertBinaryNumber(int n, int m, int i, int j)
        {
            int allOnes = ~0;
            int left = allOnes << j;
            int right = ~(1 << i);
            int mask = left | right;
            return (n & mask) | (m << i);
        }
    }
}
