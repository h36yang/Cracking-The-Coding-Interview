using System;

namespace _005_BitManipulation
{
    /// <summary>
    /// 5.4) Next Number:
    /// Given a positive integer, print the next smallest and the next largest number that have the same number of 1 bits in their binary representation.
    /// </summary>
    public static class Question_5_4
    {
        /// <summary>
        /// <para>Time Complexity: worst case O(b), where b is number of bits</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static uint FindNextLargerNumber(uint number)
        {
            uint temp = number;
            int count0 = 0;
            int count1 = 0;

            // Count the number of trailing 0s
            while ((temp & 1) == 0 && temp > 0)
            {
                count0++;
                temp >>= 1;
            }

            // Count the number of 1s between the rightmost non-trailing 0 and trailing 0s
            while ((temp & 1) == 1)
            {
                count1++;
                temp >>= 1;
            }

            // Get the position index of the rightmost non-trailing 0
            int zeroToOneIndex = count0 + count1;

            // There is no larger number with the same number of 1s if the number is 11..1100..00 or all 0s/1s.
            if (zeroToOneIndex == 32 || zeroToOneIndex == 0)
            {
                throw new ArgumentException($"There is no larger number with same number of 1s as {number}.");
            }

            // Flip the rightmost non-trailing 0 to 1
            number = Helper.SetBit(number, zeroToOneIndex);

            // Clear the bits to the right of the rightmost non-trailing 0
            number &= ~((1u << zeroToOneIndex) - 1);

            // Set count1 - 1 bits on the right
            number |= (1u << (count1 - 1)) - 1;

            return number;
        }

        /// <summary>
        /// <para>Time Complexity: worst case O(b), where b is number of bits</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static uint FindNextSmallerNumber(uint number)
        {
            uint temp = number;
            int count0 = 0;
            int count1 = 0;

            // Count the number of trailing 1s
            while ((temp & 1) == 1)
            {
                count1++;
                temp >>= 1;
            }

            // There is no smaller number with the same number of 1s if the number is all 0s/1s.
            if (temp == 0)
            {
                throw new ArgumentException($"There is no smaller number with same number of 1s as {number}.");
            }

            // Count the number of 0s between the rightmost non-trailing 1 and trailing 1s
            while ((temp & 1) == 0 && temp > 0)
            {
                count0++;
                temp >>= 1;
            }

            // Get the position index of the rightmost non-trailing 1
            int oneToZeroIndex = count0 + count1;

            // Flip the rightmost non-trailing 1 to 0
            number = Helper.ClearBit(number, oneToZeroIndex);

            // Clear the bits to the right of the rightmost non-trailing 1
            number &= ~((1u << oneToZeroIndex) - 1);

            // Set (count1 + 1) bits on the right followed by (count0 - 1) zeros
            number |= ((1u << (count1 + 1)) - 1) << (count0 - 1);

            return number;
        }
    }
}
