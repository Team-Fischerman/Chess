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
            throw new System.NotImplementedException();
        }
    }
}