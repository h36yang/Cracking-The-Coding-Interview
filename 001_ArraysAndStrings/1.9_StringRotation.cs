namespace _001_ArraysAndStrings
{
    /// <summary>
    /// 1.9) String Rotation:
    /// Assume you have a method isSubstring which checks if one word is a substring of another.
    /// Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to isSubstring.
    /// (e.g. "waterbottle" is a rotation of"erbottlewat")
    /// </summary>
    public class Question_1_9
    {
        /// <summary>
        /// Duplicate str1 and check if it contains str2
        /// <para>Time Complexity: O(n), where n is length of the string</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool CheckStringRotation(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2) || str1.Length != str2.Length)
            {
                return false;
            }

            if (str1.Equals(str2))
            {
                return true;
            }

            string str1str1 = str1 + str1;
            return str1str1.Contains(str2);
        }
    }
}
