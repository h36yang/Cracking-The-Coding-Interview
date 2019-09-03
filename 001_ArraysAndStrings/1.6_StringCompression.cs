using System.Text;

namespace _001_ArraysAndStrings
{
    /// <summary>
    /// 1.6) String Compression:
    /// Implement a method to perform basic string compression using the counts of repeated characters.
    /// For example, the string aabcccccaaa would become a2blc5a3.
    /// If the "compressed" string would not become smaller than the original string, your method should return the original string.
    /// You can assume the string has only uppercase and lowercase letters(a - z).
    /// </summary>
    public class Question_1_6
    {
        /// <summary>
        /// Use String Builder to keep track of compressed string
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CompressString(string str)
        {
            var builder = new StringBuilder();
            int charCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                charCount++;

                if (i + 1 == str.Length || str[i] != str[i + 1])
                {
                    builder.Append(str[i]);
                    builder.Append(charCount);
                    charCount = 0;
                }
            }
            return (builder.Length >= str.Length) ? str : builder.ToString();
        }

        /// <summary>
        /// Alternative - count compression length first to save constant space, but double time
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CompressStringAlt(string str)
        {
            // first pass to count compression length
            int compressLength = 0;
            int charCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                charCount++;

                if (i + 1 == str.Length || str[i] != str[i + 1])
                {
                    compressLength += 1 + charCount.ToString().Length;
                    charCount = 0;
                }
            }

            if (compressLength >= str.Length)
            {
                return str;
            }

            // second pass to build compression string if needed
            var builder = new StringBuilder(compressLength);
            charCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                charCount++;

                if (i + 1 == str.Length || str[i] != str[i + 1])
                {
                    builder.Append(str[i]);
                    builder.Append(charCount);
                    charCount = 0;
                }
            }
            return builder.ToString();
        }
    }
}
