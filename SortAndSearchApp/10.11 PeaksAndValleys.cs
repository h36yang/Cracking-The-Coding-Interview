using System;

namespace SortAndSearchApp
{
    public static class PeaksAndValleys
    {
        public static void Rearrange_v1(int[] array)
        {
            int? counter = null;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    if (counter.HasValue)
                    {
                        counter--;
                    }
                    else
                    {
                        counter = 0;
                    }
                }
                else
                {
                    if (counter.HasValue)
                    {
                        counter++;
                    }
                    else
                    {
                        counter = 1;
                    }
                }

                if (counter > 1 || counter < 0)
                {
                    var temp = array[i + 1];
                    array[i + 1] = array[i];
                    array[i] = temp;

                    if (counter > 1) { counter = 0; }
                    else { counter = 1; }
                }
            }
        }

        public static void Rearrange_v2(int[] array)
        {
            for (int i = 1; i < array.Length; i += 2)
            {
                int maxIndex = MaxIndex(array, i - 1, i, i + 1);
                if (maxIndex != i)
                {
                    var temp = array[i];
                    array[i] = array[maxIndex];
                    array[maxIndex] = temp;
                }
            }
        }

        private static int MaxIndex(int[] array, int i1, int i2, int i3)
        {
            int e1 = (i1 >= 0 && i1 < array.Length) ? array[i1] : int.MinValue;
            int e2 = (i2 >= 0 && i2 < array.Length) ? array[i2] : int.MinValue;
            int e3 = (i3 >= 0 && i3 < array.Length) ? array[i3] : int.MinValue;

            int maxElement = Math.Max(e1, Math.Max(e2, e3));
            if (maxElement == e1)
            {
                return i1;
            }
            else if (maxElement == e2)
            {
                return i2;
            }
            else
            {
                return i3;
            }
        }
    }
}
