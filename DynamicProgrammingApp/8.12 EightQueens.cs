using System;
using System.Collections.Generic;

namespace DynamicProgrammingApp
{
    public static class EightQueens
    {
        public static void PrintAllArrangements()
        {
            var columns = new int[8];
            PrintArrangements(0, columns);
        }

        private static void PrintArrangements(int row, int[] columns)
        {
            if (row == 8)
            {
                for (int r = 0; r < columns.Length; r++)
                {
                    int c = columns[r];
                    Console.Write($"({r}, {c}) -> ");
                }
                Console.WriteLine();
            }
            else
            {
                for (int col = 0; col < columns.Length; col++)
                {
                    if (CanPlace(columns, row, col))
                    {
                        columns[row] = col;
                        PrintArrangements(row + 1, columns);
                    }
                }
            }
        }

        private static bool CanPlace(int[] columns, int row, int col)
        {
            for (int r = 0; r < row; r++)
            {
                int c = columns[r];
                if (col == c)
                {
                    // On same column
                    return false;
                }

                int columnDistance = Math.Abs(col - c);
                int rowDistance = row - r;
                if (columnDistance == rowDistance)
                {
                    // On same diagonal
                    return false;
                }
            }
            return true;
        }
    }
}
