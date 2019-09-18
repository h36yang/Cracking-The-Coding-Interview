using _003_StacksAndQueues;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _003_StacksAndQueuesTest
{
    [TestClass]
    public class Question_3_3_Test
    {
        [TestMethod]
        public void PopTest()
        {
            var test = new Question_3_3.SetOfStacks<int>(2);

            test.Push(10); // 10
            test.Push(11); // 10 <- 11
            test.Push(9); // 10 <- 11 <--- 9
            test.Push(9); // 10 <- 11 <--- 9 <- 9
            test.Push(2); // 10 <- 11 <--- 9 <- 9 <--- 2
            test.Push(5); // 10 <- 11 <--- 9 <- 9 <--- 2 <- 5

            Assert.AreEqual(5, test.Pop()); // 10 <- 11 <--- 9 <- 9 <--- 2
            Assert.AreEqual(2, test.Pop()); // 10 <- 11 <--- 9 <- 9
            Assert.AreEqual(9, test.Pop()); // 10 <- 11 <--- 9
            Assert.AreEqual(9, test.Pop()); // 10 <- 11
            Assert.AreEqual(11, test.Pop()); // 10
            Assert.AreEqual(10, test.Pop()); // <Empty>

            try
            {
                test.Pop();
                Assert.Fail("Empty stack check failed.");
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("Stack is empty.", e.Message, "Incorrect exception caught.");
            }
        }
    }
}
