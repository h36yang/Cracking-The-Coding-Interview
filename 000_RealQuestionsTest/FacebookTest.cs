using _000_RealQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _000_RealQuestionsTest
{
    [TestClass]
    public class FacebookTest
    {
        [DataTestMethod]
        [DataRow(null, "cat", false)]
        [DataRow("c", "cat", false)]
        [DataRow("cat", "dog", false)]
        [DataRow("cat", "cats", true)]
        [DataRow("cat", "cut", true)]
        [DataRow("cat", "cast", true)]
        [DataRow("cat", "at", true)]
        [DataRow("cat", "act", false)]
        public void OneEditApartTest(string str1, string str2, bool expected)
        {
            // Act
            bool result = Facebook.OneEditApart(str1, str2);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(new int[] { 1, 1, 2, 2, 3, 3, 3, 4, 5, 6, 7 }, 3)]
        [DataRow(new int[] { 1, 1, 2, 2, 3, 3, 4, 5, 7, 7, 7 }, 7)]
        [DataRow(new int[] { 1, 1, 2, 3 }, 1)]
        [DataRow(new int[] { 1, 2, 2, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6 }, 2)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 5, 6, 7, 8, 10 }, int.MinValue)]
        public void FindQuarterMajorityTest(int[] testArray, int expected)
        {
            try
            {
                // Act
                int result = Facebook.FindQuarterMajority(testArray);

                // Assert
                if (expected > int.MinValue)
                {
                    Assert.AreEqual(expected, result);
                }
                else
                {
                    Assert.Fail();
                }
            }
            catch (ArgumentException e)
            {
                // Assert Exception
                if (expected == int.MinValue)
                {
                    Assert.AreEqual("Quarter Majority does not exist.", e.Message);
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void FindOverlappingIntervalsTest()
        {
            // Arrange
            var tasks = new int[][]
            {
                new int[] { 1, 10 },
                new int[] { 2, 6 },
                new int[] { 9, 12 },
                new int[] { 14, 16 },
                new int[] { 16, 17 }
            };

            var expected = new List<int[]>
            {
                new int[] { 2, 6 },
                new int[] { 9, 10 }
            };

            // Act
            List<int[]> result = Facebook.FindOverlappingIntervals(tasks);

            // Assert
            Assert.AreEqual(expected.Count, result.Count);
            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i][0], result[i][0]);
                Assert.AreEqual(expected[i][1], result[i][1]);
            }
        }
    }
}
