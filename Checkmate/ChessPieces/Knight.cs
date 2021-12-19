using System.Drawing;

namespace Checkmate.ChessPieces
{
    public class Knight : ChessPiece
    {
        public Knight(PieceColor pieceColor) : base(pieceColor)
        {
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BKnight : Properties.Resources.WKnight;
        }


        protected override void ShowCheckLegalMoves(ChessBoard board, Point location)
        {
            if (isSafe(location.X + 2, location.Y + 1))
            {
                board.board[location.X + 2, location.Y + 1].IsLegal = true;
            }

            if (isSafe(location.X + 2, location.Y - 1))
            {
                board.board[location.X + 2, location.Y - 1].IsLegal = true;
            }

            if (isSafe(location.X - 2, location.Y + 1))
            {
                board.board[location.X - 2, location.Y + 1].IsLegal = true;
            }

            if (isSafe(location.X - 2, location.Y - 1))
            {
                board.board[location.X - 2, location.Y - 1].IsLegal = true;
            }

            if (isSafe(location.X + 1, location.Y + 2))
            {
                board.board[location.X + 1, location.Y + 2].IsLegal = true;
            }

            if (isSafe(location.X + 1, location.Y - 2))
            {
                board.board[location.X + 1, location.Y - 2].IsLegal = true;
            }

            if (isSafe(location.X - 1, location.Y + 2))
            {
                board.board[location.X - 1, location.Y + 2].IsLegal = true;
            }

            if (isSafe(location.X - 1, location.Y - 2))
            {
                board.board[location.X - 1, location.Y - 2].IsLegal = true;
            }
        }


        protected override void ShowLegalMoves(ChessBoard board, Point location)
        {
            
            ShowCheckLegalMoves(board, location);
            // switch (Chess.kingState)
            // {
            //     case Chess.State.Normal:
            //         ShowCheckLegalMoves(board, location);
            //         break;
            //     case Chess.State.Check:
            //         AddPotentialMoves(board, location);
            //         EnableProtectedMoves(board,protectingMoves,board.GetAttackingList());
            //         break;
            // }
        }


        protected override void AddPotentialMoves(ChessBoard board, Point location)
        {
            base.AddPotentialMoves(board, location);
            ShowCheckLegalMoves(board, location);
            LegalMove(board, protectingMoves);
            board.ClearBoard();
        }
    }
}