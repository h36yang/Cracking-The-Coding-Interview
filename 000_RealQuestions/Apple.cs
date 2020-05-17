using System;

namespace _000_RealQuestions
{
    public static class Apple
    {
        public static int RandomInt1toN(int n)
        {
            return (int)Math.Floor((AppleHelper.RandomNum1to6() - 1) / 5 * n) + 1;
        }
    }

    public static class AppleHelper
    {
        private static Random _random;

        public static double RandomNum1to6()
        {
            if (_random == null)
            {
                _random = new Random();
            }
            return _random.NextDouble() * 5 + 1;
        }

        public static int RandomInt1to6()
        {
            if (_random == null)
            {
                _random = new Random();
            }
            return _random.Next(1, 7);
        }
    }
}
