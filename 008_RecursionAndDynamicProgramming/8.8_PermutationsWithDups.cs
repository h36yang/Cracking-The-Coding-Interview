using System.Collections.Generic;
using System.Text;

namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.8) Permutations with Dups:
    /// Write a method to compute all permutations of a string whose characters are not necessarily unique.
    /// The list of permutations should not have duplicates.
    /// </summary>
    public static class Question_8_8
    {
        /// <summary>
        /// 
        /// <para>Time Complexity: O(n^3 * n!) where n is number of chars in the string</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> FindAllPermutationsWithDups(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return new List<string>(0);
            }

            // Construct dictionary - runtime O(n)
            var charDict = new Dictionary<char, int>();
            foreach (char c in str)
            {
                if (charDict.ContainsKey(c))
                {
                    charDict[c]++;
                }
                else
                {
                    charDict.Add(c, 1);
                }
            }

            return ComputePermutations(charDict);
        }

        private static List<string> ComputePermutations(Dictionary<char, int> str)
        {
            var permutations = new List<string>();

            if (str.Count == 0)
            {
                return permutations;
            }

            if (str.Count == 1)
            {
                var sb = new StringBuilder();
                foreach (var c in str)
                {
                    for (int i = 0; i < c.Value; i++)
                    {
                        sb.Append(c.Key);
                    }
                }
                permutations.Add(sb.ToString());
                return permutations;
            }

            // Use each unique character as prefix and build sub permutations with the remaining n-1 characters
            var keys = new List<char>(str.Keys);
            foreach (char prefix in keys)
            {
                // Remove the character from the dict
                if (str[prefix] > 1)
                {
                    str[prefix]--;
                }
                else
                {
                    str.Remove(prefix);
                }

                // Build permutations for the substring - recursion depth n but getting called (distinct n)! times
                List<string> subPerms = ComputePermutations(str);

                // Revert the character back
                if (str.ContainsKey(prefix))
                {
                    str[prefix]++;
                }
                else
                {
                    str.Add(prefix, 1);
                }

                // Combine each sub permutations with prefix character - runtime O(n^2)
                foreach (string subStrPerm in subPerms)
                {
                    permutations.Add(prefix + subStrPerm); // string concat runtime O(n)
                }
            }

            return permutations;
        }
    }
}
