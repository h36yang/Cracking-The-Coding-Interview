using System;

namespace DynamicProgrammingApp
{
    public static class MagicIndex
    {
        public static int Find_BruteForce(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == i)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int Find_BinarySearch(int[] array) => BinarySearch_Distinct(array, 0, array.Length - 1);

        public static int Find_BinarySearch_v2(int[] array) => BinarySearch_NotDistinct(array, 0, array.Length - 1);

        private static int BinarySearch_Distinct(int[] array, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }

            int mid = (left + right) / 2;
            if (array[mid] > mid)
            {
                return BinarySearch_Distinct(array, left, mid - 1);
            }
            else if (array[mid] < mid)
            {
                return BinarySearch_Distinct(array, mid + 1, right);
            }
            else
            {
                return mid;
            }
        }

        private static int BinarySearch_NotDistinct(int[] array, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }

            int mid = (left + right) / 2;
            if (array[mid] == mid)
            {
                return mid;
            }
            else
            {
                var result = BinarySearch_NotDistinct(array, left, Math.Min(mid - 1, array[mid]));
                if (result != -1)
                {
                    return result;
                }
                result = BinarySearch_NotDistinct(array, Math.Max(mid + 1, array[mid]), right);
                return result;
            }
        }
    }
}
