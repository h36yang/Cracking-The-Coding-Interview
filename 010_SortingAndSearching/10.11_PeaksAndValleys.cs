using _004_TreesAndGraphs;

namespace _010_SortingAndSearching
{
    /// <summary>
    /// 10.11) Peaks and Valleys:
    /// In an array of integers, a "peak" is an element which is greater than or equal to the adjacent integers
    /// and a "valley" is an element which is less than or equal to the adjacent integers.
    /// For example, in the array {5, 8, 6, 2, 3, 4, 6}, {8, 6} are peaks and {5, 2} are valleys.
    /// Given an array integers, sort the array into an alternating sequence of peaks and valleys.
    /// </summary>
    public static class Question_10_11
    {
        /// <summary>
        /// Swap elements in one pass
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="arr"></param>
        public static void SortArrayWithPeaksAndValleys(int[] arr)
        {
            if (arr == null || arr.Length <= 2)
            {
                return;
            }

            bool peak = arr[0] < arr[1];
            for (int i = 1; i < arr.Length - 1; i++)
            {
                if (peak)
                {
                    if (arr[i] < arr[i + 1])
                    {
                        Helper.SwapArrayElements(arr, i, i + 1);
                    }
                }
                else
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Helper.SwapArrayElements(arr, i, i + 1);
                    }
                }
                peak = !peak;
            }
        }
    }
}
