using _001_ArraysAndStrings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _001_ArraysAndStringsTest
{
    [TestClass]
    public class Question_1_5_Test
    {
        [DataTestMethod]
        [DataRow("pale", "pale")]
        [DataRow("pale", "ple")]
        [DataRow("pales", "pale")]
        [DataRow("pale", "bale")]
        [DataRow("apple", "aple")]
        public void AreOneAwayTest_ReturnTrue(string str1, string str2)
        {
            bool result = Question_1_5.AreOneAway(str1, str2);
            Assert.IsTrue(result, $"{str1} and {str2} are not one away.");
        }

        [DataTestMethod]
        [DataRow("pale", "bake")]
        [DataRow("pale", "palela")]
        public void AreOneAwayTest_ReturnFalse(string str1, string str2)
        {
            bool result = Question_1_5.AreOneAway(str1, str2);
            Assert.IsFalse(result, $"{str1} and {str2} are one away.");
        }
    }
}
