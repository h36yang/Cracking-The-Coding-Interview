namespace _010_SortingAndSearching
{
    /// <summary>
    /// 10.3) Search in Rotated Array:
    /// Given a sorted array of n integers that has been rotated an unknown number of times, write code to find an element in the array.
    /// You may assume that the array was originally sorted in increasing order.
    /// </summary>
    public static class Question_10_3
    {
        /// <summary>
        /// Modified Binary Search
        /// <para>Time Complexity: worst case O(n), average case O(log(n))</para>
        /// <para>Space Complexity: O(log(n)) - recursion depth</para>
        /// </summary>
        /// <param name="rotatedArr"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int SearchRotated(int[] rotatedArr, int item)
        {
            if (rotatedArr == null || rotatedArr.Length == 0)
            {
                return -1;
            }
            return Search(rotatedArr, item, 0, rotatedArr.Length - 1);
        }

        private static int Search(int[] rotatedArr, int item, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;
            if (rotatedArr[mid] == item)
            {
                return mid;
            }

            if (rotatedArr[start] < rotatedArr[mid]) // left side is normally ordered
            {
                if (rotatedArr[start] <= item && item < rotatedArr[mid]) // item within left side
                {
                    return Search(rotatedArr, item, start, mid - 1);
                }
                else // item within right side
                {
                    return Search(rotatedArr, item, mid + 1, end);
                }
            }
            else if (rotatedArr[start] > rotatedArr[mid]) // right side is normally ordered
            {
                if (rotatedArr[mid] < item && item <= rotatedArr[end]) // item within right side
                {
                    return Search(rotatedArr, item, mid + 1, end);
                }
                else // item within left side
                {
                    return Search(rotatedArr, item, start, mid - 1);
                }
            }
            else // left or right side repeats
            {
                if (rotatedArr[mid] != rotatedArr[end]) // item within right side
                {
                    return Search(rotatedArr, item, mid + 1, end);
                }
                else // can't determine - search both sides
                {
                    int resultIndex = Search(rotatedArr, item, start, mid - 1);
                    if (resultIndex == -1)
                    {
                        return Search(rotatedArr, item, mid + 1, end);
                    }
                    else
                    {
                        return resultIndex;
                    }
                }
            }
        }
    }
}
