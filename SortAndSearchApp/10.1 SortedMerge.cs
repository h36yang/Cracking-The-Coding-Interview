using System;

namespace SortAndSearchApp
{
    public static class SortedMerge
    {
        public static void Merge(int[] a, int[] b, int lastA)
        {
            if (b.Length > a.Length)
            {
                throw new ArgumentOutOfRangeException("Size of B is larger than A.");
            }

            if (b.Length == 0) { return; }

            int endOfA = a.Length - 1;
            int lastB = b.Length - 1;
            while (lastB >= 0)
            {
                if (lastA >= 0 && b[lastB] < a[lastA])
                {
                    a[endOfA] = a[lastA];
                    lastA--;
                }
                else
                {
                    a[endOfA] = b[lastB];
                    lastB--;
                }
                endOfA--;
            }
        }
    }
}
