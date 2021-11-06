namespace Checkmate.ChessPieces
{
    public class King : ChessPiece
    {
        public King(PieceColor pieceColor) : base(pieceColor)
        {
            
            PieceImage = pieceColor == PieceColor.BLACK ? Properties.Resources.BKing : Properties.Resources.WKing;
        }
    }
}