using _002_LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _002_LinkedListsTest
{
    [TestClass]
    public class Question_2_6_Test
    {
        [TestMethod]
        public void IsPalindromeTest_ReturnTrue()
        {
            var testList = new LinkedList(new int[] { 0, 1, 2, 3, 2, 1, 0 });
            bool result = Question_2_6.IsPalindrome(testList);
            Assert.IsTrue(result, $"List {testList} is not palindrome.");

            testList = new LinkedList(new int[] { 0, 1, 2, 3, 3, 2, 1, 0 });
            result = Question_2_6.IsPalindrome(testList);
            Assert.IsTrue(result, $"List {testList} is not palindrome.");
        }

        [TestMethod]
        public void IsPalindromeTest_ReturnFalse()
        {
            var testList = new LinkedList(new int[] { 1, 2, 3, 2, 5 });
            bool result = Question_2_6.IsPalindrome(testList);
            Assert.IsFalse(result, $"List {testList} is palindrome.");

            testList = new LinkedList(new int[] { 1, 2, 3, 3, 2, 6 });
            result = Question_2_6.IsPalindrome(testList);
            Assert.IsFalse(result, $"List {testList} is palindrome.");
        }

        [TestMethod]
        public void IsPalindromeRecursiveTest_ReturnTrue()
        {
            var testList = new LinkedList(new int[] { 0, 1, 2, 3, 2, 1, 0 });
            bool result = Question_2_6.IsPalindromeRecursive(testList);
            Assert.IsTrue(result, $"List {testList} is not palindrome.");

            testList = new LinkedList(new int[] { 0, 1, 2, 3, 3, 2, 1, 0 });
            result = Question_2_6.IsPalindromeRecursive(testList);
            Assert.IsTrue(result, $"List {testList} is not palindrome.");
        }

        [TestMethod]
        public void IsPalindromeRecursiveTest_ReturnFalse()
        {
            var testList = new LinkedList(new int[] { 1, 2, 3, 2, 5 });
            bool result = Question_2_6.IsPalindromeRecursive(testList);
            Assert.IsFalse(result, $"List {testList} is palindrome.");

            testList = new LinkedList(new int[] { 1, 2, 3, 3, 2, 6 });
            result = Question_2_6.IsPalindromeRecursive(testList);
            Assert.IsFalse(result, $"List {testList} is palindrome.");
        }
    }
}
