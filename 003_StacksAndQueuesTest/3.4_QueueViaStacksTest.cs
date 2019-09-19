using _003_StacksAndQueues;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _003_StacksAndQueuesTest
{
    [TestClass]
    public class Question_3_4_Test
    {
        [TestMethod]
        public void IsEmptyTest()
        {
            var test = new Question_3_4.MyQueue<int>();
            Assert.IsTrue(test.IsEmpty(), "IsEmpty returns false.");
            test.Add(1);
            Assert.IsFalse(test.IsEmpty(), "IsEmpty returns true.");
        }

        [TestMethod]
        public void PeekTest()
        {
            var test = new Question_3_4.MyQueue<int>();

            try
            {
                test.Peek();
                Assert.Fail("Empty queue check failed.");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Queue is empty.", e.Message, "Incorrect exception caught.");
            }

            test.Add(1);
            Assert.AreEqual(1, test.Peek(), "Incorrect head returned.");
            test.Add(2);
            Assert.AreEqual(1, test.Peek(), "Incorrect head returned.");
        }

        [TestMethod]
        public void RemoveTest()
        {
            var test = new Question_3_4.MyQueue<int>();

            try
            {
                test.Remove();
                Assert.Fail("Empty queue check failed.");
            }
            catch (InvalidOperationException e)
            {
                Assert.AreEqual("Queue is empty.", e.Message, "Incorrect exception caught.");
            }

            test.Add(1); // 1
            test.Add(3); // 1 -> 3
            test.Add(2); // 1 -> 3 -> 2
            test.Add(4); // 1 -> 3 -> 2-> 4
            test.Add(6); // 1 -> 3 -> 2-> 4 -> 6
            test.Add(5); // 1 -> 3 -> 2-> 4 -> 6 -> 5

            Assert.AreEqual(1, test.Remove(), "Incorrect head removed."); // 3 -> 2-> 4 -> 6 -> 5
            Assert.AreEqual(3, test.Remove(), "Incorrect head removed."); // 2 -> 4 -> 6 -> 5
            Assert.AreEqual(2, test.Remove(), "Incorrect head removed."); // 4 -> 6 -> 5

            test.Add(10); // 4 -> 6 -> 5 -> 10
            test.Add(20); // 4 -> 6 -> 5 -> 10 -> 20

            Assert.AreEqual(4, test.Remove(), "Incorrect head removed."); // 6 -> 5 -> 10 -> 20
            Assert.AreEqual(6, test.Remove(), "Incorrect head removed."); // 5 -> 10 -> 20
            Assert.AreEqual(5, test.Remove(), "Incorrect head removed."); // 10 -> 20
            Assert.AreEqual(10, test.Remove(), "Incorrect head removed."); // 20
            Assert.AreEqual(20, test.Remove(), "Incorrect head removed."); // <Empty>
        }
    }
}
