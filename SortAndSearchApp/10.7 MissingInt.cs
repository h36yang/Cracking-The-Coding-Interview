using System;

namespace SortAndSearchApp
{
    public static class MissingInt
    {
        public static void PrintMissingInt(int[] file, int max)
        {
            var bitvector = new bool[max + 1];
            foreach (int i in file)
            {
                bitvector[i] = true;
            }

            for (int i = 0; i < bitvector.Length; i++)
            {
                if (!bitvector[i])
                {
                    Console.WriteLine($"Missing Int: {i}");
                    return;
                }
            }
        }
    }
}
