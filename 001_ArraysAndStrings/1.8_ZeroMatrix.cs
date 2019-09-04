using System;

namespace _001_ArraysAndStrings
{
    /// <summary>
    /// 1.8) Zero Matrix:
    /// Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0.
    /// </summary>
    public class Question_1_8
    {
        /// <summary>
        /// Keep track of the rows and columns with zeros in separate lists and replace them later
        /// <para>Time Complexity: O(M * N)</para>
        /// <para>Space Complexity: O(M + N)</para>
        /// </summary>
        /// <param name="inputMatrix"></param>
        /// <returns></returns>
        public static int[,] ZeroMatrix(int[,] inputMatrix)
        {
            if (!Helper.IsValidMatrix(inputMatrix))
            {
                throw new ArgumentException("Invalid input matrix.");
            }

            // first pass to flag which rows/columns contain 0 - time O(M * N)
            var rows = new bool[inputMatrix.GetLength(0)];
            var cols = new bool[inputMatrix.GetLength(1)];
            for (int x = 0; x < inputMatrix.GetLength(0); x++)
            {
                for (int y = 0; y < inputMatrix.GetLength(1); y++)
                {
                    if (inputMatrix[x, y] == 0)
                    {
                        rows[x] = true;
                        cols[y] = true;
                    }
                }
            }

            // second pass to replace elements with 0 - time O(M * N)
            for (int x = 0; x < inputMatrix.GetLength(0); x++)
            {
                if (rows[x])
                {
                    for (int y = 0; y < inputMatrix.GetLength(1); y++)
                    {
                        inputMatrix[x, y] = 0;
                    }
                }
            }

            for (int y = 0; y < inputMatrix.GetLength(1); y++)
            {
                if (cols[y])
                {
                    for (int x = 0; x < inputMatrix.GetLength(0); x++)
                    {
                        inputMatrix[x, y] = 0;
                    }
                }
            }
            return inputMatrix;
        }

        /// <summary>
        /// Keep track of the rows and columns with zeros in the matrix directly and replace them later
        /// <para>Time Complexity: O(M * N)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="inputMatrix"></param>
        /// <returns></returns>
        public static int[,] ZeroMatrixMemoryImproved(int[,] inputMatrix)
        {
            if (!Helper.IsValidMatrix(inputMatrix))
            {
                throw new ArgumentException("Invalid input matrix.");
            }

            // step 1 - check if first row/column has any zeros - time O(M + N)
            bool firstRowHasZero = false;
            bool firstColHasZero = false;
            for (int x = 0; x < inputMatrix.GetLength(0); x++)
            {
                if (inputMatrix[x, 0] == 0)
                {
                    firstRowHasZero = true;
                    break;
                }
            }
            for (int y = 0; y < inputMatrix.GetLength(1); y++)
            {
                if (inputMatrix[0, y] == 0)
                {
                    firstColHasZero = true;
                    break;
                }
            }

            // step 2 - iterate through and keep track of rows/columns of the zeros in first row/column - time O(M * N)
            for (int x = 0; x < inputMatrix.GetLength(0); x++)
            {
                for (int y = 0; y < inputMatrix.GetLength(1); y++)
                {
                    if (inputMatrix[x, y] == 0)
                    {
                        inputMatrix[x, 0] = 0;
                        inputMatrix[0, y] = 0;
                    }
                }
            }

            // step 3 - replace elements with 0 except for the first row/column - time O(M * N)
            for (int x = 1; x < inputMatrix.GetLength(0); x++)
            {
                if (inputMatrix[x, 0] == 0)
                {
                    for (int y = 1; y < inputMatrix.GetLength(1); y++)
                    {
                        inputMatrix[x, y] = 0;
                    }
                }
            }
            for (int y = 1; y < inputMatrix.GetLength(1); y++)
            {
                if (inputMatrix[0, y] == 0)
                {
                    for (int x = 1; x < inputMatrix.GetLength(0); x++)
                    {
                        inputMatrix[x, y] = 0;
                    }
                }
            }

            // step 4 - replace elements in first row/column - time O(M + N)
            if (firstRowHasZero)
            {
                for (int x = 0; x < inputMatrix.GetLength(0); x++)
                {
                    inputMatrix[x, 0] = 0;
                }
            }
            if (firstColHasZero)
            {
                for (int y = 0; y < inputMatrix.GetLength(1); y++)
                {
                    inputMatrix[0, y] = 0;
                }
            }
            return inputMatrix;
        }
    }
}
