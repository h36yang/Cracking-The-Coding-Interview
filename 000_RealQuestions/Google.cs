using System;
using System.Collections.Generic;

namespace _000_RealQuestions
{
    public static class Google
    {
        #region Min Days to Bloom

        /// <summary>
        /// Google | OA | Min Days to Bloom
        /// </summary>
        /// <param name="roses">Array of roses, <c>roses[i]</c> means rose <c>i</c> will bloom on day <c>roses[i]</c></param>
        /// <param name="k">The minimum number of adjacent bloom roses required for a bouquet</param>
        /// <param name="n">The number of bouquets we need</param>
        /// <returns>The earliest day that we can get n bouquets of roses</returns>
        public static int MinDaysBloom(int[] roses, int k, int n)
        {
            int[] maxSlidingWindow = MaxSlidingWindow(roses, k);

            var runningMin = new int[maxSlidingWindow.Length];
            runningMin[^1] = maxSlidingWindow[^1];
            for (int i = runningMin.Length - 2; i >= 0; i--)
            {
                runningMin[i] = Math.Min(runningMin[i + 1], maxSlidingWindow[i]);
            }

            var memo = new int[maxSlidingWindow.Length, n + 1];
            return MinDaysBloom(maxSlidingWindow, n, 0, runningMin, memo);
        }

        private static int MinDaysBloom(int[] maxSlidingWindow, int n, int start, int[] runningMin, int[,] memo)
        {
            if (start >= maxSlidingWindow.Length)
            {
                return 0;
            }

            if (n == 1)
            {
                return runningMin[start];
            }

            if (memo[start, n] > 0)
            {
                return memo[start, n];
            }

            int minDays = int.MaxValue;
            int localMinDays = int.MaxValue;
            for (int i = start; i <= maxSlidingWindow.Length - n; i++)
            {
                localMinDays = Math.Min(localMinDays, maxSlidingWindow[i]);
                if (localMinDays < minDays)
                {
                    minDays = Math.Min(minDays, Math.Max(localMinDays, MinDaysBloom(maxSlidingWindow, n - 1, i + 1, runningMin, memo)));
                }
            }
            return minDays;
        }

        private static int[] MaxSlidingWindow(int[] roses, int k)
        {
            var result = new int[roses.Length - k + 1];
            var deque = new LinkedList<int>();
            for (int i = 0; i < roses.Length; i++)
            {
                while (deque.Count > 0 && roses[deque.Last.Value] < roses[i])
                {
                    deque.RemoveLast();
                }

                while (deque.Count > 0 && deque.First.Value <= i - k)
                {
                    deque.RemoveFirst();
                }

                deque.AddLast(i);

                if (i >= k - 1)
                {
                    result[i - k + 1] = roses[deque.First.Value];
                }
            }
            return result;
        }

        #endregion
    }
}
