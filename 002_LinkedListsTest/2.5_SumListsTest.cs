using _002_LinkedLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _002_LinkedListsTest
{
    [TestClass]
    public class Question_2_5_Test
    {
        [DataTestMethod]
        [DataRow(617, 295, 912)]
        [DataRow(879, 586, 1465)]
        [DataRow(1817, 295, 2112)]
        [DataRow(999, 9999, 10998)]
        [DataRow(0, 295, 295)]
        [DataRow(null, 295, 295)]
        [DataRow(295, null, 295)]
        public void SumListsReverseTest(int? num1, int? num2, int expected)
        {
            var testList1 = Helper.ConvertIntToListOfDigitsReverse(num1);
            var testList2 = Helper.ConvertIntToListOfDigitsReverse(num2);
            var expectedList = Helper.ConvertIntToListOfDigitsReverse(expected);
            LinkedList resultList = Question_2_5.SumListsReverse(testList1, testList2);
            Assert.AreEqual(expectedList, resultList);
        }

        [DataTestMethod]
        [DataRow(617, 295, 912)]
        [DataRow(879, 586, 1465)]
        [DataRow(1817, 295, 2112)]
        [DataRow(999, 9999, 10998)]
        [DataRow(0, 295, 295)]
        [DataRow(null, 295, 295)]
        [DataRow(295, null, 295)]
        public void SumListsReverseRecursiveTest(int? num1, int? num2, int expected)
        {
            var testList1 = Helper.ConvertIntToListOfDigitsReverse(num1);
            var testList2 = Helper.ConvertIntToListOfDigitsReverse(num2);
            var expectedList = Helper.ConvertIntToListOfDigitsReverse(expected);
            LinkedList resultList = Question_2_5.SumListsReverseRecursive(testList1, testList2);
            Assert.AreEqual(expectedList, resultList);
        }

        [DataTestMethod]
        [DataRow(617, 295, 912)]
        [DataRow(879, 586, 1465)]
        [DataRow(1817, 295, 2112)]
        [DataRow(999, 9999, 10998)]
        [DataRow(0, 295, 295)]
        [DataRow(null, 295, 295)]
        [DataRow(295, null, 295)]
        public void SumListsForwardTest(int? num1, int? num2, int expected)
        {
            var testList1 = Helper.ConvertIntToListOfDigitsForward(num1);
            var testList2 = Helper.ConvertIntToListOfDigitsForward(num2);
            var expectedList = Helper.ConvertIntToListOfDigitsForward(expected);
            LinkedList resultList = Question_2_5.SumListsForward(testList1, testList2);
            Assert.AreEqual(expectedList, resultList);
        }
    }
}
