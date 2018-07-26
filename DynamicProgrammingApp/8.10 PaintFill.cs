namespace DynamicProgrammingApp
{
    public static class PaintFill
    {
        public static void FillColor(Color[,] screen, int row, int col, Color newColor)
        {
            var oldColor = screen[row, col];
            FillColor(screen, row, col, oldColor, newColor);
        }

        private static void FillColor(Color[,] screen, int row, int col, Color oldColor, Color newColor)
        {
            bool outOfBound = (row < 0 || row >= screen.GetLength(0)) || (col < 0 || col >= screen.GetLength(1));
            if (outOfBound || screen[row, col] != oldColor)
            {
                return;
            }
            else
            {
                screen[row, col] = newColor;
                FillColor(screen, row - 1, col, oldColor, newColor);
                FillColor(screen, row, col - 1, oldColor, newColor);
                FillColor(screen, row + 1, col, oldColor, newColor);
                FillColor(screen, row, col + 1, oldColor, newColor);
            }
        }

        public enum Color
        {
            Black,
            White,
            Red
        }
    }
}
