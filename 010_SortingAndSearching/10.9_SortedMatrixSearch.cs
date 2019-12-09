namespace _010_SortingAndSearching
{
    /// <summary>
    /// 10.9) Sorted Matrix Search:
    /// Given an M x N matrix in which each row and each column is sorted in ascending order, write a method to find an element.
    /// </summary>
    public static class Question_10_9
    {
        /// <summary>
        /// Binary Search in Matrix
        /// <para>Time Complexity: O(log(mn))</para>
        /// <para>Space Complexity: O(log(mn))</para>
        /// </summary>
        /// <param name="matrix">m * n matrix</param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static (int row, int col) FindElementInSortedMatrix(int[,] matrix, int element)
        {
            if (matrix == null)
            {
                return (-1, -1);
            }
            return FindElementInSortedMatrix(matrix, element, 0, matrix.GetLength(0) - 1, 0, matrix.GetLength(1) - 1);
        }

        private static (int row, int col) FindElementInSortedMatrix(int[,] matrix, int element, int rowStart, int rowEnd, int colStart, int colEnd)
        {
            if (rowStart > rowEnd || colStart > colEnd)
            {
                return (-1, -1);
            }

            int rowMid = (rowStart + rowEnd) / 2;
            int colMid = (colStart + colEnd) / 2;
            if (matrix[rowMid, colMid] == element)
            {
                return (rowMid, colMid);
            }

            int resultRow;
            int resultCol;
            if (matrix[rowMid, colMid] > element)
            {
                if (rowMid - 1 < rowStart || colMid - 1 < colStart)
                {
                    return (-1, -1);
                }

                if (matrix[rowMid - 1, colMid - 1] >= element)
                {
                    return FindElementInSortedMatrix(matrix, element, rowStart, rowMid - 1, colStart, colMid - 1);
                }
                else
                {
                    (resultRow, resultCol) = FindElementInSortedMatrix(matrix, element, rowStart, rowMid - 1, colMid, colEnd);
                    if (resultRow == -1 || resultCol == -1)
                    {
                        (resultRow, resultCol) = FindElementInSortedMatrix(matrix, element, rowMid, rowEnd, colStart, colMid - 1);
                    }
                }
            }
            else
            {
                if (rowMid + 1 > rowEnd || colMid + 1 > colEnd)
                {
                    return (-1, -1);
                }

                if (matrix[rowMid + 1, colMid + 1] <= element)
                {
                    return FindElementInSortedMatrix(matrix, element, rowMid + 1, rowEnd, colMid + 1, colEnd);
                }
                else
                {
                    (resultRow, resultCol) = FindElementInSortedMatrix(matrix, element, rowMid + 1, rowEnd, colStart, colMid);
                    if (resultRow == -1 || resultCol == -1)
                    {
                        (resultRow, resultCol) = FindElementInSortedMatrix(matrix, element, rowStart, rowMid, colMid + 1, colEnd);
                    }
                }
            }
            return (resultRow, resultCol);
        }
    }
}
