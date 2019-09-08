using _002_LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _002_LinkedListsTest
{
    [TestClass]
    public class Question_2_4_Test
    {
        [TestMethod]
        public void PartitionTest()
        {
            int partition = 5;
            var testList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            var expectedList = new LinkedList(new int[] { 3, 1, 2, 5, 8, 5, 10 });
            bool success = Question_2_4.Partition(testList, partition);
            Assert.IsTrue(success, "Action was not successful.");
            Assert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void PartitionTest_AllBigger()
        {
            int partition = 1;
            var testList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            var expectedList = new LinkedList(new int[] { 5, 8, 5, 10, 2, 1, 3 });
            bool success = Question_2_4.Partition(testList, partition);
            Assert.IsTrue(success, "Action was not successful.");
            Assert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void PartitionTest_AllSmaller()
        {
            int partition = 11;
            var testList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            var expectedList = new LinkedList(new int[] { 3, 1, 2, 10, 5, 8, 5 });
            bool success = Question_2_4.Partition(testList, partition);
            Assert.IsTrue(success, "Action was not successful.");
            Assert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void Partition2Test()
        {
            int partition = 5;
            var testList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            var expectedList = new LinkedList(new int[] { 3, 2, 1, 5, 8, 5, 10 });
            bool success = Question_2_4.Partition2(testList, partition);
            Assert.IsTrue(success, "Action was not successful.");
            Assert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void Partition2Test_AllBigger()
        {
            int partition = 1;
            var testList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            var expectedList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            bool success = Question_2_4.Partition2(testList, partition);
            Assert.IsTrue(success, "Action was not successful.");
            Assert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void Partition2Test_AllSmaller()
        {
            int partition = 11;
            var testList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            var expectedList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            bool success = Question_2_4.Partition2(testList, partition);
            Assert.IsTrue(success, "Action was not successful.");
            Assert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void Partition3Test()
        {
            int partition = 5;
            var testList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            var expectedList = new LinkedList(new int[] { 1, 2, 3, 5, 8, 5, 10 });
            bool success = Question_2_4.Partition3(testList, partition);
            Assert.IsTrue(success, "Action was not successful.");
            Assert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void Partition3Test_AllBigger()
        {
            int partition = 1;
            var testList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            var expectedList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            bool success = Question_2_4.Partition3(testList, partition);
            Assert.IsTrue(success, "Action was not successful.");
            Assert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void Partition3Test_AllSmaller()
        {
            int partition = 11;
            var testList = new LinkedList(new int[] { 3, 5, 8, 5, 10, 2, 1 });
            var expectedList = new LinkedList(new int[] { 1, 2, 10, 5, 8, 5, 3 });
            bool success = Question_2_4.Partition3(testList, partition);
            Assert.IsTrue(success, "Action was not successful.");
            Assert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void PartitionTest_FailureCases()
        {
            int partitionDummy = 0;
            bool success1 = Question_2_4.Partition(null, partitionDummy);
            bool success2 = Question_2_4.Partition(new LinkedList(), partitionDummy);
            bool success3 = Question_2_4.Partition2(null, partitionDummy);
            bool success4 = Question_2_4.Partition2(new LinkedList(), partitionDummy);
            bool success5 = Question_2_4.Partition3(null, partitionDummy);
            bool success6 = Question_2_4.Partition3(new LinkedList(), partitionDummy);
            Assert.IsFalse(success1, "Action 1 did not fail as expected.");
            Assert.IsFalse(success2, "Action 2 did not fail as expected.");
            Assert.IsFalse(success3, "Action 3 did not fail as expected.");
            Assert.IsFalse(success4, "Action 4 did not fail as expected.");
            Assert.IsFalse(success5, "Action 5 did not fail as expected.");
            Assert.IsFalse(success6, "Action 6 did not fail as expected.");
        }
    }
}
