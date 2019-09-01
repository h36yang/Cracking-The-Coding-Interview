using _001_ArraysAndStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _001_ArraysAndStringsTest
{
    [TestClass]
    public class Question_1_4_Test
    {
        [DataTestMethod]
        [DataRow("Tact Coa")]
        [DataRow("a")]
        [DataRow("Aa")]
        [DataRow("aba")]
        [DataRow("Aba")]
        [DataRow("Ab a")]
        [DataRow("aaa aBb bbCcc")]
        [DataRow("tactcoapapa")]
        public void IsPalindromePermutationTest_ReturnTrue(string str)
        {
            bool result = Question_1_4.IsPalindromePermutation(str);
            Assert.IsTrue(result, $"{str} is not palindrome permutation.");

            result = Question_1_4.IsPalindromePermutationAlt1(str);
            Assert.IsTrue(result, $"{str} is not palindrome permutation - alternative 1.");

            result = Question_1_4.IsPalindromePermutationAlt2(str);
            Assert.IsTrue(result, $"{str} is not palindrome permutation - alternative 2.");
        }

        [DataTestMethod]
        [DataRow("Tact Cob")]
        [DataRow("ab")]
        [DataRow("abc")]
        [DataRow("abcb")]
        public void IsPalindromePermutationTest_ReturnFalse(string str)
        {
            bool result = Question_1_4.IsPalindromePermutation(str);
            Assert.IsFalse(result, $"{str} is palindrome permutation.");

            result = Question_1_4.IsPalindromePermutationAlt1(str);
            Assert.IsFalse(result, $"{str} is palindrome permutation - alternative 1.");

            result = Question_1_4.IsPalindromePermutationAlt2(str);
            Assert.IsFalse(result, $"{str} is palindrome permutation - alternative 2.");
        }
    }
}
