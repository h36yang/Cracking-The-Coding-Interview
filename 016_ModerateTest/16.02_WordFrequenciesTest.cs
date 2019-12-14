using _016_Moderate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _016_ModerateTest
{
    [TestClass]
    public class Question_16_02_Test
    {
        [TestMethod]
        public void CoundWordTest()
        {
            // Arrange
            var testBook = new string[]
            {
                "Jack", "is", "a", "handsome", "guy", "and", "a", "smart", "Guy", "so", "is", "his", "wife", "but", "she", "ain't", "a", "guy"
            };
            var problem = new Question_16_02(testBook);

            // Act
            int count1 = problem.CoundWord("Jack");
            int count2 = problem.CoundWord("is");
            int count3 = problem.CoundWord("guy");
            int count4 = problem.CoundWord("is");

            // Assert
            Assert.AreEqual(1, count1, "Test 1 failed.");
            Assert.AreEqual(2, count2, "Test 2 failed.");
            Assert.AreEqual(3, count3, "Test 3 failed.");
            Assert.AreEqual(2, count4, "Test 4 failed.");
        }
    }
}
