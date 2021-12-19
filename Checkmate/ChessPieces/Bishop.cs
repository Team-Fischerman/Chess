
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


        protected override void ShowCheckLegalMoves(ChessBoard board, Point location)
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

        protected override void ShowLegalMoves(ChessBoard board, Point location)
        {
            
            
            ShowCheckLegalMoves(board, location);
            // switch (Chess.kingState)
            // {
            //     case Chess.State.Normal:
            //     
            //        ShowCheckLegalMoves(board,location);
            //        break;
            //     case Chess.State.Check:
            //         AddPotentialMoves(board, location);
            //        // PrintLegalMoves(protectingMoves);
            //     
            //         // Now compare the attacking moves with the bishop 
            //         EnableProtectedMoves(board, protectingMoves, board.GetAttackingList());
            //         break;
            // }
        }


        protected override void AddPotentialMoves(ChessBoard board, Point location)
        {
            base.AddPotentialMoves(board,location);
            ShowCheckLegalMoves(board,location);
            LegalMove(board, protectingMoves);
            board.ClearBoard();
        }
    }
}