using System.Collections.Generic;

namespace _001_ArraysAndStrings
{
    /// <summary>
    /// 1.4) Palindrome Permutation:
    /// Given a string, write a function to check if it is a permutation of a palindrome.
    /// A palindrome is a word or phrase that is the same forwards and backwards.
    /// A permutation is a rearrangement of letters.
    /// The palindrome does not need to be limited to just dictionary words.
    /// </summary>
    public class Question_1_4
    {
        /// <summary>
        /// Use dictionary (hash table) to count distinct chars
        /// <para>Assumption: case insensitive and white space can be ignored</para>
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPalindromePermutation(string str)
        {
            var dict = new Dictionary<char, int>();
            for (int i = 0; i < str.Length; i++)
            {
                char c = char.ToLowerInvariant(str[i]);
                if (c == ' ')
                {
                    // Skip white spaces
                    continue;
                }

                // Otherwise add char to dict
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            // Check odd count in the end
            int oddCount = 0;
            foreach (var pair in dict)
            {
                if (pair.Value % 2 == 1)
                {
                    oddCount++;

                    if (oddCount > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Alternative 1: keep track of odd count as we loop through the string the first time
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPalindromePermutationAlt1(string str)
        {
            var dict = new Dictionary<char, int>();
            int oddCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = char.ToLowerInvariant(str[i]);
                if (c == ' ')
                {
                    // Skip white spaces
                    continue;
                }

                // Otherwise add char to dict
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }

                // Keep track of odd count as we go
                if (dict[c] % 2 == 1)
                {
                    oddCount++;
                }
                else
                {
                    oddCount--;
                }
            }
            return (oddCount <= 1);
        }

        /// <summary>
        /// Alternative 2: use a dictionary of booleans instead of counts (to save a little bit of space)
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPalindromePermutationAlt2(string str)
        {
            var dict = new Dictionary<char, bool>();
            int oddCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                char c = char.ToLowerInvariant(str[i]);
                if (c == ' ')
                {
                    // Skip white spaces
                    continue;
                }

                // Otherwise add char to dict
                if (dict.ContainsKey(c))
                {
                    dict[c] = !dict[c];
                }
                else
                {
                    dict.Add(c, true);
                }

                // Keep track of odd count as we go
                if (dict[c])
                {
                    oddCount++;
                }
                else
                {
                    oddCount--;
                }
            }
            return (oddCount <= 1);
        }
    }
}
