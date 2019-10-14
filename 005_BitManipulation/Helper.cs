namespace _005_BitManipulation
{
    public static class Helper
    {
        public static uint SetBit(uint number, int index)
        {
            uint mask = (1u << index);
            return number | mask;
        }

        public static uint ClearBit(uint number, int index)
        {
            uint mask = ~(1u << index);
            return number & mask;
        }
    }
}
