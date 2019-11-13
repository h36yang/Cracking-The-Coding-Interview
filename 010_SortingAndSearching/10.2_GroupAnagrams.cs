using System.Collections.Generic;

namespace _010_SortingAndSearching
{
    /// <summary>
    /// 10.2) Group Anagrams:
    /// Write a method to sort an array of strings so that all the anagrams are next to each other.
    /// </summary>
    public static class Question_10_2
    {
        /// <summary>
        /// Use a dictionary to group the anagrams
        /// <para>Time Complexity: O(n*c*log(c)) where n is the number of strings in the array and c is the number of chars in the longest string</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="arr"></param>
        public static void GroupAnagrams(string[] arr)
        {
            var anagramGroups = new Dictionary<string, List<string>>();

            // Add each string to the dictionary - runtime O(n*c*log(c))
            foreach (string str in arr)
            {
                // Generate key by sorting chars in the string - runtime O(c*log(c))
                string key = Helper.SortChar(str);
                if (anagramGroups.ContainsKey(key))
                {
                    anagramGroups[key].Add(str);
                }
                else
                {
                    anagramGroups.Add(key, new List<string> { str });
                }
            }

            // Convert dictionary back to array - runtime O(n)
            int index = 0;
            foreach (List<string> group in anagramGroups.Values)
            {
                foreach (string anagram in group)
                {
                    arr[index] = anagram;
                    index++;
                }
            }
        }
    }
}
