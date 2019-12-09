using Microsoft.VisualStudio.TestTools.UnitTesting;
using static _010_SortingAndSearching.Question_10_10;

namespace _010_SortingAndSearchingTest
{
    [TestClass]
    public class Question_10_10_Test
    {
        [TestMethod]
        public void RankStreamTest()
        {
            // Arrange
            var rankStream = new RankStream();
            rankStream.Track(5);
            rankStream.Track(1);
            rankStream.Track(4);
            rankStream.Track(4);
            rankStream.Track(5);
            rankStream.Track(9);
            rankStream.Track(7);
            rankStream.Track(13);
            rankStream.Track(3);

            // Act
            int rank0 = rankStream.GetRankOfNumber(0);
            int rank1 = rankStream.GetRankOfNumber(1);
            int rank3 = rankStream.GetRankOfNumber(3);
            int rank4 = rankStream.GetRankOfNumber(4);

            // Assert
            Assert.AreEqual(-1, rank0, "Incorrect Rank of Number 0.");
            Assert.AreEqual(0, rank1, "Incorrect Rank of Number 1.");
            Assert.AreEqual(1, rank3, "Incorrect Rank of Number 3.");
            Assert.AreEqual(3, rank4, "Incorrect Rank of Number 4.");
        }
    }
}
