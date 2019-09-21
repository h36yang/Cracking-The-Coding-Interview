using _002_LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _002_LinkedListsTest
{
    [TestClass]
    public class Question_2_8_Test
    {
        [TestMethod]
        public void FindCircularStartNodeTest_PositiveCase()
        {
            var circularStartNode = new LinkedListNode(3)
            {
                Next = new LinkedListNode(4)
                {
                    Next = new LinkedListNode(5)
                }
            };
            circularStartNode.Next.Next.Next = circularStartNode;
            var testList = new LinkedList(new LinkedListNode(1)
            {
                Next = new LinkedListNode(2)
                {
                    Next = circularStartNode
                }
            });
            LinkedListNode resultNode = Question_2_8.FindCircularStartNode(testList);
            Assert.IsNotNull(resultNode, "List is not circular.");
            Assert.AreEqual(circularStartNode, resultNode, $"Incorrect circular start node {circularStartNode.Data} (expected) vs {resultNode.Data} (actual).");
        }

        [TestMethod]
        public void FindCircularStartNodeTest_NegativeCase()
        {
            var testList = new LinkedList(new int[] { 1, 2, 3, 4, 5, 3 });
            LinkedListNode resultNode = Question_2_8.FindCircularStartNode(testList);
            int resultData = (resultNode != null) ? resultNode.Data : -1;
            Assert.IsNull(resultNode, $"List is circular starting at node {resultData}.");

            testList = new LinkedList(new int[] { 1, 2, 3, 4, 5, 6, 3 });
            resultNode = Question_2_8.FindCircularStartNode(testList);
            resultData = (resultNode != null) ? resultNode.Data : -1;
            Assert.IsNull(resultNode, $"List is circular starting at node {resultData}.");
        }

        [TestMethod]
        public void FindCircularStartNodeInplaceTest_PositiveCase()
        {
            var circularStartNode = new LinkedListNode(3)
            {
                Next = new LinkedListNode(4)
                {
                    Next = new LinkedListNode(5)
                }
            };
            circularStartNode.Next.Next.Next = circularStartNode;
            var testList = new LinkedList(new LinkedListNode(1)
            {
                Next = new LinkedListNode(2)
                {
                    Next = circularStartNode
                }
            });
            LinkedListNode resultNode = Question_2_8.FindCircularStartNodeInplace(testList);
            Assert.IsNotNull(resultNode, "List is not circular.");
            Assert.AreEqual(circularStartNode, resultNode, $"Incorrect circular start node {circularStartNode.Data} (expected) vs {resultNode.Data} (actual).");
        }

        [TestMethod]
        public void FindCircularStartNodeInplaceTest_FullCycle()
        {
            var testList = new LinkedList(new LinkedListNode(1)
            {
                Next = new LinkedListNode(2)
                {
                    Next = new LinkedListNode(3)
                    {
                        Next = new LinkedListNode(4)
                        {
                            Next = new LinkedListNode(5)
                            {
                                Next = new LinkedListNode(6)
                            }
                        }
                    }
                }
            });
            testList.Head.Next.Next.Next.Next.Next.Next = testList.Head;
            LinkedListNode resultNode = Question_2_8.FindCircularStartNodeInplace(testList);
            Assert.IsNotNull(resultNode, "List is not circular.");
            Assert.AreEqual(testList.Head, resultNode, $"Incorrect circular start node {testList.Head.Data} (expected) vs {resultNode.Data} (actual).");
        }

        [TestMethod]
        public void FindCircularStartNodeInplaceTest_NegativeCase()
        {
            var testList = new LinkedList(new int[] { 1, 2, 3, 4, 5, 3 });
            LinkedListNode resultNode = Question_2_8.FindCircularStartNodeInplace(testList);
            int resultData = (resultNode != null) ? resultNode.Data : -1;
            Assert.IsNull(resultNode, $"List is circular starting at node {resultData}.");

            testList = new LinkedList(new int[] { 1, 2, 3, 4, 5, 6, 3 });
            resultNode = Question_2_8.FindCircularStartNodeInplace(testList);
            resultData = (resultNode != null) ? resultNode.Data : -1;
            Assert.IsNull(resultNode, $"List is circular starting at node {resultData}.");
        }
    }
}
