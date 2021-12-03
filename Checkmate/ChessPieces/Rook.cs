using System.Drawing;

namespace Checkmate.ChessPieces
{
    public class Rook : ChessPiece
    {
        public Rook(PieceColor pieceColor) : base(pieceColor)
        {
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BRook : Properties.Resources.WRook;
        }

        public override void ShowLegalMoves(ChessBoard board, Point location)
        {
            base.ShowLegalMoves(board, location);

            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X - i, location.Y))
                {
                    board.board[location.X - i, location.Y].IsLegal = true;
                    if (board.board[location.X - i, location.Y].IsOccupied == true)
                    {
                        break;
                    }
                }
            }
            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X + i, location.Y))
                {
                    board.board[location.X + i, location.Y].IsLegal = true;
                    if (board.board[location.X + i, location.Y].IsOccupied == true)
                    {
                        break;
                    }
                }
            }
            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X, location.Y + i))
                {
                    board.board[location.X, location.Y + i].IsLegal = true;
                    if (board.board[location.X, location.Y + i].IsOccupied == true)
                    {
                        break;
                    }
                }
            }
            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X, location.Y - i))
                {
                    board.board[location.X, location.Y - i].IsLegal = true;
                    if (board.board[location.X, location.Y - i].IsOccupied == true)
                    {
                        break;
                    }
                }
            }
        }
    }
}