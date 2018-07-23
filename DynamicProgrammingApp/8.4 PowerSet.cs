using System.Collections.Generic;
using System.Linq;

namespace DynamicProgrammingApp
{
    public static class PowerSet
    {
        public static List<List<int>> GetAllSubsets(int[] set) => GetAllSubsets(set, set.Length - 1);

        private static List<List<int>> GetAllSubsets(int[] set, int end)
        {
            int lastElement = set[end];
            if (end == 0)
            {
                return new List<List<int>>()
                {
                    new List<int>(),
                    new List<int>() { lastElement }
                };
            }
            else
            {
                var result = new List<List<int>>();
                var subsets = GetAllSubsets(set, end - 1);
                result.AddRange(subsets.Select(s => new List<int>(s)));
                foreach (List<int> subset in subsets)
                {
                    subset.Add(lastElement);
                    result.Add(subset);
                }
                return result;
            }
        }
    }
}
