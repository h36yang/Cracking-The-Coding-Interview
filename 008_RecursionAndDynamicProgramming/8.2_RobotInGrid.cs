using System.Collections.Generic;

namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.2) Robot in a Grid:
    /// Imagine a robot sitting on the upper left corner of grid with r rows and c columns.
    /// The robot can only move in two directions, right and down, but certain cells are "off limits" such that the robot cannot step on them.
    /// Design an algorithm to find a path for the robot from the top left to the bottom right.
    /// </summary>
    public static class Question_8_2
    {
        /// <summary>
        /// Using pure recursion
        /// <para>Time Complexity: O(2^(r+c)), where r is number of rows and c is number of columns in the maze</para>
        /// <para>Space Complexity: O(r+c) - depth of the recursion</para>
        /// </summary>
        /// <param name="maze">2D array of boolean values, where false value means off limits</param>
        /// <returns></returns>
        public static List<(int r, int c)> FindPathRecursion(bool[,] maze)
        {
            if (!IsMazeValid(maze) || AreMazeStartEndPointsOffLimits(maze))
            {
                return null;
            }

            var path = new List<(int r, int c)>();
            if (HasPath(maze, maze.GetLength(0) - 1, maze.GetLength(1) - 1, path))
            {
                return path;
            }
            return null;
        }

        private static bool HasPath(bool[,] maze, int row, int column, List<(int r, int c)> path)
        {
            if (row < 0 || column < 0 || !maze[row, column])
            {
                return false;
            }

            bool isAtStartPoint = row == 0 && column == 0;
            if (isAtStartPoint || HasPath(maze, row - 1, column, path) || HasPath(maze, row, column - 1, path))
            {
                path.Add((r: row, c: column));
                return true;
            }

            return false;
        }

        /// <summary>
        /// Using memoization
        /// <para>Time Complexity: O(r*c) - number of pixels in the grid</para>
        /// <para>Space Complexity: O(r*c)</para>
        /// </summary>
        /// <param name="maze">2D array of boolean values, where false value means off limits</param>
        /// <returns></returns>
        public static List<(int r, int c)> FindPathMemoization(bool[,] maze)
        {
            if (!IsMazeValid(maze) || AreMazeStartEndPointsOffLimits(maze))
            {
                return null;
            }

            var path = new List<(int r, int c)>();
            var failedPoints = new HashSet<(int r, int c)>();
            if (HasPath(maze, maze.GetLength(0) - 1, maze.GetLength(1) - 1, path, failedPoints))
            {
                return path;
            }
            return null;
        }

        private static bool HasPath(bool[,] maze, int row, int column, List<(int r, int c)> path, HashSet<(int r, int c)> failedPoints)
        {
            if (row < 0 || column < 0 || !maze[row, column])
            {
                return false;
            }

            // if we have already visited this point, return directly
            if (failedPoints.Contains((row, column)))
            {
                return false;
            }

            bool isAtStartPoint = row == 0 && column == 0;
            if (isAtStartPoint || HasPath(maze, row - 1, column, path, failedPoints) || HasPath(maze, row, column - 1, path, failedPoints))
            {
                path.Add((r: row, c: column));
                return true;
            }

            // Cache result before returning false
            failedPoints.Add((row, column));
            return false;
        }

        private static bool IsMazeValid(bool[,] maze)
        {
            return maze != null && maze.GetLength(0) > 0 && maze.GetLength(1) > 0;
        }

        private static bool AreMazeStartEndPointsOffLimits(bool[,] maze)
        {
            return !maze[0, 0] || !maze[maze.GetLength(0) - 1, maze.GetLength(1) - 1];
        }
    }
}
