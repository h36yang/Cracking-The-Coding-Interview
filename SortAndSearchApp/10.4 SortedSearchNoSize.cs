using System.Collections.Generic;

namespace SortAndSearchApp
{
    public static class SortedSearchNoSize
    {
        public static int Find(Listy list, int x)
        {
            int result = 0;
            int size = 1;
            while (result != -1)
            {
                size *= 2;
                result = list.ElementAt(size);
                if (result == x)
                {
                    return size;
                }
            }

            return BinarySearch(list, x, 0, size);
        }

        private static int BinarySearch(Listy list, int x, int left, int right)
        {
            if (left > right) { return -1; }

            int mid = (left + right) / 2;

            if (list.ElementAt(mid) < x)
            {
                return BinarySearch(list, x, mid + 1, right);
            }
            else if (list.ElementAt(mid) > x)
            {
                return BinarySearch(list, x, left, mid - 1);
            }
            else
            {
                return mid;
            }
        }
    }

    public class Listy
    {
        private List<int> _list { get; set; }

        public Listy()
        {
            _list = new List<int>();
        }

        public int ElementAt(int index)
        {
            if (index >= _list.Count)
            {
                return -1;
            }
            return _list[index];
        }

        public void Add(int element) => _list.Add(element);
    }
}
