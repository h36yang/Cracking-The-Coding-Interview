using _010_SortingAndSearching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace _010_SortingAndSearchingTest
{
    [TestClass]
    public class Question_10_2_Test
    {
        [DataTestMethod]
        [DataRow(new string[] { "ab", "abc", "ba", "abcd", "cba" }, new string[] { "ab", "ba", "abc", "cba", "abcd" }, "")]
        [DataRow(new string[] { "ab", "abcd", "abc", "ba", "cba" }, new string[] { "ab", "ba", "abcd", "abc", "cba" }, "")]
        public void GroupAnagramsTest(string[] testArray, string[] expectedArray, string _)
        {
            // Act
            Question_10_2.GroupAnagrams(testArray);

            // Assert
            Assert.IsTrue(expectedArray.SequenceEqual(testArray), "GroupAnagrams test failed.");
        }
    }
}
