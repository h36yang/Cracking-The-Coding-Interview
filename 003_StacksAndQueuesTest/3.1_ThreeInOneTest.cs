using _003_StacksAndQueues;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _003_StacksAndQueuesTest
{
    [TestClass]
    public class Question_3_1_Test
    {
        [TestMethod]
        public void IsEmptyTest()
        {
            var test = new Question_3_1.ThreeInOneStacks<int>();
            Assert.IsTrue(test.IsEmpty(stackNumber: 1), "Stack 1 IsEmpty should return true.");
            Assert.IsTrue(test.IsEmpty(stackNumber: 2), "Stack 2 IsEmpty should return true.");
            Assert.IsTrue(test.IsEmpty(stackNumber: 3), "Stack 3 IsEmpty should return true.");

            test.Push(item: 1, stackNumber: 1);
            Assert.IsFalse(test.IsEmpty(stackNumber: 1), "Stack 1 IsEmpty should return false.");
            Assert.IsTrue(test.IsEmpty(stackNumber: 2), "Stack 2 IsEmpty should return true.");
            Assert.IsTrue(test.IsEmpty(stackNumber: 3), "Stack 3 IsEmpty should return true.");

            test.Push(item: 2, stackNumber: 2);
            Assert.IsFalse(test.IsEmpty(stackNumber: 1), "Stack 1 IsEmpty should return false.");
            Assert.IsFalse(test.IsEmpty(stackNumber: 2), "Stack 2 IsEmpty should return false.");
            Assert.IsTrue(test.IsEmpty(stackNumber: 3), "Stack 3 IsEmpty should return true.");

            test.Push(item: 3, stackNumber: 3);
            Assert.IsFalse(test.IsEmpty(stackNumber: 1), "Stack 1 IsEmpty should return false.");
            Assert.IsFalse(test.IsEmpty(stackNumber: 2), "Stack 2 IsEmpty should return false.");
            Assert.IsFalse(test.IsEmpty(stackNumber: 3), "Stack 3 IsEmpty should return false.");
        }

        [TestMethod]
        public void PeekTest()
        {
            var test = new Question_3_1.ThreeInOneStacks<int>();

            test.Push(item: 1, stackNumber: 1);
            Assert.AreEqual(1, test.Peek(stackNumber: 1), "Top of Stack 1 should be 1.");
            Assert.IsNull(test.Peek(stackNumber: 2), "Top of Stack 2 should be NULL.");
            Assert.IsNull(test.Peek(stackNumber: 3), "Top of Stack 3 should be NULL.");

            test.Push(item: 2, stackNumber: 2);
            Assert.AreEqual(1, test.Peek(stackNumber: 1), "Top of Stack 1 should be 1.");
            Assert.AreEqual(2, test.Peek(stackNumber: 2), "Top of Stack 2 should be 2.");
            Assert.IsNull(test.Peek(stackNumber: 3), "Top of Stack 3 should be NULL.");

            test.Push(item: 3, stackNumber: 3);
            Assert.AreEqual(1, test.Peek(stackNumber: 1), "Top of Stack 1 should be 1.");
            Assert.AreEqual(2, test.Peek(stackNumber: 2), "Top of Stack 2 should be 2.");
            Assert.AreEqual(3, test.Peek(stackNumber: 3), "Top of Stack 3 should be 3.");

            test.Push(item: 11, stackNumber: 1);
            test.Push(item: 12, stackNumber: 2);
            test.Push(item: 13, stackNumber: 3);
            Assert.AreEqual(11, test.Peek(stackNumber: 1), "Top of Stack 1 should be 11.");
            Assert.AreEqual(12, test.Peek(stackNumber: 2), "Top of Stack 2 should be 12.");
            Assert.AreEqual(13, test.Peek(stackNumber: 3), "Top of Stack 3 should be 13.");
        }

        [TestMethod]
        public void PopTest()
        {
            var test = new Question_3_1.ThreeInOneStacks<int>();

            test.Push(item: 1, stackNumber: 1);
            test.Push(item: 2, stackNumber: 1);
            test.Push(item: 3, stackNumber: 1);
            test.Push(item: 4, stackNumber: 1);

            test.Push(item: 5, stackNumber: 2);
            test.Push(item: 6, stackNumber: 2);
            test.Push(item: 7, stackNumber: 2);

            test.Push(item: 8, stackNumber: 3);
            test.Push(item: 9, stackNumber: 3);
            test.Push(item: 10, stackNumber: 3);
            test.Push(item: 11, stackNumber: 3);
            test.Push(item: 12, stackNumber: 3);

            Assert.AreEqual(4, test.Pop(stackNumber: 1), "Top of Stack 1 should be 4.");
            Assert.AreEqual(3, test.Pop(stackNumber: 1), "Top of Stack 1 should be 3.");
            Assert.AreEqual(2, test.Pop(stackNumber: 1), "Top of Stack 1 should be 2.");
            Assert.AreEqual(1, test.Pop(stackNumber: 1), "Top of Stack 1 should be 1.");

            Assert.AreEqual(7, test.Pop(stackNumber: 2), "Top of Stack 2 should be 7.");
            Assert.AreEqual(6, test.Pop(stackNumber: 2), "Top of Stack 2 should be 6.");
            Assert.AreEqual(5, test.Pop(stackNumber: 2), "Top of Stack 2 should be 5.");

            Assert.AreEqual(12, test.Pop(stackNumber: 3), "Top of Stack 3 should be 12.");
            Assert.AreEqual(11, test.Pop(stackNumber: 3), "Top of Stack 3 should be 11.");
            Assert.AreEqual(10, test.Pop(stackNumber: 3), "Top of Stack 3 should be 10.");
            Assert.AreEqual(9, test.Pop(stackNumber: 3), "Top of Stack 3 should be 9.");
            Assert.AreEqual(8, test.Pop(stackNumber: 3), "Top of Stack 3 should be 9.");

            Assert.IsNull(test.Pop(stackNumber: 1), "Top of Stack 1 should be NULL.");
            Assert.IsNull(test.Pop(stackNumber: 2), "Top of Stack 2 should be NULL.");
            Assert.IsNull(test.Pop(stackNumber: 3), "Top of Stack 3 should be NULL.");
        }
    }
}
