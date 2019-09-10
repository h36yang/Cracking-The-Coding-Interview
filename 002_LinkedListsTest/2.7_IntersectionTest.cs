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
            var intersectingNode = new Node(5)
            {
                Next = new Node(6)
                {
                    Next = new Node(7)
                }
            };
            var testList1 = new LinkedList(new Node(1)
            {
                Next = new Node(2)
                {
                    Next = new Node(3)
                    {
                        Next = new Node(4)
                        {
                            Next = intersectingNode
                        }
                    }
                }
            });
            var testList2 = new LinkedList(new Node(9)
            {
                Next = new Node(8)
                {
                    Next = new Node(10)
                    {
                        Next = intersectingNode
                    }
                }
            });
            Node resultNode = Question_2_7.FindIntersection(testList1, testList2);
            Assert.IsNotNull(resultNode, "Lists are not intersecting.");
            Assert.AreEqual(intersectingNode, resultNode, $"Incorrect intersecting node.");
        }

        [TestMethod]
        public void ReturnIntersectionTest_NotIntersecting()
        {
            var testList1 = new LinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7 });
            var testList2 = new LinkedList(new int[] { 9, 8, 10, 5, 6, 7 });
            Node resultNode = Question_2_7.FindIntersection(testList1, testList2);
            Assert.IsNull(resultNode, $"Lists are intersecting.");
        }
    }
}
