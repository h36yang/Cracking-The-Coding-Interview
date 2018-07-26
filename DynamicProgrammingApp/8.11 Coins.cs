namespace DynamicProgrammingApp
{
    public static class Coins
    {
        public static long CountCombos(int cents)
        {
            var memo = new long?[cents + 1];
            memo[0] = 1;
            return CountCombos(cents, memo);
        }

        private static long CountCombos(int cents, long?[] memo)
        {
            if (cents < 0)
            {
                return 0;
            }
            else
            {
                if (!memo[cents].HasValue)
                {
                    memo[cents] = CountCombos(cents - 1, memo) + CountCombos(cents - 5, memo) + CountCombos(cents - 10, memo) + CountCombos(cents - 25, memo);
                }
                return memo[cents].Value;
            }
        }
    }
}
