namespace _010_SortingAndSearching
{
    /// <summary>
    /// 10.4) Sorted Search, No Size:
    /// You are given an array-like data structure Listy which lacks a size method.
    /// It does, however, have an elementAt(i) method that returns the element at index i in 0(1) time.
    /// If i is beyond the bounds of the data structure, it returns -1.
    /// (For this reason, the data structure only supports positive integers.)
    /// Given a Listy which contains sorted, positive integers, find the index at which an element x occurs.
    /// If x occurs multiple times, you may return any index.
    /// </summary>
    public static class Question_10_4
    {
        public class Listy
        {
            private readonly int[] _array;

            public Listy(int[] arr)
            {
                _array = arr;
            }

            public int ElementAt(int i)
            {
                if (i < 0 || i >= _array.Length)
                {
                    return -1;
                }
                return _array[i];
            }
        }

        /// <summary>
        /// Find an estimated length and use regular binary search
        /// <para>Time Complexity: O(log(n))</para>
        /// <para>Space Complexity: O(log(n)) - recursion depth</para>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int SearchWithNoSize(Listy list, int item)
        {
            if (list == null)
            {
                return -1;
            }

            // Find length - runtime O(log(n))
            int index = 1;
            while (list.ElementAt(index) != -1 && list.ElementAt(index) < item)
            {
                index *= 2;
            }
            return Search(list, item, index / 2, index);
        }

        private static int Search(Listy list, int item, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;
            if (list.ElementAt(mid) == item)
            {
                return mid;
            }
            else if (list.ElementAt(mid) > item || list.ElementAt(mid) == -1)
            {
                return Search(list, item, start, mid - 1);
            }
            else
            {
                return Search(list, item, mid + 1, end);
            }
        }
    }
}
