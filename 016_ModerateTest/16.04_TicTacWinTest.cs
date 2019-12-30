using Microsoft.VisualStudio.TestTools.UnitTesting;
using static _016_Moderate.Question_16_04;

namespace _016_ModerateTest
{
    [TestClass]
    public class Question_16_04_Test
    {
        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 2)]
        [DataRow(2, 2)]
        [DataRow(3, 2)]
        [DataRow(4, 0)]
        public void FindWinnerTest(int testCase, int expectedWinner)
        {
            // Arrange
            Piece[,] testBoard = GenerateBoard(testCase);
            Piece expected = (Piece)expectedWinner;

            // Act
            Piece resultWinner = FindWinner(testBoard);

            // Assert
            Assert.AreEqual(expected, resultWinner, "Winner result is not as expected.");
        }

        private Piece[,] GenerateBoard(int testCase)
        {
            if (testCase == 1)
            {
                // Cross Wins Row
                return new Piece[,]
                {
                    { Piece.Cross, Piece.Cross, Piece.Cross },
                    { Piece.Circle, Piece.Circle, Piece.Cross },
                    { Piece.Cross, Piece.Circle, Piece.Circle }
                };
            }
            else if (testCase == 2)
            {
                // Cross Wins Column
                return new Piece[,]
                {
                    { Piece.Cross, Piece.Cross, Piece.Circle },
                    { Piece.Circle, Piece.Cross, Piece.Cross },
                    { Piece.Circle, Piece.Cross, Piece.Circle }
                };
            }
            else if (testCase == 3)
            {
                // Cross Wins Diagonal
                return new Piece[,]
                {
                    { Piece.Cross, Piece.Circle, Piece.Cross },
                    { Piece.Circle, Piece.Cross, Piece.Cross },
                    { Piece.Cross, Piece.Circle, Piece.Circle }
                };
            }
            else if (testCase == 4)
            {
                // Draw
                return new Piece[,]
                {
                    { Piece.Cross, Piece.Circle, Piece.Cross },
                    { Piece.Circle, Piece.Cross, Piece.Cross },
                    { Piece.Circle, Piece.Cross, Piece.Circle }
                };
            }
            else
            {
                // Default empty board - no one wins
                return new Piece[,]
                {
                    { Piece.None, Piece.None, Piece.None },
                    { Piece.None, Piece.None, Piece.None },
                    { Piece.None, Piece.None, Piece.None }
                };
            }
        }
    }
}
