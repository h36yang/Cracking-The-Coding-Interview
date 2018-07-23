namespace DynamicProgrammingApp
{
    public static class TripleStep
    {
        public static long CountWaysRecursive(int steps)
        {
            if (steps < 0)
            {
                return 0;
            }
            else if (steps == 0)
            {
                return 1;
            }
            else
            {
                return CountWaysRecursive(steps - 1) + CountWaysRecursive(steps - 2) + CountWaysRecursive(steps - 3);
            }
        }

        public static long CountWaysDynamic(int steps)
        {
            var memo = new long[steps + 1];
            memo[0] = 1;
            return CountWaysDynamic(steps, memo);
        }

        private static long CountWaysDynamic(int steps, long[] memo)
        {
            if (steps < 0)
            {
                return 0;
            }
            else
            {
                if (memo[steps] == 0)
                {
                    memo[steps] = CountWaysDynamic(steps - 1, memo) + CountWaysDynamic(steps - 2, memo) + CountWaysDynamic(steps - 3, memo);
                }
                return memo[steps];
            }
        }
    }
}
