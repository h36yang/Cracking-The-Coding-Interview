namespace _005_BitManipulation
{
    /// <summary>
    /// 5.5) Debugger:
    /// Explain what the following code does: ((n & (n - 1)) == 0).
    /// </summary>
    public static class Question_5_5
    {
        public static bool IsNumberPowerOfTwo(int number)
        {
            return (number & (number - 1)) == 0;
        }
    }
}
