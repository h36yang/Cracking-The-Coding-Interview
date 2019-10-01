using System.Collections.Generic;

namespace _004_TreesAndGraphs
{
    public static class Helper
    {
        public static bool IsListSorted(IList<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public static void AddRange<T>(this LinkedList<T> list, LinkedList<T> end)
        {
            if (end.Count == 0)
            {
                return;
            }

            foreach (T item in end)
            {
                list.AddLast(item);
            }
        }
    }
}
