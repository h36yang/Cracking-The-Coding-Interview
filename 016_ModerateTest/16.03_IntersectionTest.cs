using Microsoft.VisualStudio.TestTools.UnitTesting;
using static _016_Moderate.Question_16_03;

namespace _016_ModerateTest
{
    [TestClass]
    public class Question_16_03_Test
    {
        [DataTestMethod]
        [DataRow(0.0, -3.0, 20.0, 57.0, 0.0, 4.0, 20.0, 50.0, 10.0, 27.0)]
        [DataRow(20.0, 57.0, 0.0, -3.0, 0.0, 4.0, 20.0, 50.0, 10.0, 27.0)]
        [DataRow(0.0, -3.0, 20.0, 57.0, 20.0, 50.0, 0.0, 4.0, 10.0, 27.0)]
        [DataRow(0.0, 4.0, 20.0, 50.0, 0.0, -3.0, 20.0, 57.0, 10.0, 27.0)]
        [DataRow(0.0, -3.0, 6.0, 15.0, 0.0, 4.0, 20.0, 50.0, null, null)]
        [DataRow(0.0, -4.0, 0.8, 0.0, -0.2, 0.0, 0.0, 1.0, null, null)]
        [DataRow(0.0, -3.0, 6.0, 15.0, 1.0, 0.0, 20.0, 57.0, 1.0, 0.0)]
        public void FindIntersectionTest(double start1X, double start1Y, double end1X, double end1Y, double start2X, double start2Y, double end2X, double end2Y, double? expectedX, double? expectedY)
        {
            // Arrange
            var start1 = new Point(start1X, start1Y);
            var start2 = new Point(start2X, start2Y);
            var end1 = new Point(end1X, end1Y);
            var end2 = new Point(end2X, end2Y);

            // Act
            Point resultIntersection = FindIntersection(start1, end1, start2, end2);

            // Assert
            if (expectedX.HasValue && expectedY.HasValue)
            {
                double threshold = 0.0001;
                Assert.AreEqual(expectedX.Value, resultIntersection.X, threshold, "Intersection X is incorrect.");
                Assert.AreEqual(expectedY.Value, resultIntersection.Y, threshold, "Intersection Y is incorrect.");
            }
            else
            {
                Assert.IsNull(resultIntersection, "There should be no intersection.");
            }
        }
    }
}
