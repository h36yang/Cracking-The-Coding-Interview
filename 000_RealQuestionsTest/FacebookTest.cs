using _000_RealQuestions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _000_RealQuestionsTest
{
    [TestClass]
    public class FacebookTest
    {
        [DataTestMethod]
        [DataRow(null, "cat", false)]
        [DataRow("c", "cat", false)]
        [DataRow("cat", "dog", false)]
        [DataRow("cat", "cats", true)]
        [DataRow("cat", "cut", true)]
        [DataRow("cat", "cast", true)]
        [DataRow("cat", "at", true)]
        [DataRow("cat", "act", false)]
        public void OneEditApartTest(string str1, string str2, bool expected)
        {
            // Act
            bool result = Facebook.OneEditApart(str1, str2);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
