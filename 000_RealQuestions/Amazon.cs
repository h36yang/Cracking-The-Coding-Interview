using System.Collections.Generic;
using System.Linq;

namespace _000_RealQuestions
{
    public static class Amazon
    {
        #region Is cheese reachable in the maze?

        public static bool IsCheeseReachableInMaze(int[,] maze)
        {
            var dirs = new (int, int)[]
            {
                (0, -1), (0, 1), (-1, 0), (1, 0)
            };

            var bfs = new Queue<(int, int)>();
            bfs.Enqueue((0, 0));

            var visited = new bool[maze.GetLength(0), maze.GetLength(1)];
            visited[0, 0] = true;

            while (bfs.Count > 0)
            {
                (int r, int c) = bfs.Dequeue();
                if (maze[r, c] == 9)
                {
                    return true;
                }

                foreach ((int dr, int dc) in dirs)
                {
                    int newR = r + dr;
                    int newC = c + dc;
                    if (IsPath(maze, newR, newC, visited))
                    {
                        bfs.Enqueue((newR, newC));
                        visited[newR, newC] = true;
                    }
                }
            }
            return false;
        }

        private static bool IsPath(int[,] maze, int r, int c, bool[,] visited)
        {
            return r >= 0 && r < maze.GetLength(0) && c >= 0 && c < maze.GetLength(1) && maze[r, c] != 0 && !visited[r, c];
        }

        #endregion

        #region Group Numbers by Common Elements

        /// <summary>
        /// Group numbers that share at least 1 element
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static List<List<int>> GroupNumbers(List<KeyValuePair<int, char[]>> nums)
        {
            var elements = new List<int>[26];
            foreach (KeyValuePair<int, char[]> num in nums)
            {
                foreach (char element in num.Value)
                {
                    int id = element - 'a';
                    if (elements[id] == null)
                    {
                        elements[id] = new List<int>();
                    }
                    elements[id].Add(num.Key);
                }
            }

            var numGroups = new Dictionary<int, int>();
            for (int c = 0; c < 26; c++)
            {
                if (elements[c] != null)
                {
                    for (int i = 0; i < elements[c].Count; i++)
                    {
                        if (!numGroups.ContainsKey(elements[c][i]))
                        {
                            numGroups[elements[c][i]] = (i == 0) ? -1 : elements[c][i - 1];
                        }
                        else
                        {
                            if (i > 0)
                            {
                                Union(numGroups, elements[c][i], elements[c][i - 1]);
                            }
                        }
                    }
                }
            }

            var res = new Dictionary<int, List<int>>();
            foreach (int num in numGroups.Keys)
            {
                int group = Find(numGroups, num);
                if (res.ContainsKey(group))
                {
                    res[group].Add(num);
                }
                else
                {
                    res[group] = new List<int> { num };
                }
            }
            return res.Values.ToList();
        }

        private static int Find(Dictionary<int, int> groups, int key)
        {
            if (groups[key] == -1)
            {
                return key;
            }
            return Find(groups, groups[key]);
        }

        private static void Union(Dictionary<int, int> groups, int key1, int key2)
        {
            int g1 = Find(groups, key1);
            int g2 = Find(groups, key2);
            if (g1 != g2)
            {
                groups[g1] = g2;
            }
        }

        #endregion

        #region Count of Good SubArrays

        /// <summary>
        /// Count number of good subarrays in A. A subarray is considered a good subarray if:
        /// <para>1. Length of the subarray is even and the sum of all the elements of the subarray is less than B.</para>
        /// <para>2. Length of the subarray is odd and the sum of all the elements of the subarray is greater than B.</para>
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static int CountGoodSubArrays(int[] A, int B)
        {
            int count = 0;
            for (int i = 0; i < A.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < A.Length; j++)
                {
                    int len = j - i + 1;
                    sum += A[j];
                    if (len % 2 == 0 && sum < B || len % 2 != 0 && sum > B)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        #endregion
    }
}
