namespace _001_ArraysAndStrings
{
    /// <summary>
    /// 1.3) URLify:
    /// Write a method to replace all spaces in a string with '%20'.
    /// You may assume that the string has sufficient space at the end to hold the additional characters, and that you are given the "true" length of the string.
    /// (Note: If implementing in Java, please use a character array so that you can perform this operation in place.)
    /// </summary>
    public class Question_1_3
    {
        /// <summary>
        /// Loop backwards with 2 index pointers
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="str"></param>
        /// <param name="trueLength"></param>
        /// <returns></returns>
        public static string URLify(string str, int trueLength)
        {
            int i = trueLength - 1;
            int j = str.Length - 1;
            char[] charArr = str.ToCharArray();
            while (i < j)
            {
                if (charArr[i] != ' ')
                {
                    charArr[j] = charArr[i];
                    j--;
                }
                else
                {
                    charArr[j] = '0';
                    charArr[j - 1] = '2';
                    charArr[j - 2] = '%';
                    j -= 3;
                }
                i--;
            }
            return new string(charArr);
        }
    }
}
