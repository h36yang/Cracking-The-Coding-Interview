using _002_LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _002_LinkedListsTest
{
    [TestClass]
    public class Question_2_3_Test
    {
        [TestMethod]
        public void DeleteMiddleNodeTest()
        {
            var testList = new LinkedList(
                new Node(1)
                {
                    Next = new Node(5)
                    {
                        Next = new Node(9)
                        {
                            Next = new Node(12)
                        }
                    }
                }
            );
            var expectedList = new LinkedList(
                new Node(1)
                {
                    Next = new Node(5)
                    {
                        Next = new Node(12)
                    }
                }
            );
            bool success = Question_2_3.DeleteMiddleNode(testList.Head.Next.Next);
            Assert.IsTrue(success, "Action was not successful.");
            Assert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void DeleteMiddleNodeTest_FailureCases()
        {
            var testList = new LinkedList(
                new Node(1)
                {
                    Next = new Node(5)
                }
            );
            bool success1 = Question_2_3.DeleteMiddleNode(testList.Head.Next);
            bool success2 = Question_2_3.DeleteMiddleNode(testList.Head.Next.Next);
            Assert.IsFalse(success1, "Action 1 did not fail as expected.");
            Assert.IsFalse(success2, "Action 2 did not fail as expected.");
        }
    }
}
