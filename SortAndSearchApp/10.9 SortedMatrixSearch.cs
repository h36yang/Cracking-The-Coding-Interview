using System.Collections.Generic;

namespace SortAndSearchApp
{
    public static class SortedMatrixSearch
    {
        public static KeyValuePair<int, int>? Find(int[,] matrix, int x)
        {
            int row = 0;
            int col = matrix.GetLength(1) - 1;
            while (row < matrix.GetLength(0) && col >= 0)
            {
                if (matrix[row, col] == x)
                {
                    return new KeyValuePair<int, int>(row + 1, col + 1);
                }
                else if (matrix[row, col] > x)
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }
            return null;
        }
    }
}
