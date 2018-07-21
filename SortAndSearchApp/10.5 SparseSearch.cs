namespace SortAndSearchApp
{
    public static class SparseSearch
    {
        public static int Find(string[] array, string x)
        {
            if (array == null || array.Length == 0 || string.IsNullOrEmpty(x))
            {
                return -1;
            }
            return BinarySearch(array, x, 0, array.Length - 1);
        }

        private static int BinarySearch(string[] array, string x, int left, int right)
        {
            if (left > right) { return -1; }

            int mid = (left + right) / 2;
            if (string.IsNullOrEmpty(array[mid]))
            {
                int m1 = mid - 1;
                int m2 = mid + 1;
                while (true)
                {
                    if (m1 < left && m2 > right)
                    {
                        return -1;
                    }
                    else if (!string.IsNullOrEmpty(array[m1]) && m1 >= left)
                    {
                        mid = m1;
                        break;
                    }
                    else if (!string.IsNullOrEmpty(array[m2]) && m2 <= right)
                    {
                        mid = m2;
                        break;
                    }
                    m1--;
                    m2++;
                }
            }

            if (string.Compare(array[mid], x) < 0)
            {
                return BinarySearch(array, x, mid + 1, right);
            }
            else if (string.Compare(array[mid], x) > 0)
            {
                return BinarySearch(array, x, left, mid - 1);
            }
            else
            {
                return mid;
            }
        }
    }
}
