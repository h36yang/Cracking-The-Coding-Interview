using _002_LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _002_LinkedListsTest
{
    [TestClass]
    public class Question_2_2_Test
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 10)]
        [DataRow(3, 1)]
        [DataRow(4, 2)]
        [DataRow(5, 3)]
        [DataRow(14, 2)]
        [DataRow(15, 1)]
        public void ReturnKthToLastTest(int k, int expected)
        {
            var testList = new LinkedList(new int[] { 1, 2, 3, 2, 1, 4, 5, 6, 5, 4, 3, 2, 1, 10, 1 });
            int result = Question_2_2.ReturnKthToLast(testList, k);
            Assert.AreEqual(expected, result, $"{k}th element {expected} is expected but got {result}.");

            result = Question_2_2.ReturnKthToLastRecursive(testList, k);
            Assert.AreEqual(expected, result, $"{k}th element {expected} is expected but got {result} - recursive.");

            result = Question_2_2.ReturnKthToLastOnePass(testList, k);
            Assert.AreEqual(expected, result, $"{k}th element {expected} is expected but got {result} - one pass.");
        }

        [TestMethod]
        public void ReturnKthToLastTest_InvalidCases()
        {
            try
            {
                Question_2_2.ReturnKthToLast(null, 2);
                Assert.Fail("ArgumentNullException was not thrown for null list.");
            }
            catch (ArgumentNullException) { }

            try
            {
                Question_2_2.ReturnKthToLast(new LinkedList(), 2);
                Assert.Fail("ArgumentNullException was not thrown for empty list.");
            }
            catch (ArgumentNullException) { }

            try
            {
                int k = 2;
                Question_2_2.ReturnKthToLast(new LinkedList(new int[] { 1 }), k);
                Assert.Fail($"ArgumentOutOfRangeException was not thrown for invalid k={k}.");
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                int k = -1;
                Question_2_2.ReturnKthToLast(new LinkedList(new int[] { 1 }), k);
                Assert.Fail($"ArgumentOutOfRangeException was not thrown for invalid k={k}.");
            }
            catch (ArgumentOutOfRangeException) { }
        }

        [TestMethod]
        public void ReturnKthToLastRecursiveTest_InvalidCases()
        {
            try
            {
                int k = 2;
                Question_2_2.ReturnKthToLastRecursive(new LinkedList(new int[] { 1 }), k);
                Assert.Fail($"ArgumentOutOfRangeException was not thrown for invalid k={k}.");
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                int k = -1;
                Question_2_2.ReturnKthToLastRecursive(new LinkedList(new int[] { 1 }), k);
                Assert.Fail($"ArgumentOutOfRangeException was not thrown for invalid k={k}.");
            }
            catch (ArgumentOutOfRangeException) { }
        }

        [TestMethod]
        public void ReturnKthToLastOnePassTest_InvalidCases()
        {
            try
            {
                int k = 2;
                Question_2_2.ReturnKthToLastOnePass(new LinkedList(new int[] { 1 }), k);
                Assert.Fail($"ArgumentOutOfRangeException was not thrown for invalid k={k}.");
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                int k = -1;
                Question_2_2.ReturnKthToLastOnePass(new LinkedList(new int[] { 1 }), k);
                Assert.Fail($"ArgumentOutOfRangeException was not thrown for invalid k={k}.");
            }
            catch (ArgumentOutOfRangeException) { }
        }
    }
}
