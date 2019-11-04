namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.10) Paint Fill:
    /// Implement the "paint fill" function that one might see on many image editing programs.
    /// That is, given a screen (represented by a two-dimensional array of colors), a point, and a new color, fill in the surrounding area until the color changes from the original color.
    /// </summary>
    public static class Question_8_10
    {
        public enum Color
        {
            Red,
            Yellow,
            Blue,
            Black
        }

        /// <summary>
        /// Recursively fill the curren point and all neighbor points
        /// <para>Time Complexity: O(p), where p is the number of points to fill</para>
        /// <para>Space Complexity: O(d), where d is max recursion depth, max(width, length) of the screen</para>
        /// </summary>
        /// <param name="screen"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="newColor"></param>
        public static void PaintFill(Color[,] screen, int x, int y, Color newColor)
        {
            if (x < 0 || y < 0 || x >= screen.GetLength(1) || y >= screen.GetLength(0))
            {
                return; // invalid point - do nothing
            }

            PaintFillInner(screen, x, y, screen[y, x], newColor);
        }

        private static void PaintFillInner(Color[,] screen, int x, int y, Color oldColor, Color newColor)
        {
            if (x < 0 || y < 0 || x >= screen.GetLength(1) || y >= screen.GetLength(0))
            {
                return; // invalid point - do nothing
            }

            if (screen[y, x] != oldColor || screen[y, x] == newColor)
            {
                return; // color not the same as original or already same as new - do nothing
            }

            // Set the new color
            screen[y, x] = newColor;

            // Fill the neighbor points
            PaintFillInner(screen, x - 1, y, oldColor, newColor);
            PaintFillInner(screen, x + 1, y, oldColor, newColor);
            PaintFillInner(screen, x, y - 1, oldColor, newColor);
            PaintFillInner(screen, x, y + 1, oldColor, newColor);
        }
    }
}
