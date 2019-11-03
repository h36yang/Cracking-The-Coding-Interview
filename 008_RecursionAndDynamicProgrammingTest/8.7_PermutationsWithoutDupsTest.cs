using _008_RecursionAndDynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_7_Test
    {
        [DataTestMethod]
        [DataRow(new string[0], "")]
        [DataRow(new string[] { "a" }, "a")]
        [DataRow(new string[] { "ab", "ba" }, "ab")]
        [DataRow(new string[] { "abc", "bac", "bca", "acb", "cab", "cba" }, "abc")]
        [DataRow(new string[]
        {
            "abcd", "abdc", "adbc", "dabc",
            "bacd", "badc", "bdac", "dbac",
            "bcad", "bcda", "bdca", "dbca",
            "acbd", "acdb", "adcb", "dacb",
            "cabd", "cadb", "cdab", "dcab",
            "cbad", "cbda", "cdba", "dcba",
        }, "abcd")]
        public void FindAllPermutationsWithoutDupsTest(string[] expectedPermutations, string testStr)
        {
            // Act
            var time1 = DateTime.Now;
            List<string> resultPermutations1 = Question_8_7.FindAllPermutationsWithoutDups1(testStr);
            var time2 = DateTime.Now;
            List<string> resultPermutations2 = Question_8_7.FindAllPermutationsWithoutDups2(testStr);
            var time3 = DateTime.Now;

            Console.WriteLine($"Approach 1 took {time2.Subtract(time1).TotalMilliseconds} ms.");
            Console.WriteLine($"Approach 2 took {time3.Subtract(time2).TotalMilliseconds} ms.");

            // Assert
            Assert.AreEqual(expectedPermutations.Length, resultPermutations1.Count, "Number of permutations do not match - Approach 1.");
            Assert.AreEqual(expectedPermutations.Length, resultPermutations2.Count, "Number of permutations do not match - Approach 2.");
            Assert.IsTrue(expectedPermutations.OrderBy(x => x).SequenceEqual(resultPermutations1.OrderBy(x => x)), "Permutations don't match - Approach 1.");
            Assert.IsTrue(expectedPermutations.OrderBy(x => x).SequenceEqual(resultPermutations2.OrderBy(x => x)), "Permutations don't match - Approach 2.");
        }
    }
}
