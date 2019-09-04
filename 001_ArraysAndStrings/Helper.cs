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

        public static bool IsValidMatrix<T>(T[,] matrix)
        {
            return matrix.GetLength(0) != 0 && matrix.GetLength(1) != 0;
        }

        public static bool IsSquareMatrix<T>(T[,] matrix)
        {
            return IsValidMatrix(matrix) && matrix.GetLength(0) == matrix.GetLength(1);
        }
    }
}
