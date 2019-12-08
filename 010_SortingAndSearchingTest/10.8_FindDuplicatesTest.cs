using _010_SortingAndSearching;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _010_SortingAndSearchingTest
{
    [TestClass]
    public class Question_10_8_Test
    {
        [TestMethod]
        public void FindDuplicatesTest()
        {
            // Arrange
            var randomGenerator = new Random();
            int dup = randomGenerator.Next(0, 32000);
            var expectedDups = new HashSet<int>();
            var testList = new List<int>();
            // Randomly generates test array with duplicates
            for (int i = 0; i < 32000; i++)
            {
                testList.Add(i);
                if (i == dup)
                {
                    testList.Add(i);
                    expectedDups.Add(dup);
                    dup = randomGenerator.Next(dup + 1, 32000);
                }
            }
            // Shuffle test array
            var testArray = testList.OrderBy(x => randomGenerator.Next(0, 32000)).ToArray();

            // Act
            HashSet<int> resultDups = Question_10_8.FindDuplicates(testArray);

            // Assert
            Assert.IsTrue(expectedDups.SetEquals(resultDups), "FindDuplicates test failed.");
        }
    }
}
