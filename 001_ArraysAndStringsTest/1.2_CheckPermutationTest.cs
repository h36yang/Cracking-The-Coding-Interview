using _001_ArraysAndStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _001_ArraysAndStringsTest
{
    [TestClass]
    public class Question_1_2_Test
    {
        [DataTestMethod]
        [DataRow("a", "a")]
        [DataRow("ab", "ab")]
        [DataRow("ab", "ba")]
        [DataRow("abc", "acb")]
        [DataRow("abc", "cba")]
        [DataRow("abcdefg", "gfedcba")]
        public void CheckPermutationTest_ReturnTrue(string str1, string str2)
        {
            bool result = Question_1_2.CheckPermutationInplaceSort(str1, str2);
            Assert.IsTrue(result, $"{str1} and {str2} are not permutations of each other - in-place sort.");

            result = Question_1_2.CheckPermutationHashTable(str1, str2);
            Assert.IsTrue(result, $"{str1} and {str2} are not permutations of each other - hash table.");
        }

        [DataTestMethod]
        [DataRow("a", "ab")]
        [DataRow("ab", "ac")]
        [DataRow("abc", "abd")]
        [DataRow("abcdefg", "afedcba")]
        public void CheckPermutationTest_ReturnFalse(string str1, string str2)
        {
            bool result = Question_1_2.CheckPermutationInplaceSort(str1, str2);
            Assert.IsFalse(result, $"{str1} and {str2} are permutations of each other - in-place sort.");

            result = Question_1_2.CheckPermutationHashTable(str1, str2);
            Assert.IsFalse(result, $"{str1} and {str2} are permutations of each other - hash table.");
        }
    }
}
