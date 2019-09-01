using System;
using System.Collections.Generic;
using System.Text;

namespace _001_ArraysAndStrings
{
    /// <summary>
    /// 1.2) Check Permutation:
    /// Given two strings, write a method to decide if one is a permutation of the other.
    /// </summary>
    public class Question_1_2
    {
        /// <summary>
        /// Sort and compare
        /// <para>Time Complexity: O(n*log(n))</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool CheckPermutationInplaceSort(string str1, string str2)
        {
            if (str1 == str2)
            {
                return true;
            }

            if (str1.Length != str2.Length)
            {
                return false;
            }

            str1 = Helper.SortString(str1); // assuming O(n*log(n)) runtime
            str2 = Helper.SortString(str2); // assuming O(n*log(n)) runtime
            return (str1 == str2);
        }

        /// <summary>
        /// Use hash table
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool CheckPermutationHashTable(string str1, string str2)
        {
            if (str1 == str2)
            {
                return true;
            }

            if (str1.Length != str2.Length)
            {
                return false;
            }

            var dict = new Dictionary<char, int>();
            // Add str1 to dictionary (hash table)
            foreach (char c in str1)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            // Run str2 through the same dictionary (hash table) to reduce the count
            foreach (char c in str2)
            {
                if (!dict.ContainsKey(c) || dict[c] == 0)
                {
                    // if any char in str2 is not in the dictionary or the count is 0, return false directly
                    return false;
                }
                dict[c]--;
            }

            // if we are able to run remove all str2 chars from dict, it means the 2 strs match
            return true;
        }
    }
}
