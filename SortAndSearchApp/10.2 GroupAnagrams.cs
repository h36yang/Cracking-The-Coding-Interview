using System;
using System.Collections.Generic;

namespace SortAndSearchApp
{
    public static class GroupAnagrams
    {
        public static void Sort(string[] array)
        {
            var map = new Dictionary<string, List<string>>();
            foreach (string s in array)
            {
                var k = SortChars(s);
                if (!map.ContainsKey(k))
                {
                    map.Add(k, new List<string>() { s });
                }
                else
                {
                    map[k].Add(s);
                }
            }

            int i = 0;
            foreach (var item in map)
            {
                List<string> v = item.Value;
                foreach (string vs in v)
                {
                    array[i] = vs;
                    i++;
                }
            }
        }

        private static string SortChars(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}