using _001_ArraysAndStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _001_ArraysAndStringsTest
{
    [TestClass]
    public class Question_1_1_Test
    {
        [DataTestMethod]
        [DataRow("a")]
        [DataRow("ab")]
        [DataRow("abc")]
        [DataRow("acbdefg")]
        public void IsUniqueTest_ReturnTrue(string inputStr)
        {
            bool result = Question_1_1.IsUnique(inputStr);
            Assert.IsTrue(result, $"{inputStr} contains duplicates.");

            result = Question_1_1.IsUniqueInplaceNestedLoop(inputStr);
            Assert.IsTrue(result, $"{inputStr} contains duplicates - In-place Nested Loop.");

            result = Question_1_1.IsUniqueInplaceSort(inputStr);
            Assert.IsTrue(result, $"{inputStr} contains duplicates - In-place Sort.");
        }

        [DataTestMethod]
        [DataRow("aa")]
        [DataRow("aab")]
        [DataRow("abb")]
        [DataRow("aba")]
        [DataRow("abcb")]
        [DataRow("abcbdgfuejhkjsahdakudhuegksajgck")]
        public void IsUniqueTest_ReturnFalse(string inputStr)
        {
            bool result = Question_1_1.IsUnique(inputStr);
            Assert.IsFalse(result, $"{inputStr} is unique.");

            result = Question_1_1.IsUniqueInplaceNestedLoop(inputStr);
            Assert.IsFalse(result, $"{inputStr} is unique - In-place Nested Loop.");

            result = Question_1_1.IsUniqueInplaceSort(inputStr);
            Assert.IsFalse(result, $"{inputStr} is unique - In-place Sort.");
        }
    }
}
