using _001_ArraysAndStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _001_ArraysAndStringsTest
{
    [TestClass]
    public class Question_1_9_Test
    {
        [DataTestMethod]
        [DataRow("a", "a")]
        [DataRow("ab", "ba")]
        [DataRow("abc", "abc")]
        [DataRow("abc", "bca")]
        [DataRow("aaabbbccc", "aabbbccca")]
        [DataRow("waterbottle", "erbottlewat")]
        public void CheckStringRotationTest_ReturnTrue(string str1, string str2)
        {
            bool result = Question_1_9.CheckStringRotation(str1, str2);
            Assert.IsTrue(result, $"{str1} is not rotation of {str2}.");
        }

        [DataTestMethod]
        [DataRow("a", "")]
        [DataRow("a", "b")]
        [DataRow("ab", "abc")]
        [DataRow("abcd", "acbd")]
        [DataRow("waterbottle", "erbottleway")]
        public void CheckStringRotationTest_ReturnFalse(string str1, string str2)
        {
            bool result = Question_1_9.CheckStringRotation(str1, str2);
            Assert.IsFalse(result, $"{str1} is rotation of {str2}.");
        }
    }
}
