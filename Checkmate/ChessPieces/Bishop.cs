
using System.Drawing;

namespace Checkmate.ChessPieces
{
    public class Bishop : ChessPiece
    {
       //  private List<Point> bishopMoves = new List<Point>();

        public Bishop(PieceColor pieceColor) : base(pieceColor)
        {
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BBishop : Properties.Resources.WBishop;
        }


        private void ShowAttackingMoves(ChessBoard board,Point location)
        {
            // enable legal move past the king
            board.ClearBoard();
        }


   

        protected override void ShowLegalMoves(ChessBoard board, Point location)
        {
            
            
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


        protected override void AddPotentialMoves(ChessBoard board, Point location)
        {
            // base.AddPotentialMoves(board,location);
            // ShowCheckLegalMoves(board,location);
            // LegalMove(board, protectingMoves);
            // board.ClearBoard();
        }
    }
}