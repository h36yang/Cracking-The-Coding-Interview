using _005_BitManipulation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _005_BitManipulationTest
{
    [TestClass]
    public class Question_5_4_Test
    {
        [DataTestMethod]
        [DataRow(0b10011u, 0b10101u)]
        [DataRow(0b10001001100u, 0b10001010001u)]
        public void FindNextLargerNumberTest(uint testNumber, uint expectedNumber)
        {
            // Act
            uint resultNumber = Question_5_4.FindNextLargerNumber(testNumber);

            // Assert
            Assert.AreEqual(expectedNumber, resultNumber, $"Failed to find the next larger number of {testNumber}.");
        }

        [DataTestMethod]
        [DataRow(uint.MinValue)]
        [DataRow(uint.MaxValue)]
        [DataRow(0b11111111111111110000000000000000)]
        public void FindNextLargerNumberTest_EdgeCases(uint testNumber)
        {
            try
            {
                // Act
                Question_5_4.FindNextLargerNumber(testNumber);

                // Assert
                Assert.Fail("Edge case check failed.");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual($"There is no larger number with same number of 1s as {testNumber}.", e.Message, "Incorrect exception caught.");
            }
        }

        [DataTestMethod]
        [DataRow(0b10011u, 0b01110u)]
        [DataRow(0b10001001100u, 0b10001001010u)]
        public void FindNextSmallerNumberTest(uint testNumber, uint expectedNumber)
        {
            // Act
            uint resultNumber = Question_5_4.FindNextSmallerNumber(testNumber);

            // Assert
            Assert.AreEqual(expectedNumber, resultNumber, $"Failed to find the next smaller number of {testNumber}.");
        }

        [DataTestMethod]
        [DataRow(uint.MinValue)]
        [DataRow(uint.MaxValue)]
        [DataRow(0b1111111111111111u)]
        public void FindNextSmallerNumberTest_EdgeCases(uint testNumber)
        {
            try
            {
                // Act
                Question_5_4.FindNextSmallerNumber(testNumber);

                // Assert
                Assert.Fail("Edge case check failed.");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual($"There is no smaller number with same number of 1s as {testNumber}.", e.Message, "Incorrect exception caught.");
            }
        }
    }
}
