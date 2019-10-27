using _008_RecursionAndDynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_4_Test
    {
        private HashSetComparerHelper _hashSetComparer;

        [TestInitialize]
        public void Initialize()
        {
            _hashSetComparer = new HashSetComparerHelper();
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        public void FindAllSubsetsTest(int testCase)
        {
            // Arrange
            List<int> testSet = GenerateTestSet(testCase);
            List<int> testSetCombinatorics = GenerateTestSet(testCase);
            List<HashSet<int>> expectedSubsets = GenerateExpectedSubsets(testCase);
            expectedSubsets.Sort(_hashSetComparer);

            // Act
            List<HashSet<int>> resultSubsets = Question_8_4.FindAllSubsets(testSet);
            List<HashSet<int>> resultSubsetsCombinatorics = Question_8_4.FindAllSubsetsCombinatorics(testSetCombinatorics);
            resultSubsets.Sort(_hashSetComparer);
            resultSubsetsCombinatorics.Sort(_hashSetComparer);

            // Assert
            Assert.AreEqual(expectedSubsets.Count, resultSubsets.Count, "Result count check failed - Recursion.");
            Assert.AreEqual(expectedSubsets.Count, resultSubsetsCombinatorics.Count, "Result count check failed - Combinatorics.");
            Assert.IsTrue(expectedSubsets.SequenceEqual(resultSubsets, _hashSetComparer), "Result subsets check failed - Recursion.");
            Assert.IsTrue(expectedSubsets.SequenceEqual(resultSubsetsCombinatorics, _hashSetComparer), "Result subsets check failed - Combinatorics.");
        }

        private List<int> GenerateTestSet(int testCase)
        {
            List<int> testSet = null;
            if (testCase == 1)
            {
                testSet = new List<int>(0);
            }
            else if (testCase == 2)
            {
                testSet = new List<int> { 1 };
            }
            else if (testCase == 3)
            {
                testSet = new List<int> { 1, 2 };
            }
            else if (testCase == 4)
            {
                testSet = new List<int> { 1, 2, 3 };
            }
            else if (testCase == 5)
            {
                testSet = new List<int> { 1, 2, 3, 4 };
            }
            return testSet;
        }

        private List<HashSet<int>> GenerateExpectedSubsets(int testCase)
        {
            var expectedSubsets = new List<HashSet<int>>();
            if (testCase == 1)
            {
                expectedSubsets.Add(new HashSet<int>(0)); // empty set
            }
            else if (testCase == 2)
            {
                expectedSubsets.Add(new HashSet<int>(0)); // empty set
                expectedSubsets.Add(new HashSet<int> { 1 });
            }
            else if (testCase == 3)
            {
                expectedSubsets.Add(new HashSet<int>(0)); // empty set
                expectedSubsets.Add(new HashSet<int> { 1 });
                expectedSubsets.Add(new HashSet<int> { 2 });
                expectedSubsets.Add(new HashSet<int> { 1, 2 });
            }
            else if (testCase == 4)
            {
                expectedSubsets.Add(new HashSet<int>(0)); // empty set
                expectedSubsets.Add(new HashSet<int> { 1 });
                expectedSubsets.Add(new HashSet<int> { 2 });
                expectedSubsets.Add(new HashSet<int> { 3 });
                expectedSubsets.Add(new HashSet<int> { 1, 2 });
                expectedSubsets.Add(new HashSet<int> { 1, 3 });
                expectedSubsets.Add(new HashSet<int> { 2, 3 });
                expectedSubsets.Add(new HashSet<int> { 1, 2, 3 });
            }
            else if (testCase == 5)
            {
                expectedSubsets.Add(new HashSet<int>(0)); // empty set
                expectedSubsets.Add(new HashSet<int> { 1 });
                expectedSubsets.Add(new HashSet<int> { 2 });
                expectedSubsets.Add(new HashSet<int> { 3 });
                expectedSubsets.Add(new HashSet<int> { 4 });
                expectedSubsets.Add(new HashSet<int> { 1, 2 });
                expectedSubsets.Add(new HashSet<int> { 1, 3 });
                expectedSubsets.Add(new HashSet<int> { 1, 4 });
                expectedSubsets.Add(new HashSet<int> { 2, 3 });
                expectedSubsets.Add(new HashSet<int> { 2, 4 });
                expectedSubsets.Add(new HashSet<int> { 3, 4 });
                expectedSubsets.Add(new HashSet<int> { 1, 2, 3 });
                expectedSubsets.Add(new HashSet<int> { 1, 2, 4 });
                expectedSubsets.Add(new HashSet<int> { 1, 3, 4 });
                expectedSubsets.Add(new HashSet<int> { 2, 3, 4 });
                expectedSubsets.Add(new HashSet<int> { 1, 2, 3, 4 });
            }
            return expectedSubsets;
        }
    }
}
