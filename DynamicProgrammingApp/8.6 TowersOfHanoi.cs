using System.Collections.Generic;

namespace DynamicProgrammingApp
{
    public static class TowersOfHanoi
    {
        public static void Move(int disks, Stack<int> start, Stack<int> dest, Stack<int> buffer)
        {
            if (disks == 1)
            {
                dest.Push(start.Pop());
            }
            else if (disks == 2)
            {
                buffer.Push(start.Pop());
                dest.Push(start.Pop());
                dest.Push(buffer.Pop());
            }
            else
            {
                Move(disks - 1, start, buffer, dest);
                Move(1, start, dest, buffer);
                Move(disks - 1, buffer, dest, start);
            }
        }
    }
}
