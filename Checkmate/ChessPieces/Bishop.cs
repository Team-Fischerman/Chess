using System.Drawing;

namespace Checkmate.ChessPieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(PieceColor pieceColor) : base(pieceColor)
        {
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BBishop : Properties.Resources.WBishop;
        }

        public override void ShowLegalMoves(ChessBoard board, Point location)
        {
            base.ShowLegalMoves(board, location);


            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X - i, location.Y - i))
                {
                    board.board[location.X - i, location.Y - i].IsLegal = true;
                    if (board.board[location.X - i, location.Y - i].IsOccupied)
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X + i, location.Y + i))
                {
                    board.board[location.X + i, location.Y + i].IsLegal = true;
                    if (board.board[location.X + i, location.Y + i].IsOccupied)
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X + i, location.Y - i))
                {
                    board.board[location.X + i, location.Y - i].IsLegal = true;
                    if (board.board[location.X + i, location.Y - i].IsOccupied)
                    {
                        break;
                    }
                }
            }

            for (int i = 1; i < board.Size; i++)
            {
                if (isSafe(location.X - i, location.Y + i))
                {
                    board.board[location.X - i, location.Y + i].IsLegal = true;
                    if (board.board[location.X - i, location.Y + i].IsOccupied)
                    {
                        break;
                    }
                }
            }
            
            
            
        }
    }
}