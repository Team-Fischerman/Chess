using System.Drawing;

namespace Checkmate.ChessPieces
{
    public class Queen : ChessPiece
    {
        public Queen(PieceColor pieceColor) : base(pieceColor)
        {
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BQueen : Properties.Resources.WQueen;
        }

        public override void ShowLegalMoves(ChessBoard board, Point location)
        {
            
            base.ShowLegalMoves(board,location);
            
            for(int i = 0; i < board.Size; i++) 
            {
                if(isSafe(location.X - i, location.Y)) {
                    board.board[location.X - i, location.Y].IsLegal = true;
                }
                
                if(isSafe(location.X + i, location.Y)) {
                    board.board[location.X + i, location.Y].IsLegal = true;
                }

                if(isSafe(location.X, location.Y + i)) {
                    board.board[location.X, location.Y + i].IsLegal = true;
                }

                if(isSafe(location.X, location.Y - i)) {
                    board.board[location.X, location.Y - i].IsLegal = true;
                }

                if(isSafe(location.X - i, location.Y - i)) {
                    board.board[location.X - i, location.Y - i].IsLegal = true;
                }

                if(isSafe(location.X + i, location.Y + i)) {
                    board.board[location.X + i, location.Y + i].IsLegal = true;
                }

                if(isSafe(location.X + i, location.Y - i)) {
                    board.board[location.X + i, location.Y - i].IsLegal = true;
                }

                if(isSafe(location.X - i, location.Y + i)) {
                    board.board[location.X - i, location.Y + i].IsLegal = true;
                }

            }
        }
    }
}