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
            throw new System.NotImplementedException();
        }
    }
}