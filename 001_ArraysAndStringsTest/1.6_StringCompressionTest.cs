using _001_ArraysAndStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _001_ArraysAndStringsTest
{
    [TestClass]
    public class Question_1_6_Test
    {
        [DataTestMethod]
        [DataRow("abcd", "abcd")]
        [DataRow("abcddddd", "abcddddd")]
        [DataRow("aabcccccaaa", "a2b1c5a3")]
        [DataRow("jaaccckkkk", "j1a2c3k4")]
        [DataRow("jjjjaaacck", "j4a3c2k1")]
        public void CompressStringTest(string testString, string expectedString)
        {
            string result = Question_1_6.CompressString(testString);
            Assert.AreEqual(expectedString, result);

            result = Question_1_6.CompressStringAlt(testString);
            Assert.AreEqual(expectedString, result, $"{expectedString} and {result} are not equal - alternative.");
        }
    }
}
