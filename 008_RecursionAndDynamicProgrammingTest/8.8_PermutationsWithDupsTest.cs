using _008_RecursionAndDynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_8_Test
    {
        [DataTestMethod]
        [DataRow(new string[0], "")]
        [DataRow(new string[] { "a" }, "a")]
        [DataRow(new string[] { "aa" }, "aa")]
        [DataRow(new string[] { "ab", "ba" }, "ab")]
        [DataRow(new string[] { "aab", "aba", "baa" }, "aab")]
        [DataRow(new string[] { "abc", "bac", "bca", "acb", "cab", "cba" }, "abc")]
        [DataRow(new string[] { "aaab", "aaba", "abaa", "baaa" }, "aaab")]
        [DataRow(new string[] { "aabb", "abab", "baab", "baba", "bbaa", "abba" }, "aabb")]
        [DataRow(new string[]
        {
            "abcd", "abdc", "adbc", "dabc",
            "bacd", "badc", "bdac", "dbac",
            "bcad", "bcda", "bdca", "dbca",
            "acbd", "acdb", "adcb", "dacb",
            "cabd", "cadb", "cdab", "dcab",
            "cbad", "cbda", "cdba", "dcba",
        }, "abcd")]
        public void FindAllPermutationsWithDupsTest(string[] expectedPermutations, string testStr)
        {
            // Act
            List<string> resultPermutations = Question_8_8.FindAllPermutationsWithDups(testStr);

            // Assert
            Assert.AreEqual(expectedPermutations.Length, resultPermutations.Count, "Number of permutations do not match.");
            Assert.IsTrue(expectedPermutations.OrderBy(x => x).SequenceEqual(resultPermutations.OrderBy(x => x)), "Permutations don't match.");
        }
    }
}
