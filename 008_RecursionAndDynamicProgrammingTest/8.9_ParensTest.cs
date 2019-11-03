using _008_RecursionAndDynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_9_Test
    {
        [DataTestMethod]
        [DataRow(new string[0], 0)]
        [DataRow(new string[] { "()" }, 1)]
        [DataRow(new string[] { "(())", "()()" }, 2)]
        [DataRow(new string[] { "((()))", "(()())", "(())()", "()(())", "()()()" }, 3)]
        [DataRow(new string[] { "(((())))", "((()()))", "(())(())", "(())()()", "()(())()", "()()(())", "((()))()", "()((()))", "(()())()", "()(()())", "((())())", "(()(()))", "(()()())", "()()()()" }, 4)]
        public void GenerateAllParenthesisCombosTest(string[] expectedCombos, int nPairs)
        {
            // Act
            List<string> resultCombos = Question_8_9.GenerateAllParenthesisCombos(nPairs);

            // Assert
            Assert.AreEqual(expectedCombos.Length, resultCombos.Count, "Number of parenthesis combos do not match.");
            Assert.IsTrue(expectedCombos.OrderBy(x => x).SequenceEqual(resultCombos.OrderBy(x => x)), "Parenthesis combos don't match.");
        }
    }
}
