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
            throw new System.NotImplementedException();
        }
    }
}