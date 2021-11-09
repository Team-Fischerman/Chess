using System.Drawing;

namespace Checkmate.ChessPieces
{
    public class Knight : ChessPiece
    {
        public Knight(PieceColor pieceColor) : base(pieceColor)
        {
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BKnight : Properties.Resources.WKnight;
        }

        public override void ShowLegalMoves(ChessBoard board, Point location)
        {
            
            
            base.ShowLegalMoves(board,location);
            
            if(isSafe(location.X + 2, location.Y + 1)) {
                board.board[location.X + 2, location.Y + 1].IsLegal = true;
            }

            if(isSafe(location.X + 2, location.Y - 1)) {
                board.board[location.X + 2, location.Y - 1].IsLegal = true;
            }

            if(isSafe(location.X - 2, location.Y + 1)) {
                board.board[location.X - 2, location.Y + 1].IsLegal = true;
            }

            if(isSafe(location.X - 2, location.Y - 1)) {
                board.board[location.X - 2, location.Y - 1].IsLegal = true;
            }

            if(isSafe(location.X + 1, location.Y + 2)) {
                board.board[location.X + 1, location.Y + 2].IsLegal = true;
            }

            if(isSafe(location.X + 1, location.Y - 2)) {
                board.board[location.X + 1, location.Y - 2].IsLegal = true;
            }

            if(isSafe(location.X - 1, location.Y + 2)) {
                board.board[location.X - 1, location.Y + 2].IsLegal = true;
            }

            if(isSafe(location.X - 1, location.Y - 2)) {
                board.board[location.X - 1, location.Y - 2].IsLegal = true;
            }

        }
    }
}