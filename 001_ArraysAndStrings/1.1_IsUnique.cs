using System;
using System.Collections.Generic;

namespace _001_ArraysAndStrings
{
    /// <summary>
    /// 1.1) Is Unique:
    /// Implement an algorithm to determine if a string has all unique characters.
    /// What if you cannot use additional data structures?
    /// </summary>
    public class Question_1_1
    {
        /// <summary>
        /// Implement an algorithm to determine if a string has all unique characters.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUnique(string str)
        {
            var dict = new Dictionary<char, bool>();
            foreach (char c in str)
            {
                if (dict.ContainsKey(c))
                {
                    return false;
                }
                dict.Add(c, true);
            }
            return true;
        }

        /// <summary>
        /// What if you cannot use additional data structures? Nested Loop
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUniqueInplaceNestedLoop(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    if (str[i] == str[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// What if you cannot use additional data structures? Sort and Loop
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUniqueInplaceSort(char[] str)
        {
            Array.Sort(str);
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
