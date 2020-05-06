using System;

namespace _000_RealQuestions
{
    public static class Facebook
    {
        /// <summary>
        /// Write a function that returns whether two words are exactly "one edit" away
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool OneEditApart(string str1, string str2)
        {
            if (Math.Abs((str1?.Length ?? 0) - (str2?.Length ?? 0)) > 1)
            {
                return false;
            }

            int i = 0;
            while (i < str1.Length && i < str2.Length && str1[i] == str2[i])
            {
                i++;
            }

            if (str1.Length == str2.Length)
            {
                return string.Equals(str1.Substring(i + 1), str2.Substring(i + 1));
            }
            else if (str1.Length > str2.Length)
            {
                return string.Equals(str1.Substring(i + 1), str2.Substring(i));
            }
            else
            {
                return string.Equals(str1.Substring(i), str2.Substring(i + 1));
            }
        }
    }
}
