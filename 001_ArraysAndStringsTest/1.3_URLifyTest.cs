using _001_ArraysAndStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _001_ArraysAndStringsTest
{
    [TestClass]
    public class Question_1_3_Test
    {
        [DataTestMethod]
        [DataRow("Mr John Smith    ", 13, "Mr%20John%20Smith")]
        [DataRow("Who is your daddy!      ", 18, "Who%20is%20your%20daddy!")]
        public void URLifyTest(string testStr, int trueLength, string expectedStr)
        {
            string result = Question_1_3.URLify(testStr, trueLength);
            Assert.AreEqual(expectedStr, result);
        }
    }
}
