using System;
using System.Collections.Generic;

namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.12) Eight Queens:
    /// Write an algorithm to print all ways of arranging eight queens on an 8x8 chess board so that none of them share the same row, column, or diagonal.
    /// In this case, "diagonal" means all diagonals, not just the two that bisect the board.
    /// </summary>
    public static class Question_8_12
    {
        private const int BoardSize = 8;

        /// <summary>
        /// Iteratively check each x and recursively check each y
        /// <para>Time Complexity: O(n^2), where n is the board size</para>
        /// <para>Space Complexity: O(n^2)</para>
        /// </summary>
        /// <returns></returns>
        public static List<(int x, int y)[]> GenerateAllEightQueens()
        {
            var results = new List<(int, int)[]>();
            for (int dx = 0; dx < BoardSize; dx++)
            {
                var queens = new (int, int)[BoardSize];
                GenerateTheRemainingQueens(dx, 0, queens, results);
            }
            return results;
        }

        private static void GenerateTheRemainingQueens(int x, int y, (int x, int y)[] queens, List<(int, int)[]> results)
        {
            if (x < 0 || x >= BoardSize || y < 0 || y >= BoardSize)
            {
                return; // invalid state - do nothing
            }

            for (int i = 0; i < y; i++)
            {
                if (!ValidatePoints(queens[i].x, queens[i].y, x, y))
                {
                    return; // point collides with another one - return directly
                }
            }
            queens[y] = (x, y);

            if (y == BoardSize - 1)
            {
                // Base Case
                results.Add(queens.Clone() as (int, int)[]);
            }
            else
            {
                for (int dx = 0; dx < BoardSize; dx++)
                {
                    GenerateTheRemainingQueens(dx, y + 1, queens, results);
                }
            }
        }

        public static bool ValidatePoints(int x1, int y1, int x2, int y2)
        {
            if (x1 == x2 || y1 == y2 || Math.Abs(x2 - x1) == Math.Abs(y2 - y1))
            {
                // 2 points on the same row/column/diagonal
                return false;
            }
            return true;
        }
    }
}
