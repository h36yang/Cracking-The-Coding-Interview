using System;

namespace _001_ArraysAndStrings
{
    /// <summary>
    /// 1.5) One Away:
    /// There are three types of edits that can be performed on strings: insert a character, remove a character, or replace a character.
    /// Given two strings, write a function to check if they are one edit (or zero edits) away.
    /// </summary>
    public class Question_1_5
    {
        /// <summary>
        /// Loop through each char and count diffs
        /// <para>Time Complexity: O(n)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static bool AreOneAway(string str1, string str2)
        {
            if (str1 == str2)
            {
                return true;
            }

            if (Math.Abs(str1.Length - str2.Length) > 1)
            {
                return false;
            }

            return (str1.Length > str2.Length) ? CheckOneAway(str1, str2) : CheckOneAway(str2, str1);
        }

        private static bool CheckOneAway(string sLonger, string sShorter)
        {
            bool diffExists = false;
            int iShorter = 0;
            int iLonger = 0;
            while (iShorter < sShorter.Length && iLonger < sLonger.Length)
            {
                if (sLonger[iLonger] != sShorter[iShorter])
                {
                    if (diffExists)
                    {
                        return false;
                    }
                    diffExists = true;

                    if (sLonger.Length == sShorter.Length)
                    {
                        iShorter++;
                    }
                }
                else
                {
                    iShorter++;
                }
                iLonger++;
            }
            return true;
        }
    }
}
