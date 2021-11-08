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
            throw new System.NotImplementedException();
        }
    }
}