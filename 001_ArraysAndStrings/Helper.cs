using System;

namespace _001_ArraysAndStrings
{
    public class Helper
    {
        public static string SortString(string str)
        {
            char[] charArr = str.ToCharArray();
            Array.Sort(charArr);
            return new string(charArr);
        }
    }
}
