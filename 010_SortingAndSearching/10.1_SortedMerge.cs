namespace _010_SortingAndSearching
{
    /// <summary>
    /// 10.1) Sorted Merge:
    /// You are given two sorted arrays, A and B, where A has a large enough buffer at the end to hold B.
    /// Write a method to merge B into A in sorted order.
    /// </summary>
    public static class Question_10_1
    {
        /// <summary>
        /// Iterate from the end of the sorted arrays and merge
        /// <para>Time Complexity: O(a + b)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void MergeSorted(int[] a, int[] b)
        {
            if (a.Length == 0 || b.Length == 0 || b.Length > a.Length)
            {
                return;
            }

            int indexA = a.Length - b.Length - 1;
            int indexB = b.Length - 1;
            int indexTotal = a.Length - 1;
            while (indexA >= 0 && indexB >= 0)
            {
                if (b[indexB] >= a[indexA])
                {
                    a[indexTotal] = b[indexB];
                    indexB--;
                }
                else
                {
                    a[indexTotal] = a[indexA];
                    indexA--;
                }
                indexTotal--;
            }

            // Copy the remaining of array B into A
            while (indexB >= 0)
            {
                a[indexTotal] = b[indexB];
                indexB--;
                indexTotal--;
            }
        }
    }
}
