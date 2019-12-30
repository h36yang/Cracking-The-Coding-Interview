namespace _016_Moderate
{
    /// <summary>
    /// 16.4) Tic Tac Win:
    /// Design an algorithm to figure out if someone has won a game of tic-tac-toe.
    /// </summary>
    public static class Question_16_04
    {
        public enum Piece
        {
            None = 0,
            Circle = 1,
            Cross = 2
        }

        /// <summary>
        /// Assume 3x3 constant size board
        /// <para>Time Complexity: O(1)</para>
        /// <para>Space Complexity: O(1)</para>
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static Piece FindWinner(Piece[,] board)
        {
            // check rows
            for (int row = 0; row < 3; row++)
            {
                Piece winner = RowHasSamePiece(board, row);
                if (winner != Piece.None)
                {
                    return winner;
                }
            }

            // check columns
            for (int col = 0; col < 3; col++)
            {
                Piece winner = ColumnHasSamePiece(board, col);
                if (winner != Piece.None)
                {
                    return winner;
                }
            }

            // check diagonals
            return DiagonalHasSamePiece(board);
        }

        private static Piece RowHasSamePiece(Piece[,] board, int row)
        {
            for (int col = 0; col < 2; col++)
            {
                if (board[row, col] != board[row, col + 1])
                {
                    return Piece.None;
                }
            }
            return board[row, 0];
        }

        private static Piece ColumnHasSamePiece(Piece[,] board, int col)
        {
            for (int row = 0; row < 2; row++)
            {
                if (board[row, col] != board[row + 1, col])
                {
                    return Piece.None;
                }
            }
            return board[0, col];
        }

        private static Piece DiagonalHasSamePiece(Piece[,] board)
        {
            bool diag1Win = board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2];
            bool diag2Win = board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2];
            if (diag1Win || diag2Win)
            {
                return board[1, 1];
            }
            else
            {
                return Piece.None;
            }
        }
    }
}
