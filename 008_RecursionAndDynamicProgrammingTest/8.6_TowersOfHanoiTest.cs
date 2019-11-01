using _008_RecursionAndDynamicProgramming;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _008_RecursionAndDynamicProgrammingTest
{
    [TestClass]
    public class Question_8_6_Test
    {
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(20)]
        public void MoveDisksTest(int numberOfDisks)
        {
            try
            {
                // Arrange
                var initialTower = GenerateTower(numberOfDisks);
                var finalTower = new Stack<int>(numberOfDisks);
                var expectedFinalTower = GenerateTower(numberOfDisks);

                // Act
                Question_8_6.MoveDisks(initialTower, finalTower);

                // Assert
                Assert.IsTrue(expectedFinalTower.SequenceEqual(finalTower));
            }
            catch (InvalidOperationException e)
            {
                Assert.Fail(e.Message);
            }
        }

        private Stack<int> GenerateTower(int numberOfDisks)
        {
            var tower = new Stack<int>(numberOfDisks);
            for (int k = numberOfDisks; k > 0; k--)
            {
                tower.Push(k);
            }
            return tower;
        }
    }
}
