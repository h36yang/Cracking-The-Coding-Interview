using System;

namespace _000_RealQuestions
{
    public static class Apple
    {
        public static int RandomInt1toN(int n)
        {
            return (int)Math.Floor((AppleHelper.RandomNum1to6() - 1) / 5 * n) + 1;
        }

        public static int RandomInt1toN_v2(int n)
        {
            int threshold = 6;
            int numThrows = 1;
            while (threshold < n)
            {
                threshold *= 6;
                numThrows++;
            }

            while (threshold % n != 0)
            {
                threshold--;
            }

            while (true)
            {
                int i = 0;
                for (int j = 0; j < numThrows; j++)
                {
                    i = i * 6 + AppleHelper.RandomInt1to6() - 1;
                }

                if (i >= threshold)
                {
                    continue;
                }

                return i % n + 1;
            }
        }
    }

    public static class AppleHelper
    {
        public static double RandomNum1to6()
        {
            return Helper.NextDouble() * 5 + 1;
        }

        public static int RandomInt1to6()
        {
            return Helper.Next(1, 7);
        }
    }
}
