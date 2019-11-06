using System;
using System.Collections.Generic;

namespace _008_RecursionAndDynamicProgramming
{
    /// <summary>
    /// 8.13) Stack of Boxes:
    /// You have a stack of n boxes, with widths Wi, heights Hi, and depths Di.
    /// The boxes cannot be rotated and can only be stacked on top of one another if each box in the stack is strictly larger than the box above it in width, height, and depth.
    /// Implement a method to compute the height of the tallest possible stack.
    /// The height of a stack is the sum of the heights of each box.
    /// </summary>
    public static class Question_8_13
    {
        public class Box : IComparable<Box>
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public int Depth { get; set; }

            public int CompareTo(Box other)
            {
                return (other?.Width ?? 0) - Width;
            }
        }

        /// <summary>
        /// Using pure recursion
        /// <para>Time Complexity: O(n^2) where n is number of boxes</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <returns></returns>
        public static int CalculateTallestStackHeightRecursion(Box[] boxes)
        {
            if (boxes == null)
            {
                return -1;
            }

            // Assuming fastest sorting runtime O(n*log(n))
            Array.Sort(boxes);

            int maxHeight = 0;
            // Iterate through each box from widest to narrowest - runtime O(n^2)
            for (int i = 0; i < boxes.Length; i++)
            {
                Box baseBox = boxes[i];
                // The recursion method has a runtime of O(n)
                maxHeight = Math.Max(maxHeight, CalculateStackHeight(boxes, baseBox, i));
            }
            return maxHeight;
        }

        /// <summary>
        /// Using memoization
        /// <para>Time Complexity: O(n*log(n)) where n is number of boxes</para>
        /// <para>Space Complexity: O(n)</para>
        /// </summary>
        /// <returns></returns>
        public static int CalculateTallestStackHeightMemoization(Box[] boxes)
        {
            if (boxes == null)
            {
                return -1;
            }

            // Assuming fastest sorting runtime O(n*log(n))
            Array.Sort(boxes);

            int maxHeight = 0;
            var memo = new Dictionary<Box, int>();
            // Iterate through each box from widest to narrowest - runtime O(n)
            for (int i = 0; i < boxes.Length; i++)
            {
                Box baseBox = boxes[i];
                // The recursion method has a runtime of O(1) after cache is built
                maxHeight = Math.Max(maxHeight, CalculateStackHeight(boxes, baseBox, i, memo));
            }
            return maxHeight;
        }

        private static int CalculateStackHeight(Box[] boxes, Box baseBox, int baseBoxIndex)
        {
            int height = baseBox.Height;
            if (baseBoxIndex >= boxes.Length - 1)
            {
                return height;
            }

            for (int i = baseBoxIndex + 1; i < boxes.Length; i++)
            {
                if (!baseBox.CanStack(boxes[i]))
                {
                    continue;
                }
                height += CalculateStackHeight(boxes, boxes[i], i);
                break;
            }
            return height;
        }

        private static int CalculateStackHeight(Box[] boxes, Box baseBox, int baseBoxIndex, Dictionary<Box, int> memo)
        {
            if (memo.ContainsKey(baseBox))
            {
                // Return from cache if key exists
                return memo[baseBox];
            }

            int height = baseBox.Height;
            if (baseBoxIndex >= boxes.Length - 1)
            {
                memo.Add(baseBox, height);
                return height;
            }

            for (int i = baseBoxIndex + 1; i < boxes.Length; i++)
            {
                if (!baseBox.CanStack(boxes[i]))
                {
                    continue;
                }
                height += CalculateStackHeight(boxes, boxes[i], i);
                break;
            }

            // Cache result before returning
            memo.Add(baseBox, height);
            return height;
        }

        private static bool CanStack(this Box self, Box other)
        {
            return self.Width > other.Width && self.Height > other.Height && self.Depth > other.Depth;
        }
    }
}
