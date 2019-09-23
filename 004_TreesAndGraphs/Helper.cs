using System.Collections.Generic;

namespace _004_TreesAndGraphs
{
    public class Helper
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
    }
}
