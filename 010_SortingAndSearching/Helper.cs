using System;
using System.Collections.Generic;

namespace _010_SortingAndSearching
{
    public static class Helper
    {
        /// <summary>
        /// Sort chars in string alphabetically
        /// <para>Time Complexity: O(n*log(n))</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str">string with n characters</param>
        /// <returns></returns>
        public static string SortChar(string str)
        {
            // Convert string to char array - runtime O(n)
            char[] chars = str.ToCharArray();

            // Sort char array alphabetically - runtime O(n*log(n))
            Array.Sort(chars);

            // Convert char array back to string and return - runtime O(n)
            return new string(chars);
        }

        public static bool IsCollectionNullOrEmpty<T>(IList<T> collection)
        {
            return collection == null || collection.Count == 0;
        }
    }
}
