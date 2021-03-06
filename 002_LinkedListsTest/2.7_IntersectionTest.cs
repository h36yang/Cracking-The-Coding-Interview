using _002_LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _002_LinkedListsTest
{
    [TestClass]
    public class Question_2_7_Test
    {
        [TestMethod]
        public void ReturnIntersectionTest_Intersecting()
        {
            var intersectingNode = new LinkedListNode(5)
            {
                Next = new LinkedListNode(6)
                {
                    Next = new LinkedListNode(7)
                }
            };
            var testList1 = new LinkedList(new LinkedListNode(1)
            {
                Next = new LinkedListNode(2)
                {
                    Next = new LinkedListNode(3)
                    {
                        Next = new LinkedListNode(4)
                        {
                            Next = intersectingNode
                        }
                    }
                }
            });
            var testList2 = new LinkedList(new LinkedListNode(9)
            {
                Next = new LinkedListNode(8)
                {
                    Next = new LinkedListNode(10)
                    {
                        Next = intersectingNode
                    }
                }
            });
            LinkedListNode resultNode = Question_2_7.FindIntersection(testList1, testList2);
            Assert.IsNotNull(resultNode, "Lists are not intersecting.");
            Assert.AreEqual(intersectingNode, resultNode, $"Incorrect intersecting node {intersectingNode.Data} (expected) vs {resultNode.Data} (actual).");
        }

        [TestMethod]
        public void ReturnIntersectionTest_NotIntersecting()
        {
            var testList1 = new LinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            var testList2 = new LinkedList(new int[] { 9, 8, 10, 5, 6, 7 });
            LinkedListNode resultNode = Question_2_7.FindIntersection(testList1, testList2);
            int resultData = (resultNode != null) ? resultNode.Data : -1;
            Assert.IsNull(resultNode, $"Lists are intersecting at node {resultData}.");
        }
    }
}
