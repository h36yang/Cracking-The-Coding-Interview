using _003_StacksAndQueues;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _003_StacksAndQueuesTest
{
    [TestClass]
    public class Question_3_2_Test
    {
        [TestMethod]
        public void MinTest()
        {
            var test = new Question_3_2.MinStack();

            test.Push(10); // 10
            Assert.AreEqual(10, test.Min(), "Min value is not 10.");

            test.Push(11); // 10 <- 11
            Assert.AreEqual(10, test.Min(), "Min value is not 10.");

            test.Push(9); // 10 <- 11 <- 9
            Assert.AreEqual(9, test.Min(), "Min value is not 9.");

            test.Push(9); // 10 <- 11 <- 9 <- 9
            Assert.AreEqual(9, test.Min(), "Min value is not 9.");

            test.Push(2); // 10 <- 11 <- 9 <- 9 <- 2
            Assert.AreEqual(2, test.Min(), "Min value is not 2.");

            test.Push(5); // 10 <- 11 <- 9 <- 9 <- 2 <- 5
            Assert.AreEqual(2, test.Min(), "Min value is not 2.");

            test.Pop(); // 10 <- 11 <- 9 <- 9 <- 2
            Assert.AreEqual(2, test.Min(), "Min value is not 2.");

            test.Pop(); // 10 <- 11 <- 9 <- 9
            Assert.AreEqual(9, test.Min(), "Min value is not 9.");

            test.Pop(); // 10 <- 11 <- 9
            Assert.AreEqual(9, test.Min(), "Min value is not 9.");

            test.Pop(); // 10 <- 11
            Assert.AreEqual(10, test.Min(), "Min value is not 10.");

            test.Pop(); // 10
            Assert.AreEqual(10, test.Min(), "Min value is not 10.");
        }

        [TestMethod]
        public void MinTest_NegativeCases()
        {
            var test = new Question_3_2.MinStack();
            try
            {
                test.Pop();
                Assert.Fail("Empty stack check failed.");
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("Stack is empty.", e.Message, "Incorrect exception caught.");
            }

            try
            {
                test.Min();
                Assert.Fail("Empty stack check failed.");
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("Stack is empty.", e.Message, "Incorrect exception caught.");
            }
        }
    }
}
