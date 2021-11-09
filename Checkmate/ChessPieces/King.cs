using System.Drawing;

namespace Checkmate.ChessPieces
{
    public class King : ChessPiece
    {
        public King(PieceColor pieceColor) : base(pieceColor)
        {
            
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BKing : Properties.Resources.WKing;
        }

        public override void ShowLegalMoves(ChessBoard board, Point location)
        {
            base.ShowLegalMoves(board,location);
            if(isSafe(location.X + 1, location.Y)) {
                board.board[location.X + 1, location.Y].IsLegal = true;
            }

            if(isSafe(location.X - 1, location.Y)) {
                board.board[location.X - 1, location.Y].IsLegal = true;
            } 
                            
            if(isSafe(location.X, location.Y + 1)) {
                board.board[location.X, location.Y + 1].IsLegal = true;
            } 
                            
            if(isSafe(location.X, location.Y - 1)) {
                board.board[location.X, location.Y - 1].IsLegal = true;
            }

            if(isSafe(location.X - 1, location.Y - 1)) {
                board.board[location.X - 1, location.Y - 1].IsLegal = true;
            }

            if(isSafe(location.X + 1, location.Y + 1)) {
                board.board[location.X + 1, location.Y + 1].IsLegal = true;
            }

            if(isSafe(location.X + 1, location.Y - 1)) {
                board.board[location.X + 1, location.Y - 1].IsLegal = true;
            }


            if(isSafe(location.X - 1, location.Y + 1)) {
                board.board[location.X - 1, location.Y + 1].IsLegal = true;
            }

        }
    }
}