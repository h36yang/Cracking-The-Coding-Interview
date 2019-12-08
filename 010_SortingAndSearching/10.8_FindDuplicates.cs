using System.Collections;
using System.Collections.Generic;

namespace _010_SortingAndSearching
{
    /// <summary>
    /// 10.8) Find Duplicates:
    /// You have an array with all the numbers from 1 to N, where N is at most 32,000.
    /// The array may have duplicate entries and you do not know what N is.
    /// With only 4 kilobytes of memory available, how would you print all duplicate elements in the array?
    /// </summary>
    public static class Question_10_8
    {
        /// <summary>
        /// Find duplicates with 32,000-bit vector
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n) - 4KB memory</para>
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static HashSet<int> FindDuplicates(int[] arr)
        {
            var dups = new HashSet<int>();
            if (arr == null || arr.Length <= 1)
            {
                return dups;
            }

            var bitMap = new BitArray(32000);
            foreach (int i in arr)
            {
                if (bitMap[i])
                {
                    dups.Add(i);
                }
                else
                {
                    bitMap[i] = true;
                }
            }
            return dups;
        }
    }
}
