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
            throw new System.NotImplementedException();
        }
    }
}