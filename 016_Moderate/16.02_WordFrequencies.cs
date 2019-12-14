using System.Collections.Generic;

namespace _016_Moderate
{
    /// <summary>
    /// 16.1) Word Frequencies:
    /// Design a method to find the frequency of occurrences of any given word in a book.
    /// What if we were running this algorithm multiple times?
    /// </summary>
    public class Question_16_02
    {
        private readonly Dictionary<string, int> _wordCounts = new Dictionary<string, int>();

        /// <summary>
        /// Convert book to a word count dictionary to benefit repeated word searches
        /// <para>Time Complexity: O(n) where n is total number of words in the book</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="book"></param>
        public Question_16_02(string[] book)
        {
            for (int i = 0; i < book.Length; i++)
            {
                string word = book[i].Trim().ToLowerInvariant();
                if (_wordCounts.ContainsKey(word))
                {
                    _wordCounts[word]++;
                }
                else
                {
                    _wordCounts.Add(word, 1);
                }
            }
        }

        /// <summary>
        /// Look up word count from dictionary
        /// <para>Time Complexity: O(1)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int CoundWord(string word)
        {
            string newWord = word.Trim().ToLowerInvariant();
            if (_wordCounts.ContainsKey(newWord))
            {
                return _wordCounts[newWord];
            }
            else
            {
                return 0;
            }
        }
    }
}
