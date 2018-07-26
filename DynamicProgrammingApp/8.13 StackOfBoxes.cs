using System.Collections.Generic;

namespace DynamicProgrammingApp
{
    public static class StackOfBoxes
    {
        public static int GetTallestStack(List<Box> boxes)
        {
            return GetStackHeight(null, boxes, 0, 0);
        }

        private static int GetStackHeight(Box boxBelow, List<Box> boxes, int totalHeight, int tallestHeight)
        {
            if (boxes.Count == 0)
            {
                if (totalHeight > tallestHeight)
                {
                    tallestHeight = totalHeight;
                }
                return tallestHeight;
            }

            var copyOfBoxes = boxes.ToArray();
            foreach (Box box in copyOfBoxes)
            {
                if (box.CanStackOn(boxBelow))
                {
                    boxes.Remove(box);
                    totalHeight += box.Height;
                    tallestHeight = GetStackHeight(box, boxes, totalHeight, tallestHeight);
                    if (totalHeight > tallestHeight)
                    {
                        tallestHeight = totalHeight;
                    }
                    totalHeight -= box.Height;
                    boxes.Add(box);
                }
            }
            return tallestHeight;
        }
    }

    public class Box
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }

        public Box(int w, int h, int d)
        {
            this.Width = w;
            this.Height = h;
            this.Depth = d;
        }

        public bool CanStackOn(Box other)
        {
            if (other == null)
            {
                // It means no box below
                return true;
            }
            return this.Width < other.Width && this.Height < other.Height && this.Depth < other.Depth;
        }
    }
}
