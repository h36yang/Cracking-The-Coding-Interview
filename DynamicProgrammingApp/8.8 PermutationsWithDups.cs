using System.Collections.Generic;
using System.Linq;

namespace DynamicProgrammingApp
{
    public static class PermutationsWithDups
    {
        public static List<string> FindAllPermutations(string str)
        {
            Dictionary<char, int> map = BuildFreqMap(str);
            var result = new List<string>();
            FindAllPermutations(map, string.Empty, str.Length, result);
            return result;
        }

        private static void FindAllPermutations(
            Dictionary<char, int> map, string prefix, int remaining, List<string> result)
        {
            if (remaining == 0)
            {
                result.Add(prefix);
                return;
            }

            foreach (var item in map.ToArray())
            {
                char c = item.Key;
                int count = item.Value;
                if (count > 0)
                {
                    map[c] = count - 1;
                    FindAllPermutations(map, prefix + c, remaining - 1, result);
                    map[c] = count;
                }
            }
        }

        private static Dictionary<char, int> BuildFreqMap(string str)
        {
            var map = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (!map.ContainsKey(c))
                {
                    map.Add(c, 1);
                }
                else
                {
                    map[c]++;
                }
            }
            return map;
        }
    }
}