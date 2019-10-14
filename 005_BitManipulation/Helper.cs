namespace _005_BitManipulation
{
    public static class Helper
    {
        public static int CountBits(int number)
        {
            int count = 0;
            while (number > 0)
            {
                count++;
                number >>= 1;
            }
            return count;
        }
    }
}
