using System.Collections.Generic;

namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.7) Permutations without Dups:
    /// Write a method to compute all permutations of a string of unique characters.
    /// </summary>
    public static class Question_8_7
    {
        /// <summary>
        /// Approach 1: recursively building from permutations of first n-1 characters
        /// <para>Time Complexity: O(n^4) where n is number of chars in the string</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> FindAllPermutationsWithoutDups1(string str)
        {
            var permutations = new List<string>(Helper.Factorial(str.Length));

            if (string.IsNullOrEmpty(str))
            {
                return permutations;
            }

            if (str.Length == 1)
            {
                permutations.Add(str); // base case
                return permutations;
            }

            char firstChar = str[0]; // get the first character
            string subStr = str.Substring(1); // remove the first character

            // Build permutations for the substring - recursion depth n and getting called n times
            List<string> subPerms = FindAllPermutationsWithoutDups1(subStr);

            // Insert first character into each sub permutations - runtime O(n^3)
            foreach (string subStrPerm in subPerms)
            {
                for (int i = 0; i <= subStrPerm.Length; i++)
                {
                    // string.Insert method runtime O(n)
                    permutations.Add(subStrPerm.Insert(i, firstChar.ToString()));
                }
            }

            return permutations;
        }

        /// <summary>
        /// Approach 2: building from permutations of all n-1 character substrings
        /// <para>Time Complexity: O(n^3 * n!) where n is number of chars in the string</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> FindAllPermutationsWithoutDups2(string str)
        {
            var permutations = new List<string>(Helper.Factorial(str.Length));

            if (string.IsNullOrEmpty(str))
            {
                return permutations;
            }

            if (str.Length == 1)
            {
                permutations.Add(str); // base case
                return permutations;
            }

            // Use each character as prefix and build sub permutations with the remaining n-1 characters - runtime O(n^3 * n!)
            for (int i = 0; i < str.Length; i++)
            {
                char prefix = str[i];
                var subStr = str.Substring(0, i) + str.Substring(i + 1); // string concat runtime O(n)

                // Build permutations for the substring - recursion depth n but getting called n! times
                List<string> subPerms = FindAllPermutationsWithoutDups2(subStr);

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
