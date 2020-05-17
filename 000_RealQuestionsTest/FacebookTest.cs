using _000_RealQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        public void FindQuarterMajority(int[] testArray, int expected)
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
    }
}
