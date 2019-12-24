namespace _016_Moderate
{
    /// <summary>
    /// 16.3) Intersection:
    /// Given two straight line segments (represented as a start point and an end point), compute the point of intersection, if any.
    /// </summary>
    public static class Question_16_03
    {
        public class Point
        {
            public double X { get; set; }

            public double Y { get; set; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }
        }

        private class Line
        {
            public double Slope { get; private set; }

            public double YIntercept { get; private set; }

            public Line(Point start, Point end)
            {
                Slope = (start.Y - end.Y) / (start.X - end.X);
                YIntercept = start.Y - Slope * start.X;
            }
        }

        /// <summary>
        /// Math problem
        /// <para>Time Complexity: O(1)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="start1"></param>
        /// <param name="end1"></param>
        /// <param name="start2"></param>
        /// <param name="end2"></param>
        /// <returns></returns>
        public static Point FindIntersection(Point start1, Point end1, Point start2, Point end2)
        {
            // Swap points, so starts are smaller than ends, and 1 is smaller than 2
            if (start1.X > end1.X)
            {
                SwapPoints(start1, end1);
            }

            if (start2.X > end2.X)
            {
                SwapPoints(start2, end2);
            }

            if (start1.X > start2.X)
            {
                SwapPoints(start1, start2);
                SwapPoints(end1, end2);
            }

            // Convert points to lines
            var line1 = new Line(start1, end1);
            var line2 = new Line(start2, end2);

            // Check if there will be intersection or not
            if (line1.Slope == line2.Slope)
            {
                if (line1.YIntercept == line2.YIntercept)
                {
                    if (start1.X <= start2.X && start2.X <= end1.X)
                    {
                        // If 2 line segments are the same line and start2 is on line1, make start2 the intersection point
                        return start2;
                    }
                }
                else
                {
                    // 2 parallel lines, no intersection
                    return null;
                }
            }

            // Calculate intersection point
            Point intersection = CalculateIntersection(line1, line2);

            // Check if the intersection is on the line segments
            if (IsIntersectionValid(intersection, start1, end1) && IsIntersectionValid(intersection, start2, end2))
            {
                return intersection;
            }
            return null;
        }

        private static void SwapPoints(Point p1, Point p2)
        {
            double tempX = p1.X;
            double tempY = p1.Y;
            p1.X = p2.X;
            p1.Y = p2.Y;
            p2.X = tempX;
            p2.Y = tempY;
        }

        private static Point CalculateIntersection(Line line1, Line line2)
        {
            double x = (line2.YIntercept - line1.YIntercept) / (line1.Slope - line2.Slope);
            double y = line1.Slope * x + line1.YIntercept;
            return new Point(x, y);
        }

        private static bool IsIntersectionValid(Point intersection, Point start, Point end)
        {
            return start.X <= intersection.X && intersection.X <= end.X;
        }
    }
}
