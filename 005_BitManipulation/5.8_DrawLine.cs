using System;

namespace _005_BitManipulation
{
    /// <summary>
    /// 5.8) Draw Line:
    /// A monochrome screen is stored as a single array of bytes, allowing eight consecutive pixels to be stored in one byte.
    /// The screen has width w, where w is divisible by 8 (that is, no byte will be split across rows).
    /// The height of the screen, of course, can be derived from the length of the array and the width.
    /// Implement a function that draws a horizontal line from (x1, y) to (x2, y).
    /// The method signature should look something like:
    /// drawLine(byte[] screen, int width, int x1, int x2, int y)
    /// </summary>
    public static class Question_5_8
    {
        /// <summary>
        /// Calculate the start/end byte and create masks for each. For any in-between bytes, set them directly to all 1s.
        /// <para>Time Complexity: worst case O(X), where X is number of bytes between x1 and x2</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="width"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y"></param>
        public static void DrawLine(byte[] screen, int width, int x1, int x2, int y)
        {
            ValidateInputParameters(screen, width, x1, x2, y);

            int bitLoc1 = y * width + x1;
            int bitLoc2 = y * width + x2;
            int index1 = bitLoc1 / 8;
            int index2 = bitLoc2 / 8;
            int bitLocInByte1 = bitLoc1 % 8;
            int bitLocInByte2 = bitLoc2 % 8;

            for (int i = index1; i <= index2; i++)
            {
                byte currByte = screen[i];
                byte newByte;
                if (i == index1 || i == index2)
                {
                    byte mask;
                    if (i == index1 && i == index2)
                    {
                        mask = Convert.ToByte(((1 << (bitLocInByte2 - bitLocInByte1 + 1)) - 1) << (7 - bitLocInByte2));
                    }
                    else if (i == index1)
                    {
                        mask = Convert.ToByte((1 << (8 - bitLocInByte1)) - 1);
                    }
                    else
                    {
                        mask = Convert.ToByte(((1 << (bitLocInByte2 + 1)) - 1) << (7 - bitLocInByte2));
                    }
                    newByte = (byte)(currByte | mask);
                }
                else
                {
                    newByte = 0b_1111_1111;
                }
                screen[i] = newByte;
            }
        }

        private static void ValidateInputParameters(byte[] screen, int width, int x1, int x2, int y)
        {
            int trueScreenLength = screen.Length * 8;
            if (trueScreenLength < width || trueScreenLength % width != 0)
            {
                throw new ArgumentException($"Incompatible screen array length {trueScreenLength} and width {width}.");
            }

            if (!IsCoordinateValid(x1, width))
            {
                throw new ArgumentOutOfRangeException(nameof(x1));
            }

            if (!IsCoordinateValid(x2, width))
            {
                throw new ArgumentOutOfRangeException(nameof(x2));
            }

            if (!IsCoordinateValid(y, trueScreenLength / width))
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }

            if (x1 > x2)
            {
                throw new ArgumentException("x2 cannot be smaller than x1.");
            }
        }

        private static bool IsCoordinateValid(int x, int upperBound)
        {
            return x >= 0 && x < upperBound;
        }
    }
}
