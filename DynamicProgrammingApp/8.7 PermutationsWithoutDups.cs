using System.Collections.Generic;
using System.Linq;

namespace DynamicProgrammingApp
{
    public static class PermutationsWithoutDups
    {
        public static List<string> FindAllPermutations(string str) => FindAllPermutations(str, str.Length - 1);

        private static List<string> FindAllPermutations(string str, int last)
        {
            if (last < 0) { return new List<string>(); }

            char lastElement = str[last];
            if (last == 0)
            {
                return new List<string>()
                {
                    lastElement.ToString()
                };
            }
            else
            {
                List<string> baseList = FindAllPermutations(str, last - 1);
                var result = new List<string>();
                foreach (string basePerm in baseList)
                {
                    // Add last element before the basePerm
                    result.Add($"{lastElement}{basePerm}");

                    // Add last element after each char in the basePerm
                    for (int i = 0; i < basePerm.Length; i++)
                    {
                        var perm = $"{basePerm.Substring(0, i + 1)}{lastElement}";
                        if (i < basePerm.Length - 1)
                        {
                            perm += basePerm.Substring(i + 1, basePerm.Length - i - 1);
                        }
                        result.Add(perm);
                    }
                }
                return result;
            }
        }
    }
}
