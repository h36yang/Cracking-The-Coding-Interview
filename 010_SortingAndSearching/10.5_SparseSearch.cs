namespace _010_SortingAndSearching
{
    /// <summary>
    /// 10.5) Sparse Search:
    /// Given a sorted array of strings that is interspersed with empty strings, write a method to find the location of a given string.
    /// </summary>
    public static class Question_10_5
    {
        /// <summary>
        /// Modified Binary Search
        /// <para>Time Complexity: O(log(n))</para>
        /// <para>Space Complexity: O(log(n)) - recursion depth</para>
        /// </summary>
        /// <param name="sparseArr"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int SearchSparse(string[] sparseArr, string item)
        {
            if (Helper.IsCollectionNullOrEmpty(sparseArr) || string.IsNullOrEmpty(item))
            {
                return -1;
            }
            return Search(sparseArr, item, 0, sparseArr.Length - 1);
        }

        private static int Search(string[] sparseArr, string item, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            // Find the closet not empty string nearby mid
            int mid = (start + end) / 2;
            if (string.IsNullOrEmpty(sparseArr[mid]))
            {
                int left = mid - 1;
                int right = mid + 1;
                while (true)
                {
                    if (left < start && right > end)
                    {
                        // if everything is empty, return -1 directly
                        return -1;
                    }
                    else if (left >= start && !string.IsNullOrEmpty(sparseArr[left]))
                    {
                        mid = left;
                        break;
                    }
                    else if (right <= end && !string.IsNullOrEmpty(sparseArr[right]))
                    {
                        mid = right;
                        break;
                    }
                    left--;
                    right++;
                }
            }

            if (sparseArr[mid] == item)
            {
                return mid;
            }
            else if (sparseArr[mid].CompareTo(item) > 0)
            {
                return Search(sparseArr, item, start, mid - 1);
            }
            else
            {
                return Search(sparseArr, item, mid + 1, end);
            }
        }
    }
}
