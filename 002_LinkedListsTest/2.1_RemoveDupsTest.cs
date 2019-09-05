using _002_LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _002_LinkedListsTest
{
    [TestClass]
    public class Question_2_1_Test
    {
        [TestMethod]
        public void RemoveDuplicatesTest()
        {
            var testList = new LinkedList(new int[] { 1, 2, 3, 2, 1, 4, 5, 6, 5, 4, 3, 2, 1, 10, 1 });
            var expectedList = new LinkedList(new int[] { 1, 2, 3, 4, 5, 6, 10 });
            Question_2_1.RemoveDuplicates(testList);
            Assert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void RemoveDuplicatesInplaceTest()
        {
            var testList = new LinkedList(new int[] { 1, 2, 3, 2, 1, 4, 5, 6, 5, 4, 3, 2, 1, 10, 1 });
            var expectedList = new LinkedList(new int[] { 1, 2, 3, 4, 5, 6, 10 });
            Question_2_1.RemoveDuplicatesInplace(testList);
            Assert.AreEqual(expectedList, testList);
        }
    }
}
