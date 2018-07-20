namespace SortAndSearchApp
{
    public static class SearchInRotatedArray
    {
        public static int Find_v2(int[] array, int value, int left, int right)
        {
            int mid = (left + right) / 2;
            if (array[mid] == value) { return mid; }
            if (left > right) { return -1; }


            if (array[mid] > array[left])
            {
                if (array[mid] > value && value >= array[left])
                {
                    return Find_v2(array, value, left, mid - 1);
                }
                else
                {
                    return Find_v2(array, value, mid + 1, right);
                }
            }
            else if (array[mid] < array[right])
            {
                if (array[mid] < value && value <= array[right])
                {
                    return Find_v2(array, value, mid + 1, right);
                }
                else
                {
                    return Find_v2(array, value, left, mid - 1);
                }
            }
            else if (array[mid] == array[left])
            {
                if (array[mid] != array[right])
                {
                    return Find_v2(array, value, mid + 1, right);
                }
                else
                {
                    int result = Find_v2(array, value, left, mid - 1);
                    if (result == -1)
                    {
                        return Find_v2(array, value, mid + 1, right);
                    }
                    else
                    {
                        return result;
                    }
                }
            }
            return -1; // Value not found
        }

        public static int Find(int[] array, int value)
        {
            int head = FindHeadIndex(array);
            return BinarySearch(array, value, head);
        }

        private static int FindHeadIndex(int[] sortedCircularArray)
        {
            for (int i = 0; i < sortedCircularArray.Length - 1; i++)
            {
                if (sortedCircularArray[i] > sortedCircularArray[i + 1])
                {
                    return i + 1;
                }
            }
            return 0;
        }

        private static int BinarySearch(int[] array, int value, int head)
        {
            int low = 0;
            int high = array.Length - 1;
            int mid;

            while (low <= high)
            {
                mid = (low + high) / 2;
                int actualMid = ConvertIndex(mid, head, array.Length);
                if (array[actualMid] < value)
                {
                    low = mid + 1;
                }
                else if (array[actualMid] > value)
                {
                    high = mid - 1;
                }
                else
                {
                    return actualMid;
                }
            }
            return -1; // Value not found
        }

        private static int ConvertIndex(int index, int head, int length)
        {
            return (head + index) % length;
        }
    }
}