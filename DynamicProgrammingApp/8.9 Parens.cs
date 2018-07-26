using System.Collections.Generic;

namespace DynamicProgrammingApp
{
    public static class Parens
    {
        public static Dictionary<string, bool> GetParentheses(int n)
        {
            var map = new Dictionary<string, bool>();
            if (n == 1)
            {
                map.Add("()", true);
            }
            else
            {
                var baseMap = GetParentheses(n - 1);
                foreach (var item in baseMap)
                {
                    AddKeyToDict(map, $"(){item.Key}");
                    AddKeyToDict(map, $"({item.Key})");
                    AddKeyToDict(map, $"{item.Key}()");
                }
            }
            return map;
        }

        private static void AddKeyToDict(Dictionary<string, bool> dict, string key)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, true);
            }
        }
    }
}
