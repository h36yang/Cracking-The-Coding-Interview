using System.Collections.Generic;

namespace DynamicProgrammingApp
{
    public static class RobotInGrid
    {
        public static List<KeyValuePair<int, int>> FindPath(bool[,] maze)
        {
            if (maze == null || maze.GetLength(0) == 0 || maze.GetLength(1) == 0)
            {
                return null;
            }
            
            var path = new List<KeyValuePair<int, int>>();
            var memo = new bool?[maze.GetLength(0), maze.GetLength(1)];
            memo[0, 0] = true;
            if (GetPath(maze, maze.GetLength(0) - 1, maze.GetLength(1) - 1, path, memo))
            {
                return path;
            }
            return null;
        }

        private static bool GetPath(bool[,] maze, int row, int col, List<KeyValuePair<int, int>> path, bool?[,] memo)
        {
            if (row < 0 || col < 0)
            {
                return false;
            }

            if (!maze[row, col])
            {
                memo[row, col] = false;
                return false;
            }

            if (!memo[row, col].HasValue)
            {
                memo[row, col] = GetPath(maze, row - 1, col, path, memo) || GetPath(maze, row, col - 1, path, memo);
            }

            if (memo[row, col].HasValue && memo[row, col].Value)
            {
                path.Add(new KeyValuePair<int, int>(row, col));
                return true;
            }
            return false;
        }
    }
}
