using System;
using System.Collections.Generic;

namespace _005_BitManipulation
{
    /// <summary>
    /// 5.3) Flip Bit to Win:
    /// You have an integer and you can flip exactly one bit from a 0 to a 1.
    /// Write code to find the length of the longest sequence of ls you could create.
    /// </summary>
    public static class Question_5_3
    {
        private class BitBucket
        {
            public int BitValue { get; private set; }

            public int Count { get; set; } = 1;

            public bool IsBit1
            {
                get
                {
                    return BitValue == 1;
                }
            }

            public BitBucket(int bitValue)
            {
                BitValue = bitValue;
            }
        }

        /// <summary>
        /// Count number of consecutive 0s and 1s and group them into buckets.
        /// Iterate through the buckets and calculate longest sequence of 1s when landing on bucket of 0s.
        /// <para>Time Complexity: O(b), where b is number of bits</para>
        /// <para>Space Complexity: O(k), where k is number of bit buckets</para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int FindLongestSequence(int number)
        {
            var bitBuckets = new LinkedList<BitBucket>();

            // Convert decimal number to bits and store in the BitBucket Linked List - runtime O(b), where b is number of bits
            while (number > 0)
            {
                int bit = number & 1;
                if (bitBuckets.First == null || bitBuckets.First.Value.BitValue != bit)
                {
                    var newBucket = new BitBucket(bit);
                    bitBuckets.AddFirst(newBucket);
                }
                else
                {
                    bitBuckets.First.Value.Count++;
                }
                number >>= 1;
            }

            if (bitBuckets.First == null || bitBuckets.First.Value.IsBit1)
            {
                bitBuckets.AddFirst(new BitBucket(0));
            }

            // Loop through each bit bucket and calculate max length on each 0 - runtime O(m), where m is the number of buckets and m <= b
            int maxLength = 1;
            LinkedListNode<BitBucket> temp = bitBuckets.First;
            while (temp != null)
            {
                if (!temp.Value.IsBit1)
                {
                    int prevCount = temp.Previous?.Value.Count ?? 0;
                    int nextCount = temp.Next?.Value.Count ?? 0;
                    if (temp.Value.Count == 1)
                    {
                        maxLength = Math.Max(maxLength, prevCount + nextCount + 1);
                    }
                    else
                    {
                        maxLength = Math.Max(maxLength, Math.Max(prevCount + 1, nextCount + 1));
                    }
                }
                temp = temp.Next;
            }
            return maxLength;
        }

        /// <summary>
        /// Iterate through the bits and calculate the max length as we go
        /// <para>Time Complexity: O(b), where b is number of bits</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int FindLongestSequenceOptimal(int number)
        {
            int maxLength = 1;
            int prevLength = 0;
            int currLength = 0;
            while (number > 0)
            {
                if ((number & 1) == 1)
                {
                    currLength++;
                }
                else // (number & 1) == 0
                {
                    prevLength = (number & 2) == 0 ? 0 : currLength;
                    currLength = 0;
                }
                maxLength = Math.Max(maxLength, prevLength + currLength + 1);
                number >>= 1;
            }
            return maxLength;
        }
    }
}
