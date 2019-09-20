using _003_StacksAndQueues;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace _003_StacksAndQueuesTest
{
    [TestClass]
    public class Question_3_5_Test
    {
        [DataTestMethod]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 2, 1, 9, 8, 4, 3, 7, 2, 45 })]
        public void SortStackTest(int[] testNumbers)
        {
            var testStack = TestHelper.ConvertArrayToStack(testNumbers);
            var expectedNumbers = testNumbers.OrderByDescending(x => x).ToArray();
            var expectedStack = TestHelper.ConvertArrayToStack(expectedNumbers);
            var resultStack = Question_3_5.SortStack(testStack);
            Assert.AreEqual(expectedStack.Count, resultStack.Count, "Stack counts do not match.");
            while (resultStack.Count > 0)
            {
                Assert.AreEqual(expectedStack.Pop(), resultStack.Pop(), $"Stacks are not equal at position {resultStack.Count}.");
            }
        }
    }
}
