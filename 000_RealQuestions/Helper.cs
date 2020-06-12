using System;

namespace _000_RealQuestions
{
    public static class Helper
    {
        private static Random _random = new Random();

        public static int Next(int max)
        {
            return _random.Next(max);
        }

        public static int Next(int min, int max)
        {
            return _random.Next(min, max);
        }

        public static double NextDouble()
        {
            return _random.NextDouble();
        }
    }
}
