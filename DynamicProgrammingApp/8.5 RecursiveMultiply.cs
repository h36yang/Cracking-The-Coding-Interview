namespace DynamicProgrammingApp
{
    public static class RecursiveMultiply
    {
        public static int Multiply(int x, int y)
        {
            int smaller = x < y ? x : y;
            int larger = x < y ? y : x;

            var memo = new int?[smaller + 1];
            memo[0] = 0;
            memo[1] = larger;
            return MultiplyRecursive(smaller, larger, memo);
        }

        private static int MultiplyRecursive(int smaller, int larger, int?[] memo)
        {
            if (!memo[smaller].HasValue)
            {
                int halfSmaller = smaller >> 1;
                if (smaller % 2 == 0)
                {
                    memo[smaller] = MultiplyRecursive(halfSmaller, larger, memo)
                                  + MultiplyRecursive(halfSmaller, larger, memo);
                }
                else
                {
                    memo[smaller] = MultiplyRecursive(halfSmaller, larger, memo)
                                  + MultiplyRecursive(halfSmaller, larger, memo)
                                  + larger;
                }
            }
            return memo[smaller].Value;
        }
    }
}
