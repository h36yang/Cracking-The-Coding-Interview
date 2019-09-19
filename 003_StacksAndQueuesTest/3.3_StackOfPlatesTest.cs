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
            var test = new Question_3_3.SetOfStacks(2);

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
            catch (ApplicationException e)
            {
                Assert.AreEqual("Stack is empty.", e.Message, "Incorrect exception caught.");
            }
        }

        [TestMethod]
        public void PopAtTest()
        {
            var test = new Question_3_3.SetOfStacks(3);

            test.Push(10); // 10
            test.Push(11); // 10 <- 11
            test.Push(9); // 10 <- 11 <- 9
            test.Push(9); // 10 <- 11 <- 9 <--- 9
            test.Push(2); // 10 <- 11 <- 9 <--- 9 <- 2
            test.Push(5); // 10 <- 11 <- 9 <--- 9 <- 2 <- 5

            Assert.AreEqual(9, test.PopAt(0)); // 10 <- 11 <- 9 <--- 2 <- 5
            Assert.AreEqual(5, test.PopAt(1)); // 10 <- 11 <- 9 <--- 2

            test.Push(8); // 10 <- 11 <- 9 <--- 2 <- 8
            test.Push(20); // 10 <- 11 <- 9 <--- 2 <- 8 <- 20

            Assert.AreEqual(9, test.PopAt(0)); // 10 <- 11 <- 2 <--- 8 <- 20
            Assert.AreEqual(2, test.PopAt(0)); // 10 <- 11 <- 8 <--- 20
            Assert.AreEqual(8, test.PopAt(0)); // 10 <- 11 <- 20

            try
            {
                test.PopAt(1);
                Assert.Fail("Argument Out of Range check failed.");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.AreEqual("Index is out of range.", e.Message, "Incorrect exception caught.");
            }

            Assert.AreEqual(20, test.PopAt(0)); // 10 <- 11
            Assert.AreEqual(11, test.PopAt(0)); // 10
            Assert.AreEqual(10, test.PopAt(0)); // <Empty>

            try
            {
                test.PopAt(0);
                Assert.Fail("Empty stack check failed.");
            }
            catch (ApplicationException e)
            {
                Assert.AreEqual("Stack is empty.", e.Message, "Incorrect exception caught.");
            }
        }
    }
}
