using System;
using System.Collections.Generic;

namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.6) Towers of Hanoi:
    /// In the classic problem of the Towers of Hanoi, you have 3 towers and N disks of different sizes which can slide onto any tower.
    /// The puzzle starts with disks sorted in ascending order of size from top to bottom (i.e. each disk sits on top of an even larger one).
    /// You have the following constraints:
    /// (1) Only one disk can be moved at a time.
    /// (2) A disk is slid off the top of one tower onto another tower.
    /// (3) A disk cannot be placed on top of a smaller disk.
    /// Write a program to move the disks from the first tower to the last using stacks.
    /// </summary>
    public static class Question_8_6
    {
        /// <summary>
        /// Recursively move n-1 disks to the temp tower, last disk to the final tower, and n-1 disks from temp to the final tower
        /// <para>Time Complexity: O(n) where n is the total number of disks</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <param name="initialTower"></param>
        /// <param name="finalTower"></param>
        /// <returns></returns>
        public static void MoveDisks(Stack<int> initialTower, Stack<int> finalTower)
        {
            var tempTower = new Stack<int>();
            MoveDisksInner(initialTower.Count, initialTower, tempTower, finalTower);
        }

        private static void MoveDisksInner(int numDisksToMove, Stack<int> initialTower, Stack<int> tempTower, Stack<int> finalTower)
        {
            if (numDisksToMove <= 0)
            {
                return;
            }
            else if (numDisksToMove == 1)
            {
                ValidateMove(initialTower, finalTower);
                finalTower.Push(initialTower.Pop());
            }
            else
            {
                MoveDisksInner(numDisksToMove - 1, initialTower, finalTower, tempTower);
                MoveDisksInner(1, initialTower, tempTower, finalTower);
                MoveDisksInner(numDisksToMove - 1, tempTower, initialTower, finalTower);
            }
        }

        private static void ValidateMove(Stack<int> fromTower, Stack<int> toTower)
        {
            if (fromTower.Count == 0)
            {
                throw new InvalidOperationException("FromTower has 0 disk.");
            }
            else if (toTower.Count > 0 && fromTower.Peek() > toTower.Peek())
            {
                throw new InvalidOperationException($"Unable to move Disk {fromTower.Peek()} onto Disk {toTower.Peek()}");
            }
        }
    }
}
